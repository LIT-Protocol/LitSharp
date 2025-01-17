using System.Text;
using LitContracts.PubkeyRouter;
using LitContracts.Staking;
using LitContracts.PKPHelper;
using LitContracts.PKPNFT;
using LitContracts.PKPPermissions;
using LitContracts.PKPNFTMetadata;
using LitContracts.StakingBalances;
using LitContracts.RateLimitNFT;
using LitContracts.ContractResolver;
using Nethereum.Util;
using Org.BouncyCastle.Crypto.Digests;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Blazored.LocalStorage;
namespace SharedService;

 public struct ContractAddress {
    public string name { get; set; }
    public string address { get; set; }
    
 }
 
 public enum Env {
        Dev = 0,
        Staging = 1,
        Prod = 2
    }

public enum ContractType
    {
        Allowlist ,
        BackupRecovery,
        CloneNet,
        DomainWalletRegistry,
        HDKeyDeriver,
        HostCommands,
        LitToken,
        Multisender,
        PaymentDelegation,
        PKPHelper,
        PKPHelperV2,
        PKPNFT,
        PKPNFTMetadata,
        PKPPermissions,
        PubkeyRouter,
        RateLimitNFT,
        ReleaseRegister,
        Staking,
        StakingBalances,
        WLIT,
        StylusContractP256,
        StylusContractK256
    }

public class Resolver{
    
    private ILocalStorageService localStorage { get; }
    private string defaultPrivateKey = "0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80";
    private string defaultContractResolverAddress = "0x5FbDB2315678afecb367f032d93F642f64180aa3";
    private string defaultUrl = "http://127.0.0.1:8545";

    public Resolver(ILocalStorageService localStorageService) {
        localStorage = localStorageService;

       
    }
    public async Task<Web3> GetConnection() {
    
        var url = await localStorage.GetItemAsync<string>("url");
        if (url == null)
             url = defaultUrl;
            
        var privateKey = await localStorage.GetItemAsync<string>("privateKey");
        if (privateKey == null)
             privateKey = defaultPrivateKey;
                    
        var account = new Account(privateKey);
        var web3 = new Web3(account, url);
        return web3;
    }

    public  async void SetConnection(string url, string privateKey, string contractResolverAddress) {        
     
        await localStorage.SetItemAsync<string>("url", url);
        await localStorage.SetItemAsync<string>("privateKey", privateKey);
        await localStorage.SetItemAsync<string>("contractResolverAddress", contractResolverAddress);

    }

    public static byte[] keccak256(string tx_bytes) {        
        byte[] txByte = Encoding.UTF8.GetBytes(tx_bytes);
        var digest = new KeccakDigest(256);
        digest.BlockUpdate(txByte, 0, txByte.Length);
        var calculatedHash = new byte[digest.GetByteLength()];
        digest.DoFinal(calculatedHash, 0);
        return calculatedHash;
    }

    public static byte[]? GetContractTypKeccak(ContractType contractType) {
        byte[]? typ = contractType switch
        {
            ContractType.Allowlist => keccak256("ALLOWLIST"),
            ContractType.BackupRecovery => keccak256("BACKUP_RECOVERY"),
            ContractType.CloneNet => keccak256("CLONE_NET"),
            ContractType.DomainWalletRegistry => keccak256("DOMAIN_WALLET_REGISTRY"),
            ContractType.HDKeyDeriver => keccak256("HD_KEY_DERIVER"),
            ContractType.HostCommands => keccak256("HOST_COMMANDS"),
            ContractType.LitToken => keccak256("LIT_TOKEN"),
            ContractType.Multisender => keccak256("MULTI_SENDER"),
            ContractType.PaymentDelegation => keccak256("PAYMENT_DELEGATION"),
            ContractType.PKPHelper => keccak256("PKP_HELPER"),
            ContractType.PKPHelperV2 => keccak256("PKP_HELPER_V2"),
            ContractType.PKPNFT => keccak256("PKP_NFT"),
            ContractType.PKPNFTMetadata => keccak256("PKP_NFT_METADATA"),
            ContractType.PKPPermissions => keccak256("PKP_PERMISSIONS"),
            ContractType.PubkeyRouter => keccak256("PUB_KEY_ROUTER"),
            ContractType.RateLimitNFT => keccak256("RATE_LIMIT_NFT"),
            ContractType.ReleaseRegister => keccak256("RELEASE_REGISTER"),
            ContractType.Staking => keccak256("STAKING"),
            ContractType.StakingBalances => keccak256("STAKING_BALANCES"),
            ContractType.WLIT => keccak256("WLIT"),
            ContractType.StylusContractP256 => keccak256("HD_KEY_DERIVER_CONTRACT_P256"),
            ContractType.StylusContractK256 => keccak256("HD_KEY_DERIVER_CONTRACT_K256"),
            _ => null,
        };
        if (typ == null)
            return null;

        if (typ.Length > 32)
            typ = typ.Slice(0, 32);

        return typ;
    }

    public async Task<string> GetContractAddress(ContractType contractType)
    {
        var typ = GetContractTypKeccak(contractType);    
        if (typ == null)
            return "0x0";

        var resolverService = await GetContractResolverService();
        var env = await localStorage.GetItemAsync<byte>("env");
        var address_bytes = await resolverService.GetContractQueryAsync(typ, env);
        return address_bytes;
    }
 
    public  async Task<List<ContractAddress>> GetAllContractAddresses() {
        
        var resolverService = await GetContractResolverService();
        var contractAddresses = new List<ContractAddress>();

        try {

            // Add in the ContractResolver separately
            contractAddresses.Add(new ContractAddress { name = "ContractResolver", address = resolverService.ContractHandler.ContractAddress });

            foreach (ContractType contractType in Enum.GetValues(typeof(ContractType)) ) {            
                var typ = GetContractTypKeccak(contractType);
                if (typ == null) {
                    contractAddresses.Add(new ContractAddress { name = contractType.ToString(), address = "0x0" });
                } else {
                    var env = await localStorage.GetItemAsync<byte>("env");
                    var contract = await resolverService.GetContractQueryAsync(typ, env);
                    contractAddresses.Add(new ContractAddress { name = contractType.ToString(), address = contract });
                }
            }
        }
        catch (Exception ex) {
            Console.WriteLine("Trying to get contract addresses: " + ex.Message);
        }
        return contractAddresses;
    }

    public async Task<ContractResolverService> GetContractResolverService() 
    {
        var contractResolverAddress = await localStorage.GetItemAsync<string>("contractResolverAddress");
        if (contractResolverAddress == null)
             contractResolverAddress = defaultContractResolverAddress;
        return new ContractResolverService(await GetConnection(), contractResolverAddress);
    }

    public async Task<StakingService> GetStakingService() 
    {
        return new StakingService(await GetConnection(), await GetContractAddress(ContractType.Staking));
    }

    public async Task<PubkeyRouterService> GetPubkeyRouterService()
    {
        return new PubkeyRouterService(await GetConnection(), await GetContractAddress(ContractType.PubkeyRouter));
    }

    public async Task<PKPHelperService> GetPKPHelperService()
    {
        return new PKPHelperService(await GetConnection(), await GetContractAddress(ContractType.PKPHelper));
    }

    public async Task<PKPNFTMetadataService> GetPKPNFTMetadataService()
    {
        return new PKPNFTMetadataService(await GetConnection(), await GetContractAddress(ContractType.PKPNFTMetadata));
    }

    public async Task<PKPPermissionsService>    GetPKPPermissionsService()
    {
        return new PKPPermissionsService(await GetConnection(), await GetContractAddress(ContractType.PKPPermissions));
    }

    public async Task<PkpnftService> GetPkpnftService () {
        return new PkpnftService(await GetConnection(), await GetContractAddress(ContractType.PKPNFT));
    }

    public async Task<RateLimitNFTService>  GetRateLimitNFTService()
    {
        return new RateLimitNFTService(await GetConnection(), await GetContractAddress(ContractType.RateLimitNFT));
    }

    public async Task<StakingBalancesService> GetStakingBalancesService()
    {
        return new StakingBalancesService(await GetConnection(), await GetContractAddress(ContractType.StakingBalances));
    }

}

