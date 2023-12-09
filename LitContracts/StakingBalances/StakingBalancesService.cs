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
using LitContracts.StakingBalances.ContractDefinition;

namespace LitContracts.StakingBalances
{
    public partial class StakingBalancesService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, StakingBalancesDeployment stakingBalancesDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<StakingBalancesDeployment>().SendRequestAndWaitForReceiptAsync(stakingBalancesDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, StakingBalancesDeployment stakingBalancesDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<StakingBalancesDeployment>().SendRequestAsync(stakingBalancesDeployment);
        }

        public static async Task<StakingBalancesService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, StakingBalancesDeployment stakingBalancesDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, stakingBalancesDeployment, cancellationTokenSource);
            return new StakingBalancesService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public StakingBalancesService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public StakingBalancesService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<string> AddAliasRequestAsync(AddAliasFunction addAliasFunction)
        {
             return ContractHandler.SendRequestAsync(addAliasFunction);
        }

        public Task<TransactionReceipt> AddAliasRequestAndWaitForReceiptAsync(AddAliasFunction addAliasFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAliasFunction, cancellationToken);
        }

        public Task<string> AddAliasRequestAsync(string aliasAccount)
        {
            var addAliasFunction = new AddAliasFunction();
                addAliasFunction.AliasAccount = aliasAccount;
            
             return ContractHandler.SendRequestAsync(addAliasFunction);
        }

        public Task<TransactionReceipt> AddAliasRequestAndWaitForReceiptAsync(string aliasAccount, CancellationTokenSource cancellationToken = null)
        {
            var addAliasFunction = new AddAliasFunction();
                addAliasFunction.AliasAccount = aliasAccount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addAliasFunction, cancellationToken);
        }

        public Task<string> AddPermittedStakerRequestAsync(AddPermittedStakerFunction addPermittedStakerFunction)
        {
             return ContractHandler.SendRequestAsync(addPermittedStakerFunction);
        }

        public Task<TransactionReceipt> AddPermittedStakerRequestAndWaitForReceiptAsync(AddPermittedStakerFunction addPermittedStakerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedStakerFunction, cancellationToken);
        }

        public Task<string> AddPermittedStakerRequestAsync(string staker)
        {
            var addPermittedStakerFunction = new AddPermittedStakerFunction();
                addPermittedStakerFunction.Staker = staker;
            
             return ContractHandler.SendRequestAsync(addPermittedStakerFunction);
        }

        public Task<TransactionReceipt> AddPermittedStakerRequestAndWaitForReceiptAsync(string staker, CancellationTokenSource cancellationToken = null)
        {
            var addPermittedStakerFunction = new AddPermittedStakerFunction();
                addPermittedStakerFunction.Staker = staker;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedStakerFunction, cancellationToken);
        }

        public Task<string> AddPermittedStakersRequestAsync(AddPermittedStakersFunction addPermittedStakersFunction)
        {
             return ContractHandler.SendRequestAsync(addPermittedStakersFunction);
        }

        public Task<TransactionReceipt> AddPermittedStakersRequestAndWaitForReceiptAsync(AddPermittedStakersFunction addPermittedStakersFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedStakersFunction, cancellationToken);
        }

        public Task<string> AddPermittedStakersRequestAsync(List<string> stakers)
        {
            var addPermittedStakersFunction = new AddPermittedStakersFunction();
                addPermittedStakersFunction.Stakers = stakers;
            
             return ContractHandler.SendRequestAsync(addPermittedStakersFunction);
        }

        public Task<TransactionReceipt> AddPermittedStakersRequestAndWaitForReceiptAsync(List<string> stakers, CancellationTokenSource cancellationToken = null)
        {
            var addPermittedStakersFunction = new AddPermittedStakersFunction();
                addPermittedStakersFunction.Stakers = stakers;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPermittedStakersFunction, cancellationToken);
        }

        public Task<BigInteger> BalanceOfQueryAsync(BalanceOfFunction balanceOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        
        public Task<BigInteger> BalanceOfQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var balanceOfFunction = new BalanceOfFunction();
                balanceOfFunction.Account = account;
            
            return ContractHandler.QueryAsync<BalanceOfFunction, BigInteger>(balanceOfFunction, blockParameter);
        }

        public Task<bool> CheckStakingAmountsQueryAsync(CheckStakingAmountsFunction checkStakingAmountsFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckStakingAmountsFunction, bool>(checkStakingAmountsFunction, blockParameter);
        }

        
        public Task<bool> CheckStakingAmountsQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var checkStakingAmountsFunction = new CheckStakingAmountsFunction();
                checkStakingAmountsFunction.Account = account;
            
            return ContractHandler.QueryAsync<CheckStakingAmountsFunction, bool>(checkStakingAmountsFunction, blockParameter);
        }

        public Task<string> ContractResolverQueryAsync(ContractResolverFunction contractResolverFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(contractResolverFunction, blockParameter);
        }

        
        public Task<string> ContractResolverQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(null, blockParameter);
        }

        public Task<string> GetRewardRequestAsync(GetRewardFunction getRewardFunction)
        {
             return ContractHandler.SendRequestAsync(getRewardFunction);
        }

        public Task<TransactionReceipt> GetRewardRequestAndWaitForReceiptAsync(GetRewardFunction getRewardFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(getRewardFunction, cancellationToken);
        }

        public Task<string> GetRewardRequestAsync(string account)
        {
            var getRewardFunction = new GetRewardFunction();
                getRewardFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(getRewardFunction);
        }

        public Task<TransactionReceipt> GetRewardRequestAndWaitForReceiptAsync(string account, CancellationTokenSource cancellationToken = null)
        {
            var getRewardFunction = new GetRewardFunction();
                getRewardFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(getRewardFunction, cancellationToken);
        }

        public Task<string> GetStakingAddressQueryAsync(GetStakingAddressFunction getStakingAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakingAddressFunction, string>(getStakingAddressFunction, blockParameter);
        }

        
        public Task<string> GetStakingAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetStakingAddressFunction, string>(null, blockParameter);
        }

        public Task<string> GetTokenAddressQueryAsync(GetTokenAddressFunction getTokenAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTokenAddressFunction, string>(getTokenAddressFunction, blockParameter);
        }

        
        public Task<string> GetTokenAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetTokenAddressFunction, string>(null, blockParameter);
        }

        public Task<bool> IsPermittedStakerQueryAsync(IsPermittedStakerFunction isPermittedStakerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsPermittedStakerFunction, bool>(isPermittedStakerFunction, blockParameter);
        }

        
        public Task<bool> IsPermittedStakerQueryAsync(string staker, BlockParameter blockParameter = null)
        {
            var isPermittedStakerFunction = new IsPermittedStakerFunction();
                isPermittedStakerFunction.Staker = staker;
            
            return ContractHandler.QueryAsync<IsPermittedStakerFunction, bool>(isPermittedStakerFunction, blockParameter);
        }

        public Task<BigInteger> MaximumStakeQueryAsync(MaximumStakeFunction maximumStakeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaximumStakeFunction, BigInteger>(maximumStakeFunction, blockParameter);
        }

        
        public Task<BigInteger> MaximumStakeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MaximumStakeFunction, BigInteger>(null, blockParameter);
        }

        public Task<BigInteger> MinimumStakeQueryAsync(MinimumStakeFunction minimumStakeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MinimumStakeFunction, BigInteger>(minimumStakeFunction, blockParameter);
        }

        
        public Task<BigInteger> MinimumStakeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MinimumStakeFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> PenalizeTokensRequestAsync(PenalizeTokensFunction penalizeTokensFunction)
        {
             return ContractHandler.SendRequestAsync(penalizeTokensFunction);
        }

        public Task<TransactionReceipt> PenalizeTokensRequestAndWaitForReceiptAsync(PenalizeTokensFunction penalizeTokensFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(penalizeTokensFunction, cancellationToken);
        }

        public Task<string> PenalizeTokensRequestAsync(BigInteger amount, string account)
        {
            var penalizeTokensFunction = new PenalizeTokensFunction();
                penalizeTokensFunction.Amount = amount;
                penalizeTokensFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(penalizeTokensFunction);
        }

        public Task<TransactionReceipt> PenalizeTokensRequestAndWaitForReceiptAsync(BigInteger amount, string account, CancellationTokenSource cancellationToken = null)
        {
            var penalizeTokensFunction = new PenalizeTokensFunction();
                penalizeTokensFunction.Amount = amount;
                penalizeTokensFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(penalizeTokensFunction, cancellationToken);
        }

        public Task<bool> PermittedStakersOnQueryAsync(PermittedStakersOnFunction permittedStakersOnFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PermittedStakersOnFunction, bool>(permittedStakersOnFunction, blockParameter);
        }

        
        public Task<bool> PermittedStakersOnQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PermittedStakersOnFunction, bool>(null, blockParameter);
        }

        public Task<string> RemoveAliasRequestAsync(RemoveAliasFunction removeAliasFunction)
        {
             return ContractHandler.SendRequestAsync(removeAliasFunction);
        }

        public Task<TransactionReceipt> RemoveAliasRequestAndWaitForReceiptAsync(RemoveAliasFunction removeAliasFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAliasFunction, cancellationToken);
        }

        public Task<string> RemoveAliasRequestAsync(string aliasAccount)
        {
            var removeAliasFunction = new RemoveAliasFunction();
                removeAliasFunction.AliasAccount = aliasAccount;
            
             return ContractHandler.SendRequestAsync(removeAliasFunction);
        }

        public Task<TransactionReceipt> RemoveAliasRequestAndWaitForReceiptAsync(string aliasAccount, CancellationTokenSource cancellationToken = null)
        {
            var removeAliasFunction = new RemoveAliasFunction();
                removeAliasFunction.AliasAccount = aliasAccount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeAliasFunction, cancellationToken);
        }

        public Task<string> RemovePermittedStakerRequestAsync(RemovePermittedStakerFunction removePermittedStakerFunction)
        {
             return ContractHandler.SendRequestAsync(removePermittedStakerFunction);
        }

        public Task<TransactionReceipt> RemovePermittedStakerRequestAndWaitForReceiptAsync(RemovePermittedStakerFunction removePermittedStakerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedStakerFunction, cancellationToken);
        }

        public Task<string> RemovePermittedStakerRequestAsync(string staker)
        {
            var removePermittedStakerFunction = new RemovePermittedStakerFunction();
                removePermittedStakerFunction.Staker = staker;
            
             return ContractHandler.SendRequestAsync(removePermittedStakerFunction);
        }

        public Task<TransactionReceipt> RemovePermittedStakerRequestAndWaitForReceiptAsync(string staker, CancellationTokenSource cancellationToken = null)
        {
            var removePermittedStakerFunction = new RemovePermittedStakerFunction();
                removePermittedStakerFunction.Staker = staker;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePermittedStakerFunction, cancellationToken);
        }

        public Task<string> RestakePenaltyTokensRequestAsync(RestakePenaltyTokensFunction restakePenaltyTokensFunction)
        {
             return ContractHandler.SendRequestAsync(restakePenaltyTokensFunction);
        }

        public Task<TransactionReceipt> RestakePenaltyTokensRequestAndWaitForReceiptAsync(RestakePenaltyTokensFunction restakePenaltyTokensFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(restakePenaltyTokensFunction, cancellationToken);
        }

        public Task<string> RestakePenaltyTokensRequestAsync(string staker, BigInteger balance)
        {
            var restakePenaltyTokensFunction = new RestakePenaltyTokensFunction();
                restakePenaltyTokensFunction.Staker = staker;
                restakePenaltyTokensFunction.Balance = balance;
            
             return ContractHandler.SendRequestAsync(restakePenaltyTokensFunction);
        }

        public Task<TransactionReceipt> RestakePenaltyTokensRequestAndWaitForReceiptAsync(string staker, BigInteger balance, CancellationTokenSource cancellationToken = null)
        {
            var restakePenaltyTokensFunction = new RestakePenaltyTokensFunction();
                restakePenaltyTokensFunction.Staker = staker;
                restakePenaltyTokensFunction.Balance = balance;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(restakePenaltyTokensFunction, cancellationToken);
        }

        public Task<BigInteger> RewardOfQueryAsync(RewardOfFunction rewardOfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<RewardOfFunction, BigInteger>(rewardOfFunction, blockParameter);
        }

        
        public Task<BigInteger> RewardOfQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var rewardOfFunction = new RewardOfFunction();
                rewardOfFunction.Account = account;
            
            return ContractHandler.QueryAsync<RewardOfFunction, BigInteger>(rewardOfFunction, blockParameter);
        }

        public Task<string> RewardValidatorRequestAsync(RewardValidatorFunction rewardValidatorFunction)
        {
             return ContractHandler.SendRequestAsync(rewardValidatorFunction);
        }

        public Task<TransactionReceipt> RewardValidatorRequestAndWaitForReceiptAsync(RewardValidatorFunction rewardValidatorFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rewardValidatorFunction, cancellationToken);
        }

        public Task<string> RewardValidatorRequestAsync(BigInteger amount, string account)
        {
            var rewardValidatorFunction = new RewardValidatorFunction();
                rewardValidatorFunction.Amount = amount;
                rewardValidatorFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(rewardValidatorFunction);
        }

        public Task<TransactionReceipt> RewardValidatorRequestAndWaitForReceiptAsync(BigInteger amount, string account, CancellationTokenSource cancellationToken = null)
        {
            var rewardValidatorFunction = new RewardValidatorFunction();
                rewardValidatorFunction.Amount = amount;
                rewardValidatorFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(rewardValidatorFunction, cancellationToken);
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

        public Task<string> SetMaxAliasCountRequestAsync(SetMaxAliasCountFunction setMaxAliasCountFunction)
        {
             return ContractHandler.SendRequestAsync(setMaxAliasCountFunction);
        }

        public Task<TransactionReceipt> SetMaxAliasCountRequestAndWaitForReceiptAsync(SetMaxAliasCountFunction setMaxAliasCountFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxAliasCountFunction, cancellationToken);
        }

        public Task<string> SetMaxAliasCountRequestAsync(BigInteger newMaxAliasCount)
        {
            var setMaxAliasCountFunction = new SetMaxAliasCountFunction();
                setMaxAliasCountFunction.NewMaxAliasCount = newMaxAliasCount;
            
             return ContractHandler.SendRequestAsync(setMaxAliasCountFunction);
        }

        public Task<TransactionReceipt> SetMaxAliasCountRequestAndWaitForReceiptAsync(BigInteger newMaxAliasCount, CancellationTokenSource cancellationToken = null)
        {
            var setMaxAliasCountFunction = new SetMaxAliasCountFunction();
                setMaxAliasCountFunction.NewMaxAliasCount = newMaxAliasCount;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaxAliasCountFunction, cancellationToken);
        }

        public Task<string> SetMaximumStakeRequestAsync(SetMaximumStakeFunction setMaximumStakeFunction)
        {
             return ContractHandler.SendRequestAsync(setMaximumStakeFunction);
        }

        public Task<TransactionReceipt> SetMaximumStakeRequestAndWaitForReceiptAsync(SetMaximumStakeFunction setMaximumStakeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaximumStakeFunction, cancellationToken);
        }

        public Task<string> SetMaximumStakeRequestAsync(BigInteger newMaximumStake)
        {
            var setMaximumStakeFunction = new SetMaximumStakeFunction();
                setMaximumStakeFunction.NewMaximumStake = newMaximumStake;
            
             return ContractHandler.SendRequestAsync(setMaximumStakeFunction);
        }

        public Task<TransactionReceipt> SetMaximumStakeRequestAndWaitForReceiptAsync(BigInteger newMaximumStake, CancellationTokenSource cancellationToken = null)
        {
            var setMaximumStakeFunction = new SetMaximumStakeFunction();
                setMaximumStakeFunction.NewMaximumStake = newMaximumStake;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMaximumStakeFunction, cancellationToken);
        }

        public Task<string> SetMinimumStakeRequestAsync(SetMinimumStakeFunction setMinimumStakeFunction)
        {
             return ContractHandler.SendRequestAsync(setMinimumStakeFunction);
        }

        public Task<TransactionReceipt> SetMinimumStakeRequestAndWaitForReceiptAsync(SetMinimumStakeFunction setMinimumStakeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMinimumStakeFunction, cancellationToken);
        }

        public Task<string> SetMinimumStakeRequestAsync(BigInteger newMinimumStake)
        {
            var setMinimumStakeFunction = new SetMinimumStakeFunction();
                setMinimumStakeFunction.NewMinimumStake = newMinimumStake;
            
             return ContractHandler.SendRequestAsync(setMinimumStakeFunction);
        }

        public Task<TransactionReceipt> SetMinimumStakeRequestAndWaitForReceiptAsync(BigInteger newMinimumStake, CancellationTokenSource cancellationToken = null)
        {
            var setMinimumStakeFunction = new SetMinimumStakeFunction();
                setMinimumStakeFunction.NewMinimumStake = newMinimumStake;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMinimumStakeFunction, cancellationToken);
        }

        public Task<string> SetPermittedStakersOnRequestAsync(SetPermittedStakersOnFunction setPermittedStakersOnFunction)
        {
             return ContractHandler.SendRequestAsync(setPermittedStakersOnFunction);
        }

        public Task<TransactionReceipt> SetPermittedStakersOnRequestAndWaitForReceiptAsync(SetPermittedStakersOnFunction setPermittedStakersOnFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPermittedStakersOnFunction, cancellationToken);
        }

        public Task<string> SetPermittedStakersOnRequestAsync(bool permitted)
        {
            var setPermittedStakersOnFunction = new SetPermittedStakersOnFunction();
                setPermittedStakersOnFunction.Permitted = permitted;
            
             return ContractHandler.SendRequestAsync(setPermittedStakersOnFunction);
        }

        public Task<TransactionReceipt> SetPermittedStakersOnRequestAndWaitForReceiptAsync(bool permitted, CancellationTokenSource cancellationToken = null)
        {
            var setPermittedStakersOnFunction = new SetPermittedStakersOnFunction();
                setPermittedStakersOnFunction.Permitted = permitted;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPermittedStakersOnFunction, cancellationToken);
        }

        public Task<string> StakeRequestAsync(StakeFunction stakeFunction)
        {
             return ContractHandler.SendRequestAsync(stakeFunction);
        }

        public Task<TransactionReceipt> StakeRequestAndWaitForReceiptAsync(StakeFunction stakeFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stakeFunction, cancellationToken);
        }

        public Task<string> StakeRequestAsync(BigInteger amount, string account)
        {
            var stakeFunction = new StakeFunction();
                stakeFunction.Amount = amount;
                stakeFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(stakeFunction);
        }

        public Task<TransactionReceipt> StakeRequestAndWaitForReceiptAsync(BigInteger amount, string account, CancellationTokenSource cancellationToken = null)
        {
            var stakeFunction = new StakeFunction();
                stakeFunction.Amount = amount;
                stakeFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(stakeFunction, cancellationToken);
        }

        public Task<BigInteger> TotalStakedQueryAsync(TotalStakedFunction totalStakedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalStakedFunction, BigInteger>(totalStakedFunction, blockParameter);
        }

        
        public Task<BigInteger> TotalStakedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TotalStakedFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> TransferPenaltyTokensRequestAsync(TransferPenaltyTokensFunction transferPenaltyTokensFunction)
        {
             return ContractHandler.SendRequestAsync(transferPenaltyTokensFunction);
        }

        public Task<TransactionReceipt> TransferPenaltyTokensRequestAndWaitForReceiptAsync(TransferPenaltyTokensFunction transferPenaltyTokensFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferPenaltyTokensFunction, cancellationToken);
        }

        public Task<string> TransferPenaltyTokensRequestAsync(BigInteger balance, string recipient)
        {
            var transferPenaltyTokensFunction = new TransferPenaltyTokensFunction();
                transferPenaltyTokensFunction.Balance = balance;
                transferPenaltyTokensFunction.Recipient = recipient;
            
             return ContractHandler.SendRequestAsync(transferPenaltyTokensFunction);
        }

        public Task<TransactionReceipt> TransferPenaltyTokensRequestAndWaitForReceiptAsync(BigInteger balance, string recipient, CancellationTokenSource cancellationToken = null)
        {
            var transferPenaltyTokensFunction = new TransferPenaltyTokensFunction();
                transferPenaltyTokensFunction.Balance = balance;
                transferPenaltyTokensFunction.Recipient = recipient;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(transferPenaltyTokensFunction, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(Withdraw1Function withdraw1Function)
        {
             return ContractHandler.SendRequestAsync(withdraw1Function);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(Withdraw1Function withdraw1Function, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdraw1Function, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(BigInteger amount, string account)
        {
            var withdraw1Function = new Withdraw1Function();
                withdraw1Function.Amount = amount;
                withdraw1Function.Account = account;
            
             return ContractHandler.SendRequestAsync(withdraw1Function);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(BigInteger amount, string account, CancellationTokenSource cancellationToken = null)
        {
            var withdraw1Function = new Withdraw1Function();
                withdraw1Function.Amount = amount;
                withdraw1Function.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdraw1Function, cancellationToken);
        }

        public Task<string> WithdrawRequestAsync(WithdrawFunction withdrawFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawFunction);
        }

        public Task<string> WithdrawRequestAsync()
        {
             return ContractHandler.SendRequestAsync<WithdrawFunction>();
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(WithdrawFunction withdrawFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawFunction, cancellationToken);
        }

        public Task<TransactionReceipt> WithdrawRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<WithdrawFunction>(null, cancellationToken);
        }

        public Task<string> WithdrawPenaltyTokensRequestAsync(WithdrawPenaltyTokensFunction withdrawPenaltyTokensFunction)
        {
             return ContractHandler.SendRequestAsync(withdrawPenaltyTokensFunction);
        }

        public Task<TransactionReceipt> WithdrawPenaltyTokensRequestAndWaitForReceiptAsync(WithdrawPenaltyTokensFunction withdrawPenaltyTokensFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawPenaltyTokensFunction, cancellationToken);
        }

        public Task<string> WithdrawPenaltyTokensRequestAsync(BigInteger balance)
        {
            var withdrawPenaltyTokensFunction = new WithdrawPenaltyTokensFunction();
                withdrawPenaltyTokensFunction.Balance = balance;
            
             return ContractHandler.SendRequestAsync(withdrawPenaltyTokensFunction);
        }

        public Task<TransactionReceipt> WithdrawPenaltyTokensRequestAndWaitForReceiptAsync(BigInteger balance, CancellationTokenSource cancellationToken = null)
        {
            var withdrawPenaltyTokensFunction = new WithdrawPenaltyTokensFunction();
                withdrawPenaltyTokensFunction.Balance = balance;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(withdrawPenaltyTokensFunction, cancellationToken);
        }
    }
}
