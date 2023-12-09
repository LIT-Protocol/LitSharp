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
using LitContracts.Allowlist.ContractDefinition;

namespace LitContracts.Allowlist
{
    public partial class AllowlistService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, AllowlistDeployment allowlistDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<AllowlistDeployment>().SendRequestAndWaitForReceiptAsync(allowlistDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, AllowlistDeployment allowlistDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<AllowlistDeployment>().SendRequestAsync(allowlistDeployment);
        }

        public static async Task<AllowlistService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, AllowlistDeployment allowlistDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, allowlistDeployment, cancellationTokenSource);
            return new AllowlistService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public AllowlistService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public AllowlistService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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

        public Task<bool> AllowAllQueryAsync(AllowAllFunction allowAllFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowAllFunction, bool>(allowAllFunction, blockParameter);
        }

        
        public Task<bool> AllowAllQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowAllFunction, bool>(null, blockParameter);
        }

        public Task<bool> AllowedItemsQueryAsync(AllowedItemsFunction allowedItemsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllowedItemsFunction, bool>(allowedItemsFunction, blockParameter);
        }

        
        public Task<bool> AllowedItemsQueryAsync(byte[] returnValue1, BlockParameter blockParameter = null)
        {
            var allowedItemsFunction = new AllowedItemsFunction();
                allowedItemsFunction.ReturnValue1 = returnValue1;
            
            return ContractHandler.QueryAsync<AllowedItemsFunction, bool>(allowedItemsFunction, blockParameter);
        }

        public Task<bool> IsAllowedQueryAsync(IsAllowedFunction isAllowedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsAllowedFunction, bool>(isAllowedFunction, blockParameter);
        }

        
        public Task<bool> IsAllowedQueryAsync(byte[] key, BlockParameter blockParameter = null)
        {
            var isAllowedFunction = new IsAllowedFunction();
                isAllowedFunction.Key = key;
            
            return ContractHandler.QueryAsync<IsAllowedFunction, bool>(isAllowedFunction, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> RemoveAdminRequestAsync(RemoveAdminFunction removeAdminFunction)
        {
             return ContractHandler.SendRequestAsync(removeAdminFunction);
        }

        public Task<TransactionReceipt> RemoveAdminRequestAndWaitForReceiptAsync(RemoveAdminFunction removeAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAdminFunction, cancellationToken);
        }

        public Task<string> RemoveAdminRequestAsync(string newAdmin)
        {
            var removeAdminFunction = new RemoveAdminFunction();
                removeAdminFunction.NewAdmin = newAdmin;
            
             return ContractHandler.SendRequestAsync(removeAdminFunction);
        }

        public Task<TransactionReceipt> RemoveAdminRequestAndWaitForReceiptAsync(string newAdmin, CancellationTokenSource cancellationToken = null)
        {
            var removeAdminFunction = new RemoveAdminFunction();
                removeAdminFunction.NewAdmin = newAdmin;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAdminFunction, cancellationToken);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> SetAllowAllRequestAsync(SetAllowAllFunction setAllowAllFunction)
        {
             return ContractHandler.SendRequestAsync(setAllowAllFunction);
        }

        public Task<TransactionReceipt> SetAllowAllRequestAndWaitForReceiptAsync(SetAllowAllFunction setAllowAllFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAllowAllFunction, cancellationToken);
        }

        public Task<string> SetAllowAllRequestAsync(bool allowAll)
        {
            var setAllowAllFunction = new SetAllowAllFunction();
                setAllowAllFunction.AllowAll = allowAll;
            
             return ContractHandler.SendRequestAsync(setAllowAllFunction);
        }

        public Task<TransactionReceipt> SetAllowAllRequestAndWaitForReceiptAsync(bool allowAll, CancellationTokenSource cancellationToken = null)
        {
            var setAllowAllFunction = new SetAllowAllFunction();
                setAllowAllFunction.AllowAll = allowAll;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAllowAllFunction, cancellationToken);
        }

        public Task<string> SetAllowedRequestAsync(SetAllowedFunction setAllowedFunction)
        {
             return ContractHandler.SendRequestAsync(setAllowedFunction);
        }

        public Task<TransactionReceipt> SetAllowedRequestAndWaitForReceiptAsync(SetAllowedFunction setAllowedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAllowedFunction, cancellationToken);
        }

        public Task<string> SetAllowedRequestAsync(byte[] key)
        {
            var setAllowedFunction = new SetAllowedFunction();
                setAllowedFunction.Key = key;
            
             return ContractHandler.SendRequestAsync(setAllowedFunction);
        }

        public Task<TransactionReceipt> SetAllowedRequestAndWaitForReceiptAsync(byte[] key, CancellationTokenSource cancellationToken = null)
        {
            var setAllowedFunction = new SetAllowedFunction();
                setAllowedFunction.Key = key;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAllowedFunction, cancellationToken);
        }

        public Task<string> SetNotAllowedRequestAsync(SetNotAllowedFunction setNotAllowedFunction)
        {
             return ContractHandler.SendRequestAsync(setNotAllowedFunction);
        }

        public Task<TransactionReceipt> SetNotAllowedRequestAndWaitForReceiptAsync(SetNotAllowedFunction setNotAllowedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNotAllowedFunction, cancellationToken);
        }

        public Task<string> SetNotAllowedRequestAsync(byte[] key)
        {
            var setNotAllowedFunction = new SetNotAllowedFunction();
                setNotAllowedFunction.Key = key;
            
             return ContractHandler.SendRequestAsync(setNotAllowedFunction);
        }

        public Task<TransactionReceipt> SetNotAllowedRequestAndWaitForReceiptAsync(byte[] key, CancellationTokenSource cancellationToken = null)
        {
            var setNotAllowedFunction = new SetNotAllowedFunction();
                setNotAllowedFunction.Key = key;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setNotAllowedFunction, cancellationToken);
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
    }
}
