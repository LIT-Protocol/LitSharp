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
using LitContracts.DevKeyDeriver.ContractDefinition;

namespace LitContracts.DevKeyDeriver
{
    public partial class DevKeyDeriverService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, DevKeyDeriverDeployment devKeyDeriverDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<DevKeyDeriverDeployment>().SendRequestAndWaitForReceiptAsync(devKeyDeriverDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, DevKeyDeriverDeployment devKeyDeriverDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<DevKeyDeriverDeployment>().SendRequestAsync(devKeyDeriverDeployment);
        }

        public static async Task<DevKeyDeriverService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, DevKeyDeriverDeployment devKeyDeriverDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, devKeyDeriverDeployment, cancellationTokenSource);
            return new DevKeyDeriverService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public DevKeyDeriverService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public DevKeyDeriverService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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
