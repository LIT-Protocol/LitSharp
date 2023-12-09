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
using LitContracts.PKPPermissions.ContractDefinition;

namespace LitContracts.PKPPermissions
{
    public partial class PKPPermissionsService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PKPPermissionsDeployment pKPPermissionsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PKPPermissionsDeployment>().SendRequestAndWaitForReceiptAsync(pKPPermissionsDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PKPPermissionsDeployment pKPPermissionsDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PKPPermissionsDeployment>().SendRequestAsync(pKPPermissionsDeployment);
        }

        public static async Task<PKPPermissionsService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PKPPermissionsDeployment pKPPermissionsDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, pKPPermissionsDeployment, cancellationTokenSource);
            return new PKPPermissionsService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PKPPermissionsService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public PKPPermissionsService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> DiamondCutRequestAsync(DiamondCutFunction diamondCutFunction)
        {
             return ContractHandler.SendRequestAsync(diamondCutFunction);
        }

        public Task<TransactionReceipt> DiamondCutRequestAndWaitForReceiptAsync(DiamondCutFunction diamondCutFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(diamondCutFunction, cancellationToken);
        }

        public Task<string> DiamondCutRequestAsync(List<FacetCut> diamondCut, string init, byte[] calldata)
        {
            var diamondCutFunction = new DiamondCutFunction();
                diamondCutFunction.DiamondCut = diamondCut;
                diamondCutFunction.Init = init;
                diamondCutFunction.Calldata = calldata;
            
             return ContractHandler.SendRequestAsync(diamondCutFunction);
        }

        public Task<TransactionReceipt> DiamondCutRequestAndWaitForReceiptAsync(List<FacetCut> diamondCut, string init, byte[] calldata, CancellationTokenSource cancellationToken = null)
        {
            var diamondCutFunction = new DiamondCutFunction();
                diamondCutFunction.DiamondCut = diamondCut;
                diamondCutFunction.Init = init;
                diamondCutFunction.Calldata = calldata;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(diamondCutFunction, cancellationToken);
        }

        public Task<string> FacetAddressQueryAsync(FacetAddressFunction facetAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FacetAddressFunction, string>(facetAddressFunction, blockParameter);
        }

        
        public Task<string> FacetAddressQueryAsync(byte[] functionSelector, BlockParameter blockParameter = null)
        {
            var facetAddressFunction = new FacetAddressFunction();
                facetAddressFunction.FunctionSelector = functionSelector;
            
            return ContractHandler.QueryAsync<FacetAddressFunction, string>(facetAddressFunction, blockParameter);
        }

        public Task<List<string>> FacetAddressesQueryAsync(FacetAddressesFunction facetAddressesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FacetAddressesFunction, List<string>>(facetAddressesFunction, blockParameter);
        }

        
        public Task<List<string>> FacetAddressesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FacetAddressesFunction, List<string>>(null, blockParameter);
        }

        public Task<List<byte[]>> FacetFunctionSelectorsQueryAsync(FacetFunctionSelectorsFunction facetFunctionSelectorsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FacetFunctionSelectorsFunction, List<byte[]>>(facetFunctionSelectorsFunction, blockParameter);
        }

        
        public Task<List<byte[]>> FacetFunctionSelectorsQueryAsync(string facet, BlockParameter blockParameter = null)
        {
            var facetFunctionSelectorsFunction = new FacetFunctionSelectorsFunction();
                facetFunctionSelectorsFunction.Facet = facet;
            
            return ContractHandler.QueryAsync<FacetFunctionSelectorsFunction, List<byte[]>>(facetFunctionSelectorsFunction, blockParameter);
        }

        public Task<FacetsOutputDTO> FacetsQueryAsync(FacetsFunction facetsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<FacetsFunction, FacetsOutputDTO>(facetsFunction, blockParameter);
        }

        public Task<FacetsOutputDTO> FacetsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<FacetsFunction, FacetsOutputDTO>(null, blockParameter);
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

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> AddPermittedActionRequestAsync(AddPermittedActionFunction addPermittedActionFunction)
        {
             return ContractHandler.SendRequestAsync(addPermittedActionFunction);
        }

        public Task<TransactionReceipt> AddPermittedActionRequestAndWaitForReceiptAsync(AddPermittedActionFunction addPermittedActionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedActionFunction, cancellationToken);
        }

        public Task<string> AddPermittedActionRequestAsync(BigInteger tokenId, byte[] ipfsCID, List<BigInteger> scopes)
        {
            var addPermittedActionFunction = new AddPermittedActionFunction();
                addPermittedActionFunction.TokenId = tokenId;
                addPermittedActionFunction.IpfsCID = ipfsCID;
                addPermittedActionFunction.Scopes = scopes;
            
             return ContractHandler.SendRequestAsync(addPermittedActionFunction);
        }

        public Task<TransactionReceipt> AddPermittedActionRequestAndWaitForReceiptAsync(BigInteger tokenId, byte[] ipfsCID, List<BigInteger> scopes, CancellationTokenSource cancellationToken = null)
        {
            var addPermittedActionFunction = new AddPermittedActionFunction();
                addPermittedActionFunction.TokenId = tokenId;
                addPermittedActionFunction.IpfsCID = ipfsCID;
                addPermittedActionFunction.Scopes = scopes;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedActionFunction, cancellationToken);
        }

        public Task<string> AddPermittedAddressRequestAsync(AddPermittedAddressFunction addPermittedAddressFunction)
        {
             return ContractHandler.SendRequestAsync(addPermittedAddressFunction);
        }

        public Task<TransactionReceipt> AddPermittedAddressRequestAndWaitForReceiptAsync(AddPermittedAddressFunction addPermittedAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedAddressFunction, cancellationToken);
        }

        public Task<string> AddPermittedAddressRequestAsync(BigInteger tokenId, string user, List<BigInteger> scopes)
        {
            var addPermittedAddressFunction = new AddPermittedAddressFunction();
                addPermittedAddressFunction.TokenId = tokenId;
                addPermittedAddressFunction.User = user;
                addPermittedAddressFunction.Scopes = scopes;
            
             return ContractHandler.SendRequestAsync(addPermittedAddressFunction);
        }

        public Task<TransactionReceipt> AddPermittedAddressRequestAndWaitForReceiptAsync(BigInteger tokenId, string user, List<BigInteger> scopes, CancellationTokenSource cancellationToken = null)
        {
            var addPermittedAddressFunction = new AddPermittedAddressFunction();
                addPermittedAddressFunction.TokenId = tokenId;
                addPermittedAddressFunction.User = user;
                addPermittedAddressFunction.Scopes = scopes;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedAddressFunction, cancellationToken);
        }

        public Task<string> AddPermittedAuthMethodRequestAsync(AddPermittedAuthMethodFunction addPermittedAuthMethodFunction)
        {
             return ContractHandler.SendRequestAsync(addPermittedAuthMethodFunction);
        }

        public Task<TransactionReceipt> AddPermittedAuthMethodRequestAndWaitForReceiptAsync(AddPermittedAuthMethodFunction addPermittedAuthMethodFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedAuthMethodFunction, cancellationToken);
        }

        public Task<string> AddPermittedAuthMethodRequestAsync(BigInteger tokenId, AuthMethod authMethod, List<BigInteger> scopes)
        {
            var addPermittedAuthMethodFunction = new AddPermittedAuthMethodFunction();
                addPermittedAuthMethodFunction.TokenId = tokenId;
                addPermittedAuthMethodFunction.AuthMethod = authMethod;
                addPermittedAuthMethodFunction.Scopes = scopes;
            
             return ContractHandler.SendRequestAsync(addPermittedAuthMethodFunction);
        }

        public Task<TransactionReceipt> AddPermittedAuthMethodRequestAndWaitForReceiptAsync(BigInteger tokenId, AuthMethod authMethod, List<BigInteger> scopes, CancellationTokenSource cancellationToken = null)
        {
            var addPermittedAuthMethodFunction = new AddPermittedAuthMethodFunction();
                addPermittedAuthMethodFunction.TokenId = tokenId;
                addPermittedAuthMethodFunction.AuthMethod = authMethod;
                addPermittedAuthMethodFunction.Scopes = scopes;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedAuthMethodFunction, cancellationToken);
        }

        public Task<string> AddPermittedAuthMethodScopeRequestAsync(AddPermittedAuthMethodScopeFunction addPermittedAuthMethodScopeFunction)
        {
             return ContractHandler.SendRequestAsync(addPermittedAuthMethodScopeFunction);
        }

        public Task<TransactionReceipt> AddPermittedAuthMethodScopeRequestAndWaitForReceiptAsync(AddPermittedAuthMethodScopeFunction addPermittedAuthMethodScopeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedAuthMethodScopeFunction, cancellationToken);
        }

        public Task<string> AddPermittedAuthMethodScopeRequestAsync(BigInteger tokenId, BigInteger authMethodType, byte[] id, BigInteger scopeId)
        {
            var addPermittedAuthMethodScopeFunction = new AddPermittedAuthMethodScopeFunction();
                addPermittedAuthMethodScopeFunction.TokenId = tokenId;
                addPermittedAuthMethodScopeFunction.AuthMethodType = authMethodType;
                addPermittedAuthMethodScopeFunction.Id = id;
                addPermittedAuthMethodScopeFunction.ScopeId = scopeId;
            
             return ContractHandler.SendRequestAsync(addPermittedAuthMethodScopeFunction);
        }

        public Task<TransactionReceipt> AddPermittedAuthMethodScopeRequestAndWaitForReceiptAsync(BigInteger tokenId, BigInteger authMethodType, byte[] id, BigInteger scopeId, CancellationTokenSource cancellationToken = null)
        {
            var addPermittedAuthMethodScopeFunction = new AddPermittedAuthMethodScopeFunction();
                addPermittedAuthMethodScopeFunction.TokenId = tokenId;
                addPermittedAuthMethodScopeFunction.AuthMethodType = authMethodType;
                addPermittedAuthMethodScopeFunction.Id = id;
                addPermittedAuthMethodScopeFunction.ScopeId = scopeId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedAuthMethodScopeFunction, cancellationToken);
        }

        public Task<string> BatchAddRemoveAuthMethodsRequestAsync(BatchAddRemoveAuthMethodsFunction batchAddRemoveAuthMethodsFunction)
        {
             return ContractHandler.SendRequestAsync(batchAddRemoveAuthMethodsFunction);
        }

        public Task<TransactionReceipt> BatchAddRemoveAuthMethodsRequestAndWaitForReceiptAsync(BatchAddRemoveAuthMethodsFunction batchAddRemoveAuthMethodsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(batchAddRemoveAuthMethodsFunction, cancellationToken);
        }

        public Task<string> BatchAddRemoveAuthMethodsRequestAsync(BigInteger tokenId, List<BigInteger> permittedAuthMethodTypesToAdd, List<byte[]> permittedAuthMethodIdsToAdd, List<byte[]> permittedAuthMethodPubkeysToAdd, List<List<BigInteger>> permittedAuthMethodScopesToAdd, List<BigInteger> permittedAuthMethodTypesToRemove, List<byte[]> permittedAuthMethodIdsToRemove)
        {
            var batchAddRemoveAuthMethodsFunction = new BatchAddRemoveAuthMethodsFunction();
                batchAddRemoveAuthMethodsFunction.TokenId = tokenId;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodTypesToAdd = permittedAuthMethodTypesToAdd;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodIdsToAdd = permittedAuthMethodIdsToAdd;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodPubkeysToAdd = permittedAuthMethodPubkeysToAdd;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodScopesToAdd = permittedAuthMethodScopesToAdd;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodTypesToRemove = permittedAuthMethodTypesToRemove;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodIdsToRemove = permittedAuthMethodIdsToRemove;
            
             return ContractHandler.SendRequestAsync(batchAddRemoveAuthMethodsFunction);
        }

        public Task<TransactionReceipt> BatchAddRemoveAuthMethodsRequestAndWaitForReceiptAsync(BigInteger tokenId, List<BigInteger> permittedAuthMethodTypesToAdd, List<byte[]> permittedAuthMethodIdsToAdd, List<byte[]> permittedAuthMethodPubkeysToAdd, List<List<BigInteger>> permittedAuthMethodScopesToAdd, List<BigInteger> permittedAuthMethodTypesToRemove, List<byte[]> permittedAuthMethodIdsToRemove, CancellationTokenSource cancellationToken = null)
        {
            var batchAddRemoveAuthMethodsFunction = new BatchAddRemoveAuthMethodsFunction();
                batchAddRemoveAuthMethodsFunction.TokenId = tokenId;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodTypesToAdd = permittedAuthMethodTypesToAdd;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodIdsToAdd = permittedAuthMethodIdsToAdd;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodPubkeysToAdd = permittedAuthMethodPubkeysToAdd;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodScopesToAdd = permittedAuthMethodScopesToAdd;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodTypesToRemove = permittedAuthMethodTypesToRemove;
                batchAddRemoveAuthMethodsFunction.PermittedAuthMethodIdsToRemove = permittedAuthMethodIdsToRemove;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(batchAddRemoveAuthMethodsFunction, cancellationToken);
        }

        public Task<BigInteger> GetAuthMethodIdQueryAsync(GetAuthMethodIdFunction getAuthMethodIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetAuthMethodIdFunction, BigInteger>(getAuthMethodIdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetAuthMethodIdQueryAsync(BigInteger authMethodType, byte[] id, BlockParameter blockParameter = null)
        {
            var getAuthMethodIdFunction = new GetAuthMethodIdFunction();
                getAuthMethodIdFunction.AuthMethodType = authMethodType;
                getAuthMethodIdFunction.Id = id;
            
            return ContractHandler.QueryAsync<GetAuthMethodIdFunction, BigInteger>(getAuthMethodIdFunction, blockParameter);
        }

        public Task<string> GetEthAddressQueryAsync(GetEthAddressFunction getEthAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetEthAddressFunction, string>(getEthAddressFunction, blockParameter);
        }

        
        public Task<string> GetEthAddressQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getEthAddressFunction = new GetEthAddressFunction();
                getEthAddressFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetEthAddressFunction, string>(getEthAddressFunction, blockParameter);
        }

        public Task<List<byte[]>> GetPermittedActionsQueryAsync(GetPermittedActionsFunction getPermittedActionsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPermittedActionsFunction, List<byte[]>>(getPermittedActionsFunction, blockParameter);
        }

        
        public Task<List<byte[]>> GetPermittedActionsQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getPermittedActionsFunction = new GetPermittedActionsFunction();
                getPermittedActionsFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetPermittedActionsFunction, List<byte[]>>(getPermittedActionsFunction, blockParameter);
        }

        public Task<List<string>> GetPermittedAddressesQueryAsync(GetPermittedAddressesFunction getPermittedAddressesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPermittedAddressesFunction, List<string>>(getPermittedAddressesFunction, blockParameter);
        }

        
        public Task<List<string>> GetPermittedAddressesQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getPermittedAddressesFunction = new GetPermittedAddressesFunction();
                getPermittedAddressesFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetPermittedAddressesFunction, List<string>>(getPermittedAddressesFunction, blockParameter);
        }

        public Task<List<bool>> GetPermittedAuthMethodScopesQueryAsync(GetPermittedAuthMethodScopesFunction getPermittedAuthMethodScopesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPermittedAuthMethodScopesFunction, List<bool>>(getPermittedAuthMethodScopesFunction, blockParameter);
        }

        
        public Task<List<bool>> GetPermittedAuthMethodScopesQueryAsync(BigInteger tokenId, BigInteger authMethodType, byte[] id, BigInteger maxScopeId, BlockParameter blockParameter = null)
        {
            var getPermittedAuthMethodScopesFunction = new GetPermittedAuthMethodScopesFunction();
                getPermittedAuthMethodScopesFunction.TokenId = tokenId;
                getPermittedAuthMethodScopesFunction.AuthMethodType = authMethodType;
                getPermittedAuthMethodScopesFunction.Id = id;
                getPermittedAuthMethodScopesFunction.MaxScopeId = maxScopeId;
            
            return ContractHandler.QueryAsync<GetPermittedAuthMethodScopesFunction, List<bool>>(getPermittedAuthMethodScopesFunction, blockParameter);
        }

        public Task<GetPermittedAuthMethodsOutputDTO> GetPermittedAuthMethodsQueryAsync(GetPermittedAuthMethodsFunction getPermittedAuthMethodsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPermittedAuthMethodsFunction, GetPermittedAuthMethodsOutputDTO>(getPermittedAuthMethodsFunction, blockParameter);
        }

        public Task<GetPermittedAuthMethodsOutputDTO> GetPermittedAuthMethodsQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getPermittedAuthMethodsFunction = new GetPermittedAuthMethodsFunction();
                getPermittedAuthMethodsFunction.TokenId = tokenId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetPermittedAuthMethodsFunction, GetPermittedAuthMethodsOutputDTO>(getPermittedAuthMethodsFunction, blockParameter);
        }

        public Task<string> GetPkpNftAddressQueryAsync(GetPkpNftAddressFunction getPkpNftAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpNftAddressFunction, string>(getPkpNftAddressFunction, blockParameter);
        }

        
        public Task<string> GetPkpNftAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpNftAddressFunction, string>(null, blockParameter);
        }

        public Task<byte[]> GetPubkeyQueryAsync(GetPubkeyFunction getPubkeyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPubkeyFunction, byte[]>(getPubkeyFunction, blockParameter);
        }

        
        public Task<byte[]> GetPubkeyQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getPubkeyFunction = new GetPubkeyFunction();
                getPubkeyFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetPubkeyFunction, byte[]>(getPubkeyFunction, blockParameter);
        }

        public Task<string> GetRouterAddressQueryAsync(GetRouterAddressFunction getRouterAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRouterAddressFunction, string>(getRouterAddressFunction, blockParameter);
        }

        
        public Task<string> GetRouterAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRouterAddressFunction, string>(null, blockParameter);
        }

        public Task<List<BigInteger>> GetTokenIdsForAuthMethodQueryAsync(GetTokenIdsForAuthMethodFunction getTokenIdsForAuthMethodFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTokenIdsForAuthMethodFunction, List<BigInteger>>(getTokenIdsForAuthMethodFunction, blockParameter);
        }

        
        public Task<List<BigInteger>> GetTokenIdsForAuthMethodQueryAsync(BigInteger authMethodType, byte[] id, BlockParameter blockParameter = null)
        {
            var getTokenIdsForAuthMethodFunction = new GetTokenIdsForAuthMethodFunction();
                getTokenIdsForAuthMethodFunction.AuthMethodType = authMethodType;
                getTokenIdsForAuthMethodFunction.Id = id;
            
            return ContractHandler.QueryAsync<GetTokenIdsForAuthMethodFunction, List<BigInteger>>(getTokenIdsForAuthMethodFunction, blockParameter);
        }

        public Task<byte[]> GetUserPubkeyForAuthMethodQueryAsync(GetUserPubkeyForAuthMethodFunction getUserPubkeyForAuthMethodFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetUserPubkeyForAuthMethodFunction, byte[]>(getUserPubkeyForAuthMethodFunction, blockParameter);
        }

        
        public Task<byte[]> GetUserPubkeyForAuthMethodQueryAsync(BigInteger authMethodType, byte[] id, BlockParameter blockParameter = null)
        {
            var getUserPubkeyForAuthMethodFunction = new GetUserPubkeyForAuthMethodFunction();
                getUserPubkeyForAuthMethodFunction.AuthMethodType = authMethodType;
                getUserPubkeyForAuthMethodFunction.Id = id;
            
            return ContractHandler.QueryAsync<GetUserPubkeyForAuthMethodFunction, byte[]>(getUserPubkeyForAuthMethodFunction, blockParameter);
        }

        public Task<bool> IsPermittedActionQueryAsync(IsPermittedActionFunction isPermittedActionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsPermittedActionFunction, bool>(isPermittedActionFunction, blockParameter);
        }

        
        public Task<bool> IsPermittedActionQueryAsync(BigInteger tokenId, byte[] ipfsCID, BlockParameter blockParameter = null)
        {
            var isPermittedActionFunction = new IsPermittedActionFunction();
                isPermittedActionFunction.TokenId = tokenId;
                isPermittedActionFunction.IpfsCID = ipfsCID;
            
            return ContractHandler.QueryAsync<IsPermittedActionFunction, bool>(isPermittedActionFunction, blockParameter);
        }

        public Task<bool> IsPermittedAddressQueryAsync(IsPermittedAddressFunction isPermittedAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsPermittedAddressFunction, bool>(isPermittedAddressFunction, blockParameter);
        }

        
        public Task<bool> IsPermittedAddressQueryAsync(BigInteger tokenId, string user, BlockParameter blockParameter = null)
        {
            var isPermittedAddressFunction = new IsPermittedAddressFunction();
                isPermittedAddressFunction.TokenId = tokenId;
                isPermittedAddressFunction.User = user;
            
            return ContractHandler.QueryAsync<IsPermittedAddressFunction, bool>(isPermittedAddressFunction, blockParameter);
        }

        public Task<bool> IsPermittedAuthMethodQueryAsync(IsPermittedAuthMethodFunction isPermittedAuthMethodFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsPermittedAuthMethodFunction, bool>(isPermittedAuthMethodFunction, blockParameter);
        }

        
        public Task<bool> IsPermittedAuthMethodQueryAsync(BigInteger tokenId, BigInteger authMethodType, byte[] id, BlockParameter blockParameter = null)
        {
            var isPermittedAuthMethodFunction = new IsPermittedAuthMethodFunction();
                isPermittedAuthMethodFunction.TokenId = tokenId;
                isPermittedAuthMethodFunction.AuthMethodType = authMethodType;
                isPermittedAuthMethodFunction.Id = id;
            
            return ContractHandler.QueryAsync<IsPermittedAuthMethodFunction, bool>(isPermittedAuthMethodFunction, blockParameter);
        }

        public Task<bool> IsPermittedAuthMethodScopePresentQueryAsync(IsPermittedAuthMethodScopePresentFunction isPermittedAuthMethodScopePresentFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsPermittedAuthMethodScopePresentFunction, bool>(isPermittedAuthMethodScopePresentFunction, blockParameter);
        }

        
        public Task<bool> IsPermittedAuthMethodScopePresentQueryAsync(BigInteger tokenId, BigInteger authMethodType, byte[] id, BigInteger scopeId, BlockParameter blockParameter = null)
        {
            var isPermittedAuthMethodScopePresentFunction = new IsPermittedAuthMethodScopePresentFunction();
                isPermittedAuthMethodScopePresentFunction.TokenId = tokenId;
                isPermittedAuthMethodScopePresentFunction.AuthMethodType = authMethodType;
                isPermittedAuthMethodScopePresentFunction.Id = id;
                isPermittedAuthMethodScopePresentFunction.ScopeId = scopeId;
            
            return ContractHandler.QueryAsync<IsPermittedAuthMethodScopePresentFunction, bool>(isPermittedAuthMethodScopePresentFunction, blockParameter);
        }

        public Task<string> RemovePermittedActionRequestAsync(RemovePermittedActionFunction removePermittedActionFunction)
        {
             return ContractHandler.SendRequestAsync(removePermittedActionFunction);
        }

        public Task<TransactionReceipt> RemovePermittedActionRequestAndWaitForReceiptAsync(RemovePermittedActionFunction removePermittedActionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedActionFunction, cancellationToken);
        }

        public Task<string> RemovePermittedActionRequestAsync(BigInteger tokenId, byte[] ipfsCID)
        {
            var removePermittedActionFunction = new RemovePermittedActionFunction();
                removePermittedActionFunction.TokenId = tokenId;
                removePermittedActionFunction.IpfsCID = ipfsCID;
            
             return ContractHandler.SendRequestAsync(removePermittedActionFunction);
        }

        public Task<TransactionReceipt> RemovePermittedActionRequestAndWaitForReceiptAsync(BigInteger tokenId, byte[] ipfsCID, CancellationTokenSource cancellationToken = null)
        {
            var removePermittedActionFunction = new RemovePermittedActionFunction();
                removePermittedActionFunction.TokenId = tokenId;
                removePermittedActionFunction.IpfsCID = ipfsCID;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedActionFunction, cancellationToken);
        }

        public Task<string> RemovePermittedAddressRequestAsync(RemovePermittedAddressFunction removePermittedAddressFunction)
        {
             return ContractHandler.SendRequestAsync(removePermittedAddressFunction);
        }

        public Task<TransactionReceipt> RemovePermittedAddressRequestAndWaitForReceiptAsync(RemovePermittedAddressFunction removePermittedAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedAddressFunction, cancellationToken);
        }

        public Task<string> RemovePermittedAddressRequestAsync(BigInteger tokenId, string user)
        {
            var removePermittedAddressFunction = new RemovePermittedAddressFunction();
                removePermittedAddressFunction.TokenId = tokenId;
                removePermittedAddressFunction.User = user;
            
             return ContractHandler.SendRequestAsync(removePermittedAddressFunction);
        }

        public Task<TransactionReceipt> RemovePermittedAddressRequestAndWaitForReceiptAsync(BigInteger tokenId, string user, CancellationTokenSource cancellationToken = null)
        {
            var removePermittedAddressFunction = new RemovePermittedAddressFunction();
                removePermittedAddressFunction.TokenId = tokenId;
                removePermittedAddressFunction.User = user;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedAddressFunction, cancellationToken);
        }

        public Task<string> RemovePermittedAuthMethodRequestAsync(RemovePermittedAuthMethodFunction removePermittedAuthMethodFunction)
        {
             return ContractHandler.SendRequestAsync(removePermittedAuthMethodFunction);
        }

        public Task<TransactionReceipt> RemovePermittedAuthMethodRequestAndWaitForReceiptAsync(RemovePermittedAuthMethodFunction removePermittedAuthMethodFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedAuthMethodFunction, cancellationToken);
        }

        public Task<string> RemovePermittedAuthMethodRequestAsync(BigInteger tokenId, BigInteger authMethodType, byte[] id)
        {
            var removePermittedAuthMethodFunction = new RemovePermittedAuthMethodFunction();
                removePermittedAuthMethodFunction.TokenId = tokenId;
                removePermittedAuthMethodFunction.AuthMethodType = authMethodType;
                removePermittedAuthMethodFunction.Id = id;
            
             return ContractHandler.SendRequestAsync(removePermittedAuthMethodFunction);
        }

        public Task<TransactionReceipt> RemovePermittedAuthMethodRequestAndWaitForReceiptAsync(BigInteger tokenId, BigInteger authMethodType, byte[] id, CancellationTokenSource cancellationToken = null)
        {
            var removePermittedAuthMethodFunction = new RemovePermittedAuthMethodFunction();
                removePermittedAuthMethodFunction.TokenId = tokenId;
                removePermittedAuthMethodFunction.AuthMethodType = authMethodType;
                removePermittedAuthMethodFunction.Id = id;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedAuthMethodFunction, cancellationToken);
        }

        public Task<string> RemovePermittedAuthMethodScopeRequestAsync(RemovePermittedAuthMethodScopeFunction removePermittedAuthMethodScopeFunction)
        {
             return ContractHandler.SendRequestAsync(removePermittedAuthMethodScopeFunction);
        }

        public Task<TransactionReceipt> RemovePermittedAuthMethodScopeRequestAndWaitForReceiptAsync(RemovePermittedAuthMethodScopeFunction removePermittedAuthMethodScopeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedAuthMethodScopeFunction, cancellationToken);
        }

        public Task<string> RemovePermittedAuthMethodScopeRequestAsync(BigInteger tokenId, BigInteger authMethodType, byte[] id, BigInteger scopeId)
        {
            var removePermittedAuthMethodScopeFunction = new RemovePermittedAuthMethodScopeFunction();
                removePermittedAuthMethodScopeFunction.TokenId = tokenId;
                removePermittedAuthMethodScopeFunction.AuthMethodType = authMethodType;
                removePermittedAuthMethodScopeFunction.Id = id;
                removePermittedAuthMethodScopeFunction.ScopeId = scopeId;
            
             return ContractHandler.SendRequestAsync(removePermittedAuthMethodScopeFunction);
        }

        public Task<TransactionReceipt> RemovePermittedAuthMethodScopeRequestAndWaitForReceiptAsync(BigInteger tokenId, BigInteger authMethodType, byte[] id, BigInteger scopeId, CancellationTokenSource cancellationToken = null)
        {
            var removePermittedAuthMethodScopeFunction = new RemovePermittedAuthMethodScopeFunction();
                removePermittedAuthMethodScopeFunction.TokenId = tokenId;
                removePermittedAuthMethodScopeFunction.AuthMethodType = authMethodType;
                removePermittedAuthMethodScopeFunction.Id = id;
                removePermittedAuthMethodScopeFunction.ScopeId = scopeId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedAuthMethodScopeFunction, cancellationToken);
        }

        public Task<string> SetContractResolverRequestAsync(SetContractResolverFunction setContractResolverFunction)
        {
             return ContractHandler.SendRequestAsync(setContractResolverFunction);
        }

        public Task<TransactionReceipt> SetContractResolverRequestAndWaitForReceiptAsync(SetContractResolverFunction setContractResolverFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractResolverFunction, cancellationToken);
        }

        public Task<string> SetContractResolverRequestAsync(string newResolverAddress)
        {
            var setContractResolverFunction = new SetContractResolverFunction();
                setContractResolverFunction.NewResolverAddress = newResolverAddress;
            
             return ContractHandler.SendRequestAsync(setContractResolverFunction);
        }

        public Task<TransactionReceipt> SetContractResolverRequestAndWaitForReceiptAsync(string newResolverAddress, CancellationTokenSource cancellationToken = null)
        {
            var setContractResolverFunction = new SetContractResolverFunction();
                setContractResolverFunction.NewResolverAddress = newResolverAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractResolverFunction, cancellationToken);
        }

        public Task<string> SetRootHashRequestAsync(SetRootHashFunction setRootHashFunction)
        {
             return ContractHandler.SendRequestAsync(setRootHashFunction);
        }

        public Task<TransactionReceipt> SetRootHashRequestAndWaitForReceiptAsync(SetRootHashFunction setRootHashFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRootHashFunction, cancellationToken);
        }

        public Task<string> SetRootHashRequestAsync(BigInteger tokenId, BigInteger group, byte[] root)
        {
            var setRootHashFunction = new SetRootHashFunction();
                setRootHashFunction.TokenId = tokenId;
                setRootHashFunction.Group = group;
                setRootHashFunction.Root = root;
            
             return ContractHandler.SendRequestAsync(setRootHashFunction);
        }

        public Task<TransactionReceipt> SetRootHashRequestAndWaitForReceiptAsync(BigInteger tokenId, BigInteger group, byte[] root, CancellationTokenSource cancellationToken = null)
        {
            var setRootHashFunction = new SetRootHashFunction();
                setRootHashFunction.TokenId = tokenId;
                setRootHashFunction.Group = group;
                setRootHashFunction.Root = root;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRootHashFunction, cancellationToken);
        }

        public Task<bool> VerifyStateQueryAsync(VerifyStateFunction verifyStateFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VerifyStateFunction, bool>(verifyStateFunction, blockParameter);
        }

        
        public Task<bool> VerifyStateQueryAsync(BigInteger tokenId, BigInteger group, List<byte[]> proof, byte[] leaf, BlockParameter blockParameter = null)
        {
            var verifyStateFunction = new VerifyStateFunction();
                verifyStateFunction.TokenId = tokenId;
                verifyStateFunction.Group = group;
                verifyStateFunction.Proof = proof;
                verifyStateFunction.Leaf = leaf;
            
            return ContractHandler.QueryAsync<VerifyStateFunction, bool>(verifyStateFunction, blockParameter);
        }

        public Task<bool> VerifyStatesQueryAsync(VerifyStatesFunction verifyStatesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<VerifyStatesFunction, bool>(verifyStatesFunction, blockParameter);
        }

        
        public Task<bool> VerifyStatesQueryAsync(BigInteger tokenId, BigInteger group, List<byte[]> proof, List<bool> proofFlags, List<byte[]> leaves, BlockParameter blockParameter = null)
        {
            var verifyStatesFunction = new VerifyStatesFunction();
                verifyStatesFunction.TokenId = tokenId;
                verifyStatesFunction.Group = group;
                verifyStatesFunction.Proof = proof;
                verifyStatesFunction.ProofFlags = proofFlags;
                verifyStatesFunction.Leaves = leaves;
            
            return ContractHandler.QueryAsync<VerifyStatesFunction, bool>(verifyStatesFunction, blockParameter);
        }
    }
}
