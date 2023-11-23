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

namespace LitContracts.BackupRecovery.ContractDefinition
{


    public partial class BackupRecoveryDeployment : BackupRecoveryDeploymentBase
    {
        public BackupRecoveryDeployment() : base(BYTECODE) { }
        public BackupRecoveryDeployment(string byteCode) : base(byteCode) { }
    }

    public class BackupRecoveryDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public BackupRecoveryDeploymentBase() : base(BYTECODE) { }
        public BackupRecoveryDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class CalculatePartyThresholdFunction : CalculatePartyThresholdFunctionBase { }

    [Function("_calculatePartyThreshold", "uint256")]
    public class CalculatePartyThresholdFunctionBase : FunctionMessage
    {

    }

    public partial class CheckValidatorSetForAddressFunction : CheckValidatorSetForAddressFunctionBase { }

    [Function("_checkValidatorSetForAddress", "bool")]
    public class CheckValidatorSetForAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "sender", 1)]
        public virtual string Sender { get; set; }
    }

    public partial class GetStakingViewFacetFunction : GetStakingViewFacetFunctionBase { }

    [Function("_getStakingViewFacet", "address")]
    public class GetStakingViewFacetFunctionBase : FunctionMessage
    {

    }

    public partial class AllBackupMembersMappedFunction : AllBackupMembersMappedFunctionBase { }

    [Function("allBackupMembersMapped", "bool")]
    public class AllBackupMembersMappedFunctionBase : FunctionMessage
    {

    }

    public partial class GetBackupPartyStateFunction : GetBackupPartyStateFunctionBase { }

    [Function("getBackupPartyState", typeof(GetBackupPartyStateOutputDTO))]
    public class GetBackupPartyStateFunctionBase : FunctionMessage
    {

    }

    public partial class GetDecryptionThresholdFunction : GetDecryptionThresholdFunctionBase { }

    [Function("getDecryptionThreshold", "uint256")]
    public class GetDecryptionThresholdFunctionBase : FunctionMessage
    {

    }

    public partial class GetMemberForNodeDkgFunction : GetMemberForNodeDkgFunctionBase { }

    [Function("getMemberForNodeDkg", "address")]
    public class GetMemberForNodeDkgFunctionBase : FunctionMessage
    {

    }

    public partial class GetNextBackupPartyMembersFunction : GetNextBackupPartyMembersFunctionBase { }

    [Function("getNextBackupPartyMembers", "address[]")]
    public class GetNextBackupPartyMembersFunctionBase : FunctionMessage
    {

    }

    public partial class GetNodeAddressesForDkgFunction : GetNodeAddressesForDkgFunctionBase { }

    [Function("getNodeAddressesForDkg", "address[]")]
    public class GetNodeAddressesForDkgFunctionBase : FunctionMessage
    {

    }

    public partial class GetNodeForBackupMemberFunction : GetNodeForBackupMemberFunctionBase { }

    [Function("getNodeForBackupMember", "address")]
    public class GetNodeForBackupMemberFunctionBase : FunctionMessage
    {

    }

    public partial class GetPastBackupStateFunction : GetPastBackupStateFunctionBase { }

    [Function("getPastBackupState", typeof(GetPastBackupStateOutputDTO))]
    public class GetPastBackupStateFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "sessionId", 1)]
        public virtual byte[] SessionId { get; set; }
    }

    public partial class GetStakerAddressesForDkgFunction : GetStakerAddressesForDkgFunctionBase { }

    [Function("getStakerAddressesForDkg", "address[]")]
    public class GetStakerAddressesForDkgFunctionBase : FunctionMessage
    {

    }

    public partial class IsNodeForDkgFunction : IsNodeForDkgFunctionBase { }

    [Function("isNodeForDkg", "bool")]
    public class IsNodeForDkgFunctionBase : FunctionMessage
    {

    }

    public partial class IsRecoveryDkgCompletedFunction : IsRecoveryDkgCompletedFunctionBase { }

    [Function("isRecoveryDkgCompleted", "bool")]
    public class IsRecoveryDkgCompletedFunctionBase : FunctionMessage
    {

    }

    public partial class RecieveNewKeySetFunction : RecieveNewKeySetFunctionBase { }

    [Function("recieveNewKeySet")]
    public class RecieveNewKeySetFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "publicKey", 1)]
        public virtual byte[] PublicKey { get; set; }
        [Parameter("bytes", "encryptedKey", 2)]
        public virtual byte[] EncryptedKey { get; set; }
        [Parameter("bytes", "sessionId", 3)]
        public virtual byte[] SessionId { get; set; }
    }

    public partial class RegisterNewBackupPartyFunction : RegisterNewBackupPartyFunctionBase { }

    [Function("registerNewBackupParty")]
    public class RegisterNewBackupPartyFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "partyMembers", 1)]
        public virtual List<string> PartyMembers { get; set; }
    }

    public partial class RegisterRecoveryKeysFunction : RegisterRecoveryKeysFunctionBase { }

    [Function("registerRecoveryKeys")]
    public class RegisterRecoveryKeysFunctionBase : FunctionMessage
    {
        [Parameter("tuple[]", "recoveryKeys", 1)]
        public virtual List<RecoveryKey> RecoveryKeys { get; set; }
    }

    public partial class SetMemberForDkgFunction : SetMemberForDkgFunctionBase { }

    [Function("setMemberForDkg", "address")]
    public class SetMemberForDkgFunctionBase : FunctionMessage
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

    public partial class BackupKeysRegisteredEventDTO : BackupKeysRegisteredEventDTOBase { }

    [Event("BackupKeysRegistered")]
    public class BackupKeysRegisteredEventDTOBase : IEventDTO
    {
        [Parameter("tuple", "state", 1, false )]
        public virtual BackupRecoveryState State { get; set; }
    }

    public partial class BackupPartyRegisteredEventDTO : BackupPartyRegisteredEventDTOBase { }

    [Event("BackupPartyRegistered")]
    public class BackupPartyRegisteredEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "partyTheshold", 1, false )]
        public virtual BigInteger PartyTheshold { get; set; }
    }

    public partial class NodeAssignedToBackupMemberEventDTO : NodeAssignedToBackupMemberEventDTOBase { }

    [Event("NodeAssignedToBackupMember")]
    public class NodeAssignedToBackupMemberEventDTOBase : IEventDTO
    {
        [Parameter("address", "backupMemberAddress", 1, false )]
        public virtual string BackupMemberAddress { get; set; }
        [Parameter("address", "NodeAddress", 2, false )]
        public virtual string NodeAddress { get; set; }
    }

    public partial class RecoveryKeySetEventDTO : RecoveryKeySetEventDTOBase { }

    [Event("RecoveryKeySet")]
    public class RecoveryKeySetEventDTOBase : IEventDTO
    {
        [Parameter("tuple", "recoveryKey", 1, false )]
        public virtual RecoveryKey RecoveryKey { get; set; }
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

    public partial class BackupKeysMismatchError : BackupKeysMismatchErrorBase { }

    [Error("BackupKeysMismatch")]
    public class BackupKeysMismatchErrorBase : IErrorDTO
    {
        [Parameter("bytes", "publicKey", 1)]
        public virtual byte[] PublicKey { get; set; }
        [Parameter("bytes", "senderPublicKey", 2)]
        public virtual byte[] SenderPublicKey { get; set; }
        [Parameter("bytes", "blsKey", 3)]
        public virtual byte[] BlsKey { get; set; }
        [Parameter("bytes", "senderBlsKey", 4)]
        public virtual byte[] SenderBlsKey { get; set; }
    }

    public partial class BackupMemberNotMappedToNodeError : BackupMemberNotMappedToNodeErrorBase { }

    [Error("BackupMemberNotMappedToNode")]
    public class BackupMemberNotMappedToNodeErrorBase : IErrorDTO
    {
        [Parameter("address", "peer", 1)]
        public virtual string Peer { get; set; }
    }

    public partial class BackupSetIncompleteError : BackupSetIncompleteErrorBase { }

    [Error("BackupSetIncomplete")]
    public class BackupSetIncompleteErrorBase : IErrorDTO
    {
        [Parameter("address[]", "members", 1)]
        public virtual List<string> Members { get; set; }
    }

    public partial class BackupStateAlreadyRegisteredError : BackupStateAlreadyRegisteredErrorBase { }

    [Error("BackupStateAlreadyRegistered")]
    public class BackupStateAlreadyRegisteredErrorBase : IErrorDTO
    {
        [Parameter("bytes", "pubkey", 1)]
        public virtual byte[] Pubkey { get; set; }
    }

    public partial class BackupStateNotRegisteredError : BackupStateNotRegisteredErrorBase { }
    [Error("BackupStateNotRegistered")]
    public class BackupStateNotRegisteredErrorBase : IErrorDTO
    {
    }

    public partial class CallerNotOwnerError : CallerNotOwnerErrorBase { }
    [Error("CallerNotOwner")]
    public class CallerNotOwnerErrorBase : IErrorDTO
    {
    }

    public partial class InvalidCallerError : InvalidCallerErrorBase { }

    [Error("InvalidCaller")]
    public class InvalidCallerErrorBase : IErrorDTO
    {
        [Parameter("address", "addr", 1)]
        public virtual string Addr { get; set; }
    }

    public partial class NodesAllMappedToBackupMembersError : NodesAllMappedToBackupMembersErrorBase { }

    [Error("NodesAllMappedToBackupMembers")]
    public class NodesAllMappedToBackupMembersErrorBase : IErrorDTO
    {
        [Parameter("address", "addr", 1)]
        public virtual string Addr { get; set; }
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



    public partial class CalculatePartyThresholdOutputDTO : CalculatePartyThresholdOutputDTOBase { }

    [FunctionOutput]
    public class CalculatePartyThresholdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CheckValidatorSetForAddressOutputDTO : CheckValidatorSetForAddressOutputDTOBase { }

    [FunctionOutput]
    public class CheckValidatorSetForAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class GetStakingViewFacetOutputDTO : GetStakingViewFacetOutputDTOBase { }

    [FunctionOutput]
    public class GetStakingViewFacetOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class AllBackupMembersMappedOutputDTO : AllBackupMembersMappedOutputDTOBase { }

    [FunctionOutput]
    public class AllBackupMembersMappedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "mapped", 1)]
        public virtual bool Mapped { get; set; }
    }

    public partial class GetBackupPartyStateOutputDTO : GetBackupPartyStateOutputDTOBase { }

    [FunctionOutput]
    public class GetBackupPartyStateOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual BackupRecoveryState ReturnValue1 { get; set; }
    }

    public partial class GetDecryptionThresholdOutputDTO : GetDecryptionThresholdOutputDTOBase { }

    [FunctionOutput]
    public class GetDecryptionThresholdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetMemberForNodeDkgOutputDTO : GetMemberForNodeDkgOutputDTOBase { }

    [FunctionOutput]
    public class GetMemberForNodeDkgOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "bp", 1)]
        public virtual string Bp { get; set; }
    }

    public partial class GetNextBackupPartyMembersOutputDTO : GetNextBackupPartyMembersOutputDTOBase { }

    [FunctionOutput]
    public class GetNextBackupPartyMembersOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "backupMembers", 1)]
        public virtual List<string> BackupMembers { get; set; }
    }

    public partial class GetNodeAddressesForDkgOutputDTO : GetNodeAddressesForDkgOutputDTOBase { }

    [FunctionOutput]
    public class GetNodeAddressesForDkgOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "nodes", 1)]
        public virtual List<string> Nodes { get; set; }
    }

    public partial class GetNodeForBackupMemberOutputDTO : GetNodeForBackupMemberOutputDTOBase { }

    [FunctionOutput]
    public class GetNodeForBackupMemberOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "peer", 1)]
        public virtual string Peer { get; set; }
    }

    public partial class GetPastBackupStateOutputDTO : GetPastBackupStateOutputDTOBase { }

    [FunctionOutput]
    public class GetPastBackupStateOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "partyState", 1)]
        public virtual BackupRecoveryState PartyState { get; set; }
    }

    public partial class GetStakerAddressesForDkgOutputDTO : GetStakerAddressesForDkgOutputDTOBase { }

    [FunctionOutput]
    public class GetStakerAddressesForDkgOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "nodes", 1)]
        public virtual List<string> Nodes { get; set; }
    }

    public partial class IsNodeForDkgOutputDTO : IsNodeForDkgOutputDTOBase { }

    [FunctionOutput]
    public class IsNodeForDkgOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "inSet", 1)]
        public virtual bool InSet { get; set; }
    }

    public partial class IsRecoveryDkgCompletedOutputDTO : IsRecoveryDkgCompletedOutputDTOBase { }

    [FunctionOutput]
    public class IsRecoveryDkgCompletedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }








}
