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

    public static void SetConnection(string url, string privateKey, string contractAddress) {        
     
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

        byte[]  typ = keccak256("STAKING"); // 0x080909c18c958ce5a2d36481697824e477319323d03154ceba3b78f28a61887b
                
        switch (contractType) {
        case ContractType.Allowlist:
            typ = keccak256("ALLOWLIST"); // 0x74845de37cfabd357633214b47fa91ccd19b05b7c5a08ac22c187f811fb62bca
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
            typ = keccak256("MULTI_SENDER"); // 0xd5b9b8a5e8e01f962ed7e983d58fe32e1f66aa88dd7ab30770fa9b77da7243
            break;
        case ContractType.PKPHelper:
            typ = keccak256("PKP_HELPER"); // 0x27d764ea2a4a3865434bbf4a391110149644be31448f3479fd15b44388755765
            break;
        case ContractType.PKPNFT:
            typ = keccak256("PKP_NFT"); // 0xb7b4fde9944d3c13e9a78835431c33a5084d90a7f0c73def76d7886315fe87b0
            break;
        case ContractType.PKPNFTMetadata:
            typ = keccak256("PKP_NFT_METADATA"); // 0xf14f431dadc82e7dbc5e379f71234e5735c9187e4327a7c6ac014d55d1b7727a
            break;
        case ContractType.PKPPermissions:
            typ = keccak256("PKP_PERMISSIONS"); // 0x54953c23068b8fc4c0736301b50f10027d6b469327de1fd42841a5072b1bcebe
            break;
        case ContractType.PubkeyRouter:
            typ = keccak256("PUB_KEY_ROUTER"); // 0xb1f79813bc7630a52ae948bc99781397e409d0dd3521953bf7d8d7a2db6147f7
            break;
        case ContractType.RateLimitNFT:
            typ = keccak256("RATE_LIMIT_NFT"); // 0xb931b2719aeb2a65a5035fa0a190bfdc4c8622ce8cbff7a3d1ab42531fb1a918
            break;
        case ContractType.ReleaseRegister:
            typ = keccak256("RELEASE_REGISTER"); // 0x3a68dbfd8bbb64015c42bc131c388dea7965e28c1004d09b39f59500c3a763ec
            break;
        case ContractType.Staking:
            typ = keccak256("STAKING"); // 0x080909c18c958ce5a2d36481697824e477319323d03154ceba3b78f28a61887b
            break;
        case ContractType.StakingBalances:
            typ = keccak256("STAKING_BALANCES"); // 0xaa06d108dbd7bf976b16b7bf5adb29d2d0ef2c385ca8b9d833cc802f33942d72
            break;
        case ContractType.WLIT:
            typ = keccak256("WLIT"); // 0xaa06d108dbd7bf976b16b7bf5adb29d2d0ef2c385ca8b9d833cc802f33942d72
            break;
        default:
            typ = keccak256("STAKING"); // 0x080909c18c958ce5a2d36481697824e477319323d03154ceba3b78f28a61887b
            break;
        }
         
        if ( typ.Length > 32  )
            typ = typ.Slice(0, 32);

        return typ;
    }

    public async Task<string> GetContractAddress(ContractType contractType)
    {
        var typ = GetContractTypKeccak(contractType);
        var web3 =  await GetConnection();
        ContractResolverService resolverService = new ContractResolverService(web3, defaultContractResolverAddress);
        var address_bytes = await resolverService.GetContractQueryAsync(typ, env: (byte)Env.Dev);
        return address_bytes;
    }
 
    public  async Task<List<ContractAddress>> GetAllContractAddresses() {
        var web3 = await  GetConnection();
        ContractResolverService resolverService = new ContractResolverService(web3, defaultContractResolverAddress);
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

