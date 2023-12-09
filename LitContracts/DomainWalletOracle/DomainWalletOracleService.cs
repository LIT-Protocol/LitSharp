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
using LitContracts.DomainWalletOracle.ContractDefinition;

namespace LitContracts.DomainWalletOracle
{
    public partial class DomainWalletOracleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, DomainWalletOracleDeployment domainWalletOracleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<DomainWalletOracleDeployment>().SendRequestAndWaitForReceiptAsync(domainWalletOracleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, DomainWalletOracleDeployment domainWalletOracleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<DomainWalletOracleDeployment>().SendRequestAsync(domainWalletOracleDeployment);
        }

        public static async Task<DomainWalletOracleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, DomainWalletOracleDeployment domainWalletOracleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, domainWalletOracleDeployment, cancellationTokenSource);
            return new DomainWalletOracleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public DomainWalletOracleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public DomainWalletOracleService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte[]> AdminRoleQueryAsync(AdminRoleFunction adminRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminRoleFunction, byte[]>(adminRoleFunction, blockParameter);
        }

        
        public Task<byte[]> AdminRoleQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> DefaultAdminRoleQueryAsync(DefaultAdminRoleFunction defaultAdminRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(defaultAdminRoleFunction, blockParameter);
        }

        
        public Task<byte[]> DefaultAdminRoleQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<string> AddAdminRequestAsync(AddAdminFunction addAdminFunction)
        {
             return ContractHandler.SendRequestAsync(addAdminFunction);
        }

        public Task<TransactionReceipt> AddAdminRequestAndWaitForReceiptAsync(AddAdminFunction addAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAdminFunction, cancellationToken);
        }

        public Task<string> AddAdminRequestAsync(string newAdmin)
        {
            var addAdminFunction = new AddAdminFunction();
                addAdminFunction.NewAdmin = newAdmin;
            
             return ContractHandler.SendRequestAsync(addAdminFunction);
        }

        public Task<TransactionReceipt> AddAdminRequestAndWaitForReceiptAsync(string newAdmin, CancellationTokenSource cancellationToken = null)
        {
            var addAdminFunction = new AddAdminFunction();
                addAdminFunction.NewAdmin = newAdmin;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAdminFunction, cancellationToken);
        }

        public Task<string> ContractResolverQueryAsync(ContractResolverFunction contractResolverFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(contractResolverFunction, blockParameter);
        }

        
        public Task<string> ContractResolverQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(null, blockParameter);
        }

        public Task<byte> EnvQueryAsync(EnvFunction envFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EnvFunction, byte>(envFunction, blockParameter);
        }

        
        public Task<byte> EnvQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EnvFunction, byte>(null, blockParameter);
        }

        public Task<ulong> GetDomainIdByTokenIdQueryAsync(GetDomainIdByTokenIdFunction getDomainIdByTokenIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDomainIdByTokenIdFunction, ulong>(getDomainIdByTokenIdFunction, blockParameter);
        }

        
        public Task<ulong> GetDomainIdByTokenIdQueryAsync(BigInteger pkpTokenId, BlockParameter blockParameter = null)
        {
            var getDomainIdByTokenIdFunction = new GetDomainIdByTokenIdFunction();
                getDomainIdByTokenIdFunction.PkpTokenId = pkpTokenId;
            
            return ContractHandler.QueryAsync<GetDomainIdByTokenIdFunction, ulong>(getDomainIdByTokenIdFunction, blockParameter);
        }

        public Task<BigInteger> GetDomainTokenIdByUriQueryAsync(GetDomainTokenIdByUriFunction getDomainTokenIdByUriFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDomainTokenIdByUriFunction, BigInteger>(getDomainTokenIdByUriFunction, blockParameter);
        }

        
        public Task<BigInteger> GetDomainTokenIdByUriQueryAsync(byte[] uri, BlockParameter blockParameter = null)
        {
            var getDomainTokenIdByUriFunction = new GetDomainTokenIdByUriFunction();
                getDomainTokenIdByUriFunction.Uri = uri;
            
            return ContractHandler.QueryAsync<GetDomainTokenIdByUriFunction, BigInteger>(getDomainTokenIdByUriFunction, blockParameter);
        }

        public Task<byte[]> GetDomainUriQueryAsync(GetDomainUriFunction getDomainUriFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDomainUriFunction, byte[]>(getDomainUriFunction, blockParameter);
        }

        
        public Task<byte[]> GetDomainUriQueryAsync(BigInteger pkpTokenId, BlockParameter blockParameter = null)
        {
            var getDomainUriFunction = new GetDomainUriFunction();
                getDomainUriFunction.PkpTokenId = pkpTokenId;
            
            return ContractHandler.QueryAsync<GetDomainUriFunction, byte[]>(getDomainUriFunction, blockParameter);
        }

        public Task<BigInteger> GetExpirationQueryAsync(GetExpirationFunction getExpirationFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetExpirationFunction, BigInteger>(getExpirationFunction, blockParameter);
        }

        
        public Task<BigInteger> GetExpirationQueryAsync(BigInteger pkpTokenId, BlockParameter blockParameter = null)
        {
            var getExpirationFunction = new GetExpirationFunction();
                getExpirationFunction.PkpTokenId = pkpTokenId;
            
            return ContractHandler.QueryAsync<GetExpirationFunction, BigInteger>(getExpirationFunction, blockParameter);
        }

        public Task<BigInteger> GetPkpTokenIdQueryAsync(GetPkpTokenIdFunction getPkpTokenIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpTokenIdFunction, BigInteger>(getPkpTokenIdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetPkpTokenIdQueryAsync(ulong id, BlockParameter blockParameter = null)
        {
            var getPkpTokenIdFunction = new GetPkpTokenIdFunction();
                getPkpTokenIdFunction.Id = id;
            
            return ContractHandler.QueryAsync<GetPkpTokenIdFunction, BigInteger>(getPkpTokenIdFunction, blockParameter);
        }

        public Task<byte[]> GetRecordQueryAsync(GetRecordFunction getRecordFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRecordFunction, byte[]>(getRecordFunction, blockParameter);
        }

        
        public Task<byte[]> GetRecordQueryAsync(BigInteger pkpTokenId, BlockParameter blockParameter = null)
        {
            var getRecordFunction = new GetRecordFunction();
                getRecordFunction.PkpTokenId = pkpTokenId;
            
            return ContractHandler.QueryAsync<GetRecordFunction, byte[]>(getRecordFunction, blockParameter);
        }

        public Task<byte[]> GetRoleAdminQueryAsync(GetRoleAdminFunction getRoleAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        
        public Task<byte[]> GetRoleAdminQueryAsync(byte[] role, BlockParameter blockParameter = null)
        {
            var getRoleAdminFunction = new GetRoleAdminFunction();
                getRoleAdminFunction.Role = role;
            
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        public Task<string> GrantRoleRequestAsync(GrantRoleFunction grantRoleFunction)
        {
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(GrantRoleFunction grantRoleFunction, CancellationTokenSource cancellationToken = null)
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

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<string> HasExpiredRequestAsync(HasExpiredFunction hasExpiredFunction)
        {
             return ContractHandler.SendRequestAsync(hasExpiredFunction);
        }

        public Task<TransactionReceipt> HasExpiredRequestAndWaitForReceiptAsync(HasExpiredFunction hasExpiredFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(hasExpiredFunction, cancellationToken);
        }

        public Task<string> HasExpiredRequestAsync(BigInteger pkpTokenId)
        {
            var hasExpiredFunction = new HasExpiredFunction();
                hasExpiredFunction.PkpTokenId = pkpTokenId;
            
             return ContractHandler.SendRequestAsync(hasExpiredFunction);
        }

        public Task<TransactionReceipt> HasExpiredRequestAndWaitForReceiptAsync(BigInteger pkpTokenId, CancellationTokenSource cancellationToken = null)
        {
            var hasExpiredFunction = new HasExpiredFunction();
                hasExpiredFunction.PkpTokenId = pkpTokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(hasExpiredFunction, cancellationToken);
        }

        public Task<bool> HasOwnerQueryAsync(HasOwnerFunction hasOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasOwnerFunction, bool>(hasOwnerFunction, blockParameter);
        }

        
        public Task<bool> HasOwnerQueryAsync(BigInteger pkpTokenId, BlockParameter blockParameter = null)
        {
            var hasOwnerFunction = new HasOwnerFunction();
                hasOwnerFunction.PkpTokenId = pkpTokenId;
            
            return ContractHandler.QueryAsync<HasOwnerFunction, bool>(hasOwnerFunction, blockParameter);
        }

        public Task<bool> HasRoleQueryAsync(HasRoleFunction hasRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        
        public Task<bool> HasRoleQueryAsync(byte[] role, string account, BlockParameter blockParameter = null)
        {
            var hasRoleFunction = new HasRoleFunction();
                hasRoleFunction.Role = role;
                hasRoleFunction.Account = account;
            
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        public Task<bool> IsOwnerQueryAsync(IsOwnerFunction isOwnerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsOwnerFunction, bool>(isOwnerFunction, blockParameter);
        }

        
        public Task<bool> IsOwnerQueryAsync(BigInteger pkpTokenId, BlockParameter blockParameter = null)
        {
            var isOwnerFunction = new IsOwnerFunction();
                isOwnerFunction.PkpTokenId = pkpTokenId;
            
            return ContractHandler.QueryAsync<IsOwnerFunction, bool>(isOwnerFunction, blockParameter);
        }

        public Task<bool> IsRoutedQueryAsync(IsRoutedFunction isRoutedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsRoutedFunction, bool>(isRoutedFunction, blockParameter);
        }

        
        public Task<bool> IsRoutedQueryAsync(BigInteger pkpTokenId, BlockParameter blockParameter = null)
        {
            var isRoutedFunction = new IsRoutedFunction();
                isRoutedFunction.PkpTokenId = pkpTokenId;
            
            return ContractHandler.QueryAsync<IsRoutedFunction, bool>(isRoutedFunction, blockParameter);
        }

        public Task<string> RegisterDomainRequestAsync(RegisterDomainFunction registerDomainFunction)
        {
             return ContractHandler.SendRequestAsync(registerDomainFunction);
        }

        public Task<TransactionReceipt> RegisterDomainRequestAndWaitForReceiptAsync(RegisterDomainFunction registerDomainFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerDomainFunction, cancellationToken);
        }

        public Task<string> RegisterDomainRequestAsync(byte[] userId, byte[] uri, BigInteger pkpTokenId, BigInteger ttl)
        {
            var registerDomainFunction = new RegisterDomainFunction();
                registerDomainFunction.UserId = userId;
                registerDomainFunction.Uri = uri;
                registerDomainFunction.PkpTokenId = pkpTokenId;
                registerDomainFunction.Ttl = ttl;
            
             return ContractHandler.SendRequestAsync(registerDomainFunction);
        }

        public Task<TransactionReceipt> RegisterDomainRequestAndWaitForReceiptAsync(byte[] userId, byte[] uri, BigInteger pkpTokenId, BigInteger ttl, CancellationTokenSource cancellationToken = null)
        {
            var registerDomainFunction = new RegisterDomainFunction();
                registerDomainFunction.UserId = userId;
                registerDomainFunction.Uri = uri;
                registerDomainFunction.PkpTokenId = pkpTokenId;
                registerDomainFunction.Ttl = ttl;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerDomainFunction, cancellationToken);
        }

        public Task<string> RegisterPKPRequestAsync(RegisterPKPFunction registerPKPFunction)
        {
             return ContractHandler.SendRequestAsync(registerPKPFunction);
        }

        public Task<TransactionReceipt> RegisterPKPRequestAndWaitForReceiptAsync(RegisterPKPFunction registerPKPFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerPKPFunction, cancellationToken);
        }

        public Task<string> RegisterPKPRequestAsync(ulong id, BigInteger pkpTokenId)
        {
            var registerPKPFunction = new RegisterPKPFunction();
                registerPKPFunction.Id = id;
                registerPKPFunction.PkpTokenId = pkpTokenId;
            
             return ContractHandler.SendRequestAsync(registerPKPFunction);
        }

        public Task<TransactionReceipt> RegisterPKPRequestAndWaitForReceiptAsync(ulong id, BigInteger pkpTokenId, CancellationTokenSource cancellationToken = null)
        {
            var registerPKPFunction = new RegisterPKPFunction();
                registerPKPFunction.Id = id;
                registerPKPFunction.PkpTokenId = pkpTokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerPKPFunction, cancellationToken);
        }

        public Task<string> RemoveAdminRequestAsync(RemoveAdminFunction removeAdminFunction)
        {
             return ContractHandler.SendRequestAsync(removeAdminFunction);
        }

        public Task<TransactionReceipt> RemoveAdminRequestAndWaitForReceiptAsync(RemoveAdminFunction removeAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAdminFunction, cancellationToken);
        }

        public Task<string> RemoveAdminRequestAsync(string adminBeingRemoved)
        {
            var removeAdminFunction = new RemoveAdminFunction();
                removeAdminFunction.AdminBeingRemoved = adminBeingRemoved;
            
             return ContractHandler.SendRequestAsync(removeAdminFunction);
        }

        public Task<TransactionReceipt> RemoveAdminRequestAndWaitForReceiptAsync(string adminBeingRemoved, CancellationTokenSource cancellationToken = null)
        {
            var removeAdminFunction = new RemoveAdminFunction();
                removeAdminFunction.AdminBeingRemoved = adminBeingRemoved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAdminFunction, cancellationToken);
        }

        public Task<string> RemoveDomainRequestAsync(RemoveDomainFunction removeDomainFunction)
        {
             return ContractHandler.SendRequestAsync(removeDomainFunction);
        }

        public Task<TransactionReceipt> RemoveDomainRequestAndWaitForReceiptAsync(RemoveDomainFunction removeDomainFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeDomainFunction, cancellationToken);
        }

        public Task<string> RemoveDomainRequestAsync(BigInteger pkpTokenId)
        {
            var removeDomainFunction = new RemoveDomainFunction();
                removeDomainFunction.PkpTokenId = pkpTokenId;
            
             return ContractHandler.SendRequestAsync(removeDomainFunction);
        }

        public Task<TransactionReceipt> RemoveDomainRequestAndWaitForReceiptAsync(BigInteger pkpTokenId, CancellationTokenSource cancellationToken = null)
        {
            var removeDomainFunction = new RemoveDomainFunction();
                removeDomainFunction.PkpTokenId = pkpTokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeDomainFunction, cancellationToken);
        }

        public Task<string> RenounceRoleRequestAsync(RenounceRoleFunction renounceRoleFunction)
        {
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(RenounceRoleFunction renounceRoleFunction, CancellationTokenSource cancellationToken = null)
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

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var renounceRoleFunction = new RenounceRoleFunction();
                renounceRoleFunction.Role = role;
                renounceRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceRoleFunction, cancellationToken);
        }

        public Task<string> RevokeDomainRequestAsync(RevokeDomainFunction revokeDomainFunction)
        {
             return ContractHandler.SendRequestAsync(revokeDomainFunction);
        }

        public Task<TransactionReceipt> RevokeDomainRequestAndWaitForReceiptAsync(RevokeDomainFunction revokeDomainFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeDomainFunction, cancellationToken);
        }

        public Task<string> RevokeDomainRequestAsync(BigInteger pkpTokenId)
        {
            var revokeDomainFunction = new RevokeDomainFunction();
                revokeDomainFunction.PkpTokenId = pkpTokenId;
            
             return ContractHandler.SendRequestAsync(revokeDomainFunction);
        }

        public Task<TransactionReceipt> RevokeDomainRequestAndWaitForReceiptAsync(BigInteger pkpTokenId, CancellationTokenSource cancellationToken = null)
        {
            var revokeDomainFunction = new RevokeDomainFunction();
                revokeDomainFunction.PkpTokenId = pkpTokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeDomainFunction, cancellationToken);
        }

        public Task<string> RevokeRoleRequestAsync(RevokeRoleFunction revokeRoleFunction)
        {
             return ContractHandler.SendRequestAsync(revokeRoleFunction);
        }

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(RevokeRoleFunction revokeRoleFunction, CancellationTokenSource cancellationToken = null)
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

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        public Task<string> UpdateDomainRecordRequestAsync(UpdateDomainRecordFunction updateDomainRecordFunction)
        {
             return ContractHandler.SendRequestAsync(updateDomainRecordFunction);
        }

        public Task<TransactionReceipt> UpdateDomainRecordRequestAndWaitForReceiptAsync(UpdateDomainRecordFunction updateDomainRecordFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateDomainRecordFunction, cancellationToken);
        }

        public Task<string> UpdateDomainRecordRequestAsync(BigInteger pkpTokenId, byte[] record)
        {
            var updateDomainRecordFunction = new UpdateDomainRecordFunction();
                updateDomainRecordFunction.PkpTokenId = pkpTokenId;
                updateDomainRecordFunction.Record = record;
            
             return ContractHandler.SendRequestAsync(updateDomainRecordFunction);
        }

        public Task<TransactionReceipt> UpdateDomainRecordRequestAndWaitForReceiptAsync(BigInteger pkpTokenId, byte[] record, CancellationTokenSource cancellationToken = null)
        {
            var updateDomainRecordFunction = new UpdateDomainRecordFunction();
                updateDomainRecordFunction.PkpTokenId = pkpTokenId;
                updateDomainRecordFunction.Record = record;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(updateDomainRecordFunction, cancellationToken);
        }
    }
}
