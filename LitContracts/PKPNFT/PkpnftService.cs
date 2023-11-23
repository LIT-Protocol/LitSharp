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
using LitContracts.PKPNFT.ContractDefinition;

namespace LitContracts.PKPNFT
{
    public partial class PkpnftService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PkpnftDeployment pkpnftDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PkpnftDeployment>().SendRequestAndWaitForReceiptAsync(pkpnftDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PkpnftDeployment pkpnftDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PkpnftDeployment>().SendRequestAsync(pkpnftDeployment);
        }

        public static async Task<PkpnftService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PkpnftDeployment pkpnftDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, pkpnftDeployment, cancellationTokenSource);
            return new PkpnftService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PkpnftService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public PkpnftService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> DiamondCutRequestAsync(DiamondCutFunction diamondCutFunction)
        {
             return ContractHandler.SendRequestAsync(diamondCutFunction);
        }

        public Task<TransactionReceipt> DiamondCutRequestAndWaitForReceiptAsync(DiamondCutFunction diamondCutFunction, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> DiamondCutRequestAndWaitForReceiptAsync(List<FacetCut> diamondCut, string init, byte[] calldata, CancellationTokenSource? cancellationToken = null)
        {
            var diamondCutFunction = new DiamondCutFunction();
                diamondCutFunction.DiamondCut = diamondCut;
                diamondCutFunction.Init = init;
                diamondCutFunction.Calldata = calldata;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(diamondCutFunction, cancellationToken);
        }

        public Task<string> FacetAddressQueryAsync(FacetAddressFunction facetAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<FacetAddressFunction, string>(facetAddressFunction, blockParameter);
        }

        
        public Task<string> FacetAddressQueryAsync(byte[] functionSelector, BlockParameter? blockParameter = null)
        {
            var facetAddressFunction = new FacetAddressFunction();
                facetAddressFunction.FunctionSelector = functionSelector;
            
            return ContractHandler.QueryAsync<FacetAddressFunction, string>(facetAddressFunction, blockParameter);
        }

        public Task<List<string>> FacetAddressesQueryAsync(FacetAddressesFunction facetAddressesFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<FacetAddressesFunction, List<string>>(facetAddressesFunction, blockParameter);
        }

        
        public Task<List<string>> FacetAddressesQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<FacetAddressesFunction, List<string>>(null, blockParameter);
        }

        public Task<List<byte[]>> FacetFunctionSelectorsQueryAsync(FacetFunctionSelectorsFunction facetFunctionSelectorsFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<FacetFunctionSelectorsFunction, List<byte[]>>(facetFunctionSelectorsFunction, blockParameter);
        }

        
        public Task<List<byte[]>> FacetFunctionSelectorsQueryAsync(string facet, BlockParameter? blockParameter = null)
        {
            var facetFunctionSelectorsFunction = new FacetFunctionSelectorsFunction();
                facetFunctionSelectorsFunction.Facet = facet;
            
            return ContractHandler.QueryAsync<FacetFunctionSelectorsFunction, List<byte[]>>(facetFunctionSelectorsFunction, blockParameter);
        }

        public Task<FacetsOutputDTO> FacetsQueryAsync(FacetsFunction facetsFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<FacetsFunction, FacetsOutputDTO>(facetsFunction, blockParameter);
        }

        public Task<FacetsOutputDTO> FacetsQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<FacetsFunction, FacetsOutputDTO>(null, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
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

        public Task<string> ApproveRequestAsync(ApproveFunction approveFunction)
        {
             return ContractHandler.SendRequestAsync(approveFunction);
        }

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(ApproveFunction approveFunction, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> ApproveRequestAndWaitForReceiptAsync(string to, BigInteger tokenId, CancellationTokenSource? cancellationToken = null)
        {
            var approveFunction = new ApproveFunction();
                approveFunction.To = to;
                approveFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(approveFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string owner, BlockParameter? blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Owner = owner;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<string> BurnRequestAsync(BurnFunction burnFunction)
        {
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BurnFunction burnFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> BurnRequestAsync(BigInteger tokenId)
        {
            var burnFunction = new BurnFunction();
                burnFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(burnFunction);
        }

        public Task<TransactionReceipt> BurnRequestAndWaitForReceiptAsync(BigInteger tokenId, CancellationTokenSource? cancellationToken = null)
        {
            var burnFunction = new BurnFunction();
                burnFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(burnFunction, cancellationToken);
        }

        public Task<string> ClaimAndMintRequestAsync(ClaimAndMintFunction claimAndMintFunction)
        {
             return ContractHandler.SendRequestAsync(claimAndMintFunction);
        }

        public Task<TransactionReceipt> ClaimAndMintRequestAndWaitForReceiptAsync(ClaimAndMintFunction claimAndMintFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimAndMintFunction, cancellationToken);
        }

        public Task<string> ClaimAndMintRequestAsync(BigInteger keyType, byte[] derivedKeyId, List<Signature> signatures)
        {
            var claimAndMintFunction = new ClaimAndMintFunction();
                claimAndMintFunction.KeyType = keyType;
                claimAndMintFunction.DerivedKeyId = derivedKeyId;
                claimAndMintFunction.Signatures = signatures;
            
             return ContractHandler.SendRequestAsync(claimAndMintFunction);
        }

        public Task<TransactionReceipt> ClaimAndMintRequestAndWaitForReceiptAsync(BigInteger keyType, byte[] derivedKeyId, List<Signature> signatures, CancellationTokenSource? cancellationToken = null)
        {
            var claimAndMintFunction = new ClaimAndMintFunction();
                claimAndMintFunction.KeyType = keyType;
                claimAndMintFunction.DerivedKeyId = derivedKeyId;
                claimAndMintFunction.Signatures = signatures;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimAndMintFunction, cancellationToken);
        }

        public Task<bool> ExistsQueryAsync(ExistsFunction existsFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ExistsFunction, bool>(existsFunction, blockParameter);
        }

        
        public Task<bool> ExistsQueryAsync(BigInteger tokenId, BlockParameter? blockParameter = null)
        {
            var existsFunction = new ExistsFunction();
                existsFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<ExistsFunction, bool>(existsFunction, blockParameter);
        }

        public Task<string> FreeMintSignerQueryAsync(FreeMintSignerFunction freeMintSignerFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<FreeMintSignerFunction, string>(freeMintSignerFunction, blockParameter);
        }

        
        public Task<string> FreeMintSignerQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<FreeMintSignerFunction, string>(null, blockParameter);
        }

        public Task<string> GetApprovedQueryAsync(GetApprovedFunction getApprovedFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        
        public Task<string> GetApprovedQueryAsync(BigInteger tokenId, BlockParameter? blockParameter = null)
        {
            var getApprovedFunction = new GetApprovedFunction();
                getApprovedFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetApprovedFunction, string>(getApprovedFunction, blockParameter);
        }

        public Task<string> GetEthAddressQueryAsync(GetEthAddressFunction getEthAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetEthAddressFunction, string>(getEthAddressFunction, blockParameter);
        }

        
        public Task<string> GetEthAddressQueryAsync(BigInteger tokenId, BlockParameter? blockParameter = null)
        {
            var getEthAddressFunction = new GetEthAddressFunction();
                getEthAddressFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetEthAddressFunction, string>(getEthAddressFunction, blockParameter);
        }

        public Task<byte[]> GetNextDerivedKeyIdQueryAsync(GetNextDerivedKeyIdFunction getNextDerivedKeyIdFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNextDerivedKeyIdFunction, byte[]>(getNextDerivedKeyIdFunction, blockParameter);
        }

        
        public Task<byte[]> GetNextDerivedKeyIdQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNextDerivedKeyIdFunction, byte[]>(null, blockParameter);
        }

        public Task<string> GetPkpNftMetadataAddressQueryAsync(GetPkpNftMetadataAddressFunction getPkpNftMetadataAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpNftMetadataAddressFunction, string>(getPkpNftMetadataAddressFunction, blockParameter);
        }

        
        public Task<string> GetPkpNftMetadataAddressQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpNftMetadataAddressFunction, string>(null, blockParameter);
        }

        public Task<string> GetPkpPermissionsAddressQueryAsync(GetPkpPermissionsAddressFunction getPkpPermissionsAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpPermissionsAddressFunction, string>(getPkpPermissionsAddressFunction, blockParameter);
        }

        
        public Task<string> GetPkpPermissionsAddressQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpPermissionsAddressFunction, string>(null, blockParameter);
        }

        public Task<byte[]> GetPubkeyQueryAsync(GetPubkeyFunction getPubkeyFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPubkeyFunction, byte[]>(getPubkeyFunction, blockParameter);
        }

        
        public Task<byte[]> GetPubkeyQueryAsync(BigInteger tokenId, BlockParameter? blockParameter = null)
        {
            var getPubkeyFunction = new GetPubkeyFunction();
                getPubkeyFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetPubkeyFunction, byte[]>(getPubkeyFunction, blockParameter);
        }

        public Task<string> GetRouterAddressQueryAsync(GetRouterAddressFunction getRouterAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRouterAddressFunction, string>(getRouterAddressFunction, blockParameter);
        }

        
        public Task<string> GetRouterAddressQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRouterAddressFunction, string>(null, blockParameter);
        }

        public Task<string> GetStakingAddressQueryAsync(GetStakingAddressFunction getStakingAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakingAddressFunction, string>(getStakingAddressFunction, blockParameter);
        }

        
        public Task<string> GetStakingAddressQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakingAddressFunction, string>(null, blockParameter);
        }

        public Task<string> InitializeRequestAsync(InitializeFunction initializeFunction)
        {
             return ContractHandler.SendRequestAsync(initializeFunction);
        }

        public Task<string> InitializeRequestAsync()
        {
             return ContractHandler.SendRequestAsync<InitializeFunction>();
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(InitializeFunction initializeFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(initializeFunction, cancellationToken);
        }

        public Task<TransactionReceipt> InitializeRequestAndWaitForReceiptAsync(CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<InitializeFunction>(null, cancellationToken);
        }

        public Task<bool> IsApprovedForAllQueryAsync(IsApprovedForAllFunction isApprovedForAllFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        
        public Task<bool> IsApprovedForAllQueryAsync(string owner, string @operator, BlockParameter? blockParameter = null)
        {
            var isApprovedForAllFunction = new IsApprovedForAllFunction();
                isApprovedForAllFunction.Owner = owner;
                isApprovedForAllFunction.Operator = @operator;
            
            return ContractHandler.QueryAsync<IsApprovedForAllFunction, bool>(isApprovedForAllFunction, blockParameter);
        }

        public Task<BigInteger> MintCostQueryAsync(MintCostFunction mintCostFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<MintCostFunction, BigInteger>(mintCostFunction, blockParameter);
        }

        
        public Task<BigInteger> MintCostQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<MintCostFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> MintGrantAndBurnNextRequestAsync(MintGrantAndBurnNextFunction mintGrantAndBurnNextFunction)
        {
             return ContractHandler.SendRequestAsync(mintGrantAndBurnNextFunction);
        }

        public Task<TransactionReceipt> MintGrantAndBurnNextRequestAndWaitForReceiptAsync(MintGrantAndBurnNextFunction mintGrantAndBurnNextFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintGrantAndBurnNextFunction, cancellationToken);
        }

        public Task<string> MintGrantAndBurnNextRequestAsync(BigInteger keyType, byte[] ipfsCID)
        {
            var mintGrantAndBurnNextFunction = new MintGrantAndBurnNextFunction();
                mintGrantAndBurnNextFunction.KeyType = keyType;
                mintGrantAndBurnNextFunction.IpfsCID = ipfsCID;
            
             return ContractHandler.SendRequestAsync(mintGrantAndBurnNextFunction);
        }

        public Task<TransactionReceipt> MintGrantAndBurnNextRequestAndWaitForReceiptAsync(BigInteger keyType, byte[] ipfsCID, CancellationTokenSource? cancellationToken = null)
        {
            var mintGrantAndBurnNextFunction = new MintGrantAndBurnNextFunction();
                mintGrantAndBurnNextFunction.KeyType = keyType;
                mintGrantAndBurnNextFunction.IpfsCID = ipfsCID;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintGrantAndBurnNextFunction, cancellationToken);
        }

        public Task<string> MintNextRequestAsync(MintNextFunction mintNextFunction)
        {
             return ContractHandler.SendRequestAsync(mintNextFunction);
        }

        public Task<TransactionReceipt> MintNextRequestAndWaitForReceiptAsync(MintNextFunction mintNextFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintNextFunction, cancellationToken);
        }

        public Task<string> MintNextRequestAsync(BigInteger keyType)
        {
            var mintNextFunction = new MintNextFunction();
                mintNextFunction.KeyType = keyType;
            
             return ContractHandler.SendRequestAsync(mintNextFunction);
        }

        public Task<TransactionReceipt> MintNextRequestAndWaitForReceiptAsync(BigInteger keyType, CancellationTokenSource? cancellationToken = null)
        {
            var mintNextFunction = new MintNextFunction();
                mintNextFunction.KeyType = keyType;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintNextFunction, cancellationToken);
        }

        public Task<string> NameQueryAsync(NameFunction nameFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(nameFunction, blockParameter);
        }

        
        public Task<string> NameQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<NameFunction, string>(null, blockParameter);
        }

        public Task<string> OwnerOfQueryAsync(OwnerOfFunction ownerOfFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        
        public Task<string> OwnerOfQueryAsync(BigInteger tokenId, BlockParameter? blockParameter = null)
        {
            var ownerOfFunction = new OwnerOfFunction();
                ownerOfFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<OwnerOfFunction, string>(ownerOfFunction, blockParameter);
        }

        public Task<byte[]> PrefixedQueryAsync(PrefixedFunction prefixedFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<PrefixedFunction, byte[]>(prefixedFunction, blockParameter);
        }

        
        public Task<byte[]> PrefixedQueryAsync(byte[] hash, BlockParameter? blockParameter = null)
        {
            var prefixedFunction = new PrefixedFunction();
                prefixedFunction.Hash = hash;
            
            return ContractHandler.QueryAsync<PrefixedFunction, byte[]>(prefixedFunction, blockParameter);
        }

        public Task<bool> RedeemedFreeMintIdsQueryAsync(RedeemedFreeMintIdsFunction redeemedFreeMintIdsFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<RedeemedFreeMintIdsFunction, bool>(redeemedFreeMintIdsFunction, blockParameter);
        }

        
        public Task<bool> RedeemedFreeMintIdsQueryAsync(BigInteger tokenId, BlockParameter? blockParameter = null)
        {
            var redeemedFreeMintIdsFunction = new RedeemedFreeMintIdsFunction();
                redeemedFreeMintIdsFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<RedeemedFreeMintIdsFunction, bool>(redeemedFreeMintIdsFunction, blockParameter);
        }

        public Task<string> SafeTransferFromRequestAsync(SafeTransferFromFunction safeTransferFromFunction)
        {
             return ContractHandler.SendRequestAsync(safeTransferFromFunction);
        }

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFromFunction safeTransferFromFunction, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(SafeTransferFrom1Function safeTransferFrom1Function, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> SafeTransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, byte[] data, CancellationTokenSource? cancellationToken = null)
        {
            var safeTransferFrom1Function = new SafeTransferFrom1Function();
                safeTransferFrom1Function.From = from;
                safeTransferFrom1Function.To = to;
                safeTransferFrom1Function.TokenId = tokenId;
                safeTransferFrom1Function.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(safeTransferFrom1Function, cancellationToken);
        }

        public Task<string> SetApprovalForAllRequestAsync(SetApprovalForAllFunction setApprovalForAllFunction)
        {
             return ContractHandler.SendRequestAsync(setApprovalForAllFunction);
        }

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(SetApprovalForAllFunction setApprovalForAllFunction, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> SetApprovalForAllRequestAndWaitForReceiptAsync(string @operator, bool approved, CancellationTokenSource? cancellationToken = null)
        {
            var setApprovalForAllFunction = new SetApprovalForAllFunction();
                setApprovalForAllFunction.Operator = @operator;
                setApprovalForAllFunction.Approved = approved;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setApprovalForAllFunction, cancellationToken);
        }

        public Task<string> SetContractResolverRequestAsync(SetContractResolverFunction setContractResolverFunction)
        {
             return ContractHandler.SendRequestAsync(setContractResolverFunction);
        }

        public Task<TransactionReceipt> SetContractResolverRequestAndWaitForReceiptAsync(SetContractResolverFunction setContractResolverFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractResolverFunction, cancellationToken);
        }

        public Task<string> SetContractResolverRequestAsync(string newResolverAddress)
        {
            var setContractResolverFunction = new SetContractResolverFunction();
                setContractResolverFunction.NewResolverAddress = newResolverAddress;
            
             return ContractHandler.SendRequestAsync(setContractResolverFunction);
        }

        public Task<TransactionReceipt> SetContractResolverRequestAndWaitForReceiptAsync(string newResolverAddress, CancellationTokenSource? cancellationToken = null)
        {
            var setContractResolverFunction = new SetContractResolverFunction();
                setContractResolverFunction.NewResolverAddress = newResolverAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractResolverFunction, cancellationToken);
        }

        public Task<string> SetFreeMintSignerRequestAsync(SetFreeMintSignerFunction setFreeMintSignerFunction)
        {
             return ContractHandler.SendRequestAsync(setFreeMintSignerFunction);
        }

        public Task<TransactionReceipt> SetFreeMintSignerRequestAndWaitForReceiptAsync(SetFreeMintSignerFunction setFreeMintSignerFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFreeMintSignerFunction, cancellationToken);
        }

        public Task<string> SetFreeMintSignerRequestAsync(string newFreeMintSigner)
        {
            var setFreeMintSignerFunction = new SetFreeMintSignerFunction();
                setFreeMintSignerFunction.NewFreeMintSigner = newFreeMintSigner;
            
             return ContractHandler.SendRequestAsync(setFreeMintSignerFunction);
        }

        public Task<TransactionReceipt> SetFreeMintSignerRequestAndWaitForReceiptAsync(string newFreeMintSigner, CancellationTokenSource? cancellationToken = null)
        {
            var setFreeMintSignerFunction = new SetFreeMintSignerFunction();
                setFreeMintSignerFunction.NewFreeMintSigner = newFreeMintSigner;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setFreeMintSignerFunction, cancellationToken);
        }

        public Task<string> SetMintCostRequestAsync(SetMintCostFunction setMintCostFunction)
        {
             return ContractHandler.SendRequestAsync(setMintCostFunction);
        }

        public Task<TransactionReceipt> SetMintCostRequestAndWaitForReceiptAsync(SetMintCostFunction setMintCostFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMintCostFunction, cancellationToken);
        }

        public Task<string> SetMintCostRequestAsync(BigInteger newMintCost)
        {
            var setMintCostFunction = new SetMintCostFunction();
                setMintCostFunction.NewMintCost = newMintCost;
            
             return ContractHandler.SendRequestAsync(setMintCostFunction);
        }

        public Task<TransactionReceipt> SetMintCostRequestAndWaitForReceiptAsync(BigInteger newMintCost, CancellationTokenSource? cancellationToken = null)
        {
            var setMintCostFunction = new SetMintCostFunction();
                setMintCostFunction.NewMintCost = newMintCost;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMintCostFunction, cancellationToken);
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

        public Task<string> SymbolQueryAsync(SymbolFunction symbolFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(symbolFunction, blockParameter);
        }

        
        public Task<string> SymbolQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<SymbolFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> TokenByIndexQueryAsync(TokenByIndexFunction tokenByIndexFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenByIndexFunction, BigInteger>(tokenByIndexFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenByIndexQueryAsync(BigInteger index, BlockParameter? blockParameter = null)
        {
            var tokenByIndexFunction = new TokenByIndexFunction();
                tokenByIndexFunction.Index = index;
            
            return ContractHandler.QueryAsync<TokenByIndexFunction, BigInteger>(tokenByIndexFunction, blockParameter);
        }

        public Task<BigInteger> TokenOfOwnerByIndexQueryAsync(TokenOfOwnerByIndexFunction tokenOfOwnerByIndexFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenOfOwnerByIndexFunction, BigInteger>(tokenOfOwnerByIndexFunction, blockParameter);
        }

        
        public Task<BigInteger> TokenOfOwnerByIndexQueryAsync(string owner, BigInteger index, BlockParameter? blockParameter = null)
        {
            var tokenOfOwnerByIndexFunction = new TokenOfOwnerByIndexFunction();
                tokenOfOwnerByIndexFunction.Owner = owner;
                tokenOfOwnerByIndexFunction.Index = index;
            
            return ContractHandler.QueryAsync<TokenOfOwnerByIndexFunction, BigInteger>(tokenOfOwnerByIndexFunction, blockParameter);
        }

        public Task<string> TokenURIQueryAsync(TokenURIFunction tokenURIFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        
        public Task<string> TokenURIQueryAsync(BigInteger tokenId, BlockParameter? blockParameter = null)
        {
            var tokenURIFunction = new TokenURIFunction();
                tokenURIFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        public Task<BigInteger> TotalSupplyQueryAsync(TotalSupplyFunction totalSupplyFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(totalSupplyFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalSupplyQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalSupplyFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferFromRequestAsync(TransferFromFunction transferFromFunction)
        {
             return ContractHandler.SendRequestAsync(transferFromFunction);
        }

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(TransferFromFunction transferFromFunction, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> TransferFromRequestAndWaitForReceiptAsync(string from, string to, BigInteger tokenId, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawFunction>(null, cancellationToken);
        }
    }
}
