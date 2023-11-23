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

namespace LitContracts.PKPNFTMetadata.ContractDefinition
{


    public partial class PKPNFTMetadataDeployment : PKPNFTMetadataDeploymentBase
    {
        public PKPNFTMetadataDeployment() : base(BYTECODE) { }
        public PKPNFTMetadataDeployment(string byteCode) : base(byteCode) { }
    }

    public class PKPNFTMetadataDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public PKPNFTMetadataDeploymentBase() : base(BYTECODE) { }
        public PKPNFTMetadataDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_resolver", 1)]
        public virtual string Resolver { get; set; }
        [Parameter("uint8", "_env", 2)]
        public virtual byte Env { get; set; }
    }

    public partial class AdminRoleFunction : AdminRoleFunctionBase { }

    [Function("ADMIN_ROLE", "bytes32")]
    public class AdminRoleFunctionBase : FunctionMessage
    {

    }

    public partial class DefaultAdminRoleFunction : DefaultAdminRoleFunctionBase { }

    [Function("DEFAULT_ADMIN_ROLE", "bytes32")]
    public class DefaultAdminRoleFunctionBase : FunctionMessage
    {

    }

    public partial class WriterRoleFunction : WriterRoleFunctionBase { }

    [Function("WRITER_ROLE", "bytes32")]
    public class WriterRoleFunctionBase : FunctionMessage
    {

    }

    public partial class BytesToHexFunction : BytesToHexFunctionBase { }

    [Function("bytesToHex", "string")]
    public class BytesToHexFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "buffer", 1)]
        public virtual byte[] Buffer { get; set; }
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

    public partial class RemoveProfileForPkpFunction : RemoveProfileForPkpFunctionBase { }

    [Function("removeProfileForPkp")]
    public class RemoveProfileForPkpFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class RemoveUrlForPKPFunction : RemoveUrlForPKPFunctionBase { }

    [Function("removeUrlForPKP")]
    public class RemoveUrlForPKPFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
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

    public partial class SetPKPHelperWriterAddressFunction : SetPKPHelperWriterAddressFunctionBase { }

    [Function("setPKPHelperWriterAddress")]
    public class SetPKPHelperWriterAddressFunctionBase : FunctionMessage
    {
        [Parameter("address", "pkpHelperWriterAddress", 1)]
        public virtual string PkpHelperWriterAddress { get; set; }
    }

    public partial class SetProfileForPKPFunction : SetProfileForPKPFunctionBase { }

    [Function("setProfileForPKP")]
    public class SetProfileForPKPFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("string", "imgUrl", 2)]
        public virtual string ImgUrl { get; set; }
    }

    public partial class SetUrlForPKPFunction : SetUrlForPKPFunctionBase { }

    [Function("setUrlForPKP")]
    public class SetUrlForPKPFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("string", "url", 2)]
        public virtual string Url { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class TokenURIFunction : TokenURIFunctionBase { }

    [Function("tokenURI", "string")]
    public class TokenURIFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "tokenId", 1)]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "pubKey", 2)]
        public virtual byte[] PubKey { get; set; }
        [Parameter("address", "ethAddress", 3)]
        public virtual string EthAddress { get; set; }
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

    public partial class AdminRoleOutputDTO : AdminRoleOutputDTOBase { }

    [FunctionOutput]
    public class AdminRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class DefaultAdminRoleOutputDTO : DefaultAdminRoleOutputDTOBase { }

    [FunctionOutput]
    public class DefaultAdminRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class WriterRoleOutputDTO : WriterRoleOutputDTOBase { }

    [FunctionOutput]
    public class WriterRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class BytesToHexOutputDTO : BytesToHexOutputDTOBase { }

    [FunctionOutput]
    public class BytesToHexOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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















    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class TokenURIOutputDTO : TokenURIOutputDTOBase { }

    [FunctionOutput]
    public class TokenURIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("string", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
