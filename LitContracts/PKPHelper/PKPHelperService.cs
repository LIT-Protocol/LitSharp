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
using LitContracts.PKPHelper.ContractDefinition;

namespace LitContracts.PKPHelper
{
    public partial class PKPHelperService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PKPHelperDeployment pKPHelperDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PKPHelperDeployment>().SendRequestAndWaitForReceiptAsync(pKPHelperDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PKPHelperDeployment pKPHelperDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PKPHelperDeployment>().SendRequestAsync(pKPHelperDeployment);
        }

        public static async Task<PKPHelperService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PKPHelperDeployment pKPHelperDeployment, CancellationTokenSource? cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, pKPHelperDeployment, cancellationTokenSource);
            return new PKPHelperService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.IWeb3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PKPHelperService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public PKPHelperService(Nethereum.Web3.IWeb3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<byte[]> DefaultAdminRoleQueryAsync(DefaultAdminRoleFunction defaultAdminRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(defaultAdminRoleFunction, blockParameter);
        }

        
        public Task<byte[]> DefaultAdminRoleQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<DefaultAdminRoleFunction, byte[]>(null, blockParameter);
        }

        public Task<string> ClaimAndMintNextAndAddAuthMethodsRequestAsync(ClaimAndMintNextAndAddAuthMethodsFunction claimAndMintNextAndAddAuthMethodsFunction)
        {
             return ContractHandler.SendRequestAsync(claimAndMintNextAndAddAuthMethodsFunction);
        }

        public Task<TransactionReceipt> ClaimAndMintNextAndAddAuthMethodsRequestAndWaitForReceiptAsync(ClaimAndMintNextAndAddAuthMethodsFunction claimAndMintNextAndAddAuthMethodsFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimAndMintNextAndAddAuthMethodsFunction, cancellationToken);
        }

        public Task<string> ClaimAndMintNextAndAddAuthMethodsRequestAsync(ClaimMaterial claimMaterial, AuthMethodData authMethodData)
        {
            var claimAndMintNextAndAddAuthMethodsFunction = new ClaimAndMintNextAndAddAuthMethodsFunction();
                claimAndMintNextAndAddAuthMethodsFunction.ClaimMaterial = claimMaterial;
                claimAndMintNextAndAddAuthMethodsFunction.AuthMethodData = authMethodData;
            
             return ContractHandler.SendRequestAsync(claimAndMintNextAndAddAuthMethodsFunction);
        }

        public Task<TransactionReceipt> ClaimAndMintNextAndAddAuthMethodsRequestAndWaitForReceiptAsync(ClaimMaterial claimMaterial, AuthMethodData authMethodData, CancellationTokenSource? cancellationToken = null)
        {
            var claimAndMintNextAndAddAuthMethodsFunction = new ClaimAndMintNextAndAddAuthMethodsFunction();
                claimAndMintNextAndAddAuthMethodsFunction.ClaimMaterial = claimMaterial;
                claimAndMintNextAndAddAuthMethodsFunction.AuthMethodData = authMethodData;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimAndMintNextAndAddAuthMethodsFunction, cancellationToken);
        }

        public Task<string> ClaimAndMintNextAndAddAuthMethodsWithTypesRequestAsync(ClaimAndMintNextAndAddAuthMethodsWithTypesFunction claimAndMintNextAndAddAuthMethodsWithTypesFunction)
        {
             return ContractHandler.SendRequestAsync(claimAndMintNextAndAddAuthMethodsWithTypesFunction);
        }

        public Task<TransactionReceipt> ClaimAndMintNextAndAddAuthMethodsWithTypesRequestAndWaitForReceiptAsync(ClaimAndMintNextAndAddAuthMethodsWithTypesFunction claimAndMintNextAndAddAuthMethodsWithTypesFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimAndMintNextAndAddAuthMethodsWithTypesFunction, cancellationToken);
        }

        public Task<string> ClaimAndMintNextAndAddAuthMethodsWithTypesRequestAsync(ClaimMaterial claimMaterial, AuthMethodData authMethodData)
        {
            var claimAndMintNextAndAddAuthMethodsWithTypesFunction = new ClaimAndMintNextAndAddAuthMethodsWithTypesFunction();
                claimAndMintNextAndAddAuthMethodsWithTypesFunction.ClaimMaterial = claimMaterial;
                claimAndMintNextAndAddAuthMethodsWithTypesFunction.AuthMethodData = authMethodData;
            
             return ContractHandler.SendRequestAsync(claimAndMintNextAndAddAuthMethodsWithTypesFunction);
        }

        public Task<TransactionReceipt> ClaimAndMintNextAndAddAuthMethodsWithTypesRequestAndWaitForReceiptAsync(ClaimMaterial claimMaterial, AuthMethodData authMethodData, CancellationTokenSource? cancellationToken = null)
        {
            var claimAndMintNextAndAddAuthMethodsWithTypesFunction = new ClaimAndMintNextAndAddAuthMethodsWithTypesFunction();
                claimAndMintNextAndAddAuthMethodsWithTypesFunction.ClaimMaterial = claimMaterial;
                claimAndMintNextAndAddAuthMethodsWithTypesFunction.AuthMethodData = authMethodData;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(claimAndMintNextAndAddAuthMethodsWithTypesFunction, cancellationToken);
        }

        public Task<string> ContractResolverQueryAsync(ContractResolverFunction contractResolverFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(contractResolverFunction, blockParameter);
        }

        
        public Task<string> ContractResolverQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<ContractResolverFunction, string>(null, blockParameter);
        }

        public Task<byte> EnvQueryAsync(EnvFunction envFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<EnvFunction, byte>(envFunction, blockParameter);
        }

        
        public Task<byte> EnvQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<EnvFunction, byte>(null, blockParameter);
        }

        public Task<string> GetDomainWalletRegistryQueryAsync(GetDomainWalletRegistryFunction getDomainWalletRegistryFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDomainWalletRegistryFunction, string>(getDomainWalletRegistryFunction, blockParameter);
        }

        
        public Task<string> GetDomainWalletRegistryQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetDomainWalletRegistryFunction, string>(null, blockParameter);
        }

        public Task<string> GetPKPNftMetdataAddressQueryAsync(GetPKPNftMetdataAddressFunction getPKPNftMetdataAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPKPNftMetdataAddressFunction, string>(getPKPNftMetdataAddressFunction, blockParameter);
        }

        
        public Task<string> GetPKPNftMetdataAddressQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPKPNftMetdataAddressFunction, string>(null, blockParameter);
        }

        public Task<string> GetPkpNftAddressQueryAsync(GetPkpNftAddressFunction getPkpNftAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpNftAddressFunction, string>(getPkpNftAddressFunction, blockParameter);
        }

        
        public Task<string> GetPkpNftAddressQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpNftAddressFunction, string>(null, blockParameter);
        }

        public Task<string> GetPkpPermissionsAddressQueryAsync(GetPkpPermissionsAddressFunction getPkpPermissionsAddressFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpPermissionsAddressFunction, string>(getPkpPermissionsAddressFunction, blockParameter);
        }

        
        public Task<string> GetPkpPermissionsAddressQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetPkpPermissionsAddressFunction, string>(null, blockParameter);
        }

        public Task<byte[]> GetRoleAdminQueryAsync(GetRoleAdminFunction getRoleAdminFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        
        public Task<byte[]> GetRoleAdminQueryAsync(byte[] role, BlockParameter? blockParameter = null)
        {
            var getRoleAdminFunction = new GetRoleAdminFunction();
                getRoleAdminFunction.Role = role;
            
            return ContractHandler.QueryAsync<GetRoleAdminFunction, byte[]>(getRoleAdminFunction, blockParameter);
        }

        public Task<string> GrantRoleRequestAsync(GrantRoleFunction grantRoleFunction)
        {
             return ContractHandler.SendRequestAsync(grantRoleFunction);
        }

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(GrantRoleFunction grantRoleFunction, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> GrantRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource? cancellationToken = null)
        {
            var grantRoleFunction = new GrantRoleFunction();
                grantRoleFunction.Role = role;
                grantRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(grantRoleFunction, cancellationToken);
        }

        public Task<bool> HasRoleQueryAsync(HasRoleFunction hasRoleFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        
        public Task<bool> HasRoleQueryAsync(byte[] role, string account, BlockParameter? blockParameter = null)
        {
            var hasRoleFunction = new HasRoleFunction();
                hasRoleFunction.Role = role;
                hasRoleFunction.Account = account;
            
            return ContractHandler.QueryAsync<HasRoleFunction, bool>(hasRoleFunction, blockParameter);
        }

        public Task<string> MintNextAndAddAuthMethodsRequestAsync(MintNextAndAddAuthMethodsFunction mintNextAndAddAuthMethodsFunction)
        {
             return ContractHandler.SendRequestAsync(mintNextAndAddAuthMethodsFunction);
        }

        public Task<TransactionReceipt> MintNextAndAddAuthMethodsRequestAndWaitForReceiptAsync(MintNextAndAddAuthMethodsFunction mintNextAndAddAuthMethodsFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintNextAndAddAuthMethodsFunction, cancellationToken);
        }

        public Task<string> MintNextAndAddAuthMethodsRequestAsync(BigInteger keyType, List<BigInteger> permittedAuthMethodTypes, List<byte[]> permittedAuthMethodIds, List<byte[]> permittedAuthMethodPubkeys, List<List<BigInteger>> permittedAuthMethodScopes, bool addPkpEthAddressAsPermittedAddress, bool sendPkpToItself)
        {
            var mintNextAndAddAuthMethodsFunction = new MintNextAndAddAuthMethodsFunction();
                mintNextAndAddAuthMethodsFunction.KeyType = keyType;
                mintNextAndAddAuthMethodsFunction.PermittedAuthMethodTypes = permittedAuthMethodTypes;
                mintNextAndAddAuthMethodsFunction.PermittedAuthMethodIds = permittedAuthMethodIds;
                mintNextAndAddAuthMethodsFunction.PermittedAuthMethodPubkeys = permittedAuthMethodPubkeys;
                mintNextAndAddAuthMethodsFunction.PermittedAuthMethodScopes = permittedAuthMethodScopes;
                mintNextAndAddAuthMethodsFunction.AddPkpEthAddressAsPermittedAddress = addPkpEthAddressAsPermittedAddress;
                mintNextAndAddAuthMethodsFunction.SendPkpToItself = sendPkpToItself;
            
             return ContractHandler.SendRequestAsync(mintNextAndAddAuthMethodsFunction);
        }

        public Task<TransactionReceipt> MintNextAndAddAuthMethodsRequestAndWaitForReceiptAsync(BigInteger keyType, List<BigInteger> permittedAuthMethodTypes, List<byte[]> permittedAuthMethodIds, List<byte[]> permittedAuthMethodPubkeys, List<List<BigInteger>> permittedAuthMethodScopes, bool addPkpEthAddressAsPermittedAddress, bool sendPkpToItself, CancellationTokenSource? cancellationToken = null)
        {
            var mintNextAndAddAuthMethodsFunction = new MintNextAndAddAuthMethodsFunction();
                mintNextAndAddAuthMethodsFunction.KeyType = keyType;
                mintNextAndAddAuthMethodsFunction.PermittedAuthMethodTypes = permittedAuthMethodTypes;
                mintNextAndAddAuthMethodsFunction.PermittedAuthMethodIds = permittedAuthMethodIds;
                mintNextAndAddAuthMethodsFunction.PermittedAuthMethodPubkeys = permittedAuthMethodPubkeys;
                mintNextAndAddAuthMethodsFunction.PermittedAuthMethodScopes = permittedAuthMethodScopes;
                mintNextAndAddAuthMethodsFunction.AddPkpEthAddressAsPermittedAddress = addPkpEthAddressAsPermittedAddress;
                mintNextAndAddAuthMethodsFunction.SendPkpToItself = sendPkpToItself;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintNextAndAddAuthMethodsFunction, cancellationToken);
        }

        public Task<string> MintNextAndAddAuthMethodsWithTypesRequestAsync(MintNextAndAddAuthMethodsWithTypesFunction mintNextAndAddAuthMethodsWithTypesFunction)
        {
             return ContractHandler.SendRequestAsync(mintNextAndAddAuthMethodsWithTypesFunction);
        }

        public Task<TransactionReceipt> MintNextAndAddAuthMethodsWithTypesRequestAndWaitForReceiptAsync(MintNextAndAddAuthMethodsWithTypesFunction mintNextAndAddAuthMethodsWithTypesFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintNextAndAddAuthMethodsWithTypesFunction, cancellationToken);
        }

        public Task<string> MintNextAndAddAuthMethodsWithTypesRequestAsync(BigInteger keyType, List<byte[]> permittedIpfsCIDs, List<List<BigInteger>> permittedIpfsCIDScopes, List<string> permittedAddresses, List<List<BigInteger>> permittedAddressScopes, List<BigInteger> permittedAuthMethodTypes, List<byte[]> permittedAuthMethodIds, List<byte[]> permittedAuthMethodPubkeys, List<List<BigInteger>> permittedAuthMethodScopes, bool addPkpEthAddressAsPermittedAddress, bool sendPkpToItself)
        {
            var mintNextAndAddAuthMethodsWithTypesFunction = new MintNextAndAddAuthMethodsWithTypesFunction();
                mintNextAndAddAuthMethodsWithTypesFunction.KeyType = keyType;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedIpfsCIDs = permittedIpfsCIDs;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedIpfsCIDScopes = permittedIpfsCIDScopes;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAddresses = permittedAddresses;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAddressScopes = permittedAddressScopes;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAuthMethodTypes = permittedAuthMethodTypes;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAuthMethodIds = permittedAuthMethodIds;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAuthMethodPubkeys = permittedAuthMethodPubkeys;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAuthMethodScopes = permittedAuthMethodScopes;
                mintNextAndAddAuthMethodsWithTypesFunction.AddPkpEthAddressAsPermittedAddress = addPkpEthAddressAsPermittedAddress;
                mintNextAndAddAuthMethodsWithTypesFunction.SendPkpToItself = sendPkpToItself;
            
             return ContractHandler.SendRequestAsync(mintNextAndAddAuthMethodsWithTypesFunction);
        }

        public Task<TransactionReceipt> MintNextAndAddAuthMethodsWithTypesRequestAndWaitForReceiptAsync(BigInteger keyType, List<byte[]> permittedIpfsCIDs, List<List<BigInteger>> permittedIpfsCIDScopes, List<string> permittedAddresses, List<List<BigInteger>> permittedAddressScopes, List<BigInteger> permittedAuthMethodTypes, List<byte[]> permittedAuthMethodIds, List<byte[]> permittedAuthMethodPubkeys, List<List<BigInteger>> permittedAuthMethodScopes, bool addPkpEthAddressAsPermittedAddress, bool sendPkpToItself, CancellationTokenSource? cancellationToken = null)
        {
            var mintNextAndAddAuthMethodsWithTypesFunction = new MintNextAndAddAuthMethodsWithTypesFunction();
                mintNextAndAddAuthMethodsWithTypesFunction.KeyType = keyType;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedIpfsCIDs = permittedIpfsCIDs;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedIpfsCIDScopes = permittedIpfsCIDScopes;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAddresses = permittedAddresses;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAddressScopes = permittedAddressScopes;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAuthMethodTypes = permittedAuthMethodTypes;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAuthMethodIds = permittedAuthMethodIds;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAuthMethodPubkeys = permittedAuthMethodPubkeys;
                mintNextAndAddAuthMethodsWithTypesFunction.PermittedAuthMethodScopes = permittedAuthMethodScopes;
                mintNextAndAddAuthMethodsWithTypesFunction.AddPkpEthAddressAsPermittedAddress = addPkpEthAddressAsPermittedAddress;
                mintNextAndAddAuthMethodsWithTypesFunction.SendPkpToItself = sendPkpToItself;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintNextAndAddAuthMethodsWithTypesFunction, cancellationToken);
        }

        public Task<string> MintNextAndAddDomainWalletMetadataRequestAsync(MintNextAndAddDomainWalletMetadataFunction mintNextAndAddDomainWalletMetadataFunction)
        {
             return ContractHandler.SendRequestAsync(mintNextAndAddDomainWalletMetadataFunction);
        }

        public Task<TransactionReceipt> MintNextAndAddDomainWalletMetadataRequestAndWaitForReceiptAsync(MintNextAndAddDomainWalletMetadataFunction mintNextAndAddDomainWalletMetadataFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintNextAndAddDomainWalletMetadataFunction, cancellationToken);
        }

        public Task<string> MintNextAndAddDomainWalletMetadataRequestAsync(BigInteger keyType, List<BigInteger> permittedAuthMethodTypes, List<byte[]> permittedAuthMethodIds, List<byte[]> permittedAuthMethodPubkeys, List<List<BigInteger>> permittedAuthMethodScopes, List<string> nftMetadata, bool addPkpEthAddressAsPermittedAddress, bool sendPkpToItself)
        {
            var mintNextAndAddDomainWalletMetadataFunction = new MintNextAndAddDomainWalletMetadataFunction();
                mintNextAndAddDomainWalletMetadataFunction.KeyType = keyType;
                mintNextAndAddDomainWalletMetadataFunction.PermittedAuthMethodTypes = permittedAuthMethodTypes;
                mintNextAndAddDomainWalletMetadataFunction.PermittedAuthMethodIds = permittedAuthMethodIds;
                mintNextAndAddDomainWalletMetadataFunction.PermittedAuthMethodPubkeys = permittedAuthMethodPubkeys;
                mintNextAndAddDomainWalletMetadataFunction.PermittedAuthMethodScopes = permittedAuthMethodScopes;
                mintNextAndAddDomainWalletMetadataFunction.NftMetadata = nftMetadata;
                mintNextAndAddDomainWalletMetadataFunction.AddPkpEthAddressAsPermittedAddress = addPkpEthAddressAsPermittedAddress;
                mintNextAndAddDomainWalletMetadataFunction.SendPkpToItself = sendPkpToItself;
            
             return ContractHandler.SendRequestAsync(mintNextAndAddDomainWalletMetadataFunction);
        }

        public Task<TransactionReceipt> MintNextAndAddDomainWalletMetadataRequestAndWaitForReceiptAsync(BigInteger keyType, List<BigInteger> permittedAuthMethodTypes, List<byte[]> permittedAuthMethodIds, List<byte[]> permittedAuthMethodPubkeys, List<List<BigInteger>> permittedAuthMethodScopes, List<string> nftMetadata, bool addPkpEthAddressAsPermittedAddress, bool sendPkpToItself, CancellationTokenSource? cancellationToken = null)
        {
            var mintNextAndAddDomainWalletMetadataFunction = new MintNextAndAddDomainWalletMetadataFunction();
                mintNextAndAddDomainWalletMetadataFunction.KeyType = keyType;
                mintNextAndAddDomainWalletMetadataFunction.PermittedAuthMethodTypes = permittedAuthMethodTypes;
                mintNextAndAddDomainWalletMetadataFunction.PermittedAuthMethodIds = permittedAuthMethodIds;
                mintNextAndAddDomainWalletMetadataFunction.PermittedAuthMethodPubkeys = permittedAuthMethodPubkeys;
                mintNextAndAddDomainWalletMetadataFunction.PermittedAuthMethodScopes = permittedAuthMethodScopes;
                mintNextAndAddDomainWalletMetadataFunction.NftMetadata = nftMetadata;
                mintNextAndAddDomainWalletMetadataFunction.AddPkpEthAddressAsPermittedAddress = addPkpEthAddressAsPermittedAddress;
                mintNextAndAddDomainWalletMetadataFunction.SendPkpToItself = sendPkpToItself;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(mintNextAndAddDomainWalletMetadataFunction, cancellationToken);
        }

        public Task<byte[]> OnERC721ReceivedQueryAsync(OnERC721ReceivedFunction onERC721ReceivedFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<OnERC721ReceivedFunction, byte[]>(onERC721ReceivedFunction, blockParameter);
        }

        
        public Task<byte[]> OnERC721ReceivedQueryAsync(string returnValue1, string returnValue2, BigInteger returnValue3, byte[] returnValue4, BlockParameter? blockParameter = null)
        {
            var onERC721ReceivedFunction = new OnERC721ReceivedFunction();
                onERC721ReceivedFunction.ReturnValue1 = returnValue1;
                onERC721ReceivedFunction.ReturnValue2 = returnValue2;
                onERC721ReceivedFunction.ReturnValue3 = returnValue3;
                onERC721ReceivedFunction.ReturnValue4 = returnValue4;
            
            return ContractHandler.QueryAsync<OnERC721ReceivedFunction, byte[]>(onERC721ReceivedFunction, blockParameter);
        }

        public Task<string> OwnerQueryAsync(OwnerFunction ownerFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(ownerFunction, blockParameter);
        }

        
        public Task<string> OwnerQueryAsync(BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<OwnerFunction, string>(null, blockParameter);
        }

        public Task<string> RemovePkpMetadataRequestAsync(RemovePkpMetadataFunction removePkpMetadataFunction)
        {
             return ContractHandler.SendRequestAsync(removePkpMetadataFunction);
        }

        public Task<TransactionReceipt> RemovePkpMetadataRequestAndWaitForReceiptAsync(RemovePkpMetadataFunction removePkpMetadataFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePkpMetadataFunction, cancellationToken);
        }

        public Task<string> RemovePkpMetadataRequestAsync(BigInteger tokenId)
        {
            var removePkpMetadataFunction = new RemovePkpMetadataFunction();
                removePkpMetadataFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAsync(removePkpMetadataFunction);
        }

        public Task<TransactionReceipt> RemovePkpMetadataRequestAndWaitForReceiptAsync(BigInteger tokenId, CancellationTokenSource? cancellationToken = null)
        {
            var removePkpMetadataFunction = new RemovePkpMetadataFunction();
                removePkpMetadataFunction.TokenId = tokenId;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removePkpMetadataFunction, cancellationToken);
        }

        public Task<string> RenounceOwnershipRequestAsync(RenounceOwnershipFunction renounceOwnershipFunction)
        {
             return ContractHandler.SendRequestAsync(renounceOwnershipFunction);
        }

        public Task<string> RenounceOwnershipRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceOwnershipFunction>();
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(RenounceOwnershipFunction renounceOwnershipFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceOwnershipFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceOwnershipRequestAndWaitForReceiptAsync(CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceOwnershipFunction>(null, cancellationToken);
        }

        public Task<string> RenounceRoleRequestAsync(RenounceRoleFunction renounceRoleFunction)
        {
             return ContractHandler.SendRequestAsync(renounceRoleFunction);
        }

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(RenounceRoleFunction renounceRoleFunction, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> RenounceRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(RevokeRoleFunction revokeRoleFunction, CancellationTokenSource? cancellationToken = null)
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

        public Task<TransactionReceipt> RevokeRoleRequestAndWaitForReceiptAsync(byte[] role, string account, CancellationTokenSource? cancellationToken = null)
        {
            var revokeRoleFunction = new RevokeRoleFunction();
                revokeRoleFunction.Role = role;
                revokeRoleFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(revokeRoleFunction, cancellationToken);
        }

        public Task<string> SetContractResolverRequestAsync(SetContractResolverFunction setContractResolverFunction)
        {
             return ContractHandler.SendRequestAsync(setContractResolverFunction);
        }

        public Task<TransactionReceipt> SetContractResolverRequestAndWaitForReceiptAsync(SetContractResolverFunction setContractResolverFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractResolverFunction, cancellationToken);
        }

        public Task<string> SetContractResolverRequestAsync(string newResolverAddress)
        {
            var setContractResolverFunction = new SetContractResolverFunction();
                setContractResolverFunction.NewResolverAddress = newResolverAddress;
            
             return ContractHandler.SendRequestAsync(setContractResolverFunction);
        }

        public Task<TransactionReceipt> SetContractResolverRequestAndWaitForReceiptAsync(string newResolverAddress, CancellationTokenSource? cancellationToken = null)
        {
            var setContractResolverFunction = new SetContractResolverFunction();
                setContractResolverFunction.NewResolverAddress = newResolverAddress;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setContractResolverFunction, cancellationToken);
        }

        public Task<string> SetPkpMetadataRequestAsync(SetPkpMetadataFunction setPkpMetadataFunction)
        {
             return ContractHandler.SendRequestAsync(setPkpMetadataFunction);
        }

        public Task<TransactionReceipt> SetPkpMetadataRequestAndWaitForReceiptAsync(SetPkpMetadataFunction setPkpMetadataFunction, CancellationTokenSource? cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPkpMetadataFunction, cancellationToken);
        }

        public Task<string> SetPkpMetadataRequestAsync(BigInteger tokenId, List<string> nftMetadata)
        {
            var setPkpMetadataFunction = new SetPkpMetadataFunction();
                setPkpMetadataFunction.TokenId = tokenId;
                setPkpMetadataFunction.NftMetadata = nftMetadata;
            
             return ContractHandler.SendRequestAsync(setPkpMetadataFunction);
        }

        public Task<TransactionReceipt> SetPkpMetadataRequestAndWaitForReceiptAsync(BigInteger tokenId, List<string> nftMetadata, CancellationTokenSource? cancellationToken = null)
        {
            var setPkpMetadataFunction = new SetPkpMetadataFunction();
                setPkpMetadataFunction.TokenId = tokenId;
                setPkpMetadataFunction.NftMetadata = nftMetadata;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setPkpMetadataFunction, cancellationToken);
        }

        public Task<bool> SupportsInterfaceQueryAsync(SupportsInterfaceFunction supportsInterfaceFunction, BlockParameter? blockParameter = null)
        {
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
        }

        
        public Task<bool> SupportsInterfaceQueryAsync(byte[] interfaceId, BlockParameter? blockParameter = null)
        {
            var supportsInterfaceFunction = new SupportsInterfaceFunction();
                supportsInterfaceFunction.InterfaceId = interfaceId;
            
            return ContractHandler.QueryAsync<SupportsInterfaceFunction, bool>(supportsInterfaceFunction, blockParameter);
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
    }
}
