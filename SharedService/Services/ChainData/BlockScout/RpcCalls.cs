namespace Services.ChainData.BlockScout;

using Services.ChainData.BlockScout.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

public class RpcCalls {

    //curl -X POST -H "Content-Type: application/json" --data '{"jsonrpc":"2.0", "id": 1, "method":"ots_searchTransactionsAfter","params":["0xc0a47dFe034B400B47bDaD5FecDa2621de6c4d95", 0, 5]}' http://127.0.0.1:8545
    public async Task<BlockScoutResponse> GetTxListAsync( string rpc_api_url,  string address,  long blockStart, long blockEnd) {

        BlockScoutResponse blockScoutResponse  = new BlockScoutResponse();

        var client = new HttpClient();
        try {        
            var response = await client.GetAsync( rpc_api_url + "?module=account&action=txlist&sort=asc&&offset=300&startblock=" + blockStart.ToString() + "&endBlock=" + blockEnd.ToString() + "&address=" + address);
            var responseString = await response.Content.ReadAsStringAsync();
            if ( string.IsNullOrWhiteSpace(responseString)) {
                Console.WriteLine("No data returned from BlockScout"   );                
            }
            else {
                blockScoutResponse  = System.Text.Json.JsonSerializer.Deserialize<BlockScoutResponse>(responseString);
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Error: " + ex.Message);
        }

        return blockScoutResponse;
    }
}
