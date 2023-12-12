using System.Collections.Immutable;
using Org.BouncyCastle.Crypto.Modes;
using Services.Metrics.Models;
namespace Services.Metrics;

public class NetworkHistory
{
    private int history_count = 0;
    private int node_count = 0;
    private List<String> raw_metrics = new List<String>();
    private List<List<NodeMetric>> historic_metrics = new List<List<NodeMetric>>();
    private List<ActiveActions> active_actions = new List<ActiveActions>();
    private List<NodeTripleCount> node_triples = new List<NodeTripleCount>();

    public NetworkHistory(int historiy_length, int node_length)
    {
        history_count = historiy_length;        
        node_count = node_length;
        historic_metrics = new List<List<NodeMetric>>();      
          
        node_triples = new List<NodeTripleCount>();
        for (int i = 0; i < node_count; i++) {
            node_triples.Add(new NodeTripleCount { idx = i, triples = new List<TripleCount>() });
        }

        var vals = Enum.GetValues(typeof(Action_Type_Id));    

        for (int i = 0; i < vals.Length; i++) {
            active_actions.Add(new ActiveActions { type_id = Enum.GetName(typeof(Action_Type_Id), i), ids = new List<ulong>() });
        }
    } 

    public List<ActiveActions> get_active_actions() {
        return active_actions;
    }
 
    public void add(List<NodeMetricRoot> incoming_node_metrics, List<string> raw_metrics) {


        if ( incoming_node_metrics.Count == 0 )  {
            return;
        }

        this.raw_metrics = raw_metrics;

        incoming_node_metrics.Sort((x, y) => x.idx.CompareTo(y.idx));
        var new_node_metrics = new List<NodeMetric>();

        foreach (var node_metric in incoming_node_metrics) {
            if (node_metric.metrics != null) 
            {
                var new_node_metric = new NodeMetric { node_index = node_metric.idx, metrics = node_metric.metrics };
                new_node_metrics.Add(new_node_metric);
            }

            if (node_metric.triple_count != null && node_metric.triple_count.Count > 0)
                node_triples[node_metric.idx].triples =  node_metric.triple_count;
                        
            if (node_metric.action != null) {
                foreach (var new_action in node_metric.action) {
                     Console.WriteLine("Action: " + new_action.type_id + " " + new_action.txn_id.ToString() + " " + new_action.is_start.ToString());
                    foreach (ActiveActions active_action in active_actions) {
                        if (active_action.type_id == new_action.type_id) {
                            if (!new_action.is_success) {
                                if (!active_action.error_ids.Contains(new_action.txn_id)) {
                                    active_action.error_ids.Add(new_action.txn_id);
                                }                                
                            }

                            if (new_action.is_start) { // add
                                active_action.ids.Add(new_action.txn_id);                                
                            }
                            else{ // remove
                                active_action.ids.Remove(new_action.txn_id);
                            }
                        }                        
                    }
                }
            }

        } 

        historic_metrics.Add(new_node_metrics);
        if (historic_metrics.Count > history_count) {
            historic_metrics.RemoveAt(0);
            history_count = historic_metrics.Count;
        }        

    }

    public List<string> get_raw_metrics() {
        return raw_metrics;
    }
    public List<NodeMetric> get_lastest_metrics() {
        if (historic_metrics.Count == 0) {
            Console.WriteLine("No metrics");
            return new List<NodeMetric>();
        }
        return historic_metrics[historic_metrics.Count - 1];
    }

    public List<NodeTripleCount> get_active_triples() {
        return node_triples;
    }
    public List<OutMessages> get_out_messages () {
        var out_messages = new List<OutMessages>();
        foreach (var historic_metric in historic_metrics) {
            foreach (var node_metric in historic_metric) {
                if (node_metric.metrics == null) 
                    continue;
                
                foreach (var metric in node_metric.metrics) {
                    var join_name = node_metric.node_index.ToString() + "-" + metric.idx.ToString();
                    if ( out_messages.Select(x => x.name).Contains(join_name)) {
                        var out_message = out_messages.Where(x => x.name == join_name).First();
                        out_message.count += metric.outmsg;
                    }
                    else {
                        out_messages.Add(new OutMessages { src = node_metric.node_index, dst = metric.idx, name = join_name, count = metric.outmsg });
                    }
                    out_messages.Add(new OutMessages { src = node_metric.node_index, dst = metric.idx, name = join_name, count = metric.outmsg });
                }
            }
        }
        return out_messages;
    }

    public Metric network_average() {
        var sum_incoming = 0;
        var sum_outgoing = 0;
        var count = 0;
        foreach (var historic_metric in historic_metrics) {
            foreach (var m in historic_metric) {
                if (m.metrics == null) {
                    continue;
                }
                foreach (var metric in m.metrics) 
                {
                    sum_incoming += metric.inmsg;
                    sum_outgoing += metric.outmsg;
                }
                count++;
            }
        }
        if (count == 0)
        {
            return new Metric { inmsg = 0, outmsg = 0 };
        }

        var avg_incoming = sum_incoming / count;
        var avg_outgoing = sum_outgoing / count;
        return new Metric { inmsg = avg_incoming, outmsg = avg_outgoing };
    }

    public List<Metric> node_average() {
        var node_metrics = new List<Metric>();

        if (historic_metrics.Count == 0) 
            return node_metrics;
        
        for (int i =0; i < node_count ;i++) {
            node_metrics.Add(new Metric { inmsg = 0, outmsg = 0 });
            foreach (var h in historic_metrics) {                
                foreach (var hm in h.Where(x => x.node_index == i).Select(x => x.metrics).ToArray()) {
                    if (hm == null) {
                        continue;
                    }
                    foreach (var m in hm) {
                        node_metrics[i].node_name = "Node: " + (i + 1).ToString();
                        node_metrics[i].idx = i;                        
                        node_metrics[i].inmsg += m.inmsg;
                        node_metrics[i].outmsg += m.outmsg;
                    }
                }
            }
        }

        // if (history_count == 0) {
        //     return node_metrics;
        // }

        for (int i = 0; i < node_count; i++) {
            node_metrics[i].node_name = "Node: " + (i + 1).ToString();
            node_metrics[i].idx = i;                        
            node_metrics[i].inmsg = node_metrics[i].inmsg / (history_count + 1);
            node_metrics[i].outmsg = node_metrics[i].outmsg / (history_count + 1);
        }

        return node_metrics;
    }
}
