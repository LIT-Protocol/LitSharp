namespace Services.ChainData.OtterScan;
using Services.ChainData.OtterScan.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

public class RpcCalls {

    //curl -X POST -H "Content-Type: application/json" --data '{"jsonrpc":"2.0", "id": 1, "method":"ots_searchTransactionsAfter","params":["0xc0a47dFe034B400B47bDaD5FecDa2621de6c4d95", 0, 5]}' http://127.0.0.1:8545
    public async Task<OtterscanResponse> GetTxListAsync( string rpc_api_url,  string address,  long blockStart, long blockEnd) {

        OtterscanResponse response = new OtterscanResponse();

        try {        
            var client = new Nethereum.JsonRpc.Client.RpcClient(new Uri(rpc_api_url));
            var parameters = new object[] {   address, 0, 300 };
            var resp = await client.SendRequestAsync<object>("ots_searchTransactionsAfter", null, parameters);

            response = JsonConvert.DeserializeObject<OtterscanResponse>(resp.ToString());
        }
        catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }
        return response;
    }
}
