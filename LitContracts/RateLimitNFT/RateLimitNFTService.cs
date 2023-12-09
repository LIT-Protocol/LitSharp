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
using LitContracts.RateLimitNFT.ContractDefinition;

namespace LitContracts.RateLimitNFT
{
    public partial class RateLimitNFTService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, RateLimitNFTDeployment rateLimitNFTDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<RateLimitNFTDeployment>().SendRequestAndWaitForReceiptAsync(rateLimitNFTDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, RateLimitNFTDeployment rateLimitNFTDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<RateLimitNFTDeployment>().SendRequestAsync(rateLimitNFTDeployment);
        }

        public static async Task<RateLimitNFTService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, RateLimitNFTDeployment rateLimitNFTDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, rateLimitNFTDeployment, cancellationTokenSource);
            return new RateLimitNFTService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public RateLimitNFTService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public RateLimitNFTService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<string> ApproveRequestAsync(string to, BigInteger tokenId)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> BurnRequestAsync(BurnFunction burnFunction)
        {
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BurnFunction burnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(BigInteger tokenId)
        {
            var burnFunction = new BurnFunction();
                burnFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var burnFunction = new BurnFunction();
                burnFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> FreeMintRequestAsync(FreeMintFunction freeMintFunction)
        {
             return ContractHandler.SendRequestAsync(freeMintFunction);
        }

        public Task<TransactionReceipt> FreeMintRequestAndWaitForReceiptAsync(FreeMintFunction freeMintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(freeMintFunction, cancellationToken);
        }

        public Task<string> FreeMintRequestAsync(BigInteger expiresAt, BigInteger requestsPerKilosecond, byte[] msgHash, byte v, byte[] r, byte[] sVal)
        {
            var freeMintFunction = new FreeMintFunction();
                freeMintFunction.ExpiresAt = expiresAt;
                freeMintFunction.RequestsPerKilosecond = requestsPerKilosecond;
                freeMintFunction.MsgHash = msgHash;
                freeMintFunction.V = v;
                freeMintFunction.R = r;
                freeMintFunction.SVal = sVal;
            
             return ContractHandler.SendRequestAsync(freeMintFunction);
        }

        public Task<TransactionReceipt> FreeMintRequestAndWaitForReceiptAsync(BigInteger expiresAt, BigInteger requestsPerKilosecond, byte[] msgHash, byte v, byte[] r, byte[] sVal, CancellationTokenSource cancellationToken = null)
        {
            var freeMintFunction = new FreeMintFunction();
                freeMintFunction.ExpiresAt = expiresAt;
                freeMintFunction.RequestsPerKilosecond = requestsPerKilosecond;
                freeMintFunction.MsgHash = msgHash;
                freeMintFunction.V = v;
                freeMintFunction.R = r;
                freeMintFunction.SVal = sVal;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(freeMintFunction, cancellationToken);
        }

        public Task<string> GetApprovedQueryAsync(GetApprovedFunction getApprovedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        
        public Task<string> GetApprovedQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getApprovedFunction = new GetApprovedFunction();
                getApprovedFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        public Task<string> InitializeRequestAsync(InitializeFunction initializeFunction)
        {
             return ContractHandler.SendRequestAsync(initializeFunction);
        }

        public Task<string> InitializeRequestAsync()
        {
             return ContractHandler.SendRequestAsync<InitializeFunction>();
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(InitializeFunction initializeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initializeFunction, cancellationToken);
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<InitializeFunction>(null, cancellationToken);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAllFunction isApprovedForAllFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        
        public Task<bool> IsApprovedForAllQueryAsync(string owner, string @operator, BlockParameter blockParameter = null)
        {
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
                isApprovedForAllFunction.Owner = owner;
                isApprovedForAllFunction.Operator = @operator;
            
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        public Task<string> MintRequestAsync(MintFunction mintFunction)
        {
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(MintFunction mintFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> MintRequestAsync(BigInteger expiresAt)
        {
            var mintFunction = new MintFunction();
                mintFunction.ExpiresAt = expiresAt;
            
             return ContractHandler.SendRequestAsync(mintFunction);
        }

        public Task<TransactionReceipt> MintRequestAndWaitForReceiptAsync(BigInteger expiresAt, CancellationTokenSource cancellationToken = null)
        {
            var mintFunction = new MintFunction();
                mintFunction.ExpiresAt = expiresAt;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintFunction, cancellationToken);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerOfQueryAsync(OwnerOfFunction ownerOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        
        public Task<string> OwnerOfQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var ownerOfFunction = new OwnerOfFunction();
                ownerOfFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFromFunction safeTransferFromFunction)
        {
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFromFunction safeTransferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFromFunction = new SafeTransferFromFunction();
                safeTransferFromFunction.From = from;
                safeTransferFromFunction.To = to;
                safeTransferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFromFunction, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFrom1Function safeTransferFrom1Function)
        {
             return ContractHandler.SendRequestAsync(safeTransferFrom1Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom1Function safeTransferFrom1Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function, cancellationToken);
        }

        public Task<string> SafeTransferFromRequestAsync(string from, string to, BigInteger tokenId, byte[] data)
        {
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
                safeTransferFrom1Function.From = from;
                safeTransferFrom1Function.To = to;
                safeTransferFrom1Function.TokenId = tokenId;
                safeTransferFrom1Function.Data = data;
            
             return ContractHandler.SendRequestAsync(safeTransferFrom1Function);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
                safeTransferFrom1Function.From = from;
                safeTransferFrom1Function.To = to;
                safeTransferFrom1Function.TokenId = tokenId;
                safeTransferFrom1Function.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function, cancellationToken);
        }

        public Task<string> SetAdditionalRequestsPerKilosecondCostRequestAsync(SetAdditionalRequestsPerKilosecondCostFunction setAdditionalRequestsPerKilosecondCostFunction)
        {
             return ContractHandler.SendRequestAsync(setAdditionalRequestsPerKilosecondCostFunction);
        }

        public Task<TransactionReceipt> SetAdditionalRequestsPerKilosecondCostRequestAndWaitForReceiptAsync(SetAdditionalRequestsPerKilosecondCostFunction setAdditionalRequestsPerKilosecondCostFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdditionalRequestsPerKilosecondCostFunction, cancellationToken);
        }

        public Task<string> SetAdditionalRequestsPerKilosecondCostRequestAsync(BigInteger newAdditionalRequestsPerKilosecondCost)
        {
            var setAdditionalRequestsPerKilosecondCostFunction = new SetAdditionalRequestsPerKilosecondCostFunction();
                setAdditionalRequestsPerKilosecondCostFunction.NewAdditionalRequestsPerKilosecondCost = newAdditionalRequestsPerKilosecondCost;
            
             return ContractHandler.SendRequestAsync(setAdditionalRequestsPerKilosecondCostFunction);
        }

        public Task<TransactionReceipt> SetAdditionalRequestsPerKilosecondCostRequestAndWaitForReceiptAsync(BigInteger newAdditionalRequestsPerKilosecondCost, CancellationTokenSource cancellationToken = null)
        {
            var setAdditionalRequestsPerKilosecondCostFunction = new SetAdditionalRequestsPerKilosecondCostFunction();
                setAdditionalRequestsPerKilosecondCostFunction.NewAdditionalRequestsPerKilosecondCost = newAdditionalRequestsPerKilosecondCost;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setAdditionalRequestsPerKilosecondCostFunction, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(SetApprovalForAllFunction setApprovalForAllFunction)
        {
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAllFunction setApprovalForAllFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(string @operator, bool approved)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource cancellationToken = null)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<string> SetFreeMintSignerRequestAsync(SetFreeMintSignerFunction setFreeMintSignerFunction)
        {
             return ContractHandler.SendRequestAsync(setFreeMintSignerFunction);
        }

        public Task<TransactionReceipt> SetFreeMintSignerRequestAndWaitForReceiptAsync(SetFreeMintSignerFunction setFreeMintSignerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFreeMintSignerFunction, cancellationToken);
        }

        public Task<string> SetFreeMintSignerRequestAsync(string newFreeMintSigner)
        {
            var setFreeMintSignerFunction = new SetFreeMintSignerFunction();
                setFreeMintSignerFunction.NewFreeMintSigner = newFreeMintSigner;
            
             return ContractHandler.SendRequestAsync(setFreeMintSignerFunction);
        }

        public Task<TransactionReceipt> SetFreeMintSignerRequestAndWaitForReceiptAsync(string newFreeMintSigner, CancellationTokenSource cancellationToken = null)
        {
            var setFreeMintSignerFunction = new SetFreeMintSignerFunction();
                setFreeMintSignerFunction.NewFreeMintSigner = newFreeMintSigner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFreeMintSignerFunction, cancellationToken);
        }

        public Task<string> SetFreeRequestsPerRateLimitWindowRequestAsync(SetFreeRequestsPerRateLimitWindowFunction setFreeRequestsPerRateLimitWindowFunction)
        {
             return ContractHandler.SendRequestAsync(setFreeRequestsPerRateLimitWindowFunction);
        }

        public Task<TransactionReceipt> SetFreeRequestsPerRateLimitWindowRequestAndWaitForReceiptAsync(SetFreeRequestsPerRateLimitWindowFunction setFreeRequestsPerRateLimitWindowFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFreeRequestsPerRateLimitWindowFunction, cancellationToken);
        }

        public Task<string> SetFreeRequestsPerRateLimitWindowRequestAsync(BigInteger newFreeRequestsPerRateLimitWindow)
        {
            var setFreeRequestsPerRateLimitWindowFunction = new SetFreeRequestsPerRateLimitWindowFunction();
                setFreeRequestsPerRateLimitWindowFunction.NewFreeRequestsPerRateLimitWindow = newFreeRequestsPerRateLimitWindow;
            
             return ContractHandler.SendRequestAsync(setFreeRequestsPerRateLimitWindowFunction);
        }

        public Task<TransactionReceipt> SetFreeRequestsPerRateLimitWindowRequestAndWaitForReceiptAsync(BigInteger newFreeRequestsPerRateLimitWindow, CancellationTokenSource cancellationToken = null)
        {
            var setFreeRequestsPerRateLimitWindowFunction = new SetFreeRequestsPerRateLimitWindowFunction();
                setFreeRequestsPerRateLimitWindowFunction.NewFreeRequestsPerRateLimitWindow = newFreeRequestsPerRateLimitWindow;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFreeRequestsPerRateLimitWindowFunction, cancellationToken);
        }

        public Task<string> SetMaxExpirationSecondsRequestAsync(SetMaxExpirationSecondsFunction setMaxExpirationSecondsFunction)
        {
             return ContractHandler.SendRequestAsync(setMaxExpirationSecondsFunction);
        }

        public Task<TransactionReceipt> SetMaxExpirationSecondsRequestAndWaitForReceiptAsync(SetMaxExpirationSecondsFunction setMaxExpirationSecondsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxExpirationSecondsFunction, cancellationToken);
        }

        public Task<string> SetMaxExpirationSecondsRequestAsync(BigInteger newMaxExpirationSeconds)
        {
            var setMaxExpirationSecondsFunction = new SetMaxExpirationSecondsFunction();
                setMaxExpirationSecondsFunction.NewMaxExpirationSeconds = newMaxExpirationSeconds;
            
             return ContractHandler.SendRequestAsync(setMaxExpirationSecondsFunction);
        }

        public Task<TransactionReceipt> SetMaxExpirationSecondsRequestAndWaitForReceiptAsync(BigInteger newMaxExpirationSeconds, CancellationTokenSource cancellationToken = null)
        {
            var setMaxExpirationSecondsFunction = new SetMaxExpirationSecondsFunction();
                setMaxExpirationSecondsFunction.NewMaxExpirationSeconds = newMaxExpirationSeconds;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxExpirationSecondsFunction, cancellationToken);
        }

        public Task<string> SetMaxRequestsPerKilosecondRequestAsync(SetMaxRequestsPerKilosecondFunction setMaxRequestsPerKilosecondFunction)
        {
             return ContractHandler.SendRequestAsync(setMaxRequestsPerKilosecondFunction);
        }

        public Task<TransactionReceipt> SetMaxRequestsPerKilosecondRequestAndWaitForReceiptAsync(SetMaxRequestsPerKilosecondFunction setMaxRequestsPerKilosecondFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxRequestsPerKilosecondFunction, cancellationToken);
        }

        public Task<string> SetMaxRequestsPerKilosecondRequestAsync(BigInteger newMaxRequestsPerKilosecond)
        {
            var setMaxRequestsPerKilosecondFunction = new SetMaxRequestsPerKilosecondFunction();
                setMaxRequestsPerKilosecondFunction.NewMaxRequestsPerKilosecond = newMaxRequestsPerKilosecond;
            
             return ContractHandler.SendRequestAsync(setMaxRequestsPerKilosecondFunction);
        }

        public Task<TransactionReceipt> SetMaxRequestsPerKilosecondRequestAndWaitForReceiptAsync(BigInteger newMaxRequestsPerKilosecond, CancellationTokenSource cancellationToken = null)
        {
            var setMaxRequestsPerKilosecondFunction = new SetMaxRequestsPerKilosecondFunction();
                setMaxRequestsPerKilosecondFunction.NewMaxRequestsPerKilosecond = newMaxRequestsPerKilosecond;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxRequestsPerKilosecondFunction, cancellationToken);
        }

        public Task<string> SetRLIHolderRateLimitWindowSecondsRequestAsync(SetRLIHolderRateLimitWindowSecondsFunction setRLIHolderRateLimitWindowSecondsFunction)
        {
             return ContractHandler.SendRequestAsync(setRLIHolderRateLimitWindowSecondsFunction);
        }

        public Task<TransactionReceipt> SetRLIHolderRateLimitWindowSecondsRequestAndWaitForReceiptAsync(SetRLIHolderRateLimitWindowSecondsFunction setRLIHolderRateLimitWindowSecondsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRLIHolderRateLimitWindowSecondsFunction, cancellationToken);
        }

        public Task<string> SetRLIHolderRateLimitWindowSecondsRequestAsync(BigInteger newRLIHolderRateLimitWindowSeconds)
        {
            var setRLIHolderRateLimitWindowSecondsFunction = new SetRLIHolderRateLimitWindowSecondsFunction();
                setRLIHolderRateLimitWindowSecondsFunction.NewRLIHolderRateLimitWindowSeconds = newRLIHolderRateLimitWindowSeconds;
            
             return ContractHandler.SendRequestAsync(setRLIHolderRateLimitWindowSecondsFunction);
        }

        public Task<TransactionReceipt> SetRLIHolderRateLimitWindowSecondsRequestAndWaitForReceiptAsync(BigInteger newRLIHolderRateLimitWindowSeconds, CancellationTokenSource cancellationToken = null)
        {
            var setRLIHolderRateLimitWindowSecondsFunction = new SetRLIHolderRateLimitWindowSecondsFunction();
                setRLIHolderRateLimitWindowSecondsFunction.NewRLIHolderRateLimitWindowSeconds = newRLIHolderRateLimitWindowSeconds;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRLIHolderRateLimitWindowSecondsFunction, cancellationToken);
        }

        public Task<string> SetRateLimitWindowSecondsRequestAsync(SetRateLimitWindowSecondsFunction setRateLimitWindowSecondsFunction)
        {
             return ContractHandler.SendRequestAsync(setRateLimitWindowSecondsFunction);
        }

        public Task<TransactionReceipt> SetRateLimitWindowSecondsRequestAndWaitForReceiptAsync(SetRateLimitWindowSecondsFunction setRateLimitWindowSecondsFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRateLimitWindowSecondsFunction, cancellationToken);
        }

        public Task<string> SetRateLimitWindowSecondsRequestAsync(BigInteger newRateLimitWindowSeconds)
        {
            var setRateLimitWindowSecondsFunction = new SetRateLimitWindowSecondsFunction();
                setRateLimitWindowSecondsFunction.NewRateLimitWindowSeconds = newRateLimitWindowSeconds;
            
             return ContractHandler.SendRequestAsync(setRateLimitWindowSecondsFunction);
        }

        public Task<TransactionReceipt> SetRateLimitWindowSecondsRequestAndWaitForReceiptAsync(BigInteger newRateLimitWindowSeconds, CancellationTokenSource cancellationToken = null)
        {
            var setRateLimitWindowSecondsFunction = new SetRateLimitWindowSecondsFunction();
                setRateLimitWindowSecondsFunction.NewRateLimitWindowSeconds = newRateLimitWindowSeconds;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRateLimitWindowSecondsFunction, cancellationToken);
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

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TokenByIndexQueryAsync(TokenByIndexFunction tokenByIndexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenByIndexFunction, BigInteger>(tokenByIndexFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenByIndexQueryAsync(BigInteger index, BlockParameter blockParameter = null)
        {
            var tokenByIndexFunction = new TokenByIndexFunction();
                tokenByIndexFunction.Index = index;
            
            return ContractHandler.QueryAsync<TokenByIndexFunction, BigInteger>(tokenByIndexFunction, blockParameter);
        }

        public Task<BigInteger> TokenOfOwnerByIndexQueryAsync(TokenOfOwnerByIndexFunction tokenOfOwnerByIndexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenOfOwnerByIndexFunction, BigInteger>(tokenOfOwnerByIndexFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenOfOwnerByIndexQueryAsync(string owner, BigInteger index, BlockParameter blockParameter = null)
        {
            var tokenOfOwnerByIndexFunction = new TokenOfOwnerByIndexFunction();
                tokenOfOwnerByIndexFunction.Owner = owner;
                tokenOfOwnerByIndexFunction.Index = index;
            
            return ContractHandler.QueryAsync<TokenOfOwnerByIndexFunction, BigInteger>(tokenOfOwnerByIndexFunction, blockParameter);
        }

        public Task<string> TokenURIQueryAsync(TokenURIFunction tokenURIFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        
        public Task<string> TokenURIQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var tokenURIFunction = new TokenURIFunction();
                tokenURIFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> TransferFromRequestAsync(string from, string to, BigInteger tokenId)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var transferFromFunction = new TransferFromFunction();
                transferFromFunction.From = from;
                transferFromFunction.To = to;
                transferFromFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferFromFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<string> WithdrawRequestAsync()
        {
             return ContractHandler.SendRequestAsync<WithdrawFunction>();
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawFunction>(null, cancellationToken);
        }

        public Task<BigInteger> RLIHolderRateLimitWindowSecondsQueryAsync(RLIHolderRateLimitWindowSecondsFunction rLIHolderRateLimitWindowSecondsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RLIHolderRateLimitWindowSecondsFunction, BigInteger>(rLIHolderRateLimitWindowSecondsFunction, blockParameter);
        }

        
        public Task<BigInteger> RLIHolderRateLimitWindowSecondsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RLIHolderRateLimitWindowSecondsFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> AdditionalRequestsPerKilosecondCostQueryAsync(AdditionalRequestsPerKilosecondCostFunction additionalRequestsPerKilosecondCostFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdditionalRequestsPerKilosecondCostFunction, BigInteger>(additionalRequestsPerKilosecondCostFunction, blockParameter);
        }

        
        public Task<BigInteger> AdditionalRequestsPerKilosecondCostQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdditionalRequestsPerKilosecondCostFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> CalculateCostQueryAsync(CalculateCostFunction calculateCostFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculateCostFunction, BigInteger>(calculateCostFunction, blockParameter);
        }

        
        public Task<BigInteger> CalculateCostQueryAsync(BigInteger requestsPerKilosecond, BigInteger expiresAt, BlockParameter blockParameter = null)
        {
            var calculateCostFunction = new CalculateCostFunction();
                calculateCostFunction.RequestsPerKilosecond = requestsPerKilosecond;
                calculateCostFunction.ExpiresAt = expiresAt;
            
            return ContractHandler.QueryAsync<CalculateCostFunction, BigInteger>(calculateCostFunction, blockParameter);
        }

        public Task<BigInteger> CalculateRequestsPerKilosecondQueryAsync(CalculateRequestsPerKilosecondFunction calculateRequestsPerKilosecondFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculateRequestsPerKilosecondFunction, BigInteger>(calculateRequestsPerKilosecondFunction, blockParameter);
        }

        
        public Task<BigInteger> CalculateRequestsPerKilosecondQueryAsync(BigInteger payingAmount, BigInteger expiresAt, BlockParameter blockParameter = null)
        {
            var calculateRequestsPerKilosecondFunction = new CalculateRequestsPerKilosecondFunction();
                calculateRequestsPerKilosecondFunction.PayingAmount = payingAmount;
                calculateRequestsPerKilosecondFunction.ExpiresAt = expiresAt;
            
            return ContractHandler.QueryAsync<CalculateRequestsPerKilosecondFunction, BigInteger>(calculateRequestsPerKilosecondFunction, blockParameter);
        }

        public Task<CapacityOutputDTO> CapacityQueryAsync(CapacityFunction capacityFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<CapacityFunction, CapacityOutputDTO>(capacityFunction, blockParameter);
        }

        public Task<CapacityOutputDTO> CapacityQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var capacityFunction = new CapacityFunction();
                capacityFunction.TokenId = tokenId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<CapacityFunction, CapacityOutputDTO>(capacityFunction, blockParameter);
        }

        public Task<bool> CheckBelowMaxRequestsPerKilosecondQueryAsync(CheckBelowMaxRequestsPerKilosecondFunction checkBelowMaxRequestsPerKilosecondFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckBelowMaxRequestsPerKilosecondFunction, bool>(checkBelowMaxRequestsPerKilosecondFunction, blockParameter);
        }

        
        public Task<bool> CheckBelowMaxRequestsPerKilosecondQueryAsync(BigInteger requestedRequestsPerKilosecond, BlockParameter blockParameter = null)
        {
            var checkBelowMaxRequestsPerKilosecondFunction = new CheckBelowMaxRequestsPerKilosecondFunction();
                checkBelowMaxRequestsPerKilosecondFunction.RequestedRequestsPerKilosecond = requestedRequestsPerKilosecond;
            
            return ContractHandler.QueryAsync<CheckBelowMaxRequestsPerKilosecondFunction, bool>(checkBelowMaxRequestsPerKilosecondFunction, blockParameter);
        }

        public Task<BigInteger> CurrentSoldRequestsPerKilosecondQueryAsync(CurrentSoldRequestsPerKilosecondFunction currentSoldRequestsPerKilosecondFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CurrentSoldRequestsPerKilosecondFunction, BigInteger>(currentSoldRequestsPerKilosecondFunction, blockParameter);
        }

        
        public Task<BigInteger> CurrentSoldRequestsPerKilosecondQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CurrentSoldRequestsPerKilosecondFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> DefaultRateLimitWindowSecondsQueryAsync(DefaultRateLimitWindowSecondsFunction defaultRateLimitWindowSecondsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultRateLimitWindowSecondsFunction, BigInteger>(defaultRateLimitWindowSecondsFunction, blockParameter);
        }

        
        public Task<BigInteger> DefaultRateLimitWindowSecondsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultRateLimitWindowSecondsFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> FreeMintSignerQueryAsync(FreeMintSignerFunction freeMintSignerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FreeMintSignerFunction, string>(freeMintSignerFunction, blockParameter);
        }

        
        public Task<string> FreeMintSignerQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FreeMintSignerFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> FreeRequestsPerRateLimitWindowQueryAsync(FreeRequestsPerRateLimitWindowFunction freeRequestsPerRateLimitWindowFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FreeRequestsPerRateLimitWindowFunction, BigInteger>(freeRequestsPerRateLimitWindowFunction, blockParameter);
        }

        
        public Task<BigInteger> FreeRequestsPerRateLimitWindowQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<FreeRequestsPerRateLimitWindowFunction, BigInteger>(null, blockParameter);
        }

        public Task<bool> IsExpiredQueryAsync(IsExpiredFunction isExpiredFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsExpiredFunction, bool>(isExpiredFunction, blockParameter);
        }

        
        public Task<bool> IsExpiredQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var isExpiredFunction = new IsExpiredFunction();
                isExpiredFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<IsExpiredFunction, bool>(isExpiredFunction, blockParameter);
        }

        public Task<BigInteger> MaxExpirationSecondsQueryAsync(MaxExpirationSecondsFunction maxExpirationSecondsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxExpirationSecondsFunction, BigInteger>(maxExpirationSecondsFunction, blockParameter);
        }

        
        public Task<BigInteger> MaxExpirationSecondsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxExpirationSecondsFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> MaxRequestsPerKilosecondQueryAsync(MaxRequestsPerKilosecondFunction maxRequestsPerKilosecondFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxRequestsPerKilosecondFunction, BigInteger>(maxRequestsPerKilosecondFunction, blockParameter);
        }

        
        public Task<BigInteger> MaxRequestsPerKilosecondQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaxRequestsPerKilosecondFunction, BigInteger>(null, blockParameter);
        }

        public Task<byte[]> PrefixedQueryAsync(PrefixedFunction prefixedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PrefixedFunction, byte[]>(prefixedFunction, blockParameter);
        }

        
        public Task<byte[]> PrefixedQueryAsync(byte[] hash, BlockParameter blockParameter = null)
        {
            var prefixedFunction = new PrefixedFunction();
                prefixedFunction.Hash = hash;
            
            return ContractHandler.QueryAsync<PrefixedFunction, byte[]>(prefixedFunction, blockParameter);
        }

        public Task<bool> RedeemedFreeMintsQueryAsync(RedeemedFreeMintsFunction redeemedFreeMintsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RedeemedFreeMintsFunction, bool>(redeemedFreeMintsFunction, blockParameter);
        }

        
        public Task<bool> RedeemedFreeMintsQueryAsync(byte[] msgHash, BlockParameter blockParameter = null)
        {
            var redeemedFreeMintsFunction = new RedeemedFreeMintsFunction();
                redeemedFreeMintsFunction.MsgHash = msgHash;
            
            return ContractHandler.QueryAsync<RedeemedFreeMintsFunction, bool>(redeemedFreeMintsFunction, blockParameter);
        }

        public Task<BigInteger> TokenIdCounterQueryAsync(TokenIdCounterFunction tokenIdCounterFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenIdCounterFunction, BigInteger>(tokenIdCounterFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenIdCounterQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenIdCounterFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TokenSVGQueryAsync(TokenSVGFunction tokenSVGFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenSVGFunction, string>(tokenSVGFunction, blockParameter);
        }

        
        public Task<string> TokenSVGQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var tokenSVGFunction = new TokenSVGFunction();
                tokenSVGFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<TokenSVGFunction, string>(tokenSVGFunction, blockParameter);
        }

        public Task<BigInteger> TotalSoldRequestsPerKilosecondByExpirationTimeQueryAsync(TotalSoldRequestsPerKilosecondByExpirationTimeFunction totalSoldRequestsPerKilosecondByExpirationTimeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSoldRequestsPerKilosecondByExpirationTimeFunction, BigInteger>(totalSoldRequestsPerKilosecondByExpirationTimeFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSoldRequestsPerKilosecondByExpirationTimeQueryAsync(BigInteger expiresAt, BlockParameter blockParameter = null)
        {
            var totalSoldRequestsPerKilosecondByExpirationTimeFunction = new TotalSoldRequestsPerKilosecondByExpirationTimeFunction();
                totalSoldRequestsPerKilosecondByExpirationTimeFunction.ExpiresAt = expiresAt;
            
            return ContractHandler.QueryAsync<TotalSoldRequestsPerKilosecondByExpirationTimeFunction, BigInteger>(totalSoldRequestsPerKilosecondByExpirationTimeFunction, blockParameter);
        }
    }
}
