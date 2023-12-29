namespace Services.ChainData.OtterScan.Models;

// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Log
    {
        public string address { get; set; }
        public List<string> topics { get; set; }
        public string data { get; set; }
        public string blockHash { get; set; }
        public string blockNumber { get; set; }
        public string transactionHash { get; set; }
        public string transactionIndex { get; set; }
        public string logIndex { get; set; }
        public string transactionLogIndex { get; set; }
        public bool removed { get; set; }
    }

    public class Receipt
    {
        public string transactionHash { get; set; }
        public string transactionIndex { get; set; }
        public string blockHash { get; set; }
        public string blockNumber { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string cumulativeGasUsed { get; set; }
        public string gasUsed { get; set; }
        public string contractAddress { get; set; }
        public List<Log> logs { get; set; }
        public string status { get; set; }
        public string logsBloom { get; set; }
        public string effectiveGasPrice { get; set; }
        public long timestamp { get; set; }
        public string type { get; set; }
    }

    public class OtterscanResponse
    {
        public List<Tx> txs { get; set; }
        public List<Receipt> receipts { get; set; }
        public bool firstPage { get; set; }
        public bool lastPage { get; set; }
    }

    public class Tx
    {
        public string hash { get; set; }
        public string nonce { get; set; }
        public string blockHash { get; set; }
        public string blockNumber { get; set; }
        public string transactionIndex { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string value { get; set; }
        public string gasPrice { get; set; }
        public string gas { get; set; }
        public string input { get; set; }
        public string v { get; set; }
        public string r { get; set; }
        public string s { get; set; }
        public string chainId { get; set; }
        public string type { get; set; }
        public List<object> accessList { get; set; }
        public string maxPriorityFeePerGas { get; set; }
        public string maxFeePerGas { get; set; }
    }

