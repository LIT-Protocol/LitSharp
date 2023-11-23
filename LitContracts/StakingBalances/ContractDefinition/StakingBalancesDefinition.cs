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

namespace LitContracts.StakingBalances.ContractDefinition
{


    public partial class StakingBalancesDeployment : StakingBalancesDeploymentBase
    {
        public StakingBalancesDeployment() : base(BYTECODE) { }
        public StakingBalancesDeployment(string byteCode) : base(byteCode) { }
    }

    public class StakingBalancesDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public StakingBalancesDeploymentBase() : base(BYTECODE) { }
        public StakingBalancesDeploymentBase(string byteCode) : base(byteCode) { }

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

    public partial class AddAliasFunction : AddAliasFunctionBase { }

    [Function("addAlias")]
    public class AddAliasFunctionBase : FunctionMessage
    {
        [Parameter("address", "aliasAccount", 1)]
        public virtual string AliasAccount { get; set; }
    }

    public partial class AddPermittedStakerFunction : AddPermittedStakerFunctionBase { }

    [Function("addPermittedStaker")]
    public class AddPermittedStakerFunctionBase : FunctionMessage
    {
        [Parameter("address", "staker", 1)]
        public virtual string Staker { get; set; }
    }

    public partial class AddPermittedStakersFunction : AddPermittedStakersFunctionBase { }

    [Function("addPermittedStakers")]
    public class AddPermittedStakersFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "stakers", 1)]
        public virtual List<string> Stakers { get; set; }
    }

    public partial class BalanceOfFunction : BalanceOfFunctionBase { }

    [Function("balanceOf", "uint256")]
    public class BalanceOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class CheckStakingAmountsFunction : CheckStakingAmountsFunctionBase { }

    [Function("checkStakingAmounts", "bool")]
    public class CheckStakingAmountsFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class GetRewardFunction : GetRewardFunctionBase { }

    [Function("getReward")]
    public class GetRewardFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class GetStakingAddressFunction : GetStakingAddressFunctionBase { }

    [Function("getStakingAddress", "address")]
    public class GetStakingAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetTokenAddressFunction : GetTokenAddressFunctionBase { }

    [Function("getTokenAddress", "address")]
    public class GetTokenAddressFunctionBase : FunctionMessage
    {

    }

    public partial class IsPermittedStakerFunction : IsPermittedStakerFunctionBase { }

    [Function("isPermittedStaker", "bool")]
    public class IsPermittedStakerFunctionBase : FunctionMessage
    {
        [Parameter("address", "staker", 1)]
        public virtual string Staker { get; set; }
    }

    public partial class MaximumStakeFunction : MaximumStakeFunctionBase { }

    [Function("maximumStake", "uint256")]
    public class MaximumStakeFunctionBase : FunctionMessage
    {

    }

    public partial class MinimumStakeFunction : MinimumStakeFunctionBase { }

    [Function("minimumStake", "uint256")]
    public class MinimumStakeFunctionBase : FunctionMessage
    {

    }

    public partial class PenalizeTokensFunction : PenalizeTokensFunctionBase { }

    [Function("penalizeTokens")]
    public class PenalizeTokensFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class PermittedStakersOnFunction : PermittedStakersOnFunctionBase { }

    [Function("permittedStakersOn", "bool")]
    public class PermittedStakersOnFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveAliasFunction : RemoveAliasFunctionBase { }

    [Function("removeAlias")]
    public class RemoveAliasFunctionBase : FunctionMessage
    {
        [Parameter("address", "aliasAccount", 1)]
        public virtual string AliasAccount { get; set; }
    }

    public partial class RemovePermittedStakerFunction : RemovePermittedStakerFunctionBase { }

    [Function("removePermittedStaker")]
    public class RemovePermittedStakerFunctionBase : FunctionMessage
    {
        [Parameter("address", "staker", 1)]
        public virtual string Staker { get; set; }
    }

    public partial class RestakePenaltyTokensFunction : RestakePenaltyTokensFunctionBase { }

    [Function("restakePenaltyTokens")]
    public class RestakePenaltyTokensFunctionBase : FunctionMessage
    {
        [Parameter("address", "staker", 1)]
        public virtual string Staker { get; set; }
        [Parameter("uint256", "balance", 2)]
        public virtual BigInteger Balance { get; set; }
    }

    public partial class RewardOfFunction : RewardOfFunctionBase { }

    [Function("rewardOf", "uint256")]
    public class RewardOfFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class RewardValidatorFunction : RewardValidatorFunctionBase { }

    [Function("rewardValidator")]
    public class RewardValidatorFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class SetContractResolverFunction : SetContractResolverFunctionBase { }

    [Function("setContractResolver")]
    public class SetContractResolverFunctionBase : FunctionMessage
    {
        [Parameter("address", "newResolverAddress", 1)]
        public virtual string NewResolverAddress { get; set; }
    }

    public partial class SetMaxAliasCountFunction : SetMaxAliasCountFunctionBase { }

    [Function("setMaxAliasCount")]
    public class SetMaxAliasCountFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newMaxAliasCount", 1)]
        public virtual BigInteger NewMaxAliasCount { get; set; }
    }

    public partial class SetMaximumStakeFunction : SetMaximumStakeFunctionBase { }

    [Function("setMaximumStake")]
    public class SetMaximumStakeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newMaximumStake", 1)]
        public virtual BigInteger NewMaximumStake { get; set; }
    }

    public partial class SetMinimumStakeFunction : SetMinimumStakeFunctionBase { }

    [Function("setMinimumStake")]
    public class SetMinimumStakeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "newMinimumStake", 1)]
        public virtual BigInteger NewMinimumStake { get; set; }
    }

    public partial class SetPermittedStakersOnFunction : SetPermittedStakersOnFunctionBase { }

    [Function("setPermittedStakersOn")]
    public class SetPermittedStakersOnFunctionBase : FunctionMessage
    {
        [Parameter("bool", "permitted", 1)]
        public virtual bool Permitted { get; set; }
    }

    public partial class StakeFunction : StakeFunctionBase { }

    [Function("stake")]
    public class StakeFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class TotalStakedFunction : TotalStakedFunctionBase { }

    [Function("totalStaked", "uint256")]
    public class TotalStakedFunctionBase : FunctionMessage
    {

    }

    public partial class TransferPenaltyTokensFunction : TransferPenaltyTokensFunctionBase { }

    [Function("transferPenaltyTokens")]
    public class TransferPenaltyTokensFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "balance", 1)]
        public virtual BigInteger Balance { get; set; }
        [Parameter("address", "recipient", 2)]
        public virtual string Recipient { get; set; }
    }

    public partial class Withdraw1Function : Withdraw1FunctionBase { }

    [Function("withdraw")]
    public class Withdraw1FunctionBase : FunctionMessage
    {
        [Parameter("uint256", "amount", 1)]
        public virtual BigInteger Amount { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw")]
    public class WithdrawFunctionBase : FunctionMessage
    {

    }

    public partial class WithdrawPenaltyTokensFunction : WithdrawPenaltyTokensFunctionBase { }

    [Function("withdrawPenaltyTokens")]
    public class WithdrawPenaltyTokensFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "balance", 1)]
        public virtual BigInteger Balance { get; set; }
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

    public partial class AliasAddedEventDTO : AliasAddedEventDTOBase { }

    [Event("AliasAdded")]
    public class AliasAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("address", "aliasAccount", 2, false )]
        public virtual string AliasAccount { get; set; }
    }

    public partial class AliasRemovedEventDTO : AliasRemovedEventDTOBase { }

    [Event("AliasRemoved")]
    public class AliasRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("address", "aliasAccount", 2, false )]
        public virtual string AliasAccount { get; set; }
    }

    public partial class MaxAliasCountSetEventDTO : MaxAliasCountSetEventDTOBase { }

    [Event("MaxAliasCountSet")]
    public class MaxAliasCountSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newMaxAliasCount", 1, false )]
        public virtual BigInteger NewMaxAliasCount { get; set; }
    }

    public partial class MaximumStakeSetEventDTO : MaximumStakeSetEventDTOBase { }

    [Event("MaximumStakeSet")]
    public class MaximumStakeSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newMaximumStake", 1, false )]
        public virtual BigInteger NewMaximumStake { get; set; }
    }

    public partial class MinimumStakeSetEventDTO : MinimumStakeSetEventDTOBase { }

    [Event("MinimumStakeSet")]
    public class MinimumStakeSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newMinimumStake", 1, false )]
        public virtual BigInteger NewMinimumStake { get; set; }
    }

    public partial class PermittedStakerAddedEventDTO : PermittedStakerAddedEventDTOBase { }

    [Event("PermittedStakerAdded")]
    public class PermittedStakerAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, false )]
        public virtual string Staker { get; set; }
    }

    public partial class PermittedStakerRemovedEventDTO : PermittedStakerRemovedEventDTOBase { }

    [Event("PermittedStakerRemoved")]
    public class PermittedStakerRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, false )]
        public virtual string Staker { get; set; }
    }

    public partial class PermittedStakersOnChangedEventDTO : PermittedStakersOnChangedEventDTOBase { }

    [Event("PermittedStakersOnChanged")]
    public class PermittedStakersOnChangedEventDTOBase : IEventDTO
    {
        [Parameter("bool", "permittedStakersOn", 1, false )]
        public virtual bool PermittedStakersOn { get; set; }
    }

    public partial class ResolverContractAddressSetEventDTO : ResolverContractAddressSetEventDTOBase { }

    [Event("ResolverContractAddressSet")]
    public class ResolverContractAddressSetEventDTOBase : IEventDTO
    {
        [Parameter("address", "newResolverAddress", 1, false )]
        public virtual string NewResolverAddress { get; set; }
    }

    public partial class RewardPaidEventDTO : RewardPaidEventDTOBase { }

    [Event("RewardPaid")]
    public class RewardPaidEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("uint256", "reward", 2, false )]
        public virtual BigInteger Reward { get; set; }
    }

    public partial class StakedEventDTO : StakedEventDTOBase { }

    [Event("Staked")]
    public class StakedEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("uint256", "amount", 2, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class TokenRewardPerTokenPerEpochSetEventDTO : TokenRewardPerTokenPerEpochSetEventDTOBase { }

    [Event("TokenRewardPerTokenPerEpochSet")]
    public class TokenRewardPerTokenPerEpochSetEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "newTokenRewardPerTokenPerEpoch", 1, false )]
        public virtual BigInteger NewTokenRewardPerTokenPerEpoch { get; set; }
    }

    public partial class ValidatorNotRewardedBecauseAliasEventDTO : ValidatorNotRewardedBecauseAliasEventDTOBase { }

    [Event("ValidatorNotRewardedBecauseAlias")]
    public class ValidatorNotRewardedBecauseAliasEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("address", "aliasAccount", 2, false )]
        public virtual string AliasAccount { get; set; }
    }

    public partial class ValidatorRewardedEventDTO : ValidatorRewardedEventDTOBase { }

    [Event("ValidatorRewarded")]
    public class ValidatorRewardedEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("uint256", "amount", 2, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class ValidatorTokensPenalizedEventDTO : ValidatorTokensPenalizedEventDTOBase { }

    [Event("ValidatorTokensPenalized")]
    public class ValidatorTokensPenalizedEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("uint256", "amount", 2, false )]
        public virtual BigInteger Amount { get; set; }
    }

    public partial class WithdrawnEventDTO : WithdrawnEventDTOBase { }

    [Event("Withdrawn")]
    public class WithdrawnEventDTOBase : IEventDTO
    {
        [Parameter("address", "staker", 1, true )]
        public virtual string Staker { get; set; }
        [Parameter("uint256", "amount", 2, false )]
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

    public partial class ActiveValidatorsCannotLeaveError : ActiveValidatorsCannotLeaveErrorBase { }
    [Error("ActiveValidatorsCannotLeave")]
    public class ActiveValidatorsCannotLeaveErrorBase : IErrorDTO
    {
    }

    public partial class AliasNotOwnedBySenderError : AliasNotOwnedBySenderErrorBase { }

    [Error("AliasNotOwnedBySender")]
    public class AliasNotOwnedBySenderErrorBase : IErrorDTO
    {
        [Parameter("address", "aliasAccount", 1)]
        public virtual string AliasAccount { get; set; }
        [Parameter("address", "stakerAddress", 2)]
        public virtual string StakerAddress { get; set; }
    }

    public partial class CallerNotOwnerError : CallerNotOwnerErrorBase { }
    [Error("CallerNotOwner")]
    public class CallerNotOwnerErrorBase : IErrorDTO
    {
    }

    public partial class CannotRemoveAliasOfActiveValidatorError : CannotRemoveAliasOfActiveValidatorErrorBase { }

    [Error("CannotRemoveAliasOfActiveValidator")]
    public class CannotRemoveAliasOfActiveValidatorErrorBase : IErrorDTO
    {
        [Parameter("address", "aliasAccount", 1)]
        public virtual string AliasAccount { get; set; }
    }

    public partial class CannotStakeZeroError : CannotStakeZeroErrorBase { }
    [Error("CannotStakeZero")]
    public class CannotStakeZeroErrorBase : IErrorDTO
    {
    }

    public partial class CannotWithdrawZeroError : CannotWithdrawZeroErrorBase { }
    [Error("CannotWithdrawZero")]
    public class CannotWithdrawZeroErrorBase : IErrorDTO
    {
    }

    public partial class MaxAliasCountReachedError : MaxAliasCountReachedErrorBase { }

    [Error("MaxAliasCountReached")]
    public class MaxAliasCountReachedErrorBase : IErrorDTO
    {
        [Parameter("uint256", "aliasCount", 1)]
        public virtual BigInteger AliasCount { get; set; }
    }

    public partial class OnlyStakingContractError : OnlyStakingContractErrorBase { }

    [Error("OnlyStakingContract")]
    public class OnlyStakingContractErrorBase : IErrorDTO
    {
        [Parameter("address", "sender", 1)]
        public virtual string Sender { get; set; }
    }

    public partial class StakeMustBeGreaterThanMinimumStakeError : StakeMustBeGreaterThanMinimumStakeErrorBase { }

    [Error("StakeMustBeGreaterThanMinimumStake")]
    public class StakeMustBeGreaterThanMinimumStakeErrorBase : IErrorDTO
    {
        [Parameter("uint256", "amountStaked", 1)]
        public virtual BigInteger AmountStaked { get; set; }
        [Parameter("uint256", "minimumStake", 2)]
        public virtual BigInteger MinimumStake { get; set; }
    }

    public partial class StakeMustBeLessThanMaximumStakeError : StakeMustBeLessThanMaximumStakeErrorBase { }

    [Error("StakeMustBeLessThanMaximumStake")]
    public class StakeMustBeLessThanMaximumStakeErrorBase : IErrorDTO
    {
        [Parameter("uint256", "amountStaked", 1)]
        public virtual BigInteger AmountStaked { get; set; }
        [Parameter("uint256", "maximumStake", 2)]
        public virtual BigInteger MaximumStake { get; set; }
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









    public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

    [FunctionOutput]
    public class BalanceOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class CheckStakingAmountsOutputDTO : CheckStakingAmountsOutputDTOBase { }

    [FunctionOutput]
    public class CheckStakingAmountsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }



    public partial class GetStakingAddressOutputDTO : GetStakingAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetStakingAddressOutputDTOBase : IFunctionOutputDTO 
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

    public partial class IsPermittedStakerOutputDTO : IsPermittedStakerOutputDTOBase { }

    [FunctionOutput]
    public class IsPermittedStakerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class MaximumStakeOutputDTO : MaximumStakeOutputDTOBase { }

    [FunctionOutput]
    public class MaximumStakeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class MinimumStakeOutputDTO : MinimumStakeOutputDTOBase { }

    [FunctionOutput]
    public class MinimumStakeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }



    public partial class PermittedStakersOnOutputDTO : PermittedStakersOnOutputDTOBase { }

    [FunctionOutput]
    public class PermittedStakersOnOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }







    public partial class RewardOfOutputDTO : RewardOfOutputDTOBase { }

    [FunctionOutput]
    public class RewardOfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }















    public partial class TotalStakedOutputDTO : TotalStakedOutputDTOBase { }

    [FunctionOutput]
    public class TotalStakedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }








}
