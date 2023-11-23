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

namespace LitContracts.PKPHelper.ContractDefinition
{


    public partial class PKPHelperDeployment : PKPHelperDeploymentBase
    {
        public PKPHelperDeployment() : base(BYTECODE) { }
        public PKPHelperDeployment(string byteCode) : base(byteCode) { }
    }

    public class PKPHelperDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public PKPHelperDeploymentBase() : base(BYTECODE) { }
        public PKPHelperDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_resolver", 1)]
        public virtual string Resolver { get; set; }
        [Parameter("uint8", "_env", 2)]
        public virtual byte Env { get; set; }
    }

    public partial class DefaultAdminRoleFunction : DefaultAdminRoleFunctionBase { }

    [Function("DEFAULT_ADMIN_ROLE", "bytes32")]
    public class DefaultAdminRoleFunctionBase : FunctionMessage
    {

    }

    public partial class ClaimAndMintNextAndAddAuthMethodsFunction : ClaimAndMintNextAndAddAuthMethodsFunctionBase { }

    [Function("claimAndMintNextAndAddAuthMethods", "uint256")]
    public class ClaimAndMintNextAndAddAuthMethodsFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "claimMaterial", 1)]
        public virtual ClaimMaterial ClaimMaterial { get; set; }
        [Parameter("tuple", "authMethodData", 2)]
        public virtual AuthMethodData AuthMethodData { get; set; }
    }

    public partial class ClaimAndMintNextAndAddAuthMethodsWithTypesFunction : ClaimAndMintNextAndAddAuthMethodsWithTypesFunctionBase { }

    [Function("claimAndMintNextAndAddAuthMethodsWithTypes", "uint256")]
    public class ClaimAndMintNextAndAddAuthMethodsWithTypesFunctionBase : FunctionMessage
    {
        [Parameter("tuple", "claimMaterial", 1)]
        public virtual ClaimMaterial ClaimMaterial { get; set; }
        [Parameter("tuple", "authMethodData", 2)]
        public virtual AuthMethodData AuthMethodData { get; set; }
    }

    public partial class ContractResolverFunction : ContractResolverFunctionBase { }

    [Function("contractResolver", "address")]
    public class ContractResolverFunctionBase : FunctionMessage
    {

    }

    public partial class EnvFunction : EnvFunctionBase { }

    [Function("env", "uint8")]
    public class EnvFunctionBase : FunctionMessage
    {

    }

    public partial class GetDomainWalletRegistryFunction : GetDomainWalletRegistryFunctionBase { }

    [Function("getDomainWalletRegistry", "address")]
    public class GetDomainWalletRegistryFunctionBase : FunctionMessage
    {

    }

    public partial class GetPKPNftMetdataAddressFunction : GetPKPNftMetdataAddressFunctionBase { }

    [Function("getPKPNftMetdataAddress", "address")]
    public class GetPKPNftMetdataAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetPkpNftAddressFunction : GetPkpNftAddressFunctionBase { }

    [Function("getPkpNftAddress", "address")]
    public class GetPkpNftAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetPkpPermissionsAddressFunction : GetPkpPermissionsAddressFunctionBase { }

    [Function("getPkpPermissionsAddress", "address")]
    public class GetPkpPermissionsAddressFunctionBase : FunctionMessage
    {

    }

    public partial class GetRoleAdminFunction : GetRoleAdminFunctionBase { }

    [Function("getRoleAdmin", "bytes32")]
    public class GetRoleAdminFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
    }

    public partial class GrantRoleFunction : GrantRoleFunctionBase { }

    [Function("grantRole")]
    public class GrantRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class HasRoleFunction : HasRoleFunctionBase { }

    [Function("hasRole", "bool")]
    public class HasRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class MintNextAndAddAuthMethodsFunction : MintNextAndAddAuthMethodsFunctionBase { }

    [Function("mintNextAndAddAuthMethods", "uint256")]
    public class MintNextAndAddAuthMethodsFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "keyType", 1)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("uint256[]", "permittedAuthMethodTypes", 2)]
        public virtual List<BigInteger> PermittedAuthMethodTypes { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodIds", 3)]
        public virtual List<byte[]> PermittedAuthMethodIds { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodPubkeys", 4)]
        public virtual List<byte[]> PermittedAuthMethodPubkeys { get; set; }
        [Parameter("uint256[][]", "permittedAuthMethodScopes", 5)]
        public virtual List<List<BigInteger>> PermittedAuthMethodScopes { get; set; }
        [Parameter("bool", "addPkpEthAddressAsPermittedAddress", 6)]
        public virtual bool AddPkpEthAddressAsPermittedAddress { get; set; }
        [Parameter("bool", "sendPkpToItself", 7)]
        public virtual bool SendPkpToItself { get; set; }
    }

    public partial class MintNextAndAddAuthMethodsWithTypesFunction : MintNextAndAddAuthMethodsWithTypesFunctionBase { }

    [Function("mintNextAndAddAuthMethodsWithTypes", "uint256")]
    public class MintNextAndAddAuthMethodsWithTypesFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "keyType", 1)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("bytes[]", "permittedIpfsCIDs", 2)]
        public virtual List<byte[]> PermittedIpfsCIDs { get; set; }
        [Parameter("uint256[][]", "permittedIpfsCIDScopes", 3)]
        public virtual List<List<BigInteger>> PermittedIpfsCIDScopes { get; set; }
        [Parameter("address[]", "permittedAddresses", 4)]
        public virtual List<string> PermittedAddresses { get; set; }
        [Parameter("uint256[][]", "permittedAddressScopes", 5)]
        public virtual List<List<BigInteger>> PermittedAddressScopes { get; set; }
        [Parameter("uint256[]", "permittedAuthMethodTypes", 6)]
        public virtual List<BigInteger> PermittedAuthMethodTypes { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodIds", 7)]
        public virtual List<byte[]> PermittedAuthMethodIds { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodPubkeys", 8)]
        public virtual List<byte[]> PermittedAuthMethodPubkeys { get; set; }
        [Parameter("uint256[][]", "permittedAuthMethodScopes", 9)]
        public virtual List<List<BigInteger>> PermittedAuthMethodScopes { get; set; }
        [Parameter("bool", "addPkpEthAddressAsPermittedAddress", 10)]
        public virtual bool AddPkpEthAddressAsPermittedAddress { get; set; }
        [Parameter("bool", "sendPkpToItself", 11)]
        public virtual bool SendPkpToItself { get; set; }
    }

    public partial class MintNextAndAddDomainWalletMetadataFunction : MintNextAndAddDomainWalletMetadataFunctionBase { }

    [Function("mintNextAndAddDomainWalletMetadata", "uint256")]
    public class MintNextAndAddDomainWalletMetadataFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "keyType", 1)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("uint256[]", "permittedAuthMethodTypes", 2)]
        public virtual List<BigInteger> PermittedAuthMethodTypes { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodIds", 3)]
        public virtual List<byte[]> PermittedAuthMethodIds { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodPubkeys", 4)]
        public virtual List<byte[]> PermittedAuthMethodPubkeys { get; set; }
        [Parameter("uint256[][]", "permittedAuthMethodScopes", 5)]
        public virtual List<List<BigInteger>> PermittedAuthMethodScopes { get; set; }
        [Parameter("string[]", "nftMetadata", 6)]
        public virtual List<string> NftMetadata { get; set; }
        [Parameter("bool", "addPkpEthAddressAsPermittedAddress", 7)]
        public virtual bool AddPkpEthAddressAsPermittedAddress { get; set; }
        [Parameter("bool", "sendPkpToItself", 8)]
        public virtual bool SendPkpToItself { get; set; }
    }

    public partial class OnERC721ReceivedFunction : OnERC721ReceivedFunctionBase { }

    [Function("onERC721Received", "bytes4")]
    public class OnERC721ReceivedFunctionBase : FunctionMessage
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
        [Parameter("address", "", 2)]
        public virtual string ReturnValue2 { get; set; }
        [Parameter("uint256", "", 3)]
        public virtual BigInteger ReturnValue3 { get; set; }
        [Parameter("bytes", "", 4)]
        public virtual byte[] ReturnValue4 { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class RemovePkpMetadataFunction : RemovePkpMetadataFunctionBase { }

    [Function("removePkpMetadata")]
    public class RemovePkpMetadataFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceRoleFunction : RenounceRoleFunctionBase { }

    [Function("renounceRole")]
    public class RenounceRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
    }

    public partial class RevokeRoleFunction : RevokeRoleFunctionBase { }

    [Function("revokeRole")]
    public class RevokeRoleFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "role", 1)]
        public virtual byte[] Role { get; set; }
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

    public partial class SetPkpMetadataFunction : SetPkpMetadataFunctionBase { }

    [Function("setPkpMetadata")]
    public class SetPkpMetadataFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("string[]", "nftMetadata", 2)]
        public virtual List<string> NftMetadata { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class ContractResolverAddressSetEventDTO : ContractResolverAddressSetEventDTOBase { }

    [Event("ContractResolverAddressSet")]
    public class ContractResolverAddressSetEventDTOBase : IEventDTO
    {
        [Parameter("address", "newResolverAddress", 1, false )]
        public virtual string NewResolverAddress { get; set; }
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

    public partial class RoleAdminChangedEventDTO : RoleAdminChangedEventDTOBase { }

    [Event("RoleAdminChanged")]
    public class RoleAdminChangedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "role", 1, true )]
        public virtual byte[] Role { get; set; }
        [Parameter("bytes32", "previousAdminRole", 2, true )]
        public virtual byte[] PreviousAdminRole { get; set; }
        [Parameter("bytes32", "newAdminRole", 3, true )]
        public virtual byte[] NewAdminRole { get; set; }
    }

    public partial class RoleGrantedEventDTO : RoleGrantedEventDTOBase { }

    [Event("RoleGranted")]
    public class RoleGrantedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "role", 1, true )]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2, true )]
        public virtual string Account { get; set; }
        [Parameter("address", "sender", 3, true )]
        public virtual string Sender { get; set; }
    }

    public partial class RoleRevokedEventDTO : RoleRevokedEventDTOBase { }

    [Event("RoleRevoked")]
    public class RoleRevokedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "role", 1, true )]
        public virtual byte[] Role { get; set; }
        [Parameter("address", "account", 2, true )]
        public virtual string Account { get; set; }
        [Parameter("address", "sender", 3, true )]
        public virtual string Sender { get; set; }
    }

    public partial class DefaultAdminRoleOutputDTO : DefaultAdminRoleOutputDTOBase { }

    [FunctionOutput]
    public class DefaultAdminRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }





    public partial class ContractResolverOutputDTO : ContractResolverOutputDTOBase { }

    [FunctionOutput]
    public class ContractResolverOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class EnvOutputDTO : EnvOutputDTOBase { }

    [FunctionOutput]
    public class EnvOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }

    public partial class GetDomainWalletRegistryOutputDTO : GetDomainWalletRegistryOutputDTOBase { }

    [FunctionOutput]
    public class GetDomainWalletRegistryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetPKPNftMetdataAddressOutputDTO : GetPKPNftMetdataAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetPKPNftMetdataAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetPkpNftAddressOutputDTO : GetPkpNftAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetPkpNftAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetPkpPermissionsAddressOutputDTO : GetPkpPermissionsAddressOutputDTOBase { }

    [FunctionOutput]
    public class GetPkpPermissionsAddressOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class GetRoleAdminOutputDTO : GetRoleAdminOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleAdminOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }



    public partial class HasRoleOutputDTO : HasRoleOutputDTOBase { }

    [FunctionOutput]
    public class HasRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }







    public partial class OnERC721ReceivedOutputDTO : OnERC721ReceivedOutputDTOBase { }

    [FunctionOutput]
    public class OnERC721ReceivedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes4", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }













    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }


}
