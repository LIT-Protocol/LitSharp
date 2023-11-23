using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using LitContracts.ReleaseRegister.ContractDefinition;

namespace LitContracts.ReleaseRegister
{
    public partial class ReleaseRegisterService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ReleaseRegisterDeployment releaseRegisterDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ReleaseRegisterDeployment>().SendRequestAndWaitForReceiptAsync(releaseRegisterDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ReleaseRegisterDeployment releaseRegisterDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ReleaseRegisterDeployment>().SendRequestAsync(releaseRegisterDeployment);
        }

        public static async Task<ReleaseRegisterService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ReleaseRegisterDeployment releaseRegisterDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, releaseRegisterDeployment, cancellationTokenSource);
            return new ReleaseRegisterService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ReleaseRegisterService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public ReleaseRegisterService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte[]> ActivatorRoleQueryAsync(ActivatorRoleFunction activatorRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ActivatorRoleFunction, byte[]>(activatorRoleFunction, blockParameter);
        }

        
        public Task<byte[]> ActivatorRoleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ActivatorRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> AdminRoleQueryAsync(AdminRoleFunction adminRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminRoleFunction, byte[]>(adminRoleFunction, blockParameter);
        }

        
        public Task<byte[]> AdminRoleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> BurnerRoleQueryAsync(BurnerRoleFunction burnerRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<BurnerRoleFunction, byte[]>(burnerRoleFunction, blockParameter);
        }

        
        public Task<byte[]> BurnerRoleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<BurnerRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> CreatorRoleQueryAsync(CreatorRoleFunction creatorRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<CreatorRoleFunction, byte[]>(creatorRoleFunction, blockParameter);
        }

        
        public Task<byte[]> CreatorRoleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<CreatorRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> DeactivatorRoleQueryAsync(DeactivatorRoleFunction deactivatorRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DeactivatorRoleFunction, byte[]>(deactivatorRoleFunction, blockParameter);
        }

        
        public Task<byte[]> DeactivatorRoleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DeactivatorRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> DefaultAdminRoleQueryAsync(DefaultAdminRoleFunction defaultAdminRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(defaultAdminRoleFunction, blockParameter);
        }

        
        public Task<byte[]> DefaultAdminRoleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<BigInteger> ReleaseOptionRoQueryAsync(ReleaseOptionRoFunction releaseOptionRoFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseOptionRoFunction, BigInteger>(releaseOptionRoFunction, blockParameter);
        }

        
        public Task<BigInteger> ReleaseOptionRoQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseOptionRoFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> ReleaseOptionSshQueryAsync(ReleaseOptionSshFunction releaseOptionSshFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseOptionSshFunction, BigInteger>(releaseOptionSshFunction, blockParameter);
        }

        
        public Task<BigInteger> ReleaseOptionSshQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseOptionSshFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> ReleaseOptionUsersQueryAsync(ReleaseOptionUsersFunction releaseOptionUsersFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseOptionUsersFunction, BigInteger>(releaseOptionUsersFunction, blockParameter);
        }

        
        public Task<BigInteger> ReleaseOptionUsersQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseOptionUsersFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> AddAllowedAdminSigningPublicKeyRequestAsync(AddAllowedAdminSigningPublicKeyFunction addAllowedAdminSigningPublicKeyFunction)
        {
             return ContractHandler.SendRequestAsync(addAllowedAdminSigningPublicKeyFunction);
        }

        public Task<TransactionReceipt> AddAllowedAdminSigningPublicKeyRequestAndWaitForReceiptAsync(AddAllowedAdminSigningPublicKeyFunction addAllowedAdminSigningPublicKeyFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAllowedAdminSigningPublicKeyFunction, cancellationToken);
        }

        public Task<string> AddAllowedAdminSigningPublicKeyRequestAsync(byte[] pubKey)
        {
            var addAllowedAdminSigningPublicKeyFunction = new AddAllowedAdminSigningPublicKeyFunction();
                addAllowedAdminSigningPublicKeyFunction.PubKey = pubKey;
            
             return ContractHandler.SendRequestAsync(addAllowedAdminSigningPublicKeyFunction);
        }

        public Task<TransactionReceipt> AddAllowedAdminSigningPublicKeyRequestAndWaitForReceiptAsync(byte[] pubKey, CancellationTokenSource? cancellationToken = null)
        {
            var addAllowedAdminSigningPublicKeyFunction = new AddAllowedAdminSigningPublicKeyFunction();
                addAllowedAdminSigningPublicKeyFunction.PubKey = pubKey;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAllowedAdminSigningPublicKeyFunction, cancellationToken);
        }

        public Task<string> AddAllowedEnvRequestAsync(AddAllowedEnvFunction addAllowedEnvFunction)
        {
             return ContractHandler.SendRequestAsync(addAllowedEnvFunction);
        }

        public Task<TransactionReceipt> AddAllowedEnvRequestAndWaitForReceiptAsync(AddAllowedEnvFunction addAllowedEnvFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAllowedEnvFunction, cancellationToken);
        }

        public Task<string> AddAllowedEnvRequestAsync(byte env)
        {
            var addAllowedEnvFunction = new AddAllowedEnvFunction();
                addAllowedEnvFunction.Env = env;
            
             return ContractHandler.SendRequestAsync(addAllowedEnvFunction);
        }

        public Task<TransactionReceipt> AddAllowedEnvRequestAndWaitForReceiptAsync(byte env, CancellationTokenSource? cancellationToken = null)
        {
            var addAllowedEnvFunction = new AddAllowedEnvFunction();
                addAllowedEnvFunction.Env = env;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAllowedEnvFunction, cancellationToken);
        }

        public Task<string> AddAllowedSubnetRequestAsync(AddAllowedSubnetFunction addAllowedSubnetFunction)
        {
             return ContractHandler.SendRequestAsync(addAllowedSubnetFunction);
        }

        public Task<TransactionReceipt> AddAllowedSubnetRequestAndWaitForReceiptAsync(AddAllowedSubnetFunction addAllowedSubnetFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAllowedSubnetFunction, cancellationToken);
        }

        public Task<string> AddAllowedSubnetRequestAsync(string subnet)
        {
            var addAllowedSubnetFunction = new AddAllowedSubnetFunction();
                addAllowedSubnetFunction.Subnet = subnet;
            
             return ContractHandler.SendRequestAsync(addAllowedSubnetFunction);
        }

        public Task<TransactionReceipt> AddAllowedSubnetRequestAndWaitForReceiptAsync(string subnet, CancellationTokenSource? cancellationToken = null)
        {
            var addAllowedSubnetFunction = new AddAllowedSubnetFunction();
                addAllowedSubnetFunction.Subnet = subnet;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAllowedSubnetFunction, cancellationToken);
        }

        public Task<string> BurnReleaseRequestAsync(BurnReleaseFunction burnReleaseFunction)
        {
             return ContractHandler.SendRequestAsync(burnReleaseFunction);
        }

        public Task<TransactionReceipt> BurnReleaseRequestAndWaitForReceiptAsync(BurnReleaseFunction burnReleaseFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnReleaseFunction, cancellationToken);
        }

        public Task<string> BurnReleaseRequestAsync(byte[] releaseId)
        {
            var burnReleaseFunction = new BurnReleaseFunction();
                burnReleaseFunction.ReleaseId = releaseId;
            
             return ContractHandler.SendRequestAsync(burnReleaseFunction);
        }

        public Task<TransactionReceipt> BurnReleaseRequestAndWaitForReceiptAsync(byte[] releaseId, CancellationTokenSource? cancellationToken = null)
        {
            var burnReleaseFunction = new BurnReleaseFunction();
                burnReleaseFunction.ReleaseId = releaseId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnReleaseFunction, cancellationToken);
        }

        public Task<string> CreateReleaseRequestAsync(CreateReleaseFunction createReleaseFunction)
        {
             return ContractHandler.SendRequestAsync(createReleaseFunction);
        }

        public Task<TransactionReceipt> CreateReleaseRequestAndWaitForReceiptAsync(CreateReleaseFunction createReleaseFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createReleaseFunction, cancellationToken);
        }

        public Task<string> CreateReleaseRequestAsync(byte[] releaseId, byte status, byte env, byte typ, byte[] kind, byte platform, BigInteger options, byte[] idKeyDigest, byte[] publicKey, byte[] cid, BigInteger date)
        {
            var createReleaseFunction = new CreateReleaseFunction();
                createReleaseFunction.ReleaseId = releaseId;
                createReleaseFunction.Status = status;
                createReleaseFunction.Env = env;
                createReleaseFunction.Typ = typ;
                createReleaseFunction.Kind = kind;
                createReleaseFunction.Platform = platform;
                createReleaseFunction.Options = options;
                createReleaseFunction.IdKeyDigest = idKeyDigest;
                createReleaseFunction.PublicKey = publicKey;
                createReleaseFunction.Cid = cid;
                createReleaseFunction.Date = date;
            
             return ContractHandler.SendRequestAsync(createReleaseFunction);
        }

        public Task<TransactionReceipt> CreateReleaseRequestAndWaitForReceiptAsync(byte[] releaseId, byte status, byte env, byte typ, byte[] kind, byte platform, BigInteger options, byte[] idKeyDigest, byte[] publicKey, byte[] cid, BigInteger date, CancellationTokenSource? cancellationToken = null)
        {
            var createReleaseFunction = new CreateReleaseFunction();
                createReleaseFunction.ReleaseId = releaseId;
                createReleaseFunction.Status = status;
                createReleaseFunction.Env = env;
                createReleaseFunction.Typ = typ;
                createReleaseFunction.Kind = kind;
                createReleaseFunction.Platform = platform;
                createReleaseFunction.Options = options;
                createReleaseFunction.IdKeyDigest = idKeyDigest;
                createReleaseFunction.PublicKey = publicKey;
                createReleaseFunction.Cid = cid;
                createReleaseFunction.Date = date;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(createReleaseFunction, cancellationToken);
        }

        public Task<byte[]> GetActiveReleaseQueryAsync(GetActiveReleaseFunction getActiveReleaseFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetActiveReleaseFunction, byte[]>(getActiveReleaseFunction, blockParameter);
        }

        
        public Task<byte[]> GetActiveReleaseQueryAsync(byte env, byte typ, byte[] kind, byte platform, BlockParameter? blockParameter = null)
        {
            var getActiveReleaseFunction = new GetActiveReleaseFunction();
                getActiveReleaseFunction.Env = env;
                getActiveReleaseFunction.Typ = typ;
                getActiveReleaseFunction.Kind = kind;
                getActiveReleaseFunction.Platform = platform;
            
            return ContractHandler.QueryAsync<GetActiveReleaseFunction, byte[]>(getActiveReleaseFunction, blockParameter);
        }

        public Task<List<byte[]>> GetActiveReleasesQueryAsync(GetActiveReleasesFunction getActiveReleasesFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetActiveReleasesFunction, List<byte[]>>(getActiveReleasesFunction, blockParameter);
        }

        
        public Task<List<byte[]>> GetActiveReleasesQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetActiveReleasesFunction, List<byte[]>>(null, blockParameter);
        }

        public Task<byte[]> GetCreatorDomainQueryAsync(GetCreatorDomainFunction getCreatorDomainFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCreatorDomainFunction, byte[]>(getCreatorDomainFunction, blockParameter);
        }

        
        public Task<byte[]> GetCreatorDomainQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetCreatorDomainFunction, byte[]>(null, blockParameter);
        }

        public Task<GetReleaseOutputDTO> GetReleaseQueryAsync(GetReleaseFunction getReleaseFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetReleaseFunction, GetReleaseOutputDTO>(getReleaseFunction, blockParameter);
        }

        public Task<GetReleaseOutputDTO> GetReleaseQueryAsync(byte[] releaseId, BlockParameter? blockParameter = null)
        {
            var getReleaseFunction = new GetReleaseFunction();
                getReleaseFunction.ReleaseId = releaseId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetReleaseFunction, GetReleaseOutputDTO>(getReleaseFunction, blockParameter);
        }

        public Task<byte[]> GetRoleAdminQueryAsync(GetRoleAdminFunction getRoleAdminFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        
        public Task<byte[]> GetRoleAdminQueryAsync(byte[] role, BlockParameter? blockParameter = null)
        {
            var getRoleAdminFunction = new GetRoleAdminFunction();
                getRoleAdminFunction.Role = role;
            
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        public Task<string> GrantRoleRequestAsync(GrantRoleFunction grantRoleFunction)
        {
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(GrantRoleFunction grantRoleFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<string> GrantRoleRequestAsync(byte[] role, string account)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource? cancellationToken = null)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<bool> HasAllowedAdminSigningPublicKeyQueryAsync(HasAllowedAdminSigningPublicKeyFunction hasAllowedAdminSigningPublicKeyFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasAllowedAdminSigningPublicKeyFunction, bool>(hasAllowedAdminSigningPublicKeyFunction, blockParameter);
        }

        
        public Task<bool> HasAllowedAdminSigningPublicKeyQueryAsync(byte[] pubKey, BlockParameter? blockParameter = null)
        {
            var hasAllowedAdminSigningPublicKeyFunction = new HasAllowedAdminSigningPublicKeyFunction();
                hasAllowedAdminSigningPublicKeyFunction.PubKey = pubKey;
            
            return ContractHandler.QueryAsync<HasAllowedAdminSigningPublicKeyFunction, bool>(hasAllowedAdminSigningPublicKeyFunction, blockParameter);
        }

        public Task<bool> HasAllowedAuthorKeyDigestQueryAsync(HasAllowedAuthorKeyDigestFunction hasAllowedAuthorKeyDigestFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasAllowedAuthorKeyDigestFunction, bool>(hasAllowedAuthorKeyDigestFunction, blockParameter);
        }

        
        public Task<bool> HasAllowedAuthorKeyDigestQueryAsync(byte[] digest, BlockParameter? blockParameter = null)
        {
            var hasAllowedAuthorKeyDigestFunction = new HasAllowedAuthorKeyDigestFunction();
                hasAllowedAuthorKeyDigestFunction.Digest = digest;
            
            return ContractHandler.QueryAsync<HasAllowedAuthorKeyDigestFunction, bool>(hasAllowedAuthorKeyDigestFunction, blockParameter);
        }

        public Task<bool> HasAllowedEnvQueryAsync(HasAllowedEnvFunction hasAllowedEnvFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasAllowedEnvFunction, bool>(hasAllowedEnvFunction, blockParameter);
        }

        
        public Task<bool> HasAllowedEnvQueryAsync(byte env, BlockParameter? blockParameter = null)
        {
            var hasAllowedEnvFunction = new HasAllowedEnvFunction();
                hasAllowedEnvFunction.Env = env;
            
            return ContractHandler.QueryAsync<HasAllowedEnvFunction, bool>(hasAllowedEnvFunction, blockParameter);
        }

        public Task<bool> HasAllowedSubnetQueryAsync(HasAllowedSubnetFunction hasAllowedSubnetFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasAllowedSubnetFunction, bool>(hasAllowedSubnetFunction, blockParameter);
        }

        
        public Task<bool> HasAllowedSubnetQueryAsync(string subnet, BlockParameter? blockParameter = null)
        {
            var hasAllowedSubnetFunction = new HasAllowedSubnetFunction();
                hasAllowedSubnetFunction.Subnet = subnet;
            
            return ContractHandler.QueryAsync<HasAllowedSubnetFunction, bool>(hasAllowedSubnetFunction, blockParameter);
        }

        public Task<bool> HasCreatorInitQueryAsync(HasCreatorInitFunction hasCreatorInitFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasCreatorInitFunction, bool>(hasCreatorInitFunction, blockParameter);
        }

        
        public Task<bool> HasCreatorInitQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasCreatorInitFunction, bool>(null, blockParameter);
        }

        public Task<bool> HasRoleQueryAsync(HasRoleFunction hasRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        
        public Task<bool> HasRoleQueryAsync(byte[] role, string account, BlockParameter? blockParameter = null)
        {
            var hasRoleFunction = new HasRoleFunction();
                hasRoleFunction.Role = role;
                hasRoleFunction.Account = account;
            
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        public Task<string> InitCreatorRequestAsync(InitCreatorFunction initCreatorFunction)
        {
             return ContractHandler.SendRequestAsync(initCreatorFunction);
        }

        public Task<TransactionReceipt> InitCreatorRequestAndWaitForReceiptAsync(InitCreatorFunction initCreatorFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initCreatorFunction, cancellationToken);
        }

        public Task<string> InitCreatorRequestAsync(byte env, string subnetId, byte[] domain, byte[] authorKeyDigest)
        {
            var initCreatorFunction = new InitCreatorFunction();
                initCreatorFunction.Env = env;
                initCreatorFunction.SubnetId = subnetId;
                initCreatorFunction.Domain = domain;
                initCreatorFunction.AuthorKeyDigest = authorKeyDigest;
            
             return ContractHandler.SendRequestAsync(initCreatorFunction);
        }

        public Task<TransactionReceipt> InitCreatorRequestAndWaitForReceiptAsync(byte env, string subnetId, byte[] domain, byte[] authorKeyDigest, CancellationTokenSource? cancellationToken = null)
        {
            var initCreatorFunction = new InitCreatorFunction();
                initCreatorFunction.Env = env;
                initCreatorFunction.SubnetId = subnetId;
                initCreatorFunction.Domain = domain;
                initCreatorFunction.AuthorKeyDigest = authorKeyDigest;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initCreatorFunction, cancellationToken);
        }

        public Task<string> RemoveAllowedAdminSigningPublicKeyRequestAsync(RemoveAllowedAdminSigningPublicKeyFunction removeAllowedAdminSigningPublicKeyFunction)
        {
             return ContractHandler.SendRequestAsync(removeAllowedAdminSigningPublicKeyFunction);
        }

        public Task<TransactionReceipt> RemoveAllowedAdminSigningPublicKeyRequestAndWaitForReceiptAsync(RemoveAllowedAdminSigningPublicKeyFunction removeAllowedAdminSigningPublicKeyFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAllowedAdminSigningPublicKeyFunction, cancellationToken);
        }

        public Task<string> RemoveAllowedAdminSigningPublicKeyRequestAsync(byte[] pubKey)
        {
            var removeAllowedAdminSigningPublicKeyFunction = new RemoveAllowedAdminSigningPublicKeyFunction();
                removeAllowedAdminSigningPublicKeyFunction.PubKey = pubKey;
            
             return ContractHandler.SendRequestAsync(removeAllowedAdminSigningPublicKeyFunction);
        }

        public Task<TransactionReceipt> RemoveAllowedAdminSigningPublicKeyRequestAndWaitForReceiptAsync(byte[] pubKey, CancellationTokenSource? cancellationToken = null)
        {
            var removeAllowedAdminSigningPublicKeyFunction = new RemoveAllowedAdminSigningPublicKeyFunction();
                removeAllowedAdminSigningPublicKeyFunction.PubKey = pubKey;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAllowedAdminSigningPublicKeyFunction, cancellationToken);
        }

        public Task<string> RemoveAllowedEnvRequestAsync(RemoveAllowedEnvFunction removeAllowedEnvFunction)
        {
             return ContractHandler.SendRequestAsync(removeAllowedEnvFunction);
        }

        public Task<TransactionReceipt> RemoveAllowedEnvRequestAndWaitForReceiptAsync(RemoveAllowedEnvFunction removeAllowedEnvFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAllowedEnvFunction, cancellationToken);
        }

        public Task<string> RemoveAllowedEnvRequestAsync(byte env)
        {
            var removeAllowedEnvFunction = new RemoveAllowedEnvFunction();
                removeAllowedEnvFunction.Env = env;
            
             return ContractHandler.SendRequestAsync(removeAllowedEnvFunction);
        }

        public Task<TransactionReceipt> RemoveAllowedEnvRequestAndWaitForReceiptAsync(byte env, CancellationTokenSource? cancellationToken = null)
        {
            var removeAllowedEnvFunction = new RemoveAllowedEnvFunction();
                removeAllowedEnvFunction.Env = env;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAllowedEnvFunction, cancellationToken);
        }

        public Task<string> RemoveAllowedSubnetRequestAsync(RemoveAllowedSubnetFunction removeAllowedSubnetFunction)
        {
             return ContractHandler.SendRequestAsync(removeAllowedSubnetFunction);
        }

        public Task<TransactionReceipt> RemoveAllowedSubnetRequestAndWaitForReceiptAsync(RemoveAllowedSubnetFunction removeAllowedSubnetFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAllowedSubnetFunction, cancellationToken);
        }

        public Task<string> RemoveAllowedSubnetRequestAsync(string subnet)
        {
            var removeAllowedSubnetFunction = new RemoveAllowedSubnetFunction();
                removeAllowedSubnetFunction.Subnet = subnet;
            
             return ContractHandler.SendRequestAsync(removeAllowedSubnetFunction);
        }

        public Task<TransactionReceipt> RemoveAllowedSubnetRequestAndWaitForReceiptAsync(string subnet, CancellationTokenSource? cancellationToken = null)
        {
            var removeAllowedSubnetFunction = new RemoveAllowedSubnetFunction();
                removeAllowedSubnetFunction.Subnet = subnet;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAllowedSubnetFunction, cancellationToken);
        }

        public Task<string> RenounceRoleRequestAsync(RenounceRoleFunction renounceRoleFunction)
        {
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(RenounceRoleFunction renounceRoleFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceRoleFunction, cancellationToken);
        }

        public Task<string> RenounceRoleRequestAsync(byte[] role, string account)
        {
            var renounceRoleFunction = new RenounceRoleFunction();
                renounceRoleFunction.Role = role;
                renounceRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource? cancellationToken = null)
        {
            var renounceRoleFunction = new RenounceRoleFunction();
                renounceRoleFunction.Role = role;
                renounceRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceRoleFunction, cancellationToken);
        }

        public Task<string> RevokeRoleRequestAsync(RevokeRoleFunction revokeRoleFunction)
        {
             return ContractHandler.SendRequestAsync(revokeRoleFunction);
        }

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(RevokeRoleFunction revokeRoleFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<string> RevokeRoleRequestAsync(byte[] role, string account)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(revokeRoleFunction);
        }

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource? cancellationToken = null)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<string> SetReleaseStatusRequestAsync(SetReleaseStatusFunction setReleaseStatusFunction)
        {
             return ContractHandler.SendRequestAsync(setReleaseStatusFunction);
        }

        public Task<TransactionReceipt> SetReleaseStatusRequestAndWaitForReceiptAsync(SetReleaseStatusFunction setReleaseStatusFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setReleaseStatusFunction, cancellationToken);
        }

        public Task<string> SetReleaseStatusRequestAsync(byte[] releaseId, byte status)
        {
            var setReleaseStatusFunction = new SetReleaseStatusFunction();
                setReleaseStatusFunction.ReleaseId = releaseId;
                setReleaseStatusFunction.Status = status;
            
             return ContractHandler.SendRequestAsync(setReleaseStatusFunction);
        }

        public Task<TransactionReceipt> SetReleaseStatusRequestAndWaitForReceiptAsync(byte[] releaseId, byte status, CancellationTokenSource? cancellationToken = null)
        {
            var setReleaseStatusFunction = new SetReleaseStatusFunction();
                setReleaseStatusFunction.ReleaseId = releaseId;
                setReleaseStatusFunction.Status = status;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setReleaseStatusFunction, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter? blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }
    }
}
