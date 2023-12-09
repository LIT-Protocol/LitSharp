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
using LitContracts.PubkeyRouter.ContractDefinition;

namespace LitContracts.PubkeyRouter
{
    public partial class PubkeyRouterService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PubkeyRouterDeployment pubkeyRouterDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PubkeyRouterDeployment>().SendRequestAndWaitForReceiptAsync(pubkeyRouterDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PubkeyRouterDeployment pubkeyRouterDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PubkeyRouterDeployment>().SendRequestAsync(pubkeyRouterDeployment);
        }

        public static async Task<PubkeyRouterService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PubkeyRouterDeployment pubkeyRouterDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, pubkeyRouterDeployment, cancellationTokenSource);
            return new PubkeyRouterService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PubkeyRouterService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public PubkeyRouterService(Nethereum.Web3.IWeb3 web3, string contractAddress)
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

        public Task<bool> CheckNodeSignaturesQueryAsync(CheckNodeSignaturesFunction checkNodeSignaturesFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<CheckNodeSignaturesFunction, bool>(checkNodeSignaturesFunction, blockParameter);
        }

        
        public Task<bool> CheckNodeSignaturesQueryAsync(List<Signature> signatures, byte[] signedMessage, string stakingContractAddress, BlockParameter blockParameter = null)
        {
            var checkNodeSignaturesFunction = new CheckNodeSignaturesFunction();
                checkNodeSignaturesFunction.Signatures = signatures;
                checkNodeSignaturesFunction.SignedMessage = signedMessage;
                checkNodeSignaturesFunction.StakingContractAddress = stakingContractAddress;
            
            return ContractHandler.QueryAsync<CheckNodeSignaturesFunction, bool>(checkNodeSignaturesFunction, blockParameter);
        }

        public Task<string> DeriveEthAddressFromPubkeyQueryAsync(DeriveEthAddressFromPubkeyFunction deriveEthAddressFromPubkeyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DeriveEthAddressFromPubkeyFunction, string>(deriveEthAddressFromPubkeyFunction, blockParameter);
        }

        
        public Task<string> DeriveEthAddressFromPubkeyQueryAsync(byte[] pubkey, BlockParameter blockParameter = null)
        {
            var deriveEthAddressFromPubkeyFunction = new DeriveEthAddressFromPubkeyFunction();
                deriveEthAddressFromPubkeyFunction.Pubkey = pubkey;
            
            return ContractHandler.QueryAsync<DeriveEthAddressFromPubkeyFunction, string>(deriveEthAddressFromPubkeyFunction, blockParameter);
        }

        public Task<BigInteger> EthAddressToPkpIdQueryAsync(EthAddressToPkpIdFunction ethAddressToPkpIdFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EthAddressToPkpIdFunction, BigInteger>(ethAddressToPkpIdFunction, blockParameter);
        }

        
        public Task<BigInteger> EthAddressToPkpIdQueryAsync(string ethAddress, BlockParameter blockParameter = null)
        {
            var ethAddressToPkpIdFunction = new EthAddressToPkpIdFunction();
                ethAddressToPkpIdFunction.EthAddress = ethAddress;
            
            return ContractHandler.QueryAsync<EthAddressToPkpIdFunction, BigInteger>(ethAddressToPkpIdFunction, blockParameter);
        }

        public Task<byte[]> GetDerivedPubkeyQueryAsync(GetDerivedPubkeyFunction getDerivedPubkeyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDerivedPubkeyFunction, byte[]>(getDerivedPubkeyFunction, blockParameter);
        }

        
        public Task<byte[]> GetDerivedPubkeyQueryAsync(string stakingContract, byte[] derivedKeyId, BlockParameter blockParameter = null)
        {
            var getDerivedPubkeyFunction = new GetDerivedPubkeyFunction();
                getDerivedPubkeyFunction.StakingContract = stakingContract;
                getDerivedPubkeyFunction.DerivedKeyId = derivedKeyId;
            
            return ContractHandler.QueryAsync<GetDerivedPubkeyFunction, byte[]>(getDerivedPubkeyFunction, blockParameter);
        }

        public Task<string> GetEthAddressQueryAsync(GetEthAddressFunction getEthAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetEthAddressFunction, string>(getEthAddressFunction, blockParameter);
        }

        
        public Task<string> GetEthAddressQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getEthAddressFunction = new GetEthAddressFunction();
                getEthAddressFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetEthAddressFunction, string>(getEthAddressFunction, blockParameter);
        }

        public Task<string> GetPkpNftAddressQueryAsync(GetPkpNftAddressFunction getPkpNftAddressFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpNftAddressFunction, string>(getPkpNftAddressFunction, blockParameter);
        }

        
        public Task<string> GetPkpNftAddressQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpNftAddressFunction, string>(null, blockParameter);
        }

        public Task<byte[]> GetPubkeyQueryAsync(GetPubkeyFunction getPubkeyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPubkeyFunction, byte[]>(getPubkeyFunction, blockParameter);
        }

        
        public Task<byte[]> GetPubkeyQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getPubkeyFunction = new GetPubkeyFunction();
                getPubkeyFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<GetPubkeyFunction, byte[]>(getPubkeyFunction, blockParameter);
        }

        public Task<GetRootKeysOutputDTO> GetRootKeysQueryAsync(GetRootKeysFunction getRootKeysFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetRootKeysFunction, GetRootKeysOutputDTO>(getRootKeysFunction, blockParameter);
        }

        public Task<GetRootKeysOutputDTO> GetRootKeysQueryAsync(string stakingContract, BlockParameter blockParameter = null)
        {
            var getRootKeysFunction = new GetRootKeysFunction();
                getRootKeysFunction.StakingContract = stakingContract;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetRootKeysFunction, GetRootKeysOutputDTO>(getRootKeysFunction, blockParameter);
        }

        public Task<GetRoutingDataOutputDTO> GetRoutingDataQueryAsync(GetRoutingDataFunction getRoutingDataFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<GetRoutingDataFunction, GetRoutingDataOutputDTO>(getRoutingDataFunction, blockParameter);
        }

        public Task<GetRoutingDataOutputDTO> GetRoutingDataQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var getRoutingDataFunction = new GetRoutingDataFunction();
                getRoutingDataFunction.TokenId = tokenId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<GetRoutingDataFunction, GetRoutingDataOutputDTO>(getRoutingDataFunction, blockParameter);
        }

        public Task<bool> IsRoutedQueryAsync(IsRoutedFunction isRoutedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsRoutedFunction, bool>(isRoutedFunction, blockParameter);
        }

        
        public Task<bool> IsRoutedQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var isRoutedFunction = new IsRoutedFunction();
                isRoutedFunction.TokenId = tokenId;
            
            return ContractHandler.QueryAsync<IsRoutedFunction, bool>(isRoutedFunction, blockParameter);
        }

        public Task<PubkeysOutputDTO> PubkeysQueryAsync(PubkeysFunction pubkeysFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<PubkeysFunction, PubkeysOutputDTO>(pubkeysFunction, blockParameter);
        }

        public Task<PubkeysOutputDTO> PubkeysQueryAsync(BigInteger tokenId, BlockParameter blockParameter = null)
        {
            var pubkeysFunction = new PubkeysFunction();
                pubkeysFunction.TokenId = tokenId;
            
            return ContractHandler.QueryDeserializingToObjectAsync<PubkeysFunction, PubkeysOutputDTO>(pubkeysFunction, blockParameter);
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

        public Task<string> SetRoutingDataRequestAsync(SetRoutingDataFunction setRoutingDataFunction)
        {
             return ContractHandler.SendRequestAsync(setRoutingDataFunction);
        }

        public Task<TransactionReceipt> SetRoutingDataRequestAndWaitForReceiptAsync(SetRoutingDataFunction setRoutingDataFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRoutingDataFunction, cancellationToken);
        }

        public Task<string> SetRoutingDataRequestAsync(BigInteger tokenId, byte[] pubkey, string stakingContractAddress, BigInteger keyType, byte[] derivedKeyId)
        {
            var setRoutingDataFunction = new SetRoutingDataFunction();
                setRoutingDataFunction.TokenId = tokenId;
                setRoutingDataFunction.Pubkey = pubkey;
                setRoutingDataFunction.StakingContractAddress = stakingContractAddress;
                setRoutingDataFunction.KeyType = keyType;
                setRoutingDataFunction.DerivedKeyId = derivedKeyId;
            
             return ContractHandler.SendRequestAsync(setRoutingDataFunction);
        }

        public Task<TransactionReceipt> SetRoutingDataRequestAndWaitForReceiptAsync(BigInteger tokenId, byte[] pubkey, string stakingContractAddress, BigInteger keyType, byte[] derivedKeyId, CancellationTokenSource cancellationToken = null)
        {
            var setRoutingDataFunction = new SetRoutingDataFunction();
                setRoutingDataFunction.TokenId = tokenId;
                setRoutingDataFunction.Pubkey = pubkey;
                setRoutingDataFunction.StakingContractAddress = stakingContractAddress;
                setRoutingDataFunction.KeyType = keyType;
                setRoutingDataFunction.DerivedKeyId = derivedKeyId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRoutingDataFunction, cancellationToken);
        }

        public Task<string> SetRoutingDataAsAdminRequestAsync(SetRoutingDataAsAdminFunction setRoutingDataAsAdminFunction)
        {
             return ContractHandler.SendRequestAsync(setRoutingDataAsAdminFunction);
        }

        public Task<TransactionReceipt> SetRoutingDataAsAdminRequestAndWaitForReceiptAsync(SetRoutingDataAsAdminFunction setRoutingDataAsAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRoutingDataAsAdminFunction, cancellationToken);
        }

        public Task<string> SetRoutingDataAsAdminRequestAsync(BigInteger tokenId, byte[] pubkey, string stakingContract, BigInteger keyType, byte[] derivedKeyId)
        {
            var setRoutingDataAsAdminFunction = new SetRoutingDataAsAdminFunction();
                setRoutingDataAsAdminFunction.TokenId = tokenId;
                setRoutingDataAsAdminFunction.Pubkey = pubkey;
                setRoutingDataAsAdminFunction.StakingContract = stakingContract;
                setRoutingDataAsAdminFunction.KeyType = keyType;
                setRoutingDataAsAdminFunction.DerivedKeyId = derivedKeyId;
            
             return ContractHandler.SendRequestAsync(setRoutingDataAsAdminFunction);
        }

        public Task<TransactionReceipt> SetRoutingDataAsAdminRequestAndWaitForReceiptAsync(BigInteger tokenId, byte[] pubkey, string stakingContract, BigInteger keyType, byte[] derivedKeyId, CancellationTokenSource cancellationToken = null)
        {
            var setRoutingDataAsAdminFunction = new SetRoutingDataAsAdminFunction();
                setRoutingDataAsAdminFunction.TokenId = tokenId;
                setRoutingDataAsAdminFunction.Pubkey = pubkey;
                setRoutingDataAsAdminFunction.StakingContract = stakingContract;
                setRoutingDataAsAdminFunction.KeyType = keyType;
                setRoutingDataAsAdminFunction.DerivedKeyId = derivedKeyId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setRoutingDataAsAdminFunction, cancellationToken);
        }

        public Task<string> VoteForRootKeysRequestAsync(VoteForRootKeysFunction voteForRootKeysFunction)
        {
             return ContractHandler.SendRequestAsync(voteForRootKeysFunction);
        }

        public Task<TransactionReceipt> VoteForRootKeysRequestAndWaitForReceiptAsync(VoteForRootKeysFunction voteForRootKeysFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(voteForRootKeysFunction, cancellationToken);
        }

        public Task<string> VoteForRootKeysRequestAsync(string stakingContractAddress, List<RootKey> newRootKeys)
        {
            var voteForRootKeysFunction = new VoteForRootKeysFunction();
                voteForRootKeysFunction.StakingContractAddress = stakingContractAddress;
                voteForRootKeysFunction.NewRootKeys = newRootKeys;
            
             return ContractHandler.SendRequestAsync(voteForRootKeysFunction);
        }

        public Task<TransactionReceipt> VoteForRootKeysRequestAndWaitForReceiptAsync(string stakingContractAddress, List<RootKey> newRootKeys, CancellationTokenSource cancellationToken = null)
        {
            var voteForRootKeysFunction = new VoteForRootKeysFunction();
                voteForRootKeysFunction.StakingContractAddress = stakingContractAddress;
                voteForRootKeysFunction.NewRootKeys = newRootKeys;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(voteForRootKeysFunction, cancellationToken);
        }
    }
}
