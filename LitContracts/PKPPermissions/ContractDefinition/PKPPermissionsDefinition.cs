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

namespace LitContracts.PKPPermissions.ContractDefinition
{


    public partial class PKPPermissionsDeployment : PKPPermissionsDeploymentBase
    {
        public PKPPermissionsDeployment() : base(BYTECODE) { }
        public PKPPermissionsDeployment(string byteCode) : base(byteCode) { }
    }

    public class PKPPermissionsDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public PKPPermissionsDeploymentBase() : base(BYTECODE) { }
        public PKPPermissionsDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class AddPermittedActionFunction : AddPermittedActionFunctionBase { }

    [Function("addPermittedAction")]
    public class AddPermittedActionFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "ipfsCID", 2)]
        public virtual byte[] IpfsCID { get; set; }
        [Parameter("uint256[]", "scopes", 3)]
        public virtual List<BigInteger> Scopes { get; set; }
    }

    public partial class AddPermittedAddressFunction : AddPermittedAddressFunctionBase { }

    [Function("addPermittedAddress")]
    public class AddPermittedAddressFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("address", "user", 2)]
        public virtual string User { get; set; }
        [Parameter("uint256[]", "scopes", 3)]
        public virtual List<BigInteger> Scopes { get; set; }
    }

    public partial class AddPermittedAuthMethodFunction : AddPermittedAuthMethodFunctionBase { }

    [Function("addPermittedAuthMethod")]
    public class AddPermittedAuthMethodFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("tuple", "authMethod", 2)]
        public virtual AuthMethod AuthMethod { get; set; }
        [Parameter("uint256[]", "scopes", 3)]
        public virtual List<BigInteger> Scopes { get; set; }
    }

    public partial class AddPermittedAuthMethodScopeFunction : AddPermittedAuthMethodScopeFunctionBase { }

    [Function("addPermittedAuthMethodScope")]
    public class AddPermittedAuthMethodScopeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3)]
        public virtual byte[] Id { get; set; }
        [Parameter("uint256", "scopeId", 4)]
        public virtual BigInteger ScopeId { get; set; }
    }

    public partial class BatchAddRemoveAuthMethodsFunction : BatchAddRemoveAuthMethodsFunctionBase { }

    [Function("batchAddRemoveAuthMethods")]
    public class BatchAddRemoveAuthMethodsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256[]", "permittedAuthMethodTypesToAdd", 2)]
        public virtual List<BigInteger> PermittedAuthMethodTypesToAdd { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodIdsToAdd", 3)]
        public virtual List<byte[]> PermittedAuthMethodIdsToAdd { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodPubkeysToAdd", 4)]
        public virtual List<byte[]> PermittedAuthMethodPubkeysToAdd { get; set; }
        [Parameter("uint256[][]", "permittedAuthMethodScopesToAdd", 5)]
        public virtual List<List<BigInteger>> PermittedAuthMethodScopesToAdd { get; set; }
        [Parameter("uint256[]", "permittedAuthMethodTypesToRemove", 6)]
        public virtual List<BigInteger> PermittedAuthMethodTypesToRemove { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodIdsToRemove", 7)]
        public virtual List<byte[]> PermittedAuthMethodIdsToRemove { get; set; }
    }

    public partial class GetAuthMethodIdFunction : GetAuthMethodIdFunctionBase { }

    [Function("getAuthMethodId", "uint256")]
    public class GetAuthMethodIdFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "authMethodType", 1)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 2)]
        public virtual byte[] Id { get; set; }
    }

    public partial class GetEthAddressFunction : GetEthAddressFunctionBase { }

    [Function("getEthAddress", "address")]
    public class GetEthAddressFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetPermittedActionsFunction : GetPermittedActionsFunctionBase { }

    [Function("getPermittedActions", "bytes[]")]
    public class GetPermittedActionsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetPermittedAddressesFunction : GetPermittedAddressesFunctionBase { }

    [Function("getPermittedAddresses", "address[]")]
    public class GetPermittedAddressesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class GetPermittedAuthMethodScopesFunction : GetPermittedAuthMethodScopesFunctionBase { }

    [Function("getPermittedAuthMethodScopes", "bool[]")]
    public class GetPermittedAuthMethodScopesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3)]
        public virtual byte[] Id { get; set; }
        [Parameter("uint256", "maxScopeId", 4)]
        public virtual BigInteger MaxScopeId { get; set; }
    }

    public partial class GetPermittedAuthMethodsFunction : GetPermittedAuthMethodsFunctionBase { }

    [Function("getPermittedAuthMethods", typeof(GetPermittedAuthMethodsOutputDTO))]
    public class GetPermittedAuthMethodsFunctionBase : FunctionMessage
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

    public partial class GetRouterAddressFunction : GetRouterAddressFunctionBase { }

    [Function("getRouterAddress", "address")]
    public class GetRouterAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetTokenIdsForAuthMethodFunction : GetTokenIdsForAuthMethodFunctionBase { }

    [Function("getTokenIdsForAuthMethod", "uint256[]")]
    public class GetTokenIdsForAuthMethodFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "authMethodType", 1)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 2)]
        public virtual byte[] Id { get; set; }
    }

    public partial class GetUserPubkeyForAuthMethodFunction : GetUserPubkeyForAuthMethodFunctionBase { }

    [Function("getUserPubkeyForAuthMethod", "bytes")]
    public class GetUserPubkeyForAuthMethodFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "authMethodType", 1)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 2)]
        public virtual byte[] Id { get; set; }
    }

    public partial class IsPermittedActionFunction : IsPermittedActionFunctionBase { }

    [Function("isPermittedAction", "bool")]
    public class IsPermittedActionFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "ipfsCID", 2)]
        public virtual byte[] IpfsCID { get; set; }
    }

    public partial class IsPermittedAddressFunction : IsPermittedAddressFunctionBase { }

    [Function("isPermittedAddress", "bool")]
    public class IsPermittedAddressFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("address", "user", 2)]
        public virtual string User { get; set; }
    }

    public partial class IsPermittedAuthMethodFunction : IsPermittedAuthMethodFunctionBase { }

    [Function("isPermittedAuthMethod", "bool")]
    public class IsPermittedAuthMethodFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3)]
        public virtual byte[] Id { get; set; }
    }

    public partial class IsPermittedAuthMethodScopePresentFunction : IsPermittedAuthMethodScopePresentFunctionBase { }

    [Function("isPermittedAuthMethodScopePresent", "bool")]
    public class IsPermittedAuthMethodScopePresentFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3)]
        public virtual byte[] Id { get; set; }
        [Parameter("uint256", "scopeId", 4)]
        public virtual BigInteger ScopeId { get; set; }
    }

    public partial class RemovePermittedActionFunction : RemovePermittedActionFunctionBase { }

    [Function("removePermittedAction")]
    public class RemovePermittedActionFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "ipfsCID", 2)]
        public virtual byte[] IpfsCID { get; set; }
    }

    public partial class RemovePermittedAddressFunction : RemovePermittedAddressFunctionBase { }

    [Function("removePermittedAddress")]
    public class RemovePermittedAddressFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("address", "user", 2)]
        public virtual string User { get; set; }
    }

    public partial class RemovePermittedAuthMethodFunction : RemovePermittedAuthMethodFunctionBase { }

    [Function("removePermittedAuthMethod")]
    public class RemovePermittedAuthMethodFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3)]
        public virtual byte[] Id { get; set; }
    }

    public partial class RemovePermittedAuthMethodScopeFunction : RemovePermittedAuthMethodScopeFunctionBase { }

    [Function("removePermittedAuthMethodScope")]
    public class RemovePermittedAuthMethodScopeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3)]
        public virtual byte[] Id { get; set; }
        [Parameter("uint256", "scopeId", 4)]
        public virtual BigInteger ScopeId { get; set; }
    }

    public partial class SetContractResolverFunction : SetContractResolverFunctionBase { }

    [Function("setContractResolver")]
    public class SetContractResolverFunctionBase : FunctionMessage
    {
        [Parameter("address", "newResolverAddress", 1)]
        public virtual string NewResolverAddress { get; set; }
    }

    public partial class SetRootHashFunction : SetRootHashFunctionBase { }

    [Function("setRootHash")]
    public class SetRootHashFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "group", 2)]
        public virtual BigInteger Group { get; set; }
        [Parameter("bytes32", "root", 3)]
        public virtual byte[] Root { get; set; }
    }

    public partial class VerifyStateFunction : VerifyStateFunctionBase { }

    [Function("verifyState", "bool")]
    public class VerifyStateFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "group", 2)]
        public virtual BigInteger Group { get; set; }
        [Parameter("bytes32[]", "proof", 3)]
        public virtual List<byte[]> Proof { get; set; }
        [Parameter("bytes32", "leaf", 4)]
        public virtual byte[] Leaf { get; set; }
    }

    public partial class VerifyStatesFunction : VerifyStatesFunctionBase { }

    [Function("verifyStates", "bool")]
    public class VerifyStatesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "group", 2)]
        public virtual BigInteger Group { get; set; }
        [Parameter("bytes32[]", "proof", 3)]
        public virtual List<byte[]> Proof { get; set; }
        [Parameter("bool[]", "proofFlags", 4)]
        public virtual List<bool> ProofFlags { get; set; }
        [Parameter("bytes32[]", "leaves", 5)]
        public virtual List<byte[]> Leaves { get; set; }
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

    public partial class PermittedAuthMethodAddedEventDTO : PermittedAuthMethodAddedEventDTOBase { }

    [Event("PermittedAuthMethodAdded")]
    public class PermittedAuthMethodAddedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, true )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2, false )]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3, false )]
        public virtual byte[] Id { get; set; }
        [Parameter("bytes", "userPubkey", 4, false )]
        public virtual byte[] UserPubkey { get; set; }
    }

    public partial class PermittedAuthMethodRemovedEventDTO : PermittedAuthMethodRemovedEventDTOBase { }

    [Event("PermittedAuthMethodRemoved")]
    public class PermittedAuthMethodRemovedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, true )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2, false )]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3, false )]
        public virtual byte[] Id { get; set; }
    }

    public partial class PermittedAuthMethodScopeAddedEventDTO : PermittedAuthMethodScopeAddedEventDTOBase { }

    [Event("PermittedAuthMethodScopeAdded")]
    public class PermittedAuthMethodScopeAddedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, true )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2, false )]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3, false )]
        public virtual byte[] Id { get; set; }
        [Parameter("uint256", "scopeId", 4, false )]
        public virtual BigInteger ScopeId { get; set; }
    }

    public partial class PermittedAuthMethodScopeRemovedEventDTO : PermittedAuthMethodScopeRemovedEventDTOBase { }

    [Event("PermittedAuthMethodScopeRemoved")]
    public class PermittedAuthMethodScopeRemovedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, true )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "authMethodType", 2, false )]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 3, false )]
        public virtual byte[] Id { get; set; }
        [Parameter("uint256", "scopeId", 4, false )]
        public virtual BigInteger ScopeId { get; set; }
    }

    public partial class RootHashUpdatedEventDTO : RootHashUpdatedEventDTOBase { }

    [Event("RootHashUpdated")]
    public class RootHashUpdatedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, true )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "group", 2, true )]
        public virtual BigInteger Group { get; set; }
        [Parameter("bytes32", "root", 3, false )]
        public virtual byte[] Root { get; set; }
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













    public partial class GetAuthMethodIdOutputDTO : GetAuthMethodIdOutputDTOBase { }

    [FunctionOutput]
    public class GetAuthMethodIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetEthAddressOutputDTO : GetEthAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetEthAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetPermittedActionsOutputDTO : GetPermittedActionsOutputDTOBase { }

    [FunctionOutput]
    public class GetPermittedActionsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes[]", "", 1)]
        public virtual List<byte[]> ReturnValue1 { get; set; }
    }

    public partial class GetPermittedAddressesOutputDTO : GetPermittedAddressesOutputDTOBase { }

    [FunctionOutput]
    public class GetPermittedAddressesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class GetPermittedAuthMethodScopesOutputDTO : GetPermittedAuthMethodScopesOutputDTOBase { }

    [FunctionOutput]
    public class GetPermittedAuthMethodScopesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool[]", "", 1)]
        public virtual List<bool> ReturnValue1 { get; set; }
    }

    public partial class GetPermittedAuthMethodsOutputDTO : GetPermittedAuthMethodsOutputDTOBase { }

    [FunctionOutput]
    public class GetPermittedAuthMethodsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<AuthMethod> ReturnValue1 { get; set; }
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

    public partial class GetRouterAddressOutputDTO : GetRouterAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetRouterAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetTokenIdsForAuthMethodOutputDTO : GetTokenIdsForAuthMethodOutputDTOBase { }

    [FunctionOutput]
    public class GetTokenIdsForAuthMethodOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[]", "", 1)]
        public virtual List<BigInteger> ReturnValue1 { get; set; }
    }

    public partial class GetUserPubkeyForAuthMethodOutputDTO : GetUserPubkeyForAuthMethodOutputDTOBase { }

    [FunctionOutput]
    public class GetUserPubkeyForAuthMethodOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class IsPermittedActionOutputDTO : IsPermittedActionOutputDTOBase { }

    [FunctionOutput]
    public class IsPermittedActionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsPermittedAddressOutputDTO : IsPermittedAddressOutputDTOBase { }

    [FunctionOutput]
    public class IsPermittedAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsPermittedAuthMethodOutputDTO : IsPermittedAuthMethodOutputDTOBase { }

    [FunctionOutput]
    public class IsPermittedAuthMethodOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsPermittedAuthMethodScopePresentOutputDTO : IsPermittedAuthMethodScopePresentOutputDTOBase { }

    [FunctionOutput]
    public class IsPermittedAuthMethodScopePresentOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }













    public partial class VerifyStateOutputDTO : VerifyStateOutputDTOBase { }

    [FunctionOutput]
    public class VerifyStateOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class VerifyStatesOutputDTO : VerifyStatesOutputDTOBase { }

    [FunctionOutput]
    public class VerifyStatesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
