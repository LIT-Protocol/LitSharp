using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace LitContracts.RateLimitNFT.ContractDefinition
{


    public partial class RateLimitNFTDeployment : RateLimitNFTDeploymentBase
    {
        public RateLimitNFTDeployment() : base(BYTECODE) { }
        public RateLimitNFTDeployment(string byteCode) : base(byteCode) { }
    }

    public class RateLimitNFTDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public RateLimitNFTDeploymentBase() : base(BYTECODE) { }
        public RateLimitNFTDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class DiamondCutFunction : DiamondCutFunctionBase { }

    [Function("diamondCut")]
    public class DiamondCutFunctionBase : FunctionMessage
    {
        [Parameter("tuple[]", "_diamondCut", 1)]
        public virtual List<FacetCut> DiamondCut { get; set; }
        [Parameter("address", "_init", 2)]
        public virtual string Init { get; set; }
        [Parameter("bytes", "_calldata", 3)]
        public virtual byte[] Calldata { get; set; }
    }

    public partial class FacetAddressFunction : FacetAddressFunctionBase { }

    [Function("facetAddress", "address")]
    public class FacetAddressFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "_functionSelector", 1)]
        public virtual byte[] FunctionSelector { get; set; }
    }

    public partial class FacetAddressesFunction : FacetAddressesFunctionBase { }

    [Function("facetAddresses", "address[]")]
    public class FacetAddressesFunctionBase : FunctionMessage
    {

    }

    public partial class FacetFunctionSelectorsFunction : FacetFunctionSelectorsFunctionBase { }

    [Function("facetFunctionSelectors", "bytes4[]")]
    public class FacetFunctionSelectorsFunctionBase : FunctionMessage
    {
        [Parameter("address", "_facet", 1)]
        public virtual string Facet { get; set; }
    }

    public partial class FacetsFunction : FacetsFunctionBase { }

    [Function("facets", typeof(FacetsOutputDTO))]
    public class FacetsFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "_newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class ApproveFunction : ApproveFunctionBase { }

    [Function("approve")]
    public class ApproveFunctionBase : FunctionMessage
    {
        [Parameter("address", "to", 1)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 2)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
    }

    public partial class BurnFunction : BurnFunctionBase { }

    [Function("burn")]
    public class BurnFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class FreeMintFunction : FreeMintFunctionBase { }

    [Function("freeMint", "uint256")]
    public class FreeMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "expiresAt", 1)]
        public virtual BigInteger ExpiresAt { get; set; }
        [Parameter("uint256", "requestsPerKilosecond", 2)]
        public virtual BigInteger RequestsPerKilosecond { get; set; }
        [Parameter("bytes32", "msgHash", 3)]
        public virtual byte[] MsgHash { get; set; }
        [Parameter("uint8", "v", 4)]
        public virtual byte V { get; set; }
        [Parameter("bytes32", "r", 5)]
        public virtual byte[] R { get; set; }
        [Parameter("bytes32", "sVal", 6)]
        public virtual byte[] SVal { get; set; }
    }

    public partial class GetApprovedFunction : GetApprovedFunctionBase { }

    [Function("getApproved", "address")]
    public class GetApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class InitializeFunction : InitializeFunctionBase { }

    [Function("initialize")]
    public class InitializeFunctionBase : FunctionMessage
    {

    }

    public partial class IsApprovedForAllFunction : IsApprovedForAllFunctionBase { }

    [Function("isApprovedForAll", "bool")]
    public class IsApprovedForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2)]
        public virtual string Operator { get; set; }
    }

    public partial class MintFunction : MintFunctionBase { }

    [Function("mint", "uint256")]
    public class MintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "expiresAt", 1)]
        public virtual BigInteger ExpiresAt { get; set; }
    }

    public partial class NameFunction : NameFunctionBase { }

    [Function("name", "string")]
    public class NameFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerOfFunction : OwnerOfFunctionBase { }

    [Function("ownerOf", "address")]
    public class OwnerOfFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFromFunction : SafeTransferFromFunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SafeTransferFrom1Function : SafeTransferFrom1FunctionBase { }

    [Function("safeTransferFrom")]
    public class SafeTransferFrom1FunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "data", 4)]
        public virtual byte[] Data { get; set; }
    }

    public partial class SetAdditionalRequestsPerKilosecondCostFunction : SetAdditionalRequestsPerKilosecondCostFunctionBase { }

    [Function("setAdditionalRequestsPerKilosecondCost")]
    public class SetAdditionalRequestsPerKilosecondCostFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newAdditionalRequestsPerKilosecondCost", 1)]
        public virtual BigInteger NewAdditionalRequestsPerKilosecondCost { get; set; }
    }

    public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

    [Function("setApprovalForAll")]
    public class SetApprovalForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
    }

    public partial class SetFreeMintSignerFunction : SetFreeMintSignerFunctionBase { }

    [Function("setFreeMintSigner")]
    public class SetFreeMintSignerFunctionBase : FunctionMessage
    {
        [Parameter("address", "newFreeMintSigner", 1)]
        public virtual string NewFreeMintSigner { get; set; }
    }

    public partial class SetFreeRequestsPerRateLimitWindowFunction : SetFreeRequestsPerRateLimitWindowFunctionBase { }

    [Function("setFreeRequestsPerRateLimitWindow")]
    public class SetFreeRequestsPerRateLimitWindowFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newFreeRequestsPerRateLimitWindow", 1)]
        public virtual BigInteger NewFreeRequestsPerRateLimitWindow { get; set; }
    }

    public partial class SetMaxExpirationSecondsFunction : SetMaxExpirationSecondsFunctionBase { }

    [Function("setMaxExpirationSeconds")]
    public class SetMaxExpirationSecondsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newMaxExpirationSeconds", 1)]
        public virtual BigInteger NewMaxExpirationSeconds { get; set; }
    }

    public partial class SetMaxRequestsPerKilosecondFunction : SetMaxRequestsPerKilosecondFunctionBase { }

    [Function("setMaxRequestsPerKilosecond")]
    public class SetMaxRequestsPerKilosecondFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newMaxRequestsPerKilosecond", 1)]
        public virtual BigInteger NewMaxRequestsPerKilosecond { get; set; }
    }

    public partial class SetRLIHolderRateLimitWindowSecondsFunction : SetRLIHolderRateLimitWindowSecondsFunctionBase { }

    [Function("setRLIHolderRateLimitWindowSeconds")]
    public class SetRLIHolderRateLimitWindowSecondsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newRLIHolderRateLimitWindowSeconds", 1)]
        public virtual BigInteger NewRLIHolderRateLimitWindowSeconds { get; set; }
    }

    public partial class SetRateLimitWindowSecondsFunction : SetRateLimitWindowSecondsFunctionBase { }

    [Function("setRateLimitWindowSeconds")]
    public class SetRateLimitWindowSecondsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newRateLimitWindowSeconds", 1)]
        public virtual BigInteger NewRateLimitWindowSeconds { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class SymbolFunction : SymbolFunctionBase { }

    [Function("symbol", "string")]
    public class SymbolFunctionBase : FunctionMessage
    {

    }

    public partial class TokenByIndexFunction : TokenByIndexFunctionBase { }

    [Function("tokenByIndex", "uint256")]
    public class TokenByIndexFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "index", 1)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class TokenOfOwnerByIndexFunction : TokenOfOwnerByIndexFunctionBase { }

    [Function("tokenOfOwnerByIndex", "uint256")]
    public class TokenOfOwnerByIndexFunctionBase : FunctionMessage
    {
        [Parameter("address", "owner", 1)]
        public virtual string Owner { get; set; }
        [Parameter("uint256", "index", 2)]
        public virtual BigInteger Index { get; set; }
    }

    public partial class TokenURIFunction : TokenURIFunctionBase { }

    [Function("tokenURI", "string")]
    public class TokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

    [Function("totalSupply", "uint256")]
    public class TotalSupplyFunctionBase : FunctionMessage
    {

    }

    public partial class TransferFromFunction : TransferFromFunctionBase { }

    [Function("transferFrom")]
    public class TransferFromFunctionBase : FunctionMessage
    {
        [Parameter("address", "from", 1)]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2)]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw")]
    public class WithdrawFunctionBase : FunctionMessage
    {

    }

    public partial class RLIHolderRateLimitWindowSecondsFunction : RLIHolderRateLimitWindowSecondsFunctionBase { }

    [Function("RLIHolderRateLimitWindowSeconds", "uint256")]
    public class RLIHolderRateLimitWindowSecondsFunctionBase : FunctionMessage
    {

    }

    public partial class AdditionalRequestsPerKilosecondCostFunction : AdditionalRequestsPerKilosecondCostFunctionBase { }

    [Function("additionalRequestsPerKilosecondCost", "uint256")]
    public class AdditionalRequestsPerKilosecondCostFunctionBase : FunctionMessage
    {

    }

    public partial class CalculateCostFunction : CalculateCostFunctionBase { }

    [Function("calculateCost", "uint256")]
    public class CalculateCostFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "requestsPerKilosecond", 1)]
        public virtual BigInteger RequestsPerKilosecond { get; set; }
        [Parameter("uint256", "expiresAt", 2)]
        public virtual BigInteger ExpiresAt { get; set; }
    }

    public partial class CalculateRequestsPerKilosecondFunction : CalculateRequestsPerKilosecondFunctionBase { }

    [Function("calculateRequestsPerKilosecond", "uint256")]
    public class CalculateRequestsPerKilosecondFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "payingAmount", 1)]
        public virtual BigInteger PayingAmount { get; set; }
        [Parameter("uint256", "expiresAt", 2)]
        public virtual BigInteger ExpiresAt { get; set; }
    }

    public partial class CapacityFunction : CapacityFunctionBase { }

    [Function("capacity", typeof(CapacityOutputDTO))]
    public class CapacityFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class CheckBelowMaxRequestsPerKilosecondFunction : CheckBelowMaxRequestsPerKilosecondFunctionBase { }

    [Function("checkBelowMaxRequestsPerKilosecond", "bool")]
    public class CheckBelowMaxRequestsPerKilosecondFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "requestedRequestsPerKilosecond", 1)]
        public virtual BigInteger RequestedRequestsPerKilosecond { get; set; }
    }

    public partial class CurrentSoldRequestsPerKilosecondFunction : CurrentSoldRequestsPerKilosecondFunctionBase { }

    [Function("currentSoldRequestsPerKilosecond", "uint256")]
    public class CurrentSoldRequestsPerKilosecondFunctionBase : FunctionMessage
    {

    }

    public partial class DefaultRateLimitWindowSecondsFunction : DefaultRateLimitWindowSecondsFunctionBase { }

    [Function("defaultRateLimitWindowSeconds", "uint256")]
    public class DefaultRateLimitWindowSecondsFunctionBase : FunctionMessage
    {

    }

    public partial class FreeMintSignerFunction : FreeMintSignerFunctionBase { }

    [Function("freeMintSigner", "address")]
    public class FreeMintSignerFunctionBase : FunctionMessage
    {

    }

    public partial class FreeRequestsPerRateLimitWindowFunction : FreeRequestsPerRateLimitWindowFunctionBase { }

    [Function("freeRequestsPerRateLimitWindow", "uint256")]
    public class FreeRequestsPerRateLimitWindowFunctionBase : FunctionMessage
    {

    }

    public partial class IsExpiredFunction : IsExpiredFunctionBase { }

    [Function("isExpired", "bool")]
    public class IsExpiredFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class MaxExpirationSecondsFunction : MaxExpirationSecondsFunctionBase { }

    [Function("maxExpirationSeconds", "uint256")]
    public class MaxExpirationSecondsFunctionBase : FunctionMessage
    {

    }

    public partial class MaxRequestsPerKilosecondFunction : MaxRequestsPerKilosecondFunctionBase { }

    [Function("maxRequestsPerKilosecond", "uint256")]
    public class MaxRequestsPerKilosecondFunctionBase : FunctionMessage
    {

    }

    public partial class PrefixedFunction : PrefixedFunctionBase { }

    [Function("prefixed", "bytes32")]
    public class PrefixedFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "hash", 1)]
        public virtual byte[] Hash { get; set; }
    }

    public partial class RedeemedFreeMintsFunction : RedeemedFreeMintsFunctionBase { }

    [Function("redeemedFreeMints", "bool")]
    public class RedeemedFreeMintsFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "msgHash", 1)]
        public virtual byte[] MsgHash { get; set; }
    }

    public partial class TokenIdCounterFunction : TokenIdCounterFunctionBase { }

    [Function("tokenIdCounter", "uint256")]
    public class TokenIdCounterFunctionBase : FunctionMessage
    {

    }

    public partial class TokenSVGFunction : TokenSVGFunctionBase { }

    [Function("tokenSVG", "string")]
    public class TokenSVGFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class TotalSoldRequestsPerKilosecondByExpirationTimeFunction : TotalSoldRequestsPerKilosecondByExpirationTimeFunctionBase { }

    [Function("totalSoldRequestsPerKilosecondByExpirationTime", "uint256")]
    public class TotalSoldRequestsPerKilosecondByExpirationTimeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "expiresAt", 1)]
        public virtual BigInteger ExpiresAt { get; set; }
    }

    public partial class DiamondCutEventDTO : DiamondCutEventDTOBase { }

    [Event("DiamondCut")]
    public class DiamondCutEventDTOBase : IEventDTO
    {
        [Parameter("tuple[]", "_diamondCut", 1, false )]
        public virtual List<FacetCut> DiamondCut { get; set; }
        [Parameter("address", "_init", 2, false )]
        public virtual string Init { get; set; }
        [Parameter("bytes", "_calldata", 3, false )]
        public virtual byte[] Calldata { get; set; }
    }

    public partial class OwnershipTransferredEventDTO : OwnershipTransferredEventDTOBase { }

    [Event("OwnershipTransferred")]
    public class OwnershipTransferredEventDTOBase : IEventDTO
    {
        [Parameter("address", "previousOwner", 1, true )]
        public virtual string PreviousOwner { get; set; }
        [Parameter("address", "newOwner", 2, true )]
        public virtual string NewOwner { get; set; }
    }

    public partial class AdditionalRequestsPerKilosecondCostSetEventDTO : AdditionalRequestsPerKilosecondCostSetEventDTOBase { }

    [Event("AdditionalRequestsPerKilosecondCostSet")]
    public class AdditionalRequestsPerKilosecondCostSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newAdditionalRequestsPerKilosecondCost", 1, false )]
        public virtual BigInteger NewAdditionalRequestsPerKilosecondCost { get; set; }
    }

    public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

    [Event("Approval")]
    public class ApprovalEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "approved", 2, true )]
        public virtual string Approved { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class ApprovalForAllEventDTO : ApprovalForAllEventDTOBase { }

    [Event("ApprovalForAll")]
    public class ApprovalForAllEventDTOBase : IEventDTO
    {
        [Parameter("address", "owner", 1, true )]
        public virtual string Owner { get; set; }
        [Parameter("address", "operator", 2, true )]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 3, false )]
        public virtual bool Approved { get; set; }
    }

    public partial class FreeMintSignerSetEventDTO : FreeMintSignerSetEventDTOBase { }

    [Event("FreeMintSignerSet")]
    public class FreeMintSignerSetEventDTOBase : IEventDTO
    {
        [Parameter("address", "newFreeMintSigner", 1, true )]
        public virtual string NewFreeMintSigner { get; set; }
    }

    public partial class FreeRequestsPerRateLimitWindowSetEventDTO : FreeRequestsPerRateLimitWindowSetEventDTOBase { }

    [Event("FreeRequestsPerRateLimitWindowSet")]
    public class FreeRequestsPerRateLimitWindowSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newFreeRequestsPerRateLimitWindow", 1, false )]
        public virtual BigInteger NewFreeRequestsPerRateLimitWindow { get; set; }
    }

    public partial class InitializedEventDTO : InitializedEventDTOBase { }

    [Event("Initialized")]
    public class InitializedEventDTOBase : IEventDTO
    {
        [Parameter("uint8", "version", 1, false )]
        public virtual byte Version { get; set; }
    }

    public partial class RLIHolderRateLimitWindowSecondsSetEventDTO : RLIHolderRateLimitWindowSecondsSetEventDTOBase { }

    [Event("RLIHolderRateLimitWindowSecondsSet")]
    public class RLIHolderRateLimitWindowSecondsSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newRLIHolderRateLimitWindowSeconds", 1, false )]
        public virtual BigInteger NewRLIHolderRateLimitWindowSeconds { get; set; }
    }

    public partial class RateLimitWindowSecondsSetEventDTO : RateLimitWindowSecondsSetEventDTOBase { }

    [Event("RateLimitWindowSecondsSet")]
    public class RateLimitWindowSecondsSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newRateLimitWindowSeconds", 1, false )]
        public virtual BigInteger NewRateLimitWindowSeconds { get; set; }
    }

    public partial class TransferEventDTO : TransferEventDTOBase { }

    [Event("Transfer")]
    public class TransferEventDTOBase : IEventDTO
    {
        [Parameter("address", "from", 1, true )]
        public virtual string From { get; set; }
        [Parameter("address", "to", 2, true )]
        public virtual string To { get; set; }
        [Parameter("uint256", "tokenId", 3, true )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class WithdrewEventDTO : WithdrewEventDTOBase { }

    [Event("Withdrew")]
    public class WithdrewEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "amount", 1, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class CannotAddFunctionToDiamondThatAlreadyExistsError : CannotAddFunctionToDiamondThatAlreadyExistsErrorBase { }

    [Error("CannotAddFunctionToDiamondThatAlreadyExists")]
    public class CannotAddFunctionToDiamondThatAlreadyExistsErrorBase : IErrorDTO
    {
        [Parameter("bytes4", "_selector", 1)]
        public virtual byte[] Selector { get; set; }
    }

    public partial class CannotAddSelectorsToZeroAddressError : CannotAddSelectorsToZeroAddressErrorBase { }

    [Error("CannotAddSelectorsToZeroAddress")]
    public class CannotAddSelectorsToZeroAddressErrorBase : IErrorDTO
    {
        [Parameter("bytes4[]", "_selectors", 1)]
        public virtual List<byte[]> Selectors { get; set; }
    }

    public partial class CannotRemoveFunctionThatDoesNotExistError : CannotRemoveFunctionThatDoesNotExistErrorBase { }

    [Error("CannotRemoveFunctionThatDoesNotExist")]
    public class CannotRemoveFunctionThatDoesNotExistErrorBase : IErrorDTO
    {
        [Parameter("bytes4", "_selector", 1)]
        public virtual byte[] Selector { get; set; }
    }

    public partial class CannotRemoveImmutableFunctionError : CannotRemoveImmutableFunctionErrorBase { }

    [Error("CannotRemoveImmutableFunction")]
    public class CannotRemoveImmutableFunctionErrorBase : IErrorDTO
    {
        [Parameter("bytes4", "_selector", 1)]
        public virtual byte[] Selector { get; set; }
    }

    public partial class CannotReplaceFunctionThatDoesNotExistsError : CannotReplaceFunctionThatDoesNotExistsErrorBase { }

    [Error("CannotReplaceFunctionThatDoesNotExists")]
    public class CannotReplaceFunctionThatDoesNotExistsErrorBase : IErrorDTO
    {
        [Parameter("bytes4", "_selector", 1)]
        public virtual byte[] Selector { get; set; }
    }

    public partial class CannotReplaceFunctionWithTheSameFunctionFromTheSameFacetError : CannotReplaceFunctionWithTheSameFunctionFromTheSameFacetErrorBase { }

    [Error("CannotReplaceFunctionWithTheSameFunctionFromTheSameFacet")]
    public class CannotReplaceFunctionWithTheSameFunctionFromTheSameFacetErrorBase : IErrorDTO
    {
        [Parameter("bytes4", "_selector", 1)]
        public virtual byte[] Selector { get; set; }
    }

    public partial class CannotReplaceFunctionsFromFacetWithZeroAddressError : CannotReplaceFunctionsFromFacetWithZeroAddressErrorBase { }

    [Error("CannotReplaceFunctionsFromFacetWithZeroAddress")]
    public class CannotReplaceFunctionsFromFacetWithZeroAddressErrorBase : IErrorDTO
    {
        [Parameter("bytes4[]", "_selectors", 1)]
        public virtual List<byte[]> Selectors { get; set; }
    }

    public partial class CannotReplaceImmutableFunctionError : CannotReplaceImmutableFunctionErrorBase { }

    [Error("CannotReplaceImmutableFunction")]
    public class CannotReplaceImmutableFunctionErrorBase : IErrorDTO
    {
        [Parameter("bytes4", "_selector", 1)]
        public virtual byte[] Selector { get; set; }
    }

    public partial class IncorrectFacetCutActionError : IncorrectFacetCutActionErrorBase { }

    [Error("IncorrectFacetCutAction")]
    public class IncorrectFacetCutActionErrorBase : IErrorDTO
    {
        [Parameter("uint8", "_action", 1)]
        public virtual byte Action { get; set; }
    }

    public partial class InitializationFunctionRevertedError : InitializationFunctionRevertedErrorBase { }

    [Error("InitializationFunctionReverted")]
    public class InitializationFunctionRevertedErrorBase : IErrorDTO
    {
        [Parameter("address", "_initializationContractAddress", 1)]
        public virtual string InitializationContractAddress { get; set; }
        [Parameter("bytes", "_calldata", 2)]
        public virtual byte[] Calldata { get; set; }
    }

    public partial class NoBytecodeAtAddressError : NoBytecodeAtAddressErrorBase { }

    [Error("NoBytecodeAtAddress")]
    public class NoBytecodeAtAddressErrorBase : IErrorDTO
    {
        [Parameter("address", "_contractAddress", 1)]
        public virtual string ContractAddress { get; set; }
        [Parameter("string", "_message", 2)]
        public virtual string Message { get; set; }
    }

    public partial class NoSelectorsProvidedForFacetForCutError : NoSelectorsProvidedForFacetForCutErrorBase { }

    [Error("NoSelectorsProvidedForFacetForCut")]
    public class NoSelectorsProvidedForFacetForCutErrorBase : IErrorDTO
    {
        [Parameter("address", "_facetAddress", 1)]
        public virtual string FacetAddress { get; set; }
    }

    public partial class NotContractOwnerError : NotContractOwnerErrorBase { }

    [Error("NotContractOwner")]
    public class NotContractOwnerErrorBase : IErrorDTO
    {
        [Parameter("address", "_user", 1)]
        public virtual string User { get; set; }
        [Parameter("address", "_contractOwner", 2)]
        public virtual string ContractOwner { get; set; }
    }

    public partial class RemoveFacetAddressMustBeZeroAddressError : RemoveFacetAddressMustBeZeroAddressErrorBase { }

    [Error("RemoveFacetAddressMustBeZeroAddress")]
    public class RemoveFacetAddressMustBeZeroAddressErrorBase : IErrorDTO
    {
        [Parameter("address", "_facetAddress", 1)]
        public virtual string FacetAddress { get; set; }
    }

    public partial class CallerNotOwnerError : CallerNotOwnerErrorBase { }
    [Error("CallerNotOwner")]
    public class CallerNotOwnerErrorBase : IErrorDTO
    {
    }



    public partial class FacetAddressOutputDTO : FacetAddressOutputDTOBase { }

    [FunctionOutput]
    public class FacetAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "facetAddress_", 1)]
        public virtual string Facetaddress { get; set; }
    }

    public partial class FacetAddressesOutputDTO : FacetAddressesOutputDTOBase { }

    [FunctionOutput]
    public class FacetAddressesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "facetAddresses_", 1)]
        public virtual List<string> Facetaddresses { get; set; }
    }

    public partial class FacetFunctionSelectorsOutputDTO : FacetFunctionSelectorsOutputDTOBase { }

    [FunctionOutput]
    public class FacetFunctionSelectorsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes4[]", "_facetFunctionSelectors", 1)]
        public virtual List<byte[]> FacetFunctionSelectors { get; set; }
    }

    public partial class FacetsOutputDTO : FacetsOutputDTOBase { }

    [FunctionOutput]
    public class FacetsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "facets_", 1)]
        public virtual List<Facet> Facets { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "owner_", 1)]
        public virtual string Owner { get; set; }
    }





    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

    [FunctionOutput]
    public class GetApprovedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }



    public partial class IsApprovedForAllOutputDTO : IsApprovedForAllOutputDTOBase { }

    [FunctionOutput]
    public class IsApprovedForAllOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class NameOutputDTO : NameOutputDTOBase { }

    [FunctionOutput]
    public class NameOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class OwnerOfOutputDTO : OwnerOfOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





















    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

    [FunctionOutput]
    public class SymbolOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TokenByIndexOutputDTO : TokenByIndexOutputDTOBase { }

    [FunctionOutput]
    public class TokenByIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TokenOfOwnerByIndexOutputDTO : TokenOfOwnerByIndexOutputDTOBase { }

    [FunctionOutput]
    public class TokenOfOwnerByIndexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TokenURIOutputDTO : TokenURIOutputDTOBase { }

    [FunctionOutput]
    public class TokenURIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

    [FunctionOutput]
    public class TotalSupplyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }





    public partial class RLIHolderRateLimitWindowSecondsOutputDTO : RLIHolderRateLimitWindowSecondsOutputDTOBase { }

    [FunctionOutput]
    public class RLIHolderRateLimitWindowSecondsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class AdditionalRequestsPerKilosecondCostOutputDTO : AdditionalRequestsPerKilosecondCostOutputDTOBase { }

    [FunctionOutput]
    public class AdditionalRequestsPerKilosecondCostOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CalculateCostOutputDTO : CalculateCostOutputDTOBase { }

    [FunctionOutput]
    public class CalculateCostOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CalculateRequestsPerKilosecondOutputDTO : CalculateRequestsPerKilosecondOutputDTOBase { }

    [FunctionOutput]
    public class CalculateRequestsPerKilosecondOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CapacityOutputDTO : CapacityOutputDTOBase { }

    [FunctionOutput]
    public class CapacityOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual RateLimit ReturnValue1 { get; set; }
    }

    public partial class CheckBelowMaxRequestsPerKilosecondOutputDTO : CheckBelowMaxRequestsPerKilosecondOutputDTOBase { }

    [FunctionOutput]
    public class CheckBelowMaxRequestsPerKilosecondOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class CurrentSoldRequestsPerKilosecondOutputDTO : CurrentSoldRequestsPerKilosecondOutputDTOBase { }

    [FunctionOutput]
    public class CurrentSoldRequestsPerKilosecondOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class DefaultRateLimitWindowSecondsOutputDTO : DefaultRateLimitWindowSecondsOutputDTOBase { }

    [FunctionOutput]
    public class DefaultRateLimitWindowSecondsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class FreeMintSignerOutputDTO : FreeMintSignerOutputDTOBase { }

    [FunctionOutput]
    public class FreeMintSignerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class FreeRequestsPerRateLimitWindowOutputDTO : FreeRequestsPerRateLimitWindowOutputDTOBase { }

    [FunctionOutput]
    public class FreeRequestsPerRateLimitWindowOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class IsExpiredOutputDTO : IsExpiredOutputDTOBase { }

    [FunctionOutput]
    public class IsExpiredOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class MaxExpirationSecondsOutputDTO : MaxExpirationSecondsOutputDTOBase { }

    [FunctionOutput]
    public class MaxExpirationSecondsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class MaxRequestsPerKilosecondOutputDTO : MaxRequestsPerKilosecondOutputDTOBase { }

    [FunctionOutput]
    public class MaxRequestsPerKilosecondOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class PrefixedOutputDTO : PrefixedOutputDTOBase { }

    [FunctionOutput]
    public class PrefixedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class RedeemedFreeMintsOutputDTO : RedeemedFreeMintsOutputDTOBase { }

    [FunctionOutput]
    public class RedeemedFreeMintsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class TokenIdCounterOutputDTO : TokenIdCounterOutputDTOBase { }

    [FunctionOutput]
    public class TokenIdCounterOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class TokenSVGOutputDTO : TokenSVGOutputDTOBase { }

    [FunctionOutput]
    public class TokenSVGOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class TotalSoldRequestsPerKilosecondByExpirationTimeOutputDTO : TotalSoldRequestsPerKilosecondByExpirationTimeOutputDTOBase { }

    [FunctionOutput]
    public class TotalSoldRequestsPerKilosecondByExpirationTimeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
