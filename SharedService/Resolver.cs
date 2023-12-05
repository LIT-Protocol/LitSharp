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
using  Nethereum.Web3.Accounts;
using Blazored.LocalStorage;
using Org.BouncyCastle.Crypto.Tls;
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
        ContractResolver,
        DomainWalletOracle,
        DomainWalletRegistry,
        HDKeyDeriver,
        LitToken,
        Multisender, 
        PKPHelper,
        PKPNFT,
        PKPNFTMetadata,
        PKPPermissions,
        PubkeyRouter,
        RateLimitNFT,
        ReleaseRegister,
        Staking,
        StakingBalances,
        WLIT
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

    public static byte[] GetContractTypKeccak(ContractType contractType) {

        byte[]  typ = keccak256("STAKING"); 
                
        switch (contractType) {
        case ContractType.Allowlist:
            typ = keccak256("ALLOWLIST");  
            break;
        case ContractType.BackupRecovery:
            typ = keccak256("BACKUP_RECOVERY");
            break;
        case ContractType.ContractResolver:
            break;
        case ContractType.DomainWalletOracle:
            typ = keccak256("DOMAIN_WALLET_ORACLE");
            break;
        case ContractType.DomainWalletRegistry:
            typ = keccak256("DOMAIN_WALLET_REGISTRY");
            break;
        case ContractType.HDKeyDeriver:
            typ = keccak256("HD_KEY_DERIVER");
            break;
        case ContractType.LitToken:
            typ = keccak256("LIT_TOKEN");            
            break;
        case ContractType.Multisender:
            typ = keccak256("MULTI_SENDER"); 
            break;
        case ContractType.PKPHelper:
            typ = keccak256("PKP_HELPER"); 
            break;
        case ContractType.PKPNFT:
            typ = keccak256("PKP_NFT");  
            break;
        case ContractType.PKPNFTMetadata:
            typ = keccak256("PKP_NFT_METADATA");  
            break;
        case ContractType.PKPPermissions:
            typ = keccak256("PKP_PERMISSIONS");  
            break;
        case ContractType.PubkeyRouter:
            typ = keccak256("PUB_KEY_ROUTER");  
            break;
        case ContractType.RateLimitNFT:
            typ = keccak256("RATE_LIMIT_NFT");  
            break;
        case ContractType.ReleaseRegister:
            typ = keccak256("RELEASE_REGISTER"); 
            break;
        case ContractType.Staking:
            typ = keccak256("STAKING");  
            break;
        case ContractType.StakingBalances:
            typ = keccak256("STAKING_BALANCES");  
            break;
        case ContractType.WLIT:
            typ = keccak256("WLIT"); 
            break;
        default:
            typ = keccak256("STAKING");  
            break;
        }
         
        if ( typ.Length > 32  )
            typ = typ.Slice(0, 32);

        return typ;
    }

    public async Task<string> GetContractAddress(ContractType contractType)
    {
        var typ = GetContractTypKeccak(contractType);        
        var resolverService = await GetContractResolverService();
        var address_bytes = await resolverService.GetContractQueryAsync(typ, env: (byte)Env.Dev);
        return address_bytes;
    }
 
    public  async Task<List<ContractAddress>> GetAllContractAddresses() {
        
        var resolverService = await GetContractResolverService();
        var contractAddresses = new List<ContractAddress>();

        foreach (ContractType contractType in Enum.GetValues(typeof(ContractType)) )
        {            
            var typ = GetContractTypKeccak(contractType);
            var env = (byte)Env.Dev;
            var contract = await resolverService.GetContractQueryAsync(typ, env);
            Console.WriteLine($"Contract Type: {contractType} Address: {contract}");
            contractAddresses.Add(new ContractAddress { name = contractType.ToString(), address = contract });
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

