using System.Linq.Expressions;
using LitContracts.Allowlist.ContractDefinition;
using Nethereum.Merkle.Patricia;
using Nethereum.Model;

namespace SharedService;
public class Metric
{
    public int node_index { get; set; }
    public int incoming { get; set; }
    public int outgoing { get; set; }

    public int total { get { return incoming + outgoing; } }
    public Timestamp? timestamp { get; set; }

    public string? node_name { get; set; }
}

public class NewAction
    {
        public string? name { get; set; }
        public string? txn_id { get; set; }
        public bool is_start { get; set; }
    }

public class Peer
{
    public string? address { get; set; }
    public int share_index { get; set; }
    public bool kicked { get; set; }
}

public class NodeMetricRoot
{
    public int node_index { get; set; }
    public List<Metric>? metrics { get; set; }
    public List<NewAction>? new_actions { get; set; }
    public List<Peer>? peers { get; set; }
    public Timestamp? timestamp { get; set; }
}

public class Timestamp
{
    public int secs_since_epoch { get; set; }
    public int nanos_since_epoch { get; set; }
}

public class NodeMetric {
    public int node_index { get; set; }
    public string? node_name { get; set; }
    public List<Metric>? metrics { get; set; }
}

public class ActiveActions {
    public string? action_name { get; set; }
    public List<string>? ids { get; set; }
}

public class NetworkHistory
{
    private int history_count = 0;
    private int node_count = 0;
    private List<List<NodeMetric>> historic_metrics = new List<List<NodeMetric>>();

    private List<ActiveActions> active_actions = new List<ActiveActions>();
    
    public NetworkHistory(int historiy_length, int node_length)
    {
        history_count = historiy_length;        
        node_count = node_length;
        historic_metrics = new List<List<NodeMetric>>();
        
    } 

    public List<ActiveActions> get_active_actions() {
        return active_actions;
    }
 
    public void add(List<NodeMetricRoot> new_metrics) {

        if ( new_metrics.Count == 0 )  {
            return;
        }

        new_metrics.Sort((x, y) => x.node_index.CompareTo(y.node_index));
        var new_node_metrics = new List<NodeMetric>();

        foreach (var node_metric in new_metrics) {
            node_metric.metrics.Sort((x, y) => x.node_index.CompareTo(y.node_index));
            var new_node_metric = new NodeMetric { node_index = node_metric.node_index, metrics = node_metric.metrics };
            new_node_metrics.Add(new_node_metric);
            
            if (node_metric.new_actions != null) {
                foreach (var action in node_metric.new_actions) {
                    if (action.is_start) { // add
                        if (active_actions.Where(x => x.action_name == action.name).Count() == 0) {
                            active_actions.Add(new ActiveActions { action_name = action.name, ids = new List<string>() });
                        }
                        
                        foreach (ActiveActions active_action in active_actions) {
                            if (active_action.action_name == action.name) {
                                if (active_action.ids == null) {
                                    active_action.ids = new List<string>();
                                }
                                active_action.ids.Add(action.txn_id);                                
                            }
                        }                        
                    }
                    else{ // remove
                        foreach (ActiveActions active_action in active_actions) {
                            if (active_action.action_name == action.name) {
                                if (active_action.ids != null) {
                                    active_action.ids.Remove(action.txn_id);
                                }
                                break;
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

    public Metric network_average() {
        var sum_incoming = 0;
        var sum_outgoing = 0;
        var count = 0;
        foreach (var historic_metric in historic_metrics) {
            foreach (var m in historic_metric) {
                foreach (var metric in m.metrics) 
                {
                    sum_incoming += metric.incoming;
                    sum_outgoing += metric.outgoing;
                }
                count++;
            }
        }
        var avg_incoming = sum_incoming / count;
        var avg_outgoing = sum_outgoing / count;
        return new Metric { incoming = avg_incoming, outgoing = avg_outgoing };
    }

    public List<Metric> node_average() {
        var node_metrics = new List<Metric>();

        if (historic_metrics.Count == 0) {
            return node_metrics;
        }

        
        for (int i =0; i < node_count ;i++) {
            node_metrics.Add(new Metric { incoming = 0, outgoing = 0 });
            foreach (var h in historic_metrics) {                
                foreach (var hm in h.Where(x => x.node_index == i).Select(x => x.metrics).ToArray()) {
                    foreach (var m in hm) {
                        node_metrics[i].node_name = "Node: " + (i + 1).ToString();
                        node_metrics[i].node_index = i;                        
                        node_metrics[i].incoming += m.incoming;
                        node_metrics[i].outgoing += m.outgoing;
                    }
                }
            }
        }

        if (history_count == 0) {
            return node_metrics;
        }

        for (int i = 0; i < node_count; i++) {
            node_metrics[i].incoming = node_metrics[i].incoming / (history_count + 1);
            node_metrics[i].outgoing = node_metrics[i].outgoing / (history_count + 1);
        }

        return node_metrics;
    }
}
