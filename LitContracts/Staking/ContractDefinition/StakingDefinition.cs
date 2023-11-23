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

namespace LitContracts.Staking.ContractDefinition
{


    public partial class StakingDeployment : StakingDeploymentBase
    {
        public StakingDeployment() : base(BYTECODE) { }
        public StakingDeployment(string byteCode) : base(byteCode) { }
    }

    public class StakingDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public StakingDeploymentBase() : base(BYTECODE) { }
        public StakingDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class AdminKickValidatorInNextEpochFunction : AdminKickValidatorInNextEpochFunctionBase { }

    [Function("adminKickValidatorInNextEpoch")]
    public class AdminKickValidatorInNextEpochFunctionBase : FunctionMessage
    {
        [Parameter("address", "validatorStakerAddress", 1)]
        public virtual string ValidatorStakerAddress { get; set; }
    }

    public partial class AdminRejoinValidatorFunction : AdminRejoinValidatorFunctionBase { }

    [Function("adminRejoinValidator")]
    public class AdminRejoinValidatorFunctionBase : FunctionMessage
    {
        [Parameter("address", "staker", 1)]
        public virtual string Staker { get; set; }
    }

    public partial class AdminSlashValidatorFunction : AdminSlashValidatorFunctionBase { }

    [Function("adminSlashValidator")]
    public class AdminSlashValidatorFunctionBase : FunctionMessage
    {
        [Parameter("address", "validatorStakerAddress", 1)]
        public virtual string ValidatorStakerAddress { get; set; }
        [Parameter("uint256", "amountToPenalize", 2)]
        public virtual BigInteger AmountToPenalize { get; set; }
    }

    public partial class AdvanceEpochFunction : AdvanceEpochFunctionBase { }

    [Function("advanceEpoch")]
    public class AdvanceEpochFunctionBase : FunctionMessage
    {

    }

    public partial class ExitFunction : ExitFunctionBase { }

    [Function("exit")]
    public class ExitFunctionBase : FunctionMessage
    {

    }

    public partial class GetRewardFunction : GetRewardFunctionBase { }

    [Function("getReward")]
    public class GetRewardFunctionBase : FunctionMessage
    {

    }

    public partial class KickValidatorInNextEpochFunction : KickValidatorInNextEpochFunctionBase { }

    [Function("kickValidatorInNextEpoch")]
    public class KickValidatorInNextEpochFunctionBase : FunctionMessage
    {
        [Parameter("address", "validatorStakerAddress", 1)]
        public virtual string ValidatorStakerAddress { get; set; }
        [Parameter("uint256", "reason", 2)]
        public virtual BigInteger Reason { get; set; }
        [Parameter("bytes", "data", 3)]
        public virtual byte[] Data { get; set; }
    }

    public partial class LockValidatorsForNextEpochFunction : LockValidatorsForNextEpochFunctionBase { }

    [Function("lockValidatorsForNextEpoch")]
    public class LockValidatorsForNextEpochFunctionBase : FunctionMessage
    {

    }

    public partial class RequestToJoinFunction : RequestToJoinFunctionBase { }

    [Function("requestToJoin")]
    public class RequestToJoinFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "ip", 1)]
        public virtual uint Ip { get; set; }
        [Parameter("uint128", "ipv6", 2)]
        public virtual BigInteger Ipv6 { get; set; }
        [Parameter("uint32", "port", 3)]
        public virtual uint Port { get; set; }
        [Parameter("address", "nodeAddress", 4)]
        public virtual string NodeAddress { get; set; }
        [Parameter("uint256", "senderPubKey", 5)]
        public virtual BigInteger SenderPubKey { get; set; }
        [Parameter("uint256", "receiverPubKey", 6)]
        public virtual BigInteger ReceiverPubKey { get; set; }
    }

    public partial class RequestToLeaveFunction : RequestToLeaveFunctionBase { }

    [Function("requestToLeave")]
    public class RequestToLeaveFunctionBase : FunctionMessage
    {

    }

    public partial class SetConfigFunction : SetConfigFunctionBase { }

    [Function("setConfig")]
    public class SetConfigFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newTokenRewardPerTokenPerEpoch", 1)]
        public virtual BigInteger NewTokenRewardPerTokenPerEpoch { get; set; }
        [Parameter("uint256", "newComplaintTolerance", 2)]
        public virtual BigInteger NewComplaintTolerance { get; set; }
        [Parameter("uint256", "newComplaintIntervalSecs", 3)]
        public virtual BigInteger NewComplaintIntervalSecs { get; set; }
        [Parameter("uint256[]", "newKeyTypes", 4)]
        public virtual List<BigInteger> NewKeyTypes { get; set; }
        [Parameter("uint256", "newMinimumValidatorCount", 5)]
        public virtual BigInteger NewMinimumValidatorCount { get; set; }
    }

    public partial class SetContractResolverFunction : SetContractResolverFunctionBase { }

    [Function("setContractResolver")]
    public class SetContractResolverFunctionBase : FunctionMessage
    {
        [Parameter("address", "newResolverAddress", 1)]
        public virtual string NewResolverAddress { get; set; }
    }

    public partial class SetEpochEndTimeFunction : SetEpochEndTimeFunctionBase { }

    [Function("setEpochEndTime")]
    public class SetEpochEndTimeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newEpochEndTime", 1)]
        public virtual BigInteger NewEpochEndTime { get; set; }
    }

    public partial class SetEpochLengthFunction : SetEpochLengthFunctionBase { }

    [Function("setEpochLength")]
    public class SetEpochLengthFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newEpochLength", 1)]
        public virtual BigInteger NewEpochLength { get; set; }
    }

    public partial class SetEpochStateFunction : SetEpochStateFunctionBase { }

    [Function("setEpochState")]
    public class SetEpochStateFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "newState", 1)]
        public virtual byte NewState { get; set; }
    }

    public partial class SetEpochTimeoutFunction : SetEpochTimeoutFunctionBase { }

    [Function("setEpochTimeout")]
    public class SetEpochTimeoutFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newEpochTimeout", 1)]
        public virtual BigInteger NewEpochTimeout { get; set; }
    }

    public partial class SetIpPortNodeAddressAndCommunicationPubKeysFunction : SetIpPortNodeAddressAndCommunicationPubKeysFunctionBase { }

    [Function("setIpPortNodeAddressAndCommunicationPubKeys")]
    public class SetIpPortNodeAddressAndCommunicationPubKeysFunctionBase : FunctionMessage
    {
        [Parameter("uint32", "ip", 1)]
        public virtual uint Ip { get; set; }
        [Parameter("uint128", "ipv6", 2)]
        public virtual BigInteger Ipv6 { get; set; }
        [Parameter("uint32", "port", 3)]
        public virtual uint Port { get; set; }
        [Parameter("address", "nodeAddress", 4)]
        public virtual string NodeAddress { get; set; }
        [Parameter("uint256", "senderPubKey", 5)]
        public virtual BigInteger SenderPubKey { get; set; }
        [Parameter("uint256", "receiverPubKey", 6)]
        public virtual BigInteger ReceiverPubKey { get; set; }
    }

    public partial class SetKickPenaltyPercentFunction : SetKickPenaltyPercentFunctionBase { }

    [Function("setKickPenaltyPercent")]
    public class SetKickPenaltyPercentFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "reason", 1)]
        public virtual BigInteger Reason { get; set; }
        [Parameter("uint256", "newKickPenaltyPercent", 2)]
        public virtual BigInteger NewKickPenaltyPercent { get; set; }
    }

    public partial class SignalReadyForNextEpochFunction : SignalReadyForNextEpochFunctionBase { }

    [Function("signalReadyForNextEpoch")]
    public class SignalReadyForNextEpochFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "epochNumber", 1)]
        public virtual BigInteger EpochNumber { get; set; }
    }

    public partial class StakeFunction : StakeFunctionBase { }

    [Function("stake")]
    public class StakeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class StakeAndJoinFunction : StakeAndJoinFunctionBase { }

    [Function("stakeAndJoin")]
    public class StakeAndJoinFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("uint32", "ip", 2)]
        public virtual uint Ip { get; set; }
        [Parameter("uint128", "ipv6", 3)]
        public virtual BigInteger Ipv6 { get; set; }
        [Parameter("uint32", "port", 4)]
        public virtual uint Port { get; set; }
        [Parameter("address", "nodeAddress", 5)]
        public virtual string NodeAddress { get; set; }
        [Parameter("uint256", "senderPubKey", 6)]
        public virtual BigInteger SenderPubKey { get; set; }
        [Parameter("uint256", "receiverPubKey", 7)]
        public virtual BigInteger ReceiverPubKey { get; set; }
    }

    public partial class UnlockValidatorsForNextEpochFunction : UnlockValidatorsForNextEpochFunctionBase { }

    [Function("unlockValidatorsForNextEpoch")]
    public class UnlockValidatorsForNextEpochFunctionBase : FunctionMessage
    {

    }

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw")]
    public class WithdrawFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class CheckVersionFunction : CheckVersionFunctionBase { }

    [Function("checkVersion", "bool")]
    public class CheckVersionFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "version", 1)]
        public virtual Version Version { get; set; }
    }

    public partial class GetMaxVersionFunction : GetMaxVersionFunctionBase { }

    [Function("getMaxVersion", typeof(GetMaxVersionOutputDTO))]
    public class GetMaxVersionFunctionBase : FunctionMessage
    {

    }

    public partial class GetMaxVersionStringFunction : GetMaxVersionStringFunctionBase { }

    [Function("getMaxVersionString", "string")]
    public class GetMaxVersionStringFunctionBase : FunctionMessage
    {

    }

    public partial class GetMinVersionFunction : GetMinVersionFunctionBase { }

    [Function("getMinVersion", typeof(GetMinVersionOutputDTO))]
    public class GetMinVersionFunctionBase : FunctionMessage
    {

    }

    public partial class GetMinVersionStringFunction : GetMinVersionStringFunctionBase { }

    [Function("getMinVersionString", "string")]
    public class GetMinVersionStringFunctionBase : FunctionMessage
    {

    }

    public partial class SetMaxVersionFunction : SetMaxVersionFunctionBase { }

    [Function("setMaxVersion")]
    public class SetMaxVersionFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "version", 1)]
        public virtual Version Version { get; set; }
    }

    public partial class SetMinVersionFunction : SetMinVersionFunctionBase { }

    [Function("setMinVersion")]
    public class SetMinVersionFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "version", 1)]
        public virtual Version Version { get; set; }
    }

    public partial class ConfigFunction : ConfigFunctionBase { }

    [Function("config", typeof(ConfigOutputDTO))]
    public class ConfigFunctionBase : FunctionMessage
    {

    }

    public partial class ContractResolverFunction : ContractResolverFunctionBase { }

    [Function("contractResolver", "address")]
    public class ContractResolverFunctionBase : FunctionMessage
    {

    }

    public partial class CountOfCurrentValidatorsReadyForNextEpochFunction : CountOfCurrentValidatorsReadyForNextEpochFunctionBase { }

    [Function("countOfCurrentValidatorsReadyForNextEpoch", "uint256")]
    public class CountOfCurrentValidatorsReadyForNextEpochFunctionBase : FunctionMessage
    {

    }

    public partial class CountOfNextValidatorsReadyForNextEpochFunction : CountOfNextValidatorsReadyForNextEpochFunctionBase { }

    [Function("countOfNextValidatorsReadyForNextEpoch", "uint256")]
    public class CountOfNextValidatorsReadyForNextEpochFunctionBase : FunctionMessage
    {

    }

    public partial class CurrentValidatorCountForConsensusFunction : CurrentValidatorCountForConsensusFunctionBase { }

    [Function("currentValidatorCountForConsensus", "uint256")]
    public class CurrentValidatorCountForConsensusFunctionBase : FunctionMessage
    {

    }

    public partial class EpochFunction : EpochFunctionBase { }

    [Function("epoch", typeof(EpochOutputDTO))]
    public class EpochFunctionBase : FunctionMessage
    {

    }

    public partial class GetKeyTypesFunction : GetKeyTypesFunctionBase { }

    [Function("getKeyTypes", "uint256[]")]
    public class GetKeyTypesFunctionBase : FunctionMessage
    {

    }

    public partial class GetKickedValidatorsFunction : GetKickedValidatorsFunctionBase { }

    [Function("getKickedValidators", "address[]")]
    public class GetKickedValidatorsFunctionBase : FunctionMessage
    {

    }

    public partial class GetNodeStakerAddressMappingsFunction : GetNodeStakerAddressMappingsFunctionBase { }

    [Function("getNodeStakerAddressMappings", typeof(GetNodeStakerAddressMappingsOutputDTO))]
    public class GetNodeStakerAddressMappingsFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "addresses", 1)]
        public virtual List<string> Addresses { get; set; }
    }

    public partial class GetStakingBalancesAddressFunction : GetStakingBalancesAddressFunctionBase { }

    [Function("getStakingBalancesAddress", "address")]
    public class GetStakingBalancesAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetTokenAddressFunction : GetTokenAddressFunctionBase { }

    [Function("getTokenAddress", "address")]
    public class GetTokenAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetValidatorsInCurrentEpochFunction : GetValidatorsInCurrentEpochFunctionBase { }

    [Function("getValidatorsInCurrentEpoch", "address[]")]
    public class GetValidatorsInCurrentEpochFunctionBase : FunctionMessage
    {

    }

    public partial class GetValidatorsInCurrentEpochLengthFunction : GetValidatorsInCurrentEpochLengthFunctionBase { }

    [Function("getValidatorsInCurrentEpochLength", "uint256")]
    public class GetValidatorsInCurrentEpochLengthFunctionBase : FunctionMessage
    {

    }

    public partial class GetValidatorsInNextEpochFunction : GetValidatorsInNextEpochFunctionBase { }

    [Function("getValidatorsInNextEpoch", "address[]")]
    public class GetValidatorsInNextEpochFunctionBase : FunctionMessage
    {

    }

    public partial class GetValidatorsStructsFunction : GetValidatorsStructsFunctionBase { }

    [Function("getValidatorsStructs", typeof(GetValidatorsStructsOutputDTO))]
    public class GetValidatorsStructsFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "addresses", 1)]
        public virtual List<string> Addresses { get; set; }
    }

    public partial class GetValidatorsStructsInCurrentEpochFunction : GetValidatorsStructsInCurrentEpochFunctionBase { }

    [Function("getValidatorsStructsInCurrentEpoch", typeof(GetValidatorsStructsInCurrentEpochOutputDTO))]
    public class GetValidatorsStructsInCurrentEpochFunctionBase : FunctionMessage
    {

    }

    public partial class GetValidatorsStructsInNextEpochFunction : GetValidatorsStructsInNextEpochFunctionBase { }

    [Function("getValidatorsStructsInNextEpoch", typeof(GetValidatorsStructsInNextEpochOutputDTO))]
    public class GetValidatorsStructsInNextEpochFunctionBase : FunctionMessage
    {

    }

    public partial class GetVotingStatusToKickValidatorFunction : GetVotingStatusToKickValidatorFunctionBase { }

    [Function("getVotingStatusToKickValidator", typeof(GetVotingStatusToKickValidatorOutputDTO))]
    public class GetVotingStatusToKickValidatorFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "epochNumber", 1)]
        public virtual BigInteger EpochNumber { get; set; }
        [Parameter("address", "validatorStakerAddress", 2)]
        public virtual string ValidatorStakerAddress { get; set; }
        [Parameter("address", "voterStakerAddress", 3)]
        public virtual string VoterStakerAddress { get; set; }
    }

    public partial class IsActiveValidatorFunction : IsActiveValidatorFunctionBase { }

    [Function("isActiveValidator", "bool")]
    public class IsActiveValidatorFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class IsActiveValidatorByNodeAddressFunction : IsActiveValidatorByNodeAddressFunctionBase { }

    [Function("isActiveValidatorByNodeAddress", "bool")]
    public class IsActiveValidatorByNodeAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class IsReadyForNextEpochFunction : IsReadyForNextEpochFunctionBase { }

    [Function("isReadyForNextEpoch", "bool")]
    public class IsReadyForNextEpochFunctionBase : FunctionMessage
    {

    }

    public partial class KickPenaltyPercentByReasonFunction : KickPenaltyPercentByReasonFunctionBase { }

    [Function("kickPenaltyPercentByReason", "uint256")]
    public class KickPenaltyPercentByReasonFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "reason", 1)]
        public virtual BigInteger Reason { get; set; }
    }

    public partial class NextValidatorCountForConsensusFunction : NextValidatorCountForConsensusFunctionBase { }

    [Function("nextValidatorCountForConsensus", "uint256")]
    public class NextValidatorCountForConsensusFunctionBase : FunctionMessage
    {

    }

    public partial class NodeAddressToStakerAddressFunction : NodeAddressToStakerAddressFunctionBase { }

    [Function("nodeAddressToStakerAddress", "address")]
    public class NodeAddressToStakerAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "nodeAddress", 1)]
        public virtual string NodeAddress { get; set; }
    }

    public partial class ReadyForNextEpochFunction : ReadyForNextEpochFunctionBase { }

    [Function("readyForNextEpoch", "bool")]
    public class ReadyForNextEpochFunctionBase : FunctionMessage
    {
        [Parameter("address", "stakerAddress", 1)]
        public virtual string StakerAddress { get; set; }
    }

    public partial class ShouldKickValidatorFunction : ShouldKickValidatorFunctionBase { }

    [Function("shouldKickValidator", "bool")]
    public class ShouldKickValidatorFunctionBase : FunctionMessage
    {
        [Parameter("address", "stakerAddress", 1)]
        public virtual string StakerAddress { get; set; }
    }

    public partial class StateFunction : StateFunctionBase { }

    [Function("state", "uint8")]
    public class StateFunctionBase : FunctionMessage
    {

    }

    public partial class ValidatorsFunction : ValidatorsFunctionBase { }

    [Function("validators", typeof(ValidatorsOutputDTO))]
    public class ValidatorsFunctionBase : FunctionMessage
    {
        [Parameter("address", "stakerAddress", 1)]
        public virtual string StakerAddress { get; set; }
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

    public partial class ConfigSetEventDTO : ConfigSetEventDTOBase { }

    [Event("ConfigSet")]
    public class ConfigSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newTokenRewardPerTokenPerEpoch", 1, false )]
        public virtual BigInteger NewTokenRewardPerTokenPerEpoch { get; set; }
        [Parameter("uint256", "newComplaintTolerance", 2, false )]
        public virtual BigInteger NewComplaintTolerance { get; set; }
        [Parameter("uint256", "newComplaintIntervalSecs", 3, false )]
        public virtual BigInteger NewComplaintIntervalSecs { get; set; }
        [Parameter("uint256[]", "newKeyTypes", 4, false )]
        public virtual List<BigInteger> NewKeyTypes { get; set; }
        [Parameter("uint256", "newMinimumValidatorCount", 5, false )]
        public virtual BigInteger NewMinimumValidatorCount { get; set; }
    }

    public partial class EpochEndTimeSetEventDTO : EpochEndTimeSetEventDTOBase { }

    [Event("EpochEndTimeSet")]
    public class EpochEndTimeSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newEpochEndTime", 1, false )]
        public virtual BigInteger NewEpochEndTime { get; set; }
    }

    public partial class EpochLengthSetEventDTO : EpochLengthSetEventDTOBase { }

    [Event("EpochLengthSet")]
    public class EpochLengthSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newEpochLength", 1, false )]
        public virtual BigInteger NewEpochLength { get; set; }
    }

    public partial class EpochTimeoutSetEventDTO : EpochTimeoutSetEventDTOBase { }

    [Event("EpochTimeoutSet")]
    public class EpochTimeoutSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newEpochTimeout", 1, false )]
        public virtual BigInteger NewEpochTimeout { get; set; }
    }

    public partial class KickPenaltyPercentSetEventDTO : KickPenaltyPercentSetEventDTOBase { }

    [Event("KickPenaltyPercentSet")]
    public class KickPenaltyPercentSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "reason", 1, false )]
        public virtual BigInteger Reason { get; set; }
        [Parameter("uint256", "newKickPenaltyPercent", 2, false )]
        public virtual BigInteger NewKickPenaltyPercent { get; set; }
    }

    public partial class ReadyForNextEpochEventDTO : ReadyForNextEpochEventDTOBase { }

    [Event("ReadyForNextEpoch")]
    public class ReadyForNextEpochEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("uint256", "epochNumber", 2, false )]
        public virtual BigInteger EpochNumber { get; set; }
    }

    public partial class RecoveredEventDTO : RecoveredEventDTOBase { }

    [Event("Recovered")]
    public class RecoveredEventDTOBase : IEventDTO
    {
        [Parameter("address", "token", 1, false )]
        public virtual string Token { get; set; }
        [Parameter("uint256", "amount", 2, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class RequestToJoinEventDTO : RequestToJoinEventDTOBase { }

    [Event("RequestToJoin")]
    public class RequestToJoinEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
    }

    public partial class RequestToLeaveEventDTO : RequestToLeaveEventDTOBase { }

    [Event("RequestToLeave")]
    public class RequestToLeaveEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
    }

    public partial class ResolverContractAddressSetEventDTO : ResolverContractAddressSetEventDTOBase { }

    [Event("ResolverContractAddressSet")]
    public class ResolverContractAddressSetEventDTOBase : IEventDTO
    {
        [Parameter("address", "newResolverContractAddress", 1, false )]
        public virtual string NewResolverContractAddress { get; set; }
    }

    public partial class RewardsDurationUpdatedEventDTO : RewardsDurationUpdatedEventDTOBase { }

    [Event("RewardsDurationUpdated")]
    public class RewardsDurationUpdatedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newDuration", 1, false )]
        public virtual BigInteger NewDuration { get; set; }
    }

    public partial class StakingTokenSetEventDTO : StakingTokenSetEventDTOBase { }

    [Event("StakingTokenSet")]
    public class StakingTokenSetEventDTOBase : IEventDTO
    {
        [Parameter("address", "newStakingTokenAddress", 1, false )]
        public virtual string NewStakingTokenAddress { get; set; }
    }

    public partial class StateChangedEventDTO : StateChangedEventDTOBase { }

    [Event("StateChanged")]
    public class StateChangedEventDTOBase : IEventDTO
    {
        [Parameter("uint8", "newState", 1, false )]
        public virtual byte NewState { get; set; }
    }

    public partial class ValidatorKickedFromNextEpochEventDTO : ValidatorKickedFromNextEpochEventDTOBase { }

    [Event("ValidatorKickedFromNextEpoch")]
    public class ValidatorKickedFromNextEpochEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("uint256", "amountBurned", 2, false )]
        public virtual BigInteger AmountBurned { get; set; }
    }

    public partial class ValidatorRejoinedNextEpochEventDTO : ValidatorRejoinedNextEpochEventDTOBase { }

    [Event("ValidatorRejoinedNextEpoch")]
    public class ValidatorRejoinedNextEpochEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, false )]
        public virtual string Staker { get; set; }
    }

    public partial class VotedToKickValidatorInNextEpochEventDTO : VotedToKickValidatorInNextEpochEventDTOBase { }

    [Event("VotedToKickValidatorInNextEpoch")]
    public class VotedToKickValidatorInNextEpochEventDTOBase : IEventDTO
    {
        [Parameter("address", "reporter", 1, true )]
        public virtual string Reporter { get; set; }
        [Parameter("address", "validatorStakerAddress", 2, true )]
        public virtual string ValidatorStakerAddress { get; set; }
        [Parameter("uint256", "reason", 3, true )]
        public virtual BigInteger Reason { get; set; }
        [Parameter("bytes", "data", 4, false )]
        public virtual byte[] Data { get; set; }
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

    public partial class ActiveValidatorsCannotLeaveError : ActiveValidatorsCannotLeaveErrorBase { }
    [Error("ActiveValidatorsCannotLeave")]
    public class ActiveValidatorsCannotLeaveErrorBase : IErrorDTO
    {
    }

    public partial class CallerNotOwnerError : CallerNotOwnerErrorBase { }
    [Error("CallerNotOwner")]
    public class CallerNotOwnerErrorBase : IErrorDTO
    {
    }

    public partial class CannotRejoinUntilNextEpochBecauseKickedError : CannotRejoinUntilNextEpochBecauseKickedErrorBase { }

    [Error("CannotRejoinUntilNextEpochBecauseKicked")]
    public class CannotRejoinUntilNextEpochBecauseKickedErrorBase : IErrorDTO
    {
        [Parameter("address", "stakingAddress", 1)]
        public virtual string StakingAddress { get; set; }
    }

    public partial class CannotReuseCommsKeysError : CannotReuseCommsKeysErrorBase { }

    [Error("CannotReuseCommsKeys")]
    public class CannotReuseCommsKeysErrorBase : IErrorDTO
    {
        [Parameter("uint256", "senderPubKey", 1)]
        public virtual BigInteger SenderPubKey { get; set; }
        [Parameter("uint256", "receiverPubKey", 2)]
        public virtual BigInteger ReceiverPubKey { get; set; }
    }

    public partial class CannotStakeZeroError : CannotStakeZeroErrorBase { }
    [Error("CannotStakeZero")]
    public class CannotStakeZeroErrorBase : IErrorDTO
    {
    }

    public partial class CannotVoteTwiceError : CannotVoteTwiceErrorBase { }

    [Error("CannotVoteTwice")]
    public class CannotVoteTwiceErrorBase : IErrorDTO
    {
        [Parameter("address", "stakerAddress", 1)]
        public virtual string StakerAddress { get; set; }
    }

    public partial class CannotWithdrawZeroError : CannotWithdrawZeroErrorBase { }
    [Error("CannotWithdrawZero")]
    public class CannotWithdrawZeroErrorBase : IErrorDTO
    {
    }

    public partial class CouldNotMapNodeAddressToStakerAddressError : CouldNotMapNodeAddressToStakerAddressErrorBase { }

    [Error("CouldNotMapNodeAddressToStakerAddress")]
    public class CouldNotMapNodeAddressToStakerAddressErrorBase : IErrorDTO
    {
        [Parameter("address", "nodeAddress", 1)]
        public virtual string NodeAddress { get; set; }
    }

    public partial class MustBeInActiveOrUnlockedOrPausedStateError : MustBeInActiveOrUnlockedOrPausedStateErrorBase { }

    [Error("MustBeInActiveOrUnlockedOrPausedState")]
    public class MustBeInActiveOrUnlockedOrPausedStateErrorBase : IErrorDTO
    {
        [Parameter("uint8", "state", 1)]
        public virtual byte State { get; set; }
    }

    public partial class MustBeInActiveOrUnlockedStateError : MustBeInActiveOrUnlockedStateErrorBase { }

    [Error("MustBeInActiveOrUnlockedState")]
    public class MustBeInActiveOrUnlockedStateErrorBase : IErrorDTO
    {
        [Parameter("uint8", "state", 1)]
        public virtual byte State { get; set; }
    }

    public partial class MustBeInNextValidatorSetLockedOrReadyForNextEpochOrRestoreStateError : MustBeInNextValidatorSetLockedOrReadyForNextEpochOrRestoreStateErrorBase { }

    [Error("MustBeInNextValidatorSetLockedOrReadyForNextEpochOrRestoreState")]
    public class MustBeInNextValidatorSetLockedOrReadyForNextEpochOrRestoreStateErrorBase : IErrorDTO
    {
        [Parameter("uint8", "state", 1)]
        public virtual byte State { get; set; }
    }

    public partial class MustBeInNextValidatorSetLockedStateError : MustBeInNextValidatorSetLockedStateErrorBase { }

    [Error("MustBeInNextValidatorSetLockedState")]
    public class MustBeInNextValidatorSetLockedStateErrorBase : IErrorDTO
    {
        [Parameter("uint8", "state", 1)]
        public virtual byte State { get; set; }
    }

    public partial class MustBeInReadyForNextEpochStateError : MustBeInReadyForNextEpochStateErrorBase { }

    [Error("MustBeInReadyForNextEpochState")]
    public class MustBeInReadyForNextEpochStateErrorBase : IErrorDTO
    {
        [Parameter("uint8", "state", 1)]
        public virtual byte State { get; set; }
    }

    public partial class MustBeValidatorInNextEpochToKickError : MustBeValidatorInNextEpochToKickErrorBase { }

    [Error("MustBeValidatorInNextEpochToKick")]
    public class MustBeValidatorInNextEpochToKickErrorBase : IErrorDTO
    {
        [Parameter("address", "stakerAddress", 1)]
        public virtual string StakerAddress { get; set; }
    }

    public partial class NotEnoughTimeElapsedForTimeoutSinceLastEpochError : NotEnoughTimeElapsedForTimeoutSinceLastEpochErrorBase { }

    [Error("NotEnoughTimeElapsedForTimeoutSinceLastEpoch")]
    public class NotEnoughTimeElapsedForTimeoutSinceLastEpochErrorBase : IErrorDTO
    {
        [Parameter("uint256", "currentTimestamp", 1)]
        public virtual BigInteger CurrentTimestamp { get; set; }
        [Parameter("uint256", "epochEndTime", 2)]
        public virtual BigInteger EpochEndTime { get; set; }
        [Parameter("uint256", "timeout", 3)]
        public virtual BigInteger Timeout { get; set; }
    }

    public partial class NotEnoughTimeElapsedSinceLastEpochError : NotEnoughTimeElapsedSinceLastEpochErrorBase { }

    [Error("NotEnoughTimeElapsedSinceLastEpoch")]
    public class NotEnoughTimeElapsedSinceLastEpochErrorBase : IErrorDTO
    {
        [Parameter("uint256", "currentTimestamp", 1)]
        public virtual BigInteger CurrentTimestamp { get; set; }
        [Parameter("uint256", "epochEndTime", 2)]
        public virtual BigInteger EpochEndTime { get; set; }
    }

    public partial class NotEnoughValidatorsInNextEpochError : NotEnoughValidatorsInNextEpochErrorBase { }

    [Error("NotEnoughValidatorsInNextEpoch")]
    public class NotEnoughValidatorsInNextEpochErrorBase : IErrorDTO
    {
        [Parameter("uint256", "validatorCount", 1)]
        public virtual BigInteger ValidatorCount { get; set; }
        [Parameter("uint256", "minimumValidatorCount", 2)]
        public virtual BigInteger MinimumValidatorCount { get; set; }
    }

    public partial class NotEnoughValidatorsReadyForNextEpochError : NotEnoughValidatorsReadyForNextEpochErrorBase { }

    [Error("NotEnoughValidatorsReadyForNextEpoch")]
    public class NotEnoughValidatorsReadyForNextEpochErrorBase : IErrorDTO
    {
        [Parameter("uint256", "currentReadyValidatorCount", 1)]
        public virtual BigInteger CurrentReadyValidatorCount { get; set; }
        [Parameter("uint256", "nextReadyValidatorCount", 2)]
        public virtual BigInteger NextReadyValidatorCount { get; set; }
        [Parameter("uint256", "minimumValidatorCountToBeReady", 3)]
        public virtual BigInteger MinimumValidatorCountToBeReady { get; set; }
    }

    public partial class SignaledReadyForWrongEpochNumberError : SignaledReadyForWrongEpochNumberErrorBase { }

    [Error("SignaledReadyForWrongEpochNumber")]
    public class SignaledReadyForWrongEpochNumberErrorBase : IErrorDTO
    {
        [Parameter("uint256", "currentEpochNumber", 1)]
        public virtual BigInteger CurrentEpochNumber { get; set; }
        [Parameter("uint256", "receivedEpochNumber", 2)]
        public virtual BigInteger ReceivedEpochNumber { get; set; }
    }

    public partial class StakerNotPermittedError : StakerNotPermittedErrorBase { }

    [Error("StakerNotPermitted")]
    public class StakerNotPermittedErrorBase : IErrorDTO
    {
        [Parameter("address", "stakerAddress", 1)]
        public virtual string StakerAddress { get; set; }
    }

    public partial class TryingToWithdrawMoreThanStakedError : TryingToWithdrawMoreThanStakedErrorBase { }

    [Error("TryingToWithdrawMoreThanStaked")]
    public class TryingToWithdrawMoreThanStakedErrorBase : IErrorDTO
    {
        [Parameter("uint256", "yourBalance", 1)]
        public virtual BigInteger YourBalance { get; set; }
        [Parameter("uint256", "requestedWithdrawlAmount", 2)]
        public virtual BigInteger RequestedWithdrawlAmount { get; set; }
    }

    public partial class ValidatorIsNotInNextEpochError : ValidatorIsNotInNextEpochErrorBase { }

    [Error("ValidatorIsNotInNextEpoch")]
    public class ValidatorIsNotInNextEpochErrorBase : IErrorDTO
    {
        [Parameter("address", "validator", 1)]
        public virtual string Validator { get; set; }
        [Parameter("address[]", "validatorsInNextEpoch", 2)]
        public virtual List<string> ValidatorsInNextEpoch { get; set; }
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

















































    public partial class CheckVersionOutputDTO : CheckVersionOutputDTOBase { }

    [FunctionOutput]
    public class CheckVersionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class GetMaxVersionOutputDTO : GetMaxVersionOutputDTOBase { }

    [FunctionOutput]
    public class GetMaxVersionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Version ReturnValue1 { get; set; }
    }

    public partial class GetMaxVersionStringOutputDTO : GetMaxVersionStringOutputDTOBase { }

    [FunctionOutput]
    public class GetMaxVersionStringOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetMinVersionOutputDTO : GetMinVersionOutputDTOBase { }

    [FunctionOutput]
    public class GetMinVersionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Version ReturnValue1 { get; set; }
    }

    public partial class GetMinVersionStringOutputDTO : GetMinVersionStringOutputDTOBase { }

    [FunctionOutput]
    public class GetMinVersionStringOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }





    public partial class ConfigOutputDTO : ConfigOutputDTOBase { }

    [FunctionOutput]
    public class ConfigOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Config ReturnValue1 { get; set; }
    }

    public partial class ContractResolverOutputDTO : ContractResolverOutputDTOBase { }

    [FunctionOutput]
    public class ContractResolverOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CountOfCurrentValidatorsReadyForNextEpochOutputDTO : CountOfCurrentValidatorsReadyForNextEpochOutputDTOBase { }

    [FunctionOutput]
    public class CountOfCurrentValidatorsReadyForNextEpochOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CountOfNextValidatorsReadyForNextEpochOutputDTO : CountOfNextValidatorsReadyForNextEpochOutputDTOBase { }

    [FunctionOutput]
    public class CountOfNextValidatorsReadyForNextEpochOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CurrentValidatorCountForConsensusOutputDTO : CurrentValidatorCountForConsensusOutputDTOBase { }

    [FunctionOutput]
    public class CurrentValidatorCountForConsensusOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class EpochOutputDTO : EpochOutputDTOBase { }

    [FunctionOutput]
    public class EpochOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Epoch ReturnValue1 { get; set; }
    }

    public partial class GetKeyTypesOutputDTO : GetKeyTypesOutputDTOBase { }

    [FunctionOutput]
    public class GetKeyTypesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256[]", "", 1)]
        public virtual List<BigInteger> ReturnValue1 { get; set; }
    }

    public partial class GetKickedValidatorsOutputDTO : GetKickedValidatorsOutputDTOBase { }

    [FunctionOutput]
    public class GetKickedValidatorsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class GetNodeStakerAddressMappingsOutputDTO : GetNodeStakerAddressMappingsOutputDTOBase { }

    [FunctionOutput]
    public class GetNodeStakerAddressMappingsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<AddressMapping> ReturnValue1 { get; set; }
    }

    public partial class GetStakingBalancesAddressOutputDTO : GetStakingBalancesAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetStakingBalancesAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetTokenAddressOutputDTO : GetTokenAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetTokenAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetValidatorsInCurrentEpochOutputDTO : GetValidatorsInCurrentEpochOutputDTOBase { }

    [FunctionOutput]
    public class GetValidatorsInCurrentEpochOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class GetValidatorsInCurrentEpochLengthOutputDTO : GetValidatorsInCurrentEpochLengthOutputDTOBase { }

    [FunctionOutput]
    public class GetValidatorsInCurrentEpochLengthOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetValidatorsInNextEpochOutputDTO : GetValidatorsInNextEpochOutputDTOBase { }

    [FunctionOutput]
    public class GetValidatorsInNextEpochOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address[]", "", 1)]
        public virtual List<string> ReturnValue1 { get; set; }
    }

    public partial class GetValidatorsStructsOutputDTO : GetValidatorsStructsOutputDTOBase { }

    [FunctionOutput]
    public class GetValidatorsStructsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<Validator> ReturnValue1 { get; set; }
    }

    public partial class GetValidatorsStructsInCurrentEpochOutputDTO : GetValidatorsStructsInCurrentEpochOutputDTOBase { }

    [FunctionOutput]
    public class GetValidatorsStructsInCurrentEpochOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<Validator> ReturnValue1 { get; set; }
    }

    public partial class GetValidatorsStructsInNextEpochOutputDTO : GetValidatorsStructsInNextEpochOutputDTOBase { }

    [FunctionOutput]
    public class GetValidatorsStructsInNextEpochOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple[]", "", 1)]
        public virtual List<Validator> ReturnValue1 { get; set; }
    }

    public partial class GetVotingStatusToKickValidatorOutputDTO : GetVotingStatusToKickValidatorOutputDTOBase { }

    [FunctionOutput]
    public class GetVotingStatusToKickValidatorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
        [Parameter("bool", "", 2)]
        public virtual bool ReturnValue2 { get; set; }
    }

    public partial class IsActiveValidatorOutputDTO : IsActiveValidatorOutputDTOBase { }

    [FunctionOutput]
    public class IsActiveValidatorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsActiveValidatorByNodeAddressOutputDTO : IsActiveValidatorByNodeAddressOutputDTOBase { }

    [FunctionOutput]
    public class IsActiveValidatorByNodeAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsReadyForNextEpochOutputDTO : IsReadyForNextEpochOutputDTOBase { }

    [FunctionOutput]
    public class IsReadyForNextEpochOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class KickPenaltyPercentByReasonOutputDTO : KickPenaltyPercentByReasonOutputDTOBase { }

    [FunctionOutput]
    public class KickPenaltyPercentByReasonOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class NextValidatorCountForConsensusOutputDTO : NextValidatorCountForConsensusOutputDTOBase { }

    [FunctionOutput]
    public class NextValidatorCountForConsensusOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class NodeAddressToStakerAddressOutputDTO : NodeAddressToStakerAddressOutputDTOBase { }

    [FunctionOutput]
    public class NodeAddressToStakerAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ReadyForNextEpochOutputDTO : ReadyForNextEpochOutputDTOBase { }

    [FunctionOutput]
    public class ReadyForNextEpochOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class ShouldKickValidatorOutputDTO : ShouldKickValidatorOutputDTOBase { }

    [FunctionOutput]
    public class ShouldKickValidatorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class StateOutputDTO : StateOutputDTOBase { }

    [FunctionOutput]
    public class StateOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class ValidatorsOutputDTO : ValidatorsOutputDTOBase { }

    [FunctionOutput]
    public class ValidatorsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Validator ReturnValue1 { get; set; }
    }
}
