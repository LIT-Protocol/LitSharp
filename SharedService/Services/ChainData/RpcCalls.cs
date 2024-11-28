
namespace Services.ChainData;
using Nethereum.Contracts.Standards.ENS.PublicResolver.ContractDefinition;
using Services.ChainData.Models;



public class RpcCalls {
    public async Task<List<SimpleTx>> GetTxListAsync(int rpc_api_type, string rpc_api_url, string address, long blockStart, long blockEnd) {

        var txs = new List<SimpleTx>();

        blockEnd = blockEnd == 0 ? 9999999 : blockEnd;

        Console.WriteLine("rpc_api_type: " + rpc_api_type);
        Console.WriteLine("rpc_api_url: " + rpc_api_url);
        Console.WriteLine("from/to: " + blockStart + "/" + blockEnd);


        switch (rpc_api_type) {
            case 1:
                var blockscout_response = await new BlockScout.RpcCalls().GetTxListAsync(rpc_api_url, address, blockStart, blockEnd);
                foreach (var tx in blockscout_response.result) {
                    txs.Add(new SimpleTx() {
                        blockNumber = tx.blockNumber,
                        hash = tx.hash,
                        timeStamp = tx.timeStamp,
                        from = tx.from,
                        to = tx.to,
                        // value = tx.value,
                        gas = tx.gas,
                        gasPrice = tx.gasPrice,                        
                        nonce = tx.nonce,
                        transactionIndex = tx.transactionIndex,
                        input = tx.input,
                    });
                }

                break;
            case 2:
                var otterscan_response = await new  OtterScan.RpcCalls().GetTxListAsync(rpc_api_url, address,blockStart, blockEnd);
                foreach (var tx in otterscan_response.txs) {
                    txs.Add(new SimpleTx() {
                        blockNumber = tx.blockNumber,
                        hash = tx.hash,
                        timeStamp = otterscan_response.receipts.Where(x => x.transactionHash == tx.hash).FirstOrDefault().timestamp.ToString(),
                        from = tx.from,
                        to = tx.to,
                        // value = tx.value,
                        gas = tx.gas,
                        gasPrice = tx.gasPrice,                        
                        nonce = tx.nonce,
                        transactionIndex = tx.transactionIndex,
                        input = tx.input,
                    });
                }

                break;
        }

        return txs;

    }
}

