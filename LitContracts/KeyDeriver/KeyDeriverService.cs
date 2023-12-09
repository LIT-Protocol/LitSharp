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
using LitContracts.KeyDeriver.ContractDefinition;

namespace LitContracts.KeyDeriver
{
    public partial class KeyDeriverService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, KeyDeriverDeployment keyDeriverDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<KeyDeriverDeployment>().SendRequestAndWaitForReceiptAsync(keyDeriverDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, KeyDeriverDeployment keyDeriverDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<KeyDeriverDeployment>().SendRequestAsync(keyDeriverDeployment);
        }

        public static async Task<KeyDeriverService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, KeyDeriverDeployment keyDeriverDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, keyDeriverDeployment, cancellationTokenSource);
            return new KeyDeriverService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public KeyDeriverService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public KeyDeriverService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> HdKdfQueryAsync(HdKdfFunction hdKdfFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HdKdfFunction, string>(hdKdfFunction, blockParameter);
        }

        
        public Task<string> HdKdfQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HdKdfFunction, string>(null, blockParameter);
        }

        public Task<ComputeHDPubKeyOutputDTO> ComputeHDPubKeyQueryAsync(ComputeHDPubKeyFunction computeHDPubKeyFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryDeserializingToObjectAsync<ComputeHDPubKeyFunction, ComputeHDPubKeyOutputDTO>(computeHDPubKeyFunction, blockParameter);
        }

        public Task<ComputeHDPubKeyOutputDTO> ComputeHDPubKeyQueryAsync(byte[] derivedKeyId, List<RootKey> rootHDKeys, BigInteger keyType, BlockParameter blockParameter = null)
        {
            var computeHDPubKeyFunction = new ComputeHDPubKeyFunction();
                computeHDPubKeyFunction.DerivedKeyId = derivedKeyId;
                computeHDPubKeyFunction.RootHDKeys = rootHDKeys;
                computeHDPubKeyFunction.KeyType = keyType;
            
            return ContractHandler.QueryDeserializingToObjectAsync<ComputeHDPubKeyFunction, ComputeHDPubKeyOutputDTO>(computeHDPubKeyFunction, blockParameter);
        }
    }
}
