
namespace SharedService.Metrics.Models;

public class Metric
{
    public int idx { get; set; }
    public int inmsg { get; set; }
    public int outmsg { get; set; }
    public int badmsg {get ; set;}
    public int triple { get; set; }
    public int total { get { return inmsg + outmsg; } }
    public Timestamp? timestamp { get; set; }
    public string? node_name { get; set; }
}

public class NewAction
    {
        public string? type_id { get; set; }
        public int txn_id { get; set; }
        public bool is_start { get; set; }
    }

public class Peer
{
    public int idx { get; set; }
    public bool kicked { get; set; }
}

public class NodeMetricRoot
{
    public int idx { get; set; }
    public List<Metric>? metrics { get; set; }
    public List<NewAction>? new_actions { get; set; }
    public List<Peer>? peers { get; set; }
    public List<TripleCount>? triple_count { get; set; }
    public Timestamp? timestamp { get; set; }
}

public class Timestamp
{
    public int secs_since_epoch { get; set; }
    public int nanos_since_epoch { get; set; }
}

public class NodeTripleCount {
    
    public string name { get { return "Node #" + (idx + 1).ToString(); } }
    public int idx { get; set; }
    public List<TripleCount>? triples { get; set; }
    public int total_count { get { return triples == null ? 0 :  triples.Sum(x => x.count); } }
}
public class TripleCount
    {
        public ulong peer_group_id { get; set; }
        public int count { get; set; }
        public List<object>? peer_keys { get; set; }
    }



public class NodeMetric {
    public int node_index { get; set; }
    public string? node_name { get; set; }
    public List<Metric>? metrics { get; set; }
}

public class ActiveActions {
    public string? type_id { get; set; }
    public List<int>? ids { get; set; }
}

public class OutMessages {
    public int src {get; set;}
    public int dst {get; set;}  
    public string? name {get; set;}  
    public int count {get; set;}
}

