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
using LitContracts.Multisender.ContractDefinition;

namespace LitContracts.Multisender
{
    public partial class MultisenderService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MultisenderDeployment multisenderDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MultisenderDeployment>().SendRequestAndWaitForReceiptAsync(multisenderDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MultisenderDeployment multisenderDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MultisenderDeployment>().SendRequestAsync(multisenderDeployment);
        }

        public static async Task<MultisenderService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MultisenderDeployment multisenderDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, multisenderDeployment, cancellationTokenSource);
            return new MultisenderService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MultisenderService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public MultisenderService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> SendEthRequestAsync(SendEthFunction sendEthFunction)
        {
             return ContractHandler.SendRequestAsync(sendEthFunction);
        }

        public Task<TransactionReceipt> SendEthRequestAndWaitForReceiptAsync(SendEthFunction sendEthFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sendEthFunction, cancellationToken);
        }

        public Task<string> SendEthRequestAsync(List<string> recipients)
        {
            var sendEthFunction = new SendEthFunction();
                sendEthFunction.Recipients = recipients;
            
             return ContractHandler.SendRequestAsync(sendEthFunction);
        }

        public Task<TransactionReceipt> SendEthRequestAndWaitForReceiptAsync(List<string> recipients, CancellationTokenSource? cancellationToken = null)
        {
            var sendEthFunction = new SendEthFunction();
                sendEthFunction.Recipients = recipients;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sendEthFunction, cancellationToken);
        }

        public Task<string> SendTokensRequestAsync(SendTokensFunction sendTokensFunction)
        {
             return ContractHandler.SendRequestAsync(sendTokensFunction);
        }

        public Task<TransactionReceipt> SendTokensRequestAndWaitForReceiptAsync(SendTokensFunction sendTokensFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sendTokensFunction, cancellationToken);
        }

        public Task<string> SendTokensRequestAsync(List<string> recipients, string tokenContract)
        {
            var sendTokensFunction = new SendTokensFunction();
                sendTokensFunction.Recipients = recipients;
                sendTokensFunction.TokenContract = tokenContract;
            
             return ContractHandler.SendRequestAsync(sendTokensFunction);
        }

        public Task<TransactionReceipt> SendTokensRequestAndWaitForReceiptAsync(List<string> recipients, string tokenContract, CancellationTokenSource? cancellationToken = null)
        {
            var sendTokensFunction = new SendTokensFunction();
                sendTokensFunction.Recipients = recipients;
                sendTokensFunction.TokenContract = tokenContract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(sendTokensFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(TransferOwnershipFunction transferOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(TransferOwnershipFunction transferOwnershipFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> TransferOwnershipRequestAsync(string newOwner)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAsync(transferOwnershipFunction);
        }

        public Task<TransactionReceipt> TransferOwnershipRequestAndWaitForReceiptAsync(string newOwner, CancellationTokenSource? cancellationToken = null)
        {
            var transferOwnershipFunction = new TransferOwnershipFunction();
                transferOwnershipFunction.NewOwner = newOwner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferOwnershipFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<string> WithdrawRequestAsync()
        {
             return ContractHandler.SendRequestAsync<WithdrawFunction>();
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawFunction>(null, cancellationToken);
        }

        public Task<string> WithdrawTokensRequestAsync(WithdrawTokensFunction withdrawTokensFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawTokensFunction);
        }

        public Task<TransactionReceipt> WithdrawTokensRequestAndWaitForReceiptAsync(WithdrawTokensFunction withdrawTokensFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawTokensFunction, cancellationToken);
        }

        public Task<string> WithdrawTokensRequestAsync(string tokenContract)
        {
            var withdrawTokensFunction = new WithdrawTokensFunction();
                withdrawTokensFunction.TokenContract = tokenContract;
            
             return ContractHandler.SendRequestAsync(withdrawTokensFunction);
        }

        public Task<TransactionReceipt> WithdrawTokensRequestAndWaitForReceiptAsync(string tokenContract, CancellationTokenSource? cancellationToken = null)
        {
            var withdrawTokensFunction = new WithdrawTokensFunction();
                withdrawTokensFunction.TokenContract = tokenContract;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawTokensFunction, cancellationToken);
        }
    }
}
