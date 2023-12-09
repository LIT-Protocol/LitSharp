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
using LitContracts.PKPNFTMetadata.ContractDefinition;

namespace LitContracts.PKPNFTMetadata
{
    public partial class PKPNFTMetadataService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PKPNFTMetadataDeployment pKPNFTMetadataDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PKPNFTMetadataDeployment>().SendRequestAndWaitForReceiptAsync(pKPNFTMetadataDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PKPNFTMetadataDeployment pKPNFTMetadataDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PKPNFTMetadataDeployment>().SendRequestAsync(pKPNFTMetadataDeployment);
        }

        public static async Task<PKPNFTMetadataService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PKPNFTMetadataDeployment pKPNFTMetadataDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, pKPNFTMetadataDeployment, cancellationTokenSource);
            return new PKPNFTMetadataService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PKPNFTMetadataService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public PKPNFTMetadataService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte[]> AdminRoleQueryAsync(AdminRoleFunction adminRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminRoleFunction, byte[]>(adminRoleFunction, blockParameter);
        }

        
        public Task<byte[]> AdminRoleQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<AdminRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> DefaultAdminRoleQueryAsync(DefaultAdminRoleFunction defaultAdminRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(defaultAdminRoleFunction, blockParameter);
        }

        
        public Task<byte[]> DefaultAdminRoleQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<byte[]> WriterRoleQueryAsync(WriterRoleFunction writerRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WriterRoleFunction, byte[]>(writerRoleFunction, blockParameter);
        }

        
        public Task<byte[]> WriterRoleQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<WriterRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<string> BytesToHexQueryAsync(BytesToHexFunction bytesToHexFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BytesToHexFunction, string>(bytesToHexFunction, blockParameter);
        }

        
        public Task<string> BytesToHexQueryAsync(byte[] buffer, BlockParameter blockParameter = null)
        {
            var bytesToHexFunction = new BytesToHexFunction();
                bytesToHexFunction.Buffer = buffer;
            
            return ContractHandler.QueryAsync<BytesToHexFunction, string>(bytesToHexFunction, blockParameter);
        }

        public Task<string> ContractResolverQueryAsync(ContractResolverFunction contractResolverFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(contractResolverFunction, blockParameter);
        }

        
        public Task<string> ContractResolverQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(null, blockParameter);
        }

        public Task<byte> EnvQueryAsync(EnvFunction envFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EnvFunction, byte>(envFunction, blockParameter);
        }

        
        public Task<byte> EnvQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<EnvFunction, byte>(null, blockParameter);
        }

        public Task<byte[]> GetRoleAdminQueryAsync(GetRoleAdminFunction getRoleAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        
        public Task<byte[]> GetRoleAdminQueryAsync(byte[] role, BlockParameter blockParameter = null)
        {
            var getRoleAdminFunction = new GetRoleAdminFunction();
                getRoleAdminFunction.Role = role;
            
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        public Task<string> GrantRoleRequestAsync(GrantRoleFunction grantRoleFunction)
        {
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(GrantRoleFunction grantRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<string> GrantRoleRequestAsync(byte[] role, string account)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<bool> HasRoleQueryAsync(HasRoleFunction hasRoleFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        
        public Task<bool> HasRoleQueryAsync(byte[] role, string account, BlockParameter blockParameter = null)
        {
            var hasRoleFunction = new HasRoleFunction();
                hasRoleFunction.Role = role;
                hasRoleFunction.Account = account;
            
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        public Task<string> RemoveProfileForPkpRequestAsync(RemoveProfileForPkpFunction removeProfileForPkpFunction)
        {
             return ContractHandler.SendRequestAsync(removeProfileForPkpFunction);
        }

        public Task<TransactionReceipt> RemoveProfileForPkpRequestAndWaitForReceiptAsync(RemoveProfileForPkpFunction removeProfileForPkpFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeProfileForPkpFunction, cancellationToken);
        }

        public Task<string> RemoveProfileForPkpRequestAsync(BigInteger tokenId)
        {
            var removeProfileForPkpFunction = new RemoveProfileForPkpFunction();
                removeProfileForPkpFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(removeProfileForPkpFunction);
        }

        public Task<TransactionReceipt> RemoveProfileForPkpRequestAndWaitForReceiptAsync(BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var removeProfileForPkpFunction = new RemoveProfileForPkpFunction();
                removeProfileForPkpFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeProfileForPkpFunction, cancellationToken);
        }

        public Task<string> RemoveUrlForPKPRequestAsync(RemoveUrlForPKPFunction removeUrlForPKPFunction)
        {
             return ContractHandler.SendRequestAsync(removeUrlForPKPFunction);
        }

        public Task<TransactionReceipt> RemoveUrlForPKPRequestAndWaitForReceiptAsync(RemoveUrlForPKPFunction removeUrlForPKPFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeUrlForPKPFunction, cancellationToken);
        }

        public Task<string> RemoveUrlForPKPRequestAsync(BigInteger tokenId)
        {
            var removeUrlForPKPFunction = new RemoveUrlForPKPFunction();
                removeUrlForPKPFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(removeUrlForPKPFunction);
        }

        public Task<TransactionReceipt> RemoveUrlForPKPRequestAndWaitForReceiptAsync(BigInteger tokenId, CancellationTokenSource cancellationToken = null)
        {
            var removeUrlForPKPFunction = new RemoveUrlForPKPFunction();
                removeUrlForPKPFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeUrlForPKPFunction, cancellationToken);
        }

        public Task<string> RenounceRoleRequestAsync(RenounceRoleFunction renounceRoleFunction)
        {
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(RenounceRoleFunction renounceRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceRoleFunction, cancellationToken);
        }

        public Task<string> RenounceRoleRequestAsync(byte[] role, string account)
        {
            var renounceRoleFunction = new RenounceRoleFunction();
                renounceRoleFunction.Role = role;
                renounceRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var renounceRoleFunction = new RenounceRoleFunction();
                renounceRoleFunction.Role = role;
                renounceRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceRoleFunction, cancellationToken);
        }

        public Task<string> RevokeRoleRequestAsync(RevokeRoleFunction revokeRoleFunction)
        {
             return ContractHandler.SendRequestAsync(revokeRoleFunction);
        }

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(RevokeRoleFunction revokeRoleFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<string> RevokeRoleRequestAsync(byte[] role, string account)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(revokeRoleFunction);
        }

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource cancellationToken = null)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<string> SetPKPHelperWriterAddressRequestAsync(SetPKPHelperWriterAddressFunction setPKPHelperWriterAddressFunction)
        {
             return ContractHandler.SendRequestAsync(setPKPHelperWriterAddressFunction);
        }

        public Task<TransactionReceipt> SetPKPHelperWriterAddressRequestAndWaitForReceiptAsync(SetPKPHelperWriterAddressFunction setPKPHelperWriterAddressFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPKPHelperWriterAddressFunction, cancellationToken);
        }

        public Task<string> SetPKPHelperWriterAddressRequestAsync(string pkpHelperWriterAddress)
        {
            var setPKPHelperWriterAddressFunction = new SetPKPHelperWriterAddressFunction();
                setPKPHelperWriterAddressFunction.PkpHelperWriterAddress = pkpHelperWriterAddress;
            
             return ContractHandler.SendRequestAsync(setPKPHelperWriterAddressFunction);
        }

        public Task<TransactionReceipt> SetPKPHelperWriterAddressRequestAndWaitForReceiptAsync(string pkpHelperWriterAddress, CancellationTokenSource cancellationToken = null)
        {
            var setPKPHelperWriterAddressFunction = new SetPKPHelperWriterAddressFunction();
                setPKPHelperWriterAddressFunction.PkpHelperWriterAddress = pkpHelperWriterAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPKPHelperWriterAddressFunction, cancellationToken);
        }

        public Task<string> SetProfileForPKPRequestAsync(SetProfileForPKPFunction setProfileForPKPFunction)
        {
             return ContractHandler.SendRequestAsync(setProfileForPKPFunction);
        }

        public Task<TransactionReceipt> SetProfileForPKPRequestAndWaitForReceiptAsync(SetProfileForPKPFunction setProfileForPKPFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setProfileForPKPFunction, cancellationToken);
        }

        public Task<string> SetProfileForPKPRequestAsync(BigInteger tokenId, string imgUrl)
        {
            var setProfileForPKPFunction = new SetProfileForPKPFunction();
                setProfileForPKPFunction.TokenId = tokenId;
                setProfileForPKPFunction.ImgUrl = imgUrl;
            
             return ContractHandler.SendRequestAsync(setProfileForPKPFunction);
        }

        public Task<TransactionReceipt> SetProfileForPKPRequestAndWaitForReceiptAsync(BigInteger tokenId, string imgUrl, CancellationTokenSource cancellationToken = null)
        {
            var setProfileForPKPFunction = new SetProfileForPKPFunction();
                setProfileForPKPFunction.TokenId = tokenId;
                setProfileForPKPFunction.ImgUrl = imgUrl;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setProfileForPKPFunction, cancellationToken);
        }

        public Task<string> SetUrlForPKPRequestAsync(SetUrlForPKPFunction setUrlForPKPFunction)
        {
             return ContractHandler.SendRequestAsync(setUrlForPKPFunction);
        }

        public Task<TransactionReceipt> SetUrlForPKPRequestAndWaitForReceiptAsync(SetUrlForPKPFunction setUrlForPKPFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setUrlForPKPFunction, cancellationToken);
        }

        public Task<string> SetUrlForPKPRequestAsync(BigInteger tokenId, string url)
        {
            var setUrlForPKPFunction = new SetUrlForPKPFunction();
                setUrlForPKPFunction.TokenId = tokenId;
                setUrlForPKPFunction.Url = url;
            
             return ContractHandler.SendRequestAsync(setUrlForPKPFunction);
        }

        public Task<TransactionReceipt> SetUrlForPKPRequestAndWaitForReceiptAsync(BigInteger tokenId, string url, CancellationTokenSource cancellationToken = null)
        {
            var setUrlForPKPFunction = new SetUrlForPKPFunction();
                setUrlForPKPFunction.TokenId = tokenId;
                setUrlForPKPFunction.Url = url;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setUrlForPKPFunction, cancellationToken);
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

        public Task<string> TokenURIQueryAsync(TokenURIFunction tokenURIFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }

        
        public Task<string> TokenURIQueryAsync(BigInteger tokenId, byte[] pubKey, string ethAddress, BlockParameter blockParameter = null)
        {
            var tokenURIFunction = new TokenURIFunction();
                tokenURIFunction.TokenId = tokenId;
                tokenURIFunction.PubKey = pubKey;
                tokenURIFunction.EthAddress = ethAddress;
            
            return ContractHandler.QueryAsync<TokenURIFunction, string>(tokenURIFunction, blockParameter);
        }
    }
}
