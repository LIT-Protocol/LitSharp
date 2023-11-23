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
using LitContracts.ContractResolver.ContractDefinition;

namespace LitContracts.ContractResolver
{
    public partial class ContractResolverService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ContractResolverDeployment contractResolverDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ContractResolverDeployment>().SendRequestAndWaitForReceiptAsync(contractResolverDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ContractResolverDeployment contractResolverDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ContractResolverDeployment>().SendRequestAsync(contractResolverDeployment);
        }

        public static async Task<ContractResolverService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ContractResolverDeployment contractResolverDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, contractResolverDeployment, cancellationTokenSource);
            return new ContractResolverService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ContractResolverService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public ContractResolverService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte[]> AdminRoleQueryAsync(AdminRoleFunction adminRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminRoleFunction, byte[]>(adminRoleFunction, blockParameter);
        }

        
        public Task<byte[]> AdminRoleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> AllowlistContractQueryAsync(AllowlistContractFunction allowlistContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowlistContractFunction, byte[]>(allowlistContractFunction, blockParameter);
        }

        
        public Task<byte[]> AllowlistContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowlistContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> BackupRecoveryContractQueryAsync(BackupRecoveryContractFunction backupRecoveryContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<BackupRecoveryContractFunction, byte[]>(backupRecoveryContractFunction, blockParameter);
        }

        
        public Task<byte[]> BackupRecoveryContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<BackupRecoveryContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> DefaultAdminRoleQueryAsync(DefaultAdminRoleFunction defaultAdminRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(defaultAdminRoleFunction, blockParameter);
        }

        
        public Task<byte[]> DefaultAdminRoleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> DomainWalletOracleQueryAsync(DomainWalletOracleFunction domainWalletOracleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DomainWalletOracleFunction, byte[]>(domainWalletOracleFunction, blockParameter);
        }

        
        public Task<byte[]> DomainWalletOracleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DomainWalletOracleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> DomainWalletRegistryQueryAsync(DomainWalletRegistryFunction domainWalletRegistryFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DomainWalletRegistryFunction, byte[]>(domainWalletRegistryFunction, blockParameter);
        }

        
        public Task<byte[]> DomainWalletRegistryQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DomainWalletRegistryFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> HdKeyDeriverContractQueryAsync(HdKeyDeriverContractFunction hdKeyDeriverContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HdKeyDeriverContractFunction, byte[]>(hdKeyDeriverContractFunction, blockParameter);
        }

        
        public Task<byte[]> HdKeyDeriverContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HdKeyDeriverContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> LitTokenContractQueryAsync(LitTokenContractFunction litTokenContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<LitTokenContractFunction, byte[]>(litTokenContractFunction, blockParameter);
        }

        
        public Task<byte[]> LitTokenContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<LitTokenContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> MultiSenderContractQueryAsync(MultiSenderContractFunction multiSenderContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<MultiSenderContractFunction, byte[]>(multiSenderContractFunction, blockParameter);
        }

        
        public Task<byte[]> MultiSenderContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<MultiSenderContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> PkpHelperContractQueryAsync(PkpHelperContractFunction pkpHelperContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PkpHelperContractFunction, byte[]>(pkpHelperContractFunction, blockParameter);
        }

        
        public Task<byte[]> PkpHelperContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PkpHelperContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> PkpNftContractQueryAsync(PkpNftContractFunction pkpNftContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PkpNftContractFunction, byte[]>(pkpNftContractFunction, blockParameter);
        }

        
        public Task<byte[]> PkpNftContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PkpNftContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> PkpNftMetadataContractQueryAsync(PkpNftMetadataContractFunction pkpNftMetadataContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PkpNftMetadataContractFunction, byte[]>(pkpNftMetadataContractFunction, blockParameter);
        }

        
        public Task<byte[]> PkpNftMetadataContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PkpNftMetadataContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> PkpPermissionsContractQueryAsync(PkpPermissionsContractFunction pkpPermissionsContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PkpPermissionsContractFunction, byte[]>(pkpPermissionsContractFunction, blockParameter);
        }

        
        public Task<byte[]> PkpPermissionsContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PkpPermissionsContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> PubKeyRouterContractQueryAsync(PubKeyRouterContractFunction pubKeyRouterContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PubKeyRouterContractFunction, byte[]>(pubKeyRouterContractFunction, blockParameter);
        }

        
        public Task<byte[]> PubKeyRouterContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PubKeyRouterContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> RateLimitNftContractQueryAsync(RateLimitNftContractFunction rateLimitNftContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<RateLimitNftContractFunction, byte[]>(rateLimitNftContractFunction, blockParameter);
        }

        
        public Task<byte[]> RateLimitNftContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<RateLimitNftContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> ReleaseRegisterContractQueryAsync(ReleaseRegisterContractFunction releaseRegisterContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseRegisterContractFunction, byte[]>(releaseRegisterContractFunction, blockParameter);
        }

        
        public Task<byte[]> ReleaseRegisterContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseRegisterContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> StakingBalancesContractQueryAsync(StakingBalancesContractFunction stakingBalancesContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<StakingBalancesContractFunction, byte[]>(stakingBalancesContractFunction, blockParameter);
        }

        
        public Task<byte[]> StakingBalancesContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<StakingBalancesContractFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> StakingContractQueryAsync(StakingContractFunction stakingContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<StakingContractFunction, byte[]>(stakingContractFunction, blockParameter);
        }

        
        public Task<byte[]> StakingContractQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<StakingContractFunction, byte[]>(null, blockParameter);
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

        public Task<string> GetContractQueryAsync(GetContractFunction getContractFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetContractFunction, string>(getContractFunction, blockParameter);
        }

        
        public Task<string> GetContractQueryAsync(byte[] typ, byte env, BlockParameter? blockParameter = null)
        {
            var getContractFunction = new GetContractFunction();
                getContractFunction.Typ = typ;
                getContractFunction.Env = env;
            
            return ContractHandler.QueryAsync<GetContractFunction, string>(getContractFunction, blockParameter);
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

        public Task<string> SetAdminRequestAsync(SetAdminFunction setAdminFunction)
        {
             return ContractHandler.SendRequestAsync(setAdminFunction);
        }

        public Task<TransactionReceipt> SetAdminRequestAndWaitForReceiptAsync(SetAdminFunction setAdminFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdminFunction, cancellationToken);
        }

        public Task<string> SetAdminRequestAsync(string newAdmin)
        {
            var setAdminFunction = new SetAdminFunction();
                setAdminFunction.NewAdmin = newAdmin;
            
             return ContractHandler.SendRequestAsync(setAdminFunction);
        }

        public Task<TransactionReceipt> SetAdminRequestAndWaitForReceiptAsync(string newAdmin, CancellationTokenSource? cancellationToken = null)
        {
            var setAdminFunction = new SetAdminFunction();
                setAdminFunction.NewAdmin = newAdmin;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdminFunction, cancellationToken);
        }

        public Task<string> SetContractRequestAsync(SetContractFunction setContractFunction)
        {
             return ContractHandler.SendRequestAsync(setContractFunction);
        }

        public Task<TransactionReceipt> SetContractRequestAndWaitForReceiptAsync(SetContractFunction setContractFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractFunction, cancellationToken);
        }

        public Task<string> SetContractRequestAsync(byte[] typ, byte env, string addr)
        {
            var setContractFunction = new SetContractFunction();
                setContractFunction.Typ = typ;
                setContractFunction.Env = env;
                setContractFunction.Addr = addr;
            
             return ContractHandler.SendRequestAsync(setContractFunction);
        }

        public Task<TransactionReceipt> SetContractRequestAndWaitForReceiptAsync(byte[] typ, byte env, string addr, CancellationTokenSource? cancellationToken = null)
        {
            var setContractFunction = new SetContractFunction();
                setContractFunction.Typ = typ;
                setContractFunction.Env = env;
                setContractFunction.Addr = addr;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractFunction, cancellationToken);
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

        public Task<string> TypeAddressesQueryAsync(TypeAddressesFunction typeAddressesFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<TypeAddressesFunction, string>(typeAddressesFunction, blockParameter);
        }

        
        public Task<string> TypeAddressesQueryAsync(byte[] returnValue1, byte returnValue2, BlockParameter? blockParameter = null)
        {
            var typeAddressesFunction = new TypeAddressesFunction();
                typeAddressesFunction.ReturnValue1 = returnValue1;
                typeAddressesFunction.ReturnValue2 = returnValue2;
            
            return ContractHandler.QueryAsync<TypeAddressesFunction, string>(typeAddressesFunction, blockParameter);
        }
    }
}
