using Nethereum.Web3;
using  Nethereum.Web3.Accounts;
namespace SharedService;

public class NodeContracts
{
    public static Web3 GetAnvilConnection() {

        var url = "http://127.0.0.1:8545";
        var privateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
        var account = new Account(privateKey);
        var web3 = new Web3(account, url);

        return web3;
    }

}
