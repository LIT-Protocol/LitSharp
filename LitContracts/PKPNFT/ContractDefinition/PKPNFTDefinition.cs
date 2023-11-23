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

namespace LitContracts.PKPNFT.ContractDefinition
{


    public partial class PkpnftDeployment : PkpnftDeploymentBase
    {
        public PkpnftDeployment() : base(BYTECODE) { }
        public PkpnftDeployment(string byteCode) : base(byteCode) { }
    }

    public class PkpnftDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public PkpnftDeploymentBase() : base(BYTECODE) { }
        public PkpnftDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class ClaimAndMintFunction : ClaimAndMintFunctionBase { }

    [Function("claimAndMint", "uint256")]
    public class ClaimAndMintFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "keyType", 1)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("bytes32", "derivedKeyId", 2)]
        public virtual byte[] DerivedKeyId { get; set; }
        [Parameter("tuple[]", "signatures", 3)]
        public virtual List<Signature> Signatures { get; set; }
    }

    public partial class ExistsFunction : ExistsFunctionBase { }

    [Function("exists", "bool")]
    public class ExistsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class FreeMintSignerFunction : FreeMintSignerFunctionBase { }

    [Function("freeMintSigner", "address")]
    public class FreeMintSignerFunctionBase : FunctionMessage
    {

    }

    public partial class GetApprovedFunction : GetApprovedFunctionBase { }

    [Function("getApproved", "address")]
    public class GetApprovedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetEthAddressFunction : GetEthAddressFunctionBase { }

    [Function("getEthAddress", "address")]
    public class GetEthAddressFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetNextDerivedKeyIdFunction : GetNextDerivedKeyIdFunctionBase { }

    [Function("getNextDerivedKeyId", "bytes32")]
    public class GetNextDerivedKeyIdFunctionBase : FunctionMessage
    {

    }

    public partial class GetPkpNftMetadataAddressFunction : GetPkpNftMetadataAddressFunctionBase { }

    [Function("getPkpNftMetadataAddress", "address")]
    public class GetPkpNftMetadataAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetPkpPermissionsAddressFunction : GetPkpPermissionsAddressFunctionBase { }

    [Function("getPkpPermissionsAddress", "address")]
    public class GetPkpPermissionsAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetPubkeyFunction : GetPubkeyFunctionBase { }

    [Function("getPubkey", "bytes")]
    public class GetPubkeyFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetRouterAddressFunction : GetRouterAddressFunctionBase { }

    [Function("getRouterAddress", "address")]
    public class GetRouterAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetStakingAddressFunction : GetStakingAddressFunctionBase { }

    [Function("getStakingAddress", "address")]
    public class GetStakingAddressFunctionBase : FunctionMessage
    {

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

    public partial class MintCostFunction : MintCostFunctionBase { }

    [Function("mintCost", "uint256")]
    public class MintCostFunctionBase : FunctionMessage
    {

    }

    public partial class MintGrantAndBurnNextFunction : MintGrantAndBurnNextFunctionBase { }

    [Function("mintGrantAndBurnNext", "uint256")]
    public class MintGrantAndBurnNextFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "keyType", 1)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("bytes", "ipfsCID", 2)]
        public virtual byte[] IpfsCID { get; set; }
    }

    public partial class MintNextFunction : MintNextFunctionBase { }

    [Function("mintNext", "uint256")]
    public class MintNextFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "keyType", 1)]
        public virtual BigInteger KeyType { get; set; }
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

    public partial class PrefixedFunction : PrefixedFunctionBase { }

    [Function("prefixed", "bytes32")]
    public class PrefixedFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "hash", 1)]
        public virtual byte[] Hash { get; set; }
    }

    public partial class RedeemedFreeMintIdsFunction : RedeemedFreeMintIdsFunctionBase { }

    [Function("redeemedFreeMintIds", "bool")]
    public class RedeemedFreeMintIdsFunctionBase : FunctionMessage
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

    public partial class SetApprovalForAllFunction : SetApprovalForAllFunctionBase { }

    [Function("setApprovalForAll")]
    public class SetApprovalForAllFunctionBase : FunctionMessage
    {
        [Parameter("address", "operator", 1)]
        public virtual string Operator { get; set; }
        [Parameter("bool", "approved", 2)]
        public virtual bool Approved { get; set; }
    }

    public partial class SetContractResolverFunction : SetContractResolverFunctionBase { }

    [Function("setContractResolver")]
    public class SetContractResolverFunctionBase : FunctionMessage
    {
        [Parameter("address", "newResolverAddress", 1)]
        public virtual string NewResolverAddress { get; set; }
    }

    public partial class SetFreeMintSignerFunction : SetFreeMintSignerFunctionBase { }

    [Function("setFreeMintSigner")]
    public class SetFreeMintSignerFunctionBase : FunctionMessage
    {
        [Parameter("address", "newFreeMintSigner", 1)]
        public virtual string NewFreeMintSigner { get; set; }
    }

    public partial class SetMintCostFunction : SetMintCostFunctionBase { }

    [Function("setMintCost")]
    public class SetMintCostFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newMintCost", 1)]
        public virtual BigInteger NewMintCost { get; set; }
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

    public partial class ContractResolverAddressSetEventDTO : ContractResolverAddressSetEventDTOBase { }

    [Event("ContractResolverAddressSet")]
    public class ContractResolverAddressSetEventDTOBase : IEventDTO
    {
        [Parameter("address", "newResolverAddress", 1, false )]
        public virtual string NewResolverAddress { get; set; }
    }

    public partial class FreeMintSignerSetEventDTO : FreeMintSignerSetEventDTOBase { }

    [Event("FreeMintSignerSet")]
    public class FreeMintSignerSetEventDTOBase : IEventDTO
    {
        [Parameter("address", "newFreeMintSigner", 1, true )]
        public virtual string NewFreeMintSigner { get; set; }
    }

    public partial class InitializedEventDTO : InitializedEventDTOBase { }

    [Event("Initialized")]
    public class InitializedEventDTOBase : IEventDTO
    {
        [Parameter("uint8", "version", 1, false )]
        public virtual byte Version { get; set; }
    }

    public partial class MintCostSetEventDTO : MintCostSetEventDTOBase { }

    [Event("MintCostSet")]
    public class MintCostSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newMintCost", 1, false )]
        public virtual BigInteger NewMintCost { get; set; }
    }

    public partial class PKPMintedEventDTO : PKPMintedEventDTOBase { }

    [Event("PKPMinted")]
    public class PKPMintedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, true )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "pubkey", 2, false )]
        public virtual byte[] Pubkey { get; set; }
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





    public partial class ExistsOutputDTO : ExistsOutputDTOBase { }

    [FunctionOutput]
    public class ExistsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class FreeMintSignerOutputDTO : FreeMintSignerOutputDTOBase { }

    [FunctionOutput]
    public class FreeMintSignerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetApprovedOutputDTO : GetApprovedOutputDTOBase { }

    [FunctionOutput]
    public class GetApprovedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetEthAddressOutputDTO : GetEthAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetEthAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetNextDerivedKeyIdOutputDTO : GetNextDerivedKeyIdOutputDTOBase { }

    [FunctionOutput]
    public class GetNextDerivedKeyIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetPkpNftMetadataAddressOutputDTO : GetPkpNftMetadataAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetPkpNftMetadataAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetPkpPermissionsAddressOutputDTO : GetPkpPermissionsAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetPkpPermissionsAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetPubkeyOutputDTO : GetPubkeyOutputDTOBase { }

    [FunctionOutput]
    public class GetPubkeyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetRouterAddressOutputDTO : GetRouterAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetRouterAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetStakingAddressOutputDTO : GetStakingAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetStakingAddressOutputDTOBase : IFunctionOutputDTO 
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

    public partial class MintCostOutputDTO : MintCostOutputDTOBase { }

    [FunctionOutput]
    public class MintCostOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
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

    public partial class PrefixedOutputDTO : PrefixedOutputDTOBase { }

    [FunctionOutput]
    public class PrefixedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class RedeemedFreeMintIdsOutputDTO : RedeemedFreeMintIdsOutputDTOBase { }

    [FunctionOutput]
    public class RedeemedFreeMintIdsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
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




}
