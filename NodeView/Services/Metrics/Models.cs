using System.Net;
using System.Reflection.Metadata.Ecma335;
using Org.BouncyCastle.Bcpg.OpenPgp;
namespace Services.Metrics.Models;

public enum Action_Type_Id {
    DKG,
    BeaverTriple,
    SignEcdsa
}   

public class Validator: LitContracts.Staking.ContractDefinition.Validator  {
        
    public IPAddress Node_Ip  { get { return IPAddress.Parse( Ip.ToString()); } }
}

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
        public ulong txn_id { get; set; }
        public bool is_start { get; set; }
        public bool is_success { get; set; }
        
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
    public List<NewAction>? action { get; set; }
    public List<Peer>? peers { get; set; }
    public List<TripleCount>? triple_count { get; set; }
    public Timestamp? time { get; set; }

    public DateTime datetime { get {
            DateTime epochTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            if (time == null) {
                return epochTime;
            }
            return epochTime.AddSeconds(time.secs_since_epoch).AddMicroseconds(time.nanos_since_epoch / 1000);
        }
    }
}

public class Timestamp
{
    public long secs_since_epoch { get; set; }
    public long nanos_since_epoch { get; set; }
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
    public List<ulong> ids { get; set; } = new List<ulong>();    
    public List<ulong> error_ids { get; set; } = new List<ulong>();
    public DateTime last_error_time { get; set; } = DateTime.MinValue;
    public int count { get { return ids.Count; } }
    public int distinct_count { get { return ids.Distinct().ToList().Count(); } }
    public int error_count { get { return error_ids.Count; } }
}

public class ActiveActionId {
    
    public int node_idx { get; set; }
    public ulong txn_id { get; set; }
    public DateTime start_time { get; set; }
}

public class OutMessages {
    public int src {get; set;}
    public int dst {get; set;}  
    public string? name {get; set;}  
    public int count {get; set;}
}

public class TimingMetric {
    // public Action_Type_Id action_Type_Id { get; set; }
    public string? type_id { get; set; }
    public ulong txn_id { get; set; }
    public DateTime start_time { get; set; }
    public DateTime? finished_time { get; set; }
    public int milliseconds { get { if (finished_time == null) return 0;  return (int)(finished_time.Value - start_time).TotalMilliseconds; } }
    public bool success { get; set; }
}

public class TimingSummary {
    public string? type_id { get; set; }
    public int min { get; set; }
    public int max { get; set; }
    public int avg { get; set; }
    public int count { get; set; }
    public int count_success { get; set; }
    public int count_error { get; set; }
}