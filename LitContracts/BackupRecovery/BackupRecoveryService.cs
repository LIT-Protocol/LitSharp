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
using LitContracts.BackupRecovery.ContractDefinition;

namespace LitContracts.BackupRecovery
{
    public partial class BackupRecoveryService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, BackupRecoveryDeployment backupRecoveryDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<BackupRecoveryDeployment>().SendRequestAndWaitForReceiptAsync(backupRecoveryDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, BackupRecoveryDeployment backupRecoveryDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<BackupRecoveryDeployment>().SendRequestAsync(backupRecoveryDeployment);
        }

        public static async Task<BackupRecoveryService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, BackupRecoveryDeployment backupRecoveryDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, backupRecoveryDeployment, cancellationTokenSource);
            return new BackupRecoveryService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public BackupRecoveryService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public BackupRecoveryService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<BigInteger> CalculatePartyThresholdQueryAsync(CalculatePartyThresholdFunction calculatePartyThresholdFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculatePartyThresholdFunction, BigInteger>(calculatePartyThresholdFunction, blockParameter);
        }

        
        public Task<BigInteger> CalculatePartyThresholdQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<CalculatePartyThresholdFunction, BigInteger>(null, blockParameter);
        }

        public Task<bool> CheckValidatorSetForAddressQueryAsync(CheckValidatorSetForAddressFunction checkValidatorSetForAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckValidatorSetForAddressFunction, bool>(checkValidatorSetForAddressFunction, blockParameter);
        }

        
        public Task<bool> CheckValidatorSetForAddressQueryAsync(string sender, BlockParameter? blockParameter = null)
        {
            var checkValidatorSetForAddressFunction = new CheckValidatorSetForAddressFunction();
                checkValidatorSetForAddressFunction.Sender = sender;
            
            return ContractHandler.QueryAsync<CheckValidatorSetForAddressFunction, bool>(checkValidatorSetForAddressFunction, blockParameter);
        }

        public Task<string> GetStakingViewFacetQueryAsync(GetStakingViewFacetFunction getStakingViewFacetFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakingViewFacetFunction, string>(getStakingViewFacetFunction, blockParameter);
        }

        
        public Task<string> GetStakingViewFacetQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakingViewFacetFunction, string>(null, blockParameter);
        }

        public Task<bool> AllBackupMembersMappedQueryAsync(AllBackupMembersMappedFunction allBackupMembersMappedFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllBackupMembersMappedFunction, bool>(allBackupMembersMappedFunction, blockParameter);
        }

        
        public Task<bool> AllBackupMembersMappedQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<AllBackupMembersMappedFunction, bool>(null, blockParameter);
        }

        public Task<GetBackupPartyStateOutputDTO> GetBackupPartyStateQueryAsync(GetBackupPartyStateFunction getBackupPartyStateFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetBackupPartyStateFunction, GetBackupPartyStateOutputDTO>(getBackupPartyStateFunction, blockParameter);
        }

        public Task<GetBackupPartyStateOutputDTO> GetBackupPartyStateQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetBackupPartyStateFunction, GetBackupPartyStateOutputDTO>(null, blockParameter);
        }

        public Task<BigInteger> GetDecryptionThresholdQueryAsync(GetDecryptionThresholdFunction getDecryptionThresholdFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDecryptionThresholdFunction, BigInteger>(getDecryptionThresholdFunction, blockParameter);
        }

        
        public Task<BigInteger> GetDecryptionThresholdQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDecryptionThresholdFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> GetMemberForNodeDkgQueryAsync(GetMemberForNodeDkgFunction getMemberForNodeDkgFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMemberForNodeDkgFunction, string>(getMemberForNodeDkgFunction, blockParameter);
        }

        
        public Task<string> GetMemberForNodeDkgQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMemberForNodeDkgFunction, string>(null, blockParameter);
        }

        public Task<List<string>> GetNextBackupPartyMembersQueryAsync(GetNextBackupPartyMembersFunction getNextBackupPartyMembersFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNextBackupPartyMembersFunction, List<string>>(getNextBackupPartyMembersFunction, blockParameter);
        }

        
        public Task<List<string>> GetNextBackupPartyMembersQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNextBackupPartyMembersFunction, List<string>>(null, blockParameter);
        }

        public Task<List<string>> GetNodeAddressesForDkgQueryAsync(GetNodeAddressesForDkgFunction getNodeAddressesForDkgFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNodeAddressesForDkgFunction, List<string>>(getNodeAddressesForDkgFunction, blockParameter);
        }

        
        public Task<List<string>> GetNodeAddressesForDkgQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNodeAddressesForDkgFunction, List<string>>(null, blockParameter);
        }

        public Task<string> GetNodeForBackupMemberQueryAsync(GetNodeForBackupMemberFunction getNodeForBackupMemberFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNodeForBackupMemberFunction, string>(getNodeForBackupMemberFunction, blockParameter);
        }

        
        public Task<string> GetNodeForBackupMemberQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetNodeForBackupMemberFunction, string>(null, blockParameter);
        }

        public Task<GetPastBackupStateOutputDTO> GetPastBackupStateQueryAsync(GetPastBackupStateFunction getPastBackupStateFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetPastBackupStateFunction, GetPastBackupStateOutputDTO>(getPastBackupStateFunction, blockParameter);
        }

        public Task<GetPastBackupStateOutputDTO> GetPastBackupStateQueryAsync(byte[] sessionId, BlockParameter? blockParameter = null)
        {
            var getPastBackupStateFunction = new GetPastBackupStateFunction();
                getPastBackupStateFunction.SessionId = sessionId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetPastBackupStateFunction, GetPastBackupStateOutputDTO>(getPastBackupStateFunction, blockParameter);
        }

        public Task<List<string>> GetStakerAddressesForDkgQueryAsync(GetStakerAddressesForDkgFunction getStakerAddressesForDkgFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakerAddressesForDkgFunction, List<string>>(getStakerAddressesForDkgFunction, blockParameter);
        }

        
        public Task<List<string>> GetStakerAddressesForDkgQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakerAddressesForDkgFunction, List<string>>(null, blockParameter);
        }

        public Task<bool> IsNodeForDkgQueryAsync(IsNodeForDkgFunction isNodeForDkgFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsNodeForDkgFunction, bool>(isNodeForDkgFunction, blockParameter);
        }

        
        public Task<bool> IsNodeForDkgQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsNodeForDkgFunction, bool>(null, blockParameter);
        }

        public Task<bool> IsRecoveryDkgCompletedQueryAsync(IsRecoveryDkgCompletedFunction isRecoveryDkgCompletedFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsRecoveryDkgCompletedFunction, bool>(isRecoveryDkgCompletedFunction, blockParameter);
        }

        
        public Task<bool> IsRecoveryDkgCompletedQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsRecoveryDkgCompletedFunction, bool>(null, blockParameter);
        }

        public Task<string> RecieveNewKeySetRequestAsync(RecieveNewKeySetFunction recieveNewKeySetFunction)
        {
             return ContractHandler.SendRequestAsync(recieveNewKeySetFunction);
        }

        public Task<TransactionReceipt> RecieveNewKeySetRequestAndWaitForReceiptAsync(RecieveNewKeySetFunction recieveNewKeySetFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(recieveNewKeySetFunction, cancellationToken);
        }

        public Task<string> RecieveNewKeySetRequestAsync(byte[] publicKey, byte[] encryptedKey, byte[] sessionId)
        {
            var recieveNewKeySetFunction = new RecieveNewKeySetFunction();
                recieveNewKeySetFunction.PublicKey = publicKey;
                recieveNewKeySetFunction.EncryptedKey = encryptedKey;
                recieveNewKeySetFunction.SessionId = sessionId;
            
             return ContractHandler.SendRequestAsync(recieveNewKeySetFunction);
        }

        public Task<TransactionReceipt> RecieveNewKeySetRequestAndWaitForReceiptAsync(byte[] publicKey, byte[] encryptedKey, byte[] sessionId, CancellationTokenSource? cancellationToken = null)
        {
            var recieveNewKeySetFunction = new RecieveNewKeySetFunction();
                recieveNewKeySetFunction.PublicKey = publicKey;
                recieveNewKeySetFunction.EncryptedKey = encryptedKey;
                recieveNewKeySetFunction.SessionId = sessionId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(recieveNewKeySetFunction, cancellationToken);
        }

        public Task<string> RegisterNewBackupPartyRequestAsync(RegisterNewBackupPartyFunction registerNewBackupPartyFunction)
        {
             return ContractHandler.SendRequestAsync(registerNewBackupPartyFunction);
        }

        public Task<TransactionReceipt> RegisterNewBackupPartyRequestAndWaitForReceiptAsync(RegisterNewBackupPartyFunction registerNewBackupPartyFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerNewBackupPartyFunction, cancellationToken);
        }

        public Task<string> RegisterNewBackupPartyRequestAsync(List<string> partyMembers)
        {
            var registerNewBackupPartyFunction = new RegisterNewBackupPartyFunction();
                registerNewBackupPartyFunction.PartyMembers = partyMembers;
            
             return ContractHandler.SendRequestAsync(registerNewBackupPartyFunction);
        }

        public Task<TransactionReceipt> RegisterNewBackupPartyRequestAndWaitForReceiptAsync(List<string> partyMembers, CancellationTokenSource? cancellationToken = null)
        {
            var registerNewBackupPartyFunction = new RegisterNewBackupPartyFunction();
                registerNewBackupPartyFunction.PartyMembers = partyMembers;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerNewBackupPartyFunction, cancellationToken);
        }

        public Task<string> RegisterRecoveryKeysRequestAsync(RegisterRecoveryKeysFunction registerRecoveryKeysFunction)
        {
             return ContractHandler.SendRequestAsync(registerRecoveryKeysFunction);
        }

        public Task<TransactionReceipt> RegisterRecoveryKeysRequestAndWaitForReceiptAsync(RegisterRecoveryKeysFunction registerRecoveryKeysFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerRecoveryKeysFunction, cancellationToken);
        }

        public Task<string> RegisterRecoveryKeysRequestAsync(List<RecoveryKey> recoveryKeys)
        {
            var registerRecoveryKeysFunction = new RegisterRecoveryKeysFunction();
                registerRecoveryKeysFunction.RecoveryKeys = recoveryKeys;
            
             return ContractHandler.SendRequestAsync(registerRecoveryKeysFunction);
        }

        public Task<TransactionReceipt> RegisterRecoveryKeysRequestAndWaitForReceiptAsync(List<RecoveryKey> recoveryKeys, CancellationTokenSource? cancellationToken = null)
        {
            var registerRecoveryKeysFunction = new RegisterRecoveryKeysFunction();
                registerRecoveryKeysFunction.RecoveryKeys = recoveryKeys;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(registerRecoveryKeysFunction, cancellationToken);
        }

        public Task<string> SetMemberForDkgRequestAsync(SetMemberForDkgFunction setMemberForDkgFunction)
        {
             return ContractHandler.SendRequestAsync(setMemberForDkgFunction);
        }

        public Task<string> SetMemberForDkgRequestAsync()
        {
             return ContractHandler.SendRequestAsync<SetMemberForDkgFunction>();
        }

        public Task<TransactionReceipt> SetMemberForDkgRequestAndWaitForReceiptAsync(SetMemberForDkgFunction setMemberForDkgFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMemberForDkgFunction, cancellationToken);
        }

        public Task<TransactionReceipt> SetMemberForDkgRequestAndWaitForReceiptAsync(CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<SetMemberForDkgFunction>(null, cancellationToken);
        }
    }
}
