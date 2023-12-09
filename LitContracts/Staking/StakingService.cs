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
using LitContracts.Staking.ContractDefinition;

namespace LitContracts.Staking
{
    public partial class StakingService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, StakingDeployment stakingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<StakingDeployment>().SendRequestAndWaitForReceiptAsync(stakingDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, StakingDeployment stakingDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<StakingDeployment>().SendRequestAsync(stakingDeployment);
        }

        public static async Task<StakingService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, StakingDeployment stakingDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, stakingDeployment, cancellationTokenSource);
            return new StakingService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public StakingService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public StakingService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<string> AdminKickValidatorInNextEpochRequestAsync(AdminKickValidatorInNextEpochFunction adminKickValidatorInNextEpochFunction)
        {
             return ContractHandler.SendRequestAsync(adminKickValidatorInNextEpochFunction);
        }

        public Task<TransactionReceipt> AdminKickValidatorInNextEpochRequestAndWaitForReceiptAsync(AdminKickValidatorInNextEpochFunction adminKickValidatorInNextEpochFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(adminKickValidatorInNextEpochFunction, cancellationToken);
        }

        public Task<string> AdminKickValidatorInNextEpochRequestAsync(string validatorStakerAddress)
        {
            var adminKickValidatorInNextEpochFunction = new AdminKickValidatorInNextEpochFunction();
                adminKickValidatorInNextEpochFunction.ValidatorStakerAddress = validatorStakerAddress;
            
             return ContractHandler.SendRequestAsync(adminKickValidatorInNextEpochFunction);
        }

        public Task<TransactionReceipt> AdminKickValidatorInNextEpochRequestAndWaitForReceiptAsync(string validatorStakerAddress, CancellationTokenSource cancellationToken = null)
        {
            var adminKickValidatorInNextEpochFunction = new AdminKickValidatorInNextEpochFunction();
                adminKickValidatorInNextEpochFunction.ValidatorStakerAddress = validatorStakerAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(adminKickValidatorInNextEpochFunction, cancellationToken);
        }

        public Task<string> AdminRejoinValidatorRequestAsync(AdminRejoinValidatorFunction adminRejoinValidatorFunction)
        {
             return ContractHandler.SendRequestAsync(adminRejoinValidatorFunction);
        }

        public Task<TransactionReceipt> AdminRejoinValidatorRequestAndWaitForReceiptAsync(AdminRejoinValidatorFunction adminRejoinValidatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(adminRejoinValidatorFunction, cancellationToken);
        }

        public Task<string> AdminRejoinValidatorRequestAsync(string staker)
        {
            var adminRejoinValidatorFunction = new AdminRejoinValidatorFunction();
                adminRejoinValidatorFunction.Staker = staker;
            
             return ContractHandler.SendRequestAsync(adminRejoinValidatorFunction);
        }

        public Task<TransactionReceipt> AdminRejoinValidatorRequestAndWaitForReceiptAsync(string staker, CancellationTokenSource cancellationToken = null)
        {
            var adminRejoinValidatorFunction = new AdminRejoinValidatorFunction();
                adminRejoinValidatorFunction.Staker = staker;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(adminRejoinValidatorFunction, cancellationToken);
        }

        public Task<string> AdminSlashValidatorRequestAsync(AdminSlashValidatorFunction adminSlashValidatorFunction)
        {
             return ContractHandler.SendRequestAsync(adminSlashValidatorFunction);
        }

        public Task<TransactionReceipt> AdminSlashValidatorRequestAndWaitForReceiptAsync(AdminSlashValidatorFunction adminSlashValidatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(adminSlashValidatorFunction, cancellationToken);
        }

        public Task<string> AdminSlashValidatorRequestAsync(string validatorStakerAddress, BigInteger amountToPenalize)
        {
            var adminSlashValidatorFunction = new AdminSlashValidatorFunction();
                adminSlashValidatorFunction.ValidatorStakerAddress = validatorStakerAddress;
                adminSlashValidatorFunction.AmountToPenalize = amountToPenalize;
            
             return ContractHandler.SendRequestAsync(adminSlashValidatorFunction);
        }

        public Task<TransactionReceipt> AdminSlashValidatorRequestAndWaitForReceiptAsync(string validatorStakerAddress, BigInteger amountToPenalize, CancellationTokenSource cancellationToken = null)
        {
            var adminSlashValidatorFunction = new AdminSlashValidatorFunction();
                adminSlashValidatorFunction.ValidatorStakerAddress = validatorStakerAddress;
                adminSlashValidatorFunction.AmountToPenalize = amountToPenalize;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(adminSlashValidatorFunction, cancellationToken);
        }

        public Task<string> AdvanceEpochRequestAsync(AdvanceEpochFunction advanceEpochFunction)
        {
             return ContractHandler.SendRequestAsync(advanceEpochFunction);
        }

        public Task<string> AdvanceEpochRequestAsync()
        {
             return ContractHandler.SendRequestAsync<AdvanceEpochFunction>();
        }

        public Task<TransactionReceipt> AdvanceEpochRequestAndWaitForReceiptAsync(AdvanceEpochFunction advanceEpochFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(advanceEpochFunction, cancellationToken);
        }

        public Task<TransactionReceipt> AdvanceEpochRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<AdvanceEpochFunction>(null, cancellationToken);
        }

        public Task<string> ExitRequestAsync(ExitFunction exitFunction)
        {
             return ContractHandler.SendRequestAsync(exitFunction);
        }

        public Task<string> ExitRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ExitFunction>();
        }

        public Task<TransactionReceipt> ExitRequestAndWaitForReceiptAsync(ExitFunction exitFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(exitFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ExitRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ExitFunction>(null, cancellationToken);
        }

        public Task<string> GetRewardRequestAsync(GetRewardFunction getRewardFunction)
        {
             return ContractHandler.SendRequestAsync(getRewardFunction);
        }

        public Task<string> GetRewardRequestAsync()
        {
             return ContractHandler.SendRequestAsync<GetRewardFunction>();
        }

        public Task<TransactionReceipt> GetRewardRequestAndWaitForReceiptAsync(GetRewardFunction getRewardFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(getRewardFunction, cancellationToken);
        }

        public Task<TransactionReceipt> GetRewardRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<GetRewardFunction>(null, cancellationToken);
        }

        public Task<string> KickValidatorInNextEpochRequestAsync(KickValidatorInNextEpochFunction kickValidatorInNextEpochFunction)
        {
             return ContractHandler.SendRequestAsync(kickValidatorInNextEpochFunction);
        }

        public Task<TransactionReceipt> KickValidatorInNextEpochRequestAndWaitForReceiptAsync(KickValidatorInNextEpochFunction kickValidatorInNextEpochFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(kickValidatorInNextEpochFunction, cancellationToken);
        }

        public Task<string> KickValidatorInNextEpochRequestAsync(string validatorStakerAddress, BigInteger reason, byte[] data)
        {
            var kickValidatorInNextEpochFunction = new KickValidatorInNextEpochFunction();
                kickValidatorInNextEpochFunction.ValidatorStakerAddress = validatorStakerAddress;
                kickValidatorInNextEpochFunction.Reason = reason;
                kickValidatorInNextEpochFunction.Data = data;
            
             return ContractHandler.SendRequestAsync(kickValidatorInNextEpochFunction);
        }

        public Task<TransactionReceipt> KickValidatorInNextEpochRequestAndWaitForReceiptAsync(string validatorStakerAddress, BigInteger reason, byte[] data, CancellationTokenSource cancellationToken = null)
        {
            var kickValidatorInNextEpochFunction = new KickValidatorInNextEpochFunction();
                kickValidatorInNextEpochFunction.ValidatorStakerAddress = validatorStakerAddress;
                kickValidatorInNextEpochFunction.Reason = reason;
                kickValidatorInNextEpochFunction.Data = data;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(kickValidatorInNextEpochFunction, cancellationToken);
        }

        public Task<string> LockValidatorsForNextEpochRequestAsync(LockValidatorsForNextEpochFunction lockValidatorsForNextEpochFunction)
        {
             return ContractHandler.SendRequestAsync(lockValidatorsForNextEpochFunction);
        }

        public Task<string> LockValidatorsForNextEpochRequestAsync()
        {
             return ContractHandler.SendRequestAsync<LockValidatorsForNextEpochFunction>();
        }

        public Task<TransactionReceipt> LockValidatorsForNextEpochRequestAndWaitForReceiptAsync(LockValidatorsForNextEpochFunction lockValidatorsForNextEpochFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(lockValidatorsForNextEpochFunction, cancellationToken);
        }

        public Task<TransactionReceipt> LockValidatorsForNextEpochRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<LockValidatorsForNextEpochFunction>(null, cancellationToken);
        }

        public Task<string> RequestToJoinRequestAsync(RequestToJoinFunction requestToJoinFunction)
        {
             return ContractHandler.SendRequestAsync(requestToJoinFunction);
        }

        public Task<TransactionReceipt> RequestToJoinRequestAndWaitForReceiptAsync(RequestToJoinFunction requestToJoinFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(requestToJoinFunction, cancellationToken);
        }

        public Task<string> RequestToJoinRequestAsync(uint ip, BigInteger ipv6, uint port, string nodeAddress, BigInteger senderPubKey, BigInteger receiverPubKey)
        {
            var requestToJoinFunction = new RequestToJoinFunction();
                requestToJoinFunction.Ip = ip;
                requestToJoinFunction.Ipv6 = ipv6;
                requestToJoinFunction.Port = port;
                requestToJoinFunction.NodeAddress = nodeAddress;
                requestToJoinFunction.SenderPubKey = senderPubKey;
                requestToJoinFunction.ReceiverPubKey = receiverPubKey;
            
             return ContractHandler.SendRequestAsync(requestToJoinFunction);
        }

        public Task<TransactionReceipt> RequestToJoinRequestAndWaitForReceiptAsync(uint ip, BigInteger ipv6, uint port, string nodeAddress, BigInteger senderPubKey, BigInteger receiverPubKey, CancellationTokenSource cancellationToken = null)
        {
            var requestToJoinFunction = new RequestToJoinFunction();
                requestToJoinFunction.Ip = ip;
                requestToJoinFunction.Ipv6 = ipv6;
                requestToJoinFunction.Port = port;
                requestToJoinFunction.NodeAddress = nodeAddress;
                requestToJoinFunction.SenderPubKey = senderPubKey;
                requestToJoinFunction.ReceiverPubKey = receiverPubKey;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(requestToJoinFunction, cancellationToken);
        }

        public Task<string> RequestToLeaveRequestAsync(RequestToLeaveFunction requestToLeaveFunction)
        {
             return ContractHandler.SendRequestAsync(requestToLeaveFunction);
        }

        public Task<string> RequestToLeaveRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RequestToLeaveFunction>();
        }

        public Task<TransactionReceipt> RequestToLeaveRequestAndWaitForReceiptAsync(RequestToLeaveFunction requestToLeaveFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(requestToLeaveFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RequestToLeaveRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RequestToLeaveFunction>(null, cancellationToken);
        }

        public Task<string> SetConfigRequestAsync(SetConfigFunction setConfigFunction)
        {
             return ContractHandler.SendRequestAsync(setConfigFunction);
        }

        public Task<TransactionReceipt> SetConfigRequestAndWaitForReceiptAsync(SetConfigFunction setConfigFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setConfigFunction, cancellationToken);
        }

        public Task<string> SetConfigRequestAsync(BigInteger newTokenRewardPerTokenPerEpoch, BigInteger newComplaintTolerance, BigInteger newComplaintIntervalSecs, List<BigInteger> newKeyTypes, BigInteger newMinimumValidatorCount, BigInteger newMaxConcurrentRequests, BigInteger newMaxTripleCount, BigInteger newMinTripleCount)
        {
            var setConfigFunction = new SetConfigFunction();
                setConfigFunction.NewTokenRewardPerTokenPerEpoch = newTokenRewardPerTokenPerEpoch;
                setConfigFunction.NewComplaintTolerance = newComplaintTolerance;
                setConfigFunction.NewComplaintIntervalSecs = newComplaintIntervalSecs;
                setConfigFunction.NewKeyTypes = newKeyTypes;
                setConfigFunction.NewMinimumValidatorCount = newMinimumValidatorCount;
                setConfigFunction.NewMaxConcurrentRequests = newMaxConcurrentRequests;
                setConfigFunction.NewMaxTripleCount = newMaxTripleCount;
                setConfigFunction.NewMinTripleCount = newMinTripleCount;
            
             return ContractHandler.SendRequestAsync(setConfigFunction);
        }

        public Task<TransactionReceipt> SetConfigRequestAndWaitForReceiptAsync(BigInteger newTokenRewardPerTokenPerEpoch, BigInteger newComplaintTolerance, BigInteger newComplaintIntervalSecs, List<BigInteger> newKeyTypes, BigInteger newMinimumValidatorCount, BigInteger newMaxConcurrentRequests, BigInteger newMaxTripleCount, BigInteger newMinTripleCount, CancellationTokenSource cancellationToken = null)
        {
            var setConfigFunction = new SetConfigFunction();
                setConfigFunction.NewTokenRewardPerTokenPerEpoch = newTokenRewardPerTokenPerEpoch;
                setConfigFunction.NewComplaintTolerance = newComplaintTolerance;
                setConfigFunction.NewComplaintIntervalSecs = newComplaintIntervalSecs;
                setConfigFunction.NewKeyTypes = newKeyTypes;
                setConfigFunction.NewMinimumValidatorCount = newMinimumValidatorCount;
                setConfigFunction.NewMaxConcurrentRequests = newMaxConcurrentRequests;
                setConfigFunction.NewMaxTripleCount = newMaxTripleCount;
                setConfigFunction.NewMinTripleCount = newMinTripleCount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setConfigFunction, cancellationToken);
        }

        public Task<string> SetContractResolverRequestAsync(SetContractResolverFunction setContractResolverFunction)
        {
             return ContractHandler.SendRequestAsync(setContractResolverFunction);
        }

        public Task<TransactionReceipt> SetContractResolverRequestAndWaitForReceiptAsync(SetContractResolverFunction setContractResolverFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractResolverFunction, cancellationToken);
        }

        public Task<string> SetContractResolverRequestAsync(string newResolverAddress)
        {
            var setContractResolverFunction = new SetContractResolverFunction();
                setContractResolverFunction.NewResolverAddress = newResolverAddress;
            
             return ContractHandler.SendRequestAsync(setContractResolverFunction);
        }

        public Task<TransactionReceipt> SetContractResolverRequestAndWaitForReceiptAsync(string newResolverAddress, CancellationTokenSource cancellationToken = null)
        {
            var setContractResolverFunction = new SetContractResolverFunction();
                setContractResolverFunction.NewResolverAddress = newResolverAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractResolverFunction, cancellationToken);
        }

        public Task<string> SetEpochEndTimeRequestAsync(SetEpochEndTimeFunction setEpochEndTimeFunction)
        {
             return ContractHandler.SendRequestAsync(setEpochEndTimeFunction);
        }

        public Task<TransactionReceipt> SetEpochEndTimeRequestAndWaitForReceiptAsync(SetEpochEndTimeFunction setEpochEndTimeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEpochEndTimeFunction, cancellationToken);
        }

        public Task<string> SetEpochEndTimeRequestAsync(BigInteger newEpochEndTime)
        {
            var setEpochEndTimeFunction = new SetEpochEndTimeFunction();
                setEpochEndTimeFunction.NewEpochEndTime = newEpochEndTime;
            
             return ContractHandler.SendRequestAsync(setEpochEndTimeFunction);
        }

        public Task<TransactionReceipt> SetEpochEndTimeRequestAndWaitForReceiptAsync(BigInteger newEpochEndTime, CancellationTokenSource cancellationToken = null)
        {
            var setEpochEndTimeFunction = new SetEpochEndTimeFunction();
                setEpochEndTimeFunction.NewEpochEndTime = newEpochEndTime;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEpochEndTimeFunction, cancellationToken);
        }

        public Task<string> SetEpochLengthRequestAsync(SetEpochLengthFunction setEpochLengthFunction)
        {
             return ContractHandler.SendRequestAsync(setEpochLengthFunction);
        }

        public Task<TransactionReceipt> SetEpochLengthRequestAndWaitForReceiptAsync(SetEpochLengthFunction setEpochLengthFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEpochLengthFunction, cancellationToken);
        }

        public Task<string> SetEpochLengthRequestAsync(BigInteger newEpochLength)
        {
            var setEpochLengthFunction = new SetEpochLengthFunction();
                setEpochLengthFunction.NewEpochLength = newEpochLength;
            
             return ContractHandler.SendRequestAsync(setEpochLengthFunction);
        }

        public Task<TransactionReceipt> SetEpochLengthRequestAndWaitForReceiptAsync(BigInteger newEpochLength, CancellationTokenSource cancellationToken = null)
        {
            var setEpochLengthFunction = new SetEpochLengthFunction();
                setEpochLengthFunction.NewEpochLength = newEpochLength;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEpochLengthFunction, cancellationToken);
        }

        public Task<string> SetEpochStateRequestAsync(SetEpochStateFunction setEpochStateFunction)
        {
             return ContractHandler.SendRequestAsync(setEpochStateFunction);
        }

        public Task<TransactionReceipt> SetEpochStateRequestAndWaitForReceiptAsync(SetEpochStateFunction setEpochStateFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEpochStateFunction, cancellationToken);
        }

        public Task<string> SetEpochStateRequestAsync(byte newState)
        {
            var setEpochStateFunction = new SetEpochStateFunction();
                setEpochStateFunction.NewState = newState;
            
             return ContractHandler.SendRequestAsync(setEpochStateFunction);
        }

        public Task<TransactionReceipt> SetEpochStateRequestAndWaitForReceiptAsync(byte newState, CancellationTokenSource cancellationToken = null)
        {
            var setEpochStateFunction = new SetEpochStateFunction();
                setEpochStateFunction.NewState = newState;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEpochStateFunction, cancellationToken);
        }

        public Task<string> SetEpochTimeoutRequestAsync(SetEpochTimeoutFunction setEpochTimeoutFunction)
        {
             return ContractHandler.SendRequestAsync(setEpochTimeoutFunction);
        }

        public Task<TransactionReceipt> SetEpochTimeoutRequestAndWaitForReceiptAsync(SetEpochTimeoutFunction setEpochTimeoutFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEpochTimeoutFunction, cancellationToken);
        }

        public Task<string> SetEpochTimeoutRequestAsync(BigInteger newEpochTimeout)
        {
            var setEpochTimeoutFunction = new SetEpochTimeoutFunction();
                setEpochTimeoutFunction.NewEpochTimeout = newEpochTimeout;
            
             return ContractHandler.SendRequestAsync(setEpochTimeoutFunction);
        }

        public Task<TransactionReceipt> SetEpochTimeoutRequestAndWaitForReceiptAsync(BigInteger newEpochTimeout, CancellationTokenSource cancellationToken = null)
        {
            var setEpochTimeoutFunction = new SetEpochTimeoutFunction();
                setEpochTimeoutFunction.NewEpochTimeout = newEpochTimeout;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setEpochTimeoutFunction, cancellationToken);
        }

        public Task<string> SetIpPortNodeAddressAndCommunicationPubKeysRequestAsync(SetIpPortNodeAddressAndCommunicationPubKeysFunction setIpPortNodeAddressAndCommunicationPubKeysFunction)
        {
             return ContractHandler.SendRequestAsync(setIpPortNodeAddressAndCommunicationPubKeysFunction);
        }

        public Task<TransactionReceipt> SetIpPortNodeAddressAndCommunicationPubKeysRequestAndWaitForReceiptAsync(SetIpPortNodeAddressAndCommunicationPubKeysFunction setIpPortNodeAddressAndCommunicationPubKeysFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setIpPortNodeAddressAndCommunicationPubKeysFunction, cancellationToken);
        }

        public Task<string> SetIpPortNodeAddressAndCommunicationPubKeysRequestAsync(uint ip, BigInteger ipv6, uint port, string nodeAddress, BigInteger senderPubKey, BigInteger receiverPubKey)
        {
            var setIpPortNodeAddressAndCommunicationPubKeysFunction = new SetIpPortNodeAddressAndCommunicationPubKeysFunction();
                setIpPortNodeAddressAndCommunicationPubKeysFunction.Ip = ip;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.Ipv6 = ipv6;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.Port = port;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.NodeAddress = nodeAddress;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.SenderPubKey = senderPubKey;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.ReceiverPubKey = receiverPubKey;
            
             return ContractHandler.SendRequestAsync(setIpPortNodeAddressAndCommunicationPubKeysFunction);
        }

        public Task<TransactionReceipt> SetIpPortNodeAddressAndCommunicationPubKeysRequestAndWaitForReceiptAsync(uint ip, BigInteger ipv6, uint port, string nodeAddress, BigInteger senderPubKey, BigInteger receiverPubKey, CancellationTokenSource cancellationToken = null)
        {
            var setIpPortNodeAddressAndCommunicationPubKeysFunction = new SetIpPortNodeAddressAndCommunicationPubKeysFunction();
                setIpPortNodeAddressAndCommunicationPubKeysFunction.Ip = ip;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.Ipv6 = ipv6;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.Port = port;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.NodeAddress = nodeAddress;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.SenderPubKey = senderPubKey;
                setIpPortNodeAddressAndCommunicationPubKeysFunction.ReceiverPubKey = receiverPubKey;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setIpPortNodeAddressAndCommunicationPubKeysFunction, cancellationToken);
        }

        public Task<string> SetKickPenaltyPercentRequestAsync(SetKickPenaltyPercentFunction setKickPenaltyPercentFunction)
        {
             return ContractHandler.SendRequestAsync(setKickPenaltyPercentFunction);
        }

        public Task<TransactionReceipt> SetKickPenaltyPercentRequestAndWaitForReceiptAsync(SetKickPenaltyPercentFunction setKickPenaltyPercentFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setKickPenaltyPercentFunction, cancellationToken);
        }

        public Task<string> SetKickPenaltyPercentRequestAsync(BigInteger reason, BigInteger newKickPenaltyPercent)
        {
            var setKickPenaltyPercentFunction = new SetKickPenaltyPercentFunction();
                setKickPenaltyPercentFunction.Reason = reason;
                setKickPenaltyPercentFunction.NewKickPenaltyPercent = newKickPenaltyPercent;
            
             return ContractHandler.SendRequestAsync(setKickPenaltyPercentFunction);
        }

        public Task<TransactionReceipt> SetKickPenaltyPercentRequestAndWaitForReceiptAsync(BigInteger reason, BigInteger newKickPenaltyPercent, CancellationTokenSource cancellationToken = null)
        {
            var setKickPenaltyPercentFunction = new SetKickPenaltyPercentFunction();
                setKickPenaltyPercentFunction.Reason = reason;
                setKickPenaltyPercentFunction.NewKickPenaltyPercent = newKickPenaltyPercent;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setKickPenaltyPercentFunction, cancellationToken);
        }

        public Task<string> SignalReadyForNextEpochRequestAsync(SignalReadyForNextEpochFunction signalReadyForNextEpochFunction)
        {
             return ContractHandler.SendRequestAsync(signalReadyForNextEpochFunction);
        }

        public Task<TransactionReceipt> SignalReadyForNextEpochRequestAndWaitForReceiptAsync(SignalReadyForNextEpochFunction signalReadyForNextEpochFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(signalReadyForNextEpochFunction, cancellationToken);
        }

        public Task<string> SignalReadyForNextEpochRequestAsync(BigInteger epochNumber)
        {
            var signalReadyForNextEpochFunction = new SignalReadyForNextEpochFunction();
                signalReadyForNextEpochFunction.EpochNumber = epochNumber;
            
             return ContractHandler.SendRequestAsync(signalReadyForNextEpochFunction);
        }

        public Task<TransactionReceipt> SignalReadyForNextEpochRequestAndWaitForReceiptAsync(BigInteger epochNumber, CancellationTokenSource cancellationToken = null)
        {
            var signalReadyForNextEpochFunction = new SignalReadyForNextEpochFunction();
                signalReadyForNextEpochFunction.EpochNumber = epochNumber;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(signalReadyForNextEpochFunction, cancellationToken);
        }

        public Task<string> StakeRequestAsync(StakeFunction stakeFunction)
        {
             return ContractHandler.SendRequestAsync(stakeFunction);
        }

        public Task<TransactionReceipt> StakeRequestAndWaitForReceiptAsync(StakeFunction stakeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stakeFunction, cancellationToken);
        }

        public Task<string> StakeRequestAsync(BigInteger amount)
        {
            var stakeFunction = new StakeFunction();
                stakeFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(stakeFunction);
        }

        public Task<TransactionReceipt> StakeRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var stakeFunction = new StakeFunction();
                stakeFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stakeFunction, cancellationToken);
        }

        public Task<string> StakeAndJoinRequestAsync(StakeAndJoinFunction stakeAndJoinFunction)
        {
             return ContractHandler.SendRequestAsync(stakeAndJoinFunction);
        }

        public Task<TransactionReceipt> StakeAndJoinRequestAndWaitForReceiptAsync(StakeAndJoinFunction stakeAndJoinFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stakeAndJoinFunction, cancellationToken);
        }

        public Task<string> StakeAndJoinRequestAsync(BigInteger amount, uint ip, BigInteger ipv6, uint port, string nodeAddress, BigInteger senderPubKey, BigInteger receiverPubKey)
        {
            var stakeAndJoinFunction = new StakeAndJoinFunction();
                stakeAndJoinFunction.Amount = amount;
                stakeAndJoinFunction.Ip = ip;
                stakeAndJoinFunction.Ipv6 = ipv6;
                stakeAndJoinFunction.Port = port;
                stakeAndJoinFunction.NodeAddress = nodeAddress;
                stakeAndJoinFunction.SenderPubKey = senderPubKey;
                stakeAndJoinFunction.ReceiverPubKey = receiverPubKey;
            
             return ContractHandler.SendRequestAsync(stakeAndJoinFunction);
        }

        public Task<TransactionReceipt> StakeAndJoinRequestAndWaitForReceiptAsync(BigInteger amount, uint ip, BigInteger ipv6, uint port, string nodeAddress, BigInteger senderPubKey, BigInteger receiverPubKey, CancellationTokenSource cancellationToken = null)
        {
            var stakeAndJoinFunction = new StakeAndJoinFunction();
                stakeAndJoinFunction.Amount = amount;
                stakeAndJoinFunction.Ip = ip;
                stakeAndJoinFunction.Ipv6 = ipv6;
                stakeAndJoinFunction.Port = port;
                stakeAndJoinFunction.NodeAddress = nodeAddress;
                stakeAndJoinFunction.SenderPubKey = senderPubKey;
                stakeAndJoinFunction.ReceiverPubKey = receiverPubKey;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stakeAndJoinFunction, cancellationToken);
        }

        public Task<string> UnlockValidatorsForNextEpochRequestAsync(UnlockValidatorsForNextEpochFunction unlockValidatorsForNextEpochFunction)
        {
             return ContractHandler.SendRequestAsync(unlockValidatorsForNextEpochFunction);
        }

        public Task<string> UnlockValidatorsForNextEpochRequestAsync()
        {
             return ContractHandler.SendRequestAsync<UnlockValidatorsForNextEpochFunction>();
        }

        public Task<TransactionReceipt> UnlockValidatorsForNextEpochRequestAndWaitForReceiptAsync(UnlockValidatorsForNextEpochFunction unlockValidatorsForNextEpochFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(unlockValidatorsForNextEpochFunction, cancellationToken);
        }

        public Task<TransactionReceipt> UnlockValidatorsForNextEpochRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<UnlockValidatorsForNextEpochFunction>(null, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(BigInteger amount)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(BigInteger amount, CancellationTokenSource cancellationToken = null)
        {
            var withdrawFunction = new WithdrawFunction();
                withdrawFunction.Amount = amount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<bool> CheckVersionQueryAsync(CheckVersionFunction checkVersionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckVersionFunction, bool>(checkVersionFunction, blockParameter);
        }

        
        public Task<bool> CheckVersionQueryAsync(ContractDefinition.Version version, BlockParameter blockParameter = null)
        {
            var checkVersionFunction = new CheckVersionFunction();
                checkVersionFunction.Version = version;
            
            return ContractHandler.QueryAsync<CheckVersionFunction, bool>(checkVersionFunction, blockParameter);
        }

        public Task<GetMaxVersionOutputDTO> GetMaxVersionQueryAsync(GetMaxVersionFunction getMaxVersionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMaxVersionFunction, GetMaxVersionOutputDTO>(getMaxVersionFunction, blockParameter);
        }

        public Task<GetMaxVersionOutputDTO> GetMaxVersionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMaxVersionFunction, GetMaxVersionOutputDTO>(null, blockParameter);
        }

        public Task<string> GetMaxVersionStringQueryAsync(GetMaxVersionStringFunction getMaxVersionStringFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMaxVersionStringFunction, string>(getMaxVersionStringFunction, blockParameter);
        }

        
        public Task<string> GetMaxVersionStringQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMaxVersionStringFunction, string>(null, blockParameter);
        }

        public Task<GetMinVersionOutputDTO> GetMinVersionQueryAsync(GetMinVersionFunction getMinVersionFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMinVersionFunction, GetMinVersionOutputDTO>(getMinVersionFunction, blockParameter);
        }

        public Task<GetMinVersionOutputDTO> GetMinVersionQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetMinVersionFunction, GetMinVersionOutputDTO>(null, blockParameter);
        }

        public Task<string> GetMinVersionStringQueryAsync(GetMinVersionStringFunction getMinVersionStringFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMinVersionStringFunction, string>(getMinVersionStringFunction, blockParameter);
        }

        
        public Task<string> GetMinVersionStringQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMinVersionStringFunction, string>(null, blockParameter);
        }

        public Task<string> SetMaxVersionRequestAsync(SetMaxVersionFunction setMaxVersionFunction)
        {
             return ContractHandler.SendRequestAsync(setMaxVersionFunction);
        }

        public Task<TransactionReceipt> SetMaxVersionRequestAndWaitForReceiptAsync(SetMaxVersionFunction setMaxVersionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxVersionFunction, cancellationToken);
        }

        public Task<string> SetMaxVersionRequestAsync(ContractDefinition.Version version)
        {
            var setMaxVersionFunction = new SetMaxVersionFunction();
                setMaxVersionFunction.Version = version;
            
             return ContractHandler.SendRequestAsync(setMaxVersionFunction);
        }

        public Task<TransactionReceipt> SetMaxVersionRequestAndWaitForReceiptAsync(ContractDefinition.Version version, CancellationTokenSource cancellationToken = null)
        {
            var setMaxVersionFunction = new SetMaxVersionFunction();
                setMaxVersionFunction.Version = version;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxVersionFunction, cancellationToken);
        }

        public Task<string> SetMinVersionRequestAsync(SetMinVersionFunction setMinVersionFunction)
        {
             return ContractHandler.SendRequestAsync(setMinVersionFunction);
        }

        public Task<TransactionReceipt> SetMinVersionRequestAndWaitForReceiptAsync(SetMinVersionFunction setMinVersionFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMinVersionFunction, cancellationToken);
        }

        public Task<string> SetMinVersionRequestAsync(ContractDefinition.Version version)
        {
            var setMinVersionFunction = new SetMinVersionFunction();
                setMinVersionFunction.Version = version;
            
             return ContractHandler.SendRequestAsync(setMinVersionFunction);
        }

        public Task<TransactionReceipt> SetMinVersionRequestAndWaitForReceiptAsync(ContractDefinition.Version version, CancellationTokenSource cancellationToken = null)
        {
            var setMinVersionFunction = new SetMinVersionFunction();
                setMinVersionFunction.Version = version;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMinVersionFunction, cancellationToken);
        }

        public Task<ConfigOutputDTO> ConfigQueryAsync(ConfigFunction configFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ConfigFunction, ConfigOutputDTO>(configFunction, blockParameter);
        }

        public Task<ConfigOutputDTO> ConfigQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ConfigFunction, ConfigOutputDTO>(null, blockParameter);
        }

        public Task<string> ContractResolverQueryAsync(ContractResolverFunction contractResolverFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(contractResolverFunction, blockParameter);
        }

        
        public Task<string> ContractResolverQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> CountOfCurrentValidatorsReadyForNextEpochQueryAsync(CountOfCurrentValidatorsReadyForNextEpochFunction countOfCurrentValidatorsReadyForNextEpochFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CountOfCurrentValidatorsReadyForNextEpochFunction, BigInteger>(countOfCurrentValidatorsReadyForNextEpochFunction, blockParameter);
        }

        
        public Task<BigInteger> CountOfCurrentValidatorsReadyForNextEpochQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CountOfCurrentValidatorsReadyForNextEpochFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> CountOfNextValidatorsReadyForNextEpochQueryAsync(CountOfNextValidatorsReadyForNextEpochFunction countOfNextValidatorsReadyForNextEpochFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CountOfNextValidatorsReadyForNextEpochFunction, BigInteger>(countOfNextValidatorsReadyForNextEpochFunction, blockParameter);
        }

        
        public Task<BigInteger> CountOfNextValidatorsReadyForNextEpochQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CountOfNextValidatorsReadyForNextEpochFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> CurrentValidatorCountForConsensusQueryAsync(CurrentValidatorCountForConsensusFunction currentValidatorCountForConsensusFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CurrentValidatorCountForConsensusFunction, BigInteger>(currentValidatorCountForConsensusFunction, blockParameter);
        }

        
        public Task<BigInteger> CurrentValidatorCountForConsensusQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CurrentValidatorCountForConsensusFunction, BigInteger>(null, blockParameter);
        }

        public Task<EpochOutputDTO> EpochQueryAsync(EpochFunction epochFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<EpochFunction, EpochOutputDTO>(epochFunction, blockParameter);
        }

        public Task<EpochOutputDTO> EpochQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<EpochFunction, EpochOutputDTO>(null, blockParameter);
        }

        public Task<List<BigInteger>> GetKeyTypesQueryAsync(GetKeyTypesFunction getKeyTypesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetKeyTypesFunction, List<BigInteger>>(getKeyTypesFunction, blockParameter);
        }

        
        public Task<List<BigInteger>> GetKeyTypesQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetKeyTypesFunction, List<BigInteger>>(null, blockParameter);
        }

        public Task<List<string>> GetKickedValidatorsQueryAsync(GetKickedValidatorsFunction getKickedValidatorsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetKickedValidatorsFunction, List<string>>(getKickedValidatorsFunction, blockParameter);
        }

        
        public Task<List<string>> GetKickedValidatorsQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetKickedValidatorsFunction, List<string>>(null, blockParameter);
        }

        public Task<GetNodeStakerAddressMappingsOutputDTO> GetNodeStakerAddressMappingsQueryAsync(GetNodeStakerAddressMappingsFunction getNodeStakerAddressMappingsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetNodeStakerAddressMappingsFunction, GetNodeStakerAddressMappingsOutputDTO>(getNodeStakerAddressMappingsFunction, blockParameter);
        }

        public Task<GetNodeStakerAddressMappingsOutputDTO> GetNodeStakerAddressMappingsQueryAsync(List<string> addresses, BlockParameter blockParameter = null)
        {
            var getNodeStakerAddressMappingsFunction = new GetNodeStakerAddressMappingsFunction();
                getNodeStakerAddressMappingsFunction.Addresses = addresses;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetNodeStakerAddressMappingsFunction, GetNodeStakerAddressMappingsOutputDTO>(getNodeStakerAddressMappingsFunction, blockParameter);
        }

        public Task<string> GetStakingBalancesAddressQueryAsync(GetStakingBalancesAddressFunction getStakingBalancesAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakingBalancesAddressFunction, string>(getStakingBalancesAddressFunction, blockParameter);
        }

        
        public Task<string> GetStakingBalancesAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakingBalancesAddressFunction, string>(null, blockParameter);
        }

        public Task<string> GetTokenAddressQueryAsync(GetTokenAddressFunction getTokenAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTokenAddressFunction, string>(getTokenAddressFunction, blockParameter);
        }

        
        public Task<string> GetTokenAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTokenAddressFunction, string>(null, blockParameter);
        }

        public Task<List<string>> GetValidatorsInCurrentEpochQueryAsync(GetValidatorsInCurrentEpochFunction getValidatorsInCurrentEpochFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetValidatorsInCurrentEpochFunction, List<string>>(getValidatorsInCurrentEpochFunction, blockParameter);
        }

        
        public Task<List<string>> GetValidatorsInCurrentEpochQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetValidatorsInCurrentEpochFunction, List<string>>(null, blockParameter);
        }

        public Task<BigInteger> GetValidatorsInCurrentEpochLengthQueryAsync(GetValidatorsInCurrentEpochLengthFunction getValidatorsInCurrentEpochLengthFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetValidatorsInCurrentEpochLengthFunction, BigInteger>(getValidatorsInCurrentEpochLengthFunction, blockParameter);
        }

        
        public Task<BigInteger> GetValidatorsInCurrentEpochLengthQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetValidatorsInCurrentEpochLengthFunction, BigInteger>(null, blockParameter);
        }

        public Task<List<string>> GetValidatorsInNextEpochQueryAsync(GetValidatorsInNextEpochFunction getValidatorsInNextEpochFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetValidatorsInNextEpochFunction, List<string>>(getValidatorsInNextEpochFunction, blockParameter);
        }

        
        public Task<List<string>> GetValidatorsInNextEpochQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetValidatorsInNextEpochFunction, List<string>>(null, blockParameter);
        }

        public Task<GetValidatorsStructsOutputDTO> GetValidatorsStructsQueryAsync(GetValidatorsStructsFunction getValidatorsStructsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetValidatorsStructsFunction, GetValidatorsStructsOutputDTO>(getValidatorsStructsFunction, blockParameter);
        }

        public Task<GetValidatorsStructsOutputDTO> GetValidatorsStructsQueryAsync(List<string> addresses, BlockParameter blockParameter = null)
        {
            var getValidatorsStructsFunction = new GetValidatorsStructsFunction();
                getValidatorsStructsFunction.Addresses = addresses;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetValidatorsStructsFunction, GetValidatorsStructsOutputDTO>(getValidatorsStructsFunction, blockParameter);
        }

        public Task<GetValidatorsStructsInCurrentEpochOutputDTO> GetValidatorsStructsInCurrentEpochQueryAsync(GetValidatorsStructsInCurrentEpochFunction getValidatorsStructsInCurrentEpochFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetValidatorsStructsInCurrentEpochFunction, GetValidatorsStructsInCurrentEpochOutputDTO>(getValidatorsStructsInCurrentEpochFunction, blockParameter);
        }

        public Task<GetValidatorsStructsInCurrentEpochOutputDTO> GetValidatorsStructsInCurrentEpochQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetValidatorsStructsInCurrentEpochFunction, GetValidatorsStructsInCurrentEpochOutputDTO>(null, blockParameter);
        }

        public Task<GetValidatorsStructsInNextEpochOutputDTO> GetValidatorsStructsInNextEpochQueryAsync(GetValidatorsStructsInNextEpochFunction getValidatorsStructsInNextEpochFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetValidatorsStructsInNextEpochFunction, GetValidatorsStructsInNextEpochOutputDTO>(getValidatorsStructsInNextEpochFunction, blockParameter);
        }

        public Task<GetValidatorsStructsInNextEpochOutputDTO> GetValidatorsStructsInNextEpochQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetValidatorsStructsInNextEpochFunction, GetValidatorsStructsInNextEpochOutputDTO>(null, blockParameter);
        }

        public Task<GetVotingStatusToKickValidatorOutputDTO> GetVotingStatusToKickValidatorQueryAsync(GetVotingStatusToKickValidatorFunction getVotingStatusToKickValidatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetVotingStatusToKickValidatorFunction, GetVotingStatusToKickValidatorOutputDTO>(getVotingStatusToKickValidatorFunction, blockParameter);
        }

        public Task<GetVotingStatusToKickValidatorOutputDTO> GetVotingStatusToKickValidatorQueryAsync(BigInteger epochNumber, string validatorStakerAddress, string voterStakerAddress, BlockParameter blockParameter = null)
        {
            var getVotingStatusToKickValidatorFunction = new GetVotingStatusToKickValidatorFunction();
                getVotingStatusToKickValidatorFunction.EpochNumber = epochNumber;
                getVotingStatusToKickValidatorFunction.ValidatorStakerAddress = validatorStakerAddress;
                getVotingStatusToKickValidatorFunction.VoterStakerAddress = voterStakerAddress;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetVotingStatusToKickValidatorFunction, GetVotingStatusToKickValidatorOutputDTO>(getVotingStatusToKickValidatorFunction, blockParameter);
        }

        public Task<bool> IsActiveValidatorQueryAsync(IsActiveValidatorFunction isActiveValidatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsActiveValidatorFunction, bool>(isActiveValidatorFunction, blockParameter);
        }

        
        public Task<bool> IsActiveValidatorQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var isActiveValidatorFunction = new IsActiveValidatorFunction();
                isActiveValidatorFunction.Account = account;
            
            return ContractHandler.QueryAsync<IsActiveValidatorFunction, bool>(isActiveValidatorFunction, blockParameter);
        }

        public Task<bool> IsActiveValidatorByNodeAddressQueryAsync(IsActiveValidatorByNodeAddressFunction isActiveValidatorByNodeAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsActiveValidatorByNodeAddressFunction, bool>(isActiveValidatorByNodeAddressFunction, blockParameter);
        }

        
        public Task<bool> IsActiveValidatorByNodeAddressQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var isActiveValidatorByNodeAddressFunction = new IsActiveValidatorByNodeAddressFunction();
                isActiveValidatorByNodeAddressFunction.Account = account;
            
            return ContractHandler.QueryAsync<IsActiveValidatorByNodeAddressFunction, bool>(isActiveValidatorByNodeAddressFunction, blockParameter);
        }

        public Task<bool> IsReadyForNextEpochQueryAsync(IsReadyForNextEpochFunction isReadyForNextEpochFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsReadyForNextEpochFunction, bool>(isReadyForNextEpochFunction, blockParameter);
        }

        
        public Task<bool> IsReadyForNextEpochQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsReadyForNextEpochFunction, bool>(null, blockParameter);
        }

        public Task<BigInteger> KickPenaltyPercentByReasonQueryAsync(KickPenaltyPercentByReasonFunction kickPenaltyPercentByReasonFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<KickPenaltyPercentByReasonFunction, BigInteger>(kickPenaltyPercentByReasonFunction, blockParameter);
        }

        
        public Task<BigInteger> KickPenaltyPercentByReasonQueryAsync(BigInteger reason, BlockParameter blockParameter = null)
        {
            var kickPenaltyPercentByReasonFunction = new KickPenaltyPercentByReasonFunction();
                kickPenaltyPercentByReasonFunction.Reason = reason;
            
            return ContractHandler.QueryAsync<KickPenaltyPercentByReasonFunction, BigInteger>(kickPenaltyPercentByReasonFunction, blockParameter);
        }

        public Task<BigInteger> NextValidatorCountForConsensusQueryAsync(NextValidatorCountForConsensusFunction nextValidatorCountForConsensusFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NextValidatorCountForConsensusFunction, BigInteger>(nextValidatorCountForConsensusFunction, blockParameter);
        }

        
        public Task<BigInteger> NextValidatorCountForConsensusQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NextValidatorCountForConsensusFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> NodeAddressToStakerAddressQueryAsync(NodeAddressToStakerAddressFunction nodeAddressToStakerAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<NodeAddressToStakerAddressFunction, string>(nodeAddressToStakerAddressFunction, blockParameter);
        }

        
        public Task<string> NodeAddressToStakerAddressQueryAsync(string nodeAddress, BlockParameter blockParameter = null)
        {
            var nodeAddressToStakerAddressFunction = new NodeAddressToStakerAddressFunction();
                nodeAddressToStakerAddressFunction.NodeAddress = nodeAddress;
            
            return ContractHandler.QueryAsync<NodeAddressToStakerAddressFunction, string>(nodeAddressToStakerAddressFunction, blockParameter);
        }

        public Task<bool> ReadyForNextEpochQueryAsync(ReadyForNextEpochFunction readyForNextEpochFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReadyForNextEpochFunction, bool>(readyForNextEpochFunction, blockParameter);
        }

        
        public Task<bool> ReadyForNextEpochQueryAsync(string stakerAddress, BlockParameter blockParameter = null)
        {
            var readyForNextEpochFunction = new ReadyForNextEpochFunction();
                readyForNextEpochFunction.StakerAddress = stakerAddress;
            
            return ContractHandler.QueryAsync<ReadyForNextEpochFunction, bool>(readyForNextEpochFunction, blockParameter);
        }

        public Task<bool> ShouldKickValidatorQueryAsync(ShouldKickValidatorFunction shouldKickValidatorFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ShouldKickValidatorFunction, bool>(shouldKickValidatorFunction, blockParameter);
        }

        
        public Task<bool> ShouldKickValidatorQueryAsync(string stakerAddress, BlockParameter blockParameter = null)
        {
            var shouldKickValidatorFunction = new ShouldKickValidatorFunction();
                shouldKickValidatorFunction.StakerAddress = stakerAddress;
            
            return ContractHandler.QueryAsync<ShouldKickValidatorFunction, bool>(shouldKickValidatorFunction, blockParameter);
        }

        public Task<byte> StateQueryAsync(StateFunction stateFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StateFunction, byte>(stateFunction, blockParameter);
        }

        
        public Task<byte> StateQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<StateFunction, byte>(null, blockParameter);
        }

        public Task<ValidatorsOutputDTO> ValidatorsQueryAsync(ValidatorsFunction validatorsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ValidatorsFunction, ValidatorsOutputDTO>(validatorsFunction, blockParameter);
        }

        public Task<ValidatorsOutputDTO> ValidatorsQueryAsync(string stakerAddress, BlockParameter blockParameter = null)
        {
            var validatorsFunction = new ValidatorsFunction();
                validatorsFunction.StakerAddress = stakerAddress;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ValidatorsFunction, ValidatorsOutputDTO>(validatorsFunction, blockParameter);
        }
    }
}
