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

namespace LitContracts.PubkeyRouter.ContractDefinition
{


    public partial class PubkeyRouterDeployment : PubkeyRouterDeploymentBase
    {
        public PubkeyRouterDeployment() : base(BYTECODE) { }
        public PubkeyRouterDeployment(string byteCode) : base(byteCode) { }
    }

    public class PubkeyRouterDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public PubkeyRouterDeploymentBase() : base(BYTECODE) { }
        public PubkeyRouterDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "_interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
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

    public partial class CheckNodeSignaturesFunction : CheckNodeSignaturesFunctionBase { }

    [Function("checkNodeSignatures", "bool")]
    public class CheckNodeSignaturesFunctionBase : FunctionMessage
    {
        [Parameter("tuple[]", "signatures", 1)]
        public virtual List<Signature> Signatures { get; set; }
        [Parameter("bytes", "signedMessage", 2)]
        public virtual byte[] SignedMessage { get; set; }
        [Parameter("address", "stakingContractAddress", 3)]
        public virtual string StakingContractAddress { get; set; }
    }

    public partial class DeriveEthAddressFromPubkeyFunction : DeriveEthAddressFromPubkeyFunctionBase { }

    [Function("deriveEthAddressFromPubkey", "address")]
    public class DeriveEthAddressFromPubkeyFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "pubkey", 1)]
        public virtual byte[] Pubkey { get; set; }
    }

    public partial class EthAddressToPkpIdFunction : EthAddressToPkpIdFunctionBase { }

    [Function("ethAddressToPkpId", "uint256")]
    public class EthAddressToPkpIdFunctionBase : FunctionMessage
    {
        [Parameter("address", "ethAddress", 1)]
        public virtual string EthAddress { get; set; }
    }

    public partial class GetDerivedPubkeyFunction : GetDerivedPubkeyFunctionBase { }

    [Function("getDerivedPubkey", "bytes")]
    public class GetDerivedPubkeyFunctionBase : FunctionMessage
    {
        [Parameter("address", "stakingContract", 1)]
        public virtual string StakingContract { get; set; }
        [Parameter("bytes32", "derivedKeyId", 2)]
        public virtual byte[] DerivedKeyId { get; set; }
    }

    public partial class GetEthAddressFunction : GetEthAddressFunctionBase { }

    [Function("getEthAddress", "address")]
    public class GetEthAddressFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetPkpNftAddressFunction : GetPkpNftAddressFunctionBase { }

    [Function("getPkpNftAddress", "address")]
    public class GetPkpNftAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetPubkeyFunction : GetPubkeyFunctionBase { }

    [Function("getPubkey", "bytes")]
    public class GetPubkeyFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetRootKeysFunction : GetRootKeysFunctionBase { }

    [Function("getRootKeys", typeof(GetRootKeysOutputDTO))]
    public class GetRootKeysFunctionBase : FunctionMessage
    {
        [Parameter("address", "stakingContract", 1)]
        public virtual string StakingContract { get; set; }
    }

    public partial class GetRoutingDataFunction : GetRoutingDataFunctionBase { }

    [Function("getRoutingData", typeof(GetRoutingDataOutputDTO))]
    public class GetRoutingDataFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class IsRoutedFunction : IsRoutedFunctionBase { }

    [Function("isRouted", "bool")]
    public class IsRoutedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class PubkeysFunction : PubkeysFunctionBase { }

    [Function("pubkeys", typeof(PubkeysOutputDTO))]
    public class PubkeysFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class SetContractResolverFunction : SetContractResolverFunctionBase { }

    [Function("setContractResolver")]
    public class SetContractResolverFunctionBase : FunctionMessage
    {
        [Parameter("address", "newResolverAddress", 1)]
        public virtual string NewResolverAddress { get; set; }
    }

    public partial class SetRoutingDataFunction : SetRoutingDataFunctionBase { }

    [Function("setRoutingData")]
    public class SetRoutingDataFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "pubkey", 2)]
        public virtual byte[] Pubkey { get; set; }
        [Parameter("address", "stakingContractAddress", 3)]
        public virtual string StakingContractAddress { get; set; }
        [Parameter("uint256", "keyType", 4)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("bytes32", "derivedKeyId", 5)]
        public virtual byte[] DerivedKeyId { get; set; }
    }

    public partial class SetRoutingDataAsAdminFunction : SetRoutingDataAsAdminFunctionBase { }

    [Function("setRoutingDataAsAdmin")]
    public class SetRoutingDataAsAdminFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "pubkey", 2)]
        public virtual byte[] Pubkey { get; set; }
        [Parameter("address", "stakingContract", 3)]
        public virtual string StakingContract { get; set; }
        [Parameter("uint256", "keyType", 4)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("bytes32", "derivedKeyId", 5)]
        public virtual byte[] DerivedKeyId { get; set; }
    }

    public partial class VoteForRootKeysFunction : VoteForRootKeysFunctionBase { }

    [Function("voteForRootKeys")]
    public class VoteForRootKeysFunctionBase : FunctionMessage
    {
        [Parameter("address", "stakingContractAddress", 1)]
        public virtual string StakingContractAddress { get; set; }
        [Parameter("tuple[]", "newRootKeys", 2)]
        public virtual List<RootKey> NewRootKeys { get; set; }
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

    public partial class ContractResolverAddressSetEventDTO : ContractResolverAddressSetEventDTOBase { }

    [Event("ContractResolverAddressSet")]
    public class ContractResolverAddressSetEventDTOBase : IEventDTO
    {
        [Parameter("address", "newResolverAddress", 1, false )]
        public virtual string NewResolverAddress { get; set; }
    }

    public partial class PubkeyRoutingDataSetEventDTO : PubkeyRoutingDataSetEventDTOBase { }

    [Event("PubkeyRoutingDataSet")]
    public class PubkeyRoutingDataSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, true )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "pubkey", 2, false )]
        public virtual byte[] Pubkey { get; set; }
        [Parameter("address", "stakingContract", 3, false )]
        public virtual string StakingContract { get; set; }
        [Parameter("uint256", "keyType", 4, false )]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("bytes32", "derivedKeyId", 5, false )]
        public virtual byte[] DerivedKeyId { get; set; }
    }

    public partial class RootKeySetEventDTO : RootKeySetEventDTOBase { }

    [Event("RootKeySet")]
    public class RootKeySetEventDTOBase : IEventDTO
    {
        [Parameter("address", "stakingContract", 1, false )]
        public virtual string StakingContract { get; set; }
        [Parameter("tuple", "rootKey", 2, false )]
        public virtual RootKey RootKey { get; set; }
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

    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "owner_", 1)]
        public virtual string Owner { get; set; }
    }



    public partial class CheckNodeSignaturesOutputDTO : CheckNodeSignaturesOutputDTOBase { }

    [FunctionOutput]
    public class CheckNodeSignaturesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class DeriveEthAddressFromPubkeyOutputDTO : DeriveEthAddressFromPubkeyOutputDTOBase { }

    [FunctionOutput]
    public class DeriveEthAddressFromPubkeyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class EthAddressToPkpIdOutputDTO : EthAddressToPkpIdOutputDTOBase { }

    [FunctionOutput]
    public class EthAddressToPkpIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetDerivedPubkeyOutputDTO : GetDerivedPubkeyOutputDTOBase { }

    [FunctionOutput]
    public class GetDerivedPubkeyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetEthAddressOutputDTO : GetEthAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetEthAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetPkpNftAddressOutputDTO : GetPkpNftAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetPkpNftAddressOutputDTOBase : IFunctionOutputDTO 
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

    public partial class GetRootKeysOutputDTO : GetRootKeysOutputDTOBase { }

    [FunctionOutput]
    public class GetRootKeysOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<RootKey> ReturnValue1 { get; set; }
    }

    public partial class GetRoutingDataOutputDTO : GetRoutingDataOutputDTOBase { }

    [FunctionOutput]
    public class GetRoutingDataOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual PubkeyRoutingData ReturnValue1 { get; set; }
    }

    public partial class IsRoutedOutputDTO : IsRoutedOutputDTOBase { }

    [FunctionOutput]
    public class IsRoutedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class PubkeysOutputDTO : PubkeysOutputDTOBase { }

    [FunctionOutput]
    public class PubkeysOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual PubkeyRoutingData ReturnValue1 { get; set; }
    }








}
