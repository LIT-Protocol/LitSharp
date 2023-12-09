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

namespace LitContracts.DomainWalletOracle.ContractDefinition
{


    public partial class DomainWalletOracleDeployment : DomainWalletOracleDeploymentBase
    {
        public DomainWalletOracleDeployment() : base(BYTECODE) { }
        public DomainWalletOracleDeployment(string byteCode) : base(byteCode) { }
    }

    public class DomainWalletOracleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public DomainWalletOracleDeploymentBase() : base(BYTECODE) { }
        public DomainWalletOracleDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "_contractResolver", 1)]
        public virtual string ContractResolver { get; set; }
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

    public partial class AddAdminFunction : AddAdminFunctionBase { }

    [Function("addAdmin")]
    public class AddAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "newAdmin", 1)]
        public virtual string NewAdmin { get; set; }
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

    public partial class GetDomainIdByTokenIdFunction : GetDomainIdByTokenIdFunctionBase { }

    [Function("getDomainIdByTokenId", "uint64")]
    public class GetDomainIdByTokenIdFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
    }

    public partial class GetDomainTokenIdByUriFunction : GetDomainTokenIdByUriFunctionBase { }

    [Function("getDomainTokenIdByUri", "uint256")]
    public class GetDomainTokenIdByUriFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "uri", 1)]
        public virtual byte[] Uri { get; set; }
    }

    public partial class GetDomainUriFunction : GetDomainUriFunctionBase { }

    [Function("getDomainUri", "bytes")]
    public class GetDomainUriFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
    }

    public partial class GetExpirationFunction : GetExpirationFunctionBase { }

    [Function("getExpiration", "uint256")]
    public class GetExpirationFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
    }

    public partial class GetPkpTokenIdFunction : GetPkpTokenIdFunctionBase { }

    [Function("getPkpTokenId", "uint256")]
    public class GetPkpTokenIdFunctionBase : FunctionMessage
    {
        [Parameter("uint64", "id", 1)]
        public virtual ulong Id { get; set; }
    }

    public partial class GetRecordFunction : GetRecordFunctionBase { }

    [Function("getRecord", "bytes")]
    public class GetRecordFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
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

    public partial class HasExpiredFunction : HasExpiredFunctionBase { }

    [Function("hasExpired", "bool")]
    public class HasExpiredFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
    }

    public partial class HasOwnerFunction : HasOwnerFunctionBase { }

    [Function("hasOwner", "bool")]
    public class HasOwnerFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
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

    public partial class IsOwnerFunction : IsOwnerFunctionBase { }

    [Function("isOwner", "bool")]
    public class IsOwnerFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
    }

    public partial class IsRoutedFunction : IsRoutedFunctionBase { }

    [Function("isRouted", "bool")]
    public class IsRoutedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
    }

    public partial class RegisterDomainFunction : RegisterDomainFunctionBase { }

    [Function("registerDomain")]
    public class RegisterDomainFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "userId", 1)]
        public virtual byte[] UserId { get; set; }
        [Parameter("bytes", "uri", 2)]
        public virtual byte[] Uri { get; set; }
        [Parameter("uint256", "pkpTokenId", 3)]
        public virtual BigInteger PkpTokenId { get; set; }
        [Parameter("uint256", "ttl", 4)]
        public virtual BigInteger Ttl { get; set; }
    }

    public partial class RegisterPKPFunction : RegisterPKPFunctionBase { }

    [Function("registerPKP", "bool")]
    public class RegisterPKPFunctionBase : FunctionMessage
    {
        [Parameter("uint64", "id", 1)]
        public virtual ulong Id { get; set; }
        [Parameter("uint256", "pkpTokenId", 2)]
        public virtual BigInteger PkpTokenId { get; set; }
    }

    public partial class RemoveAdminFunction : RemoveAdminFunctionBase { }

    [Function("removeAdmin")]
    public class RemoveAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "adminBeingRemoved", 1)]
        public virtual string AdminBeingRemoved { get; set; }
    }

    public partial class RemoveDomainFunction : RemoveDomainFunctionBase { }

    [Function("removeDomain", "bool")]
    public class RemoveDomainFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
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

    public partial class RevokeDomainFunction : RevokeDomainFunctionBase { }

    [Function("revokeDomain", "bool")]
    public class RevokeDomainFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
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

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class UpdateDomainRecordFunction : UpdateDomainRecordFunctionBase { }

    [Function("updateDomainRecord", "bool")]
    public class UpdateDomainRecordFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "pkpTokenId", 1)]
        public virtual BigInteger PkpTokenId { get; set; }
        [Parameter("bytes", "record", 2)]
        public virtual byte[] Record { get; set; }
    }

    public partial class ExpiredEventDTO : ExpiredEventDTOBase { }

    [Event("Expired")]
    public class ExpiredEventDTOBase : IEventDTO
    {
        [Parameter("bytes", "subDomain", 1, false )]
        public virtual byte[] SubDomain { get; set; }
        [Parameter("uint256", "tokenId", 2, false )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("uint256", "ttl", 3, false )]
        public virtual BigInteger Ttl { get; set; }
    }

    public partial class RegisteredEventDTO : RegisteredEventDTOBase { }

    [Event("Registered")]
    public class RegisteredEventDTOBase : IEventDTO
    {
        [Parameter("uint64", "id", 1, false )]
        public virtual ulong Id { get; set; }
        [Parameter("bytes", "subDomain", 2, false )]
        public virtual byte[] SubDomain { get; set; }
        [Parameter("uint256", "ttl", 3, false )]
        public virtual BigInteger Ttl { get; set; }
        [Parameter("uint256", "tokenId", 4, false )]
        public virtual BigInteger TokenId { get; set; }
    }

    public partial class RemovedEventDTO : RemovedEventDTOBase { }

    [Event("Removed")]
    public class RemovedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, false )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "subDomain", 2, false )]
        public virtual byte[] SubDomain { get; set; }
    }

    public partial class RevokedEventDTO : RevokedEventDTOBase { }

    [Event("Revoked")]
    public class RevokedEventDTOBase : IEventDTO
    {
        [Parameter("uint256", "tokenId", 1, false )]
        public virtual BigInteger TokenId { get; set; }
        [Parameter("bytes", "subDomain", 2, false )]
        public virtual byte[] SubDomain { get; set; }
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

    public partial class DomainAlreadyRegisteredError : DomainAlreadyRegisteredErrorBase { }

    [Error("DomainAlreadyRegistered")]
    public class DomainAlreadyRegisteredErrorBase : IErrorDTO
    {
        [Parameter("bytes", "uri", 1)]
        public virtual byte[] Uri { get; set; }
        [Parameter("uint256", "pkpTokenId", 2)]
        public virtual BigInteger PkpTokenId { get; set; }
    }

    public partial class NonRegistryCallerError : NonRegistryCallerErrorBase { }

    [Error("NonRegistryCaller")]
    public class NonRegistryCallerErrorBase : IErrorDTO
    {
        [Parameter("address", "registryAddress", 1)]
        public virtual string RegistryAddress { get; set; }
        [Parameter("address", "account", 2)]
        public virtual string Account { get; set; }
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

    public partial class GetDomainIdByTokenIdOutputDTO : GetDomainIdByTokenIdOutputDTOBase { }

    [FunctionOutput]
    public class GetDomainIdByTokenIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint64", "", 1)]
        public virtual ulong ReturnValue1 { get; set; }
    }

    public partial class GetDomainTokenIdByUriOutputDTO : GetDomainTokenIdByUriOutputDTOBase { }

    [FunctionOutput]
    public class GetDomainTokenIdByUriOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetDomainUriOutputDTO : GetDomainUriOutputDTOBase { }

    [FunctionOutput]
    public class GetDomainUriOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetExpirationOutputDTO : GetExpirationOutputDTOBase { }

    [FunctionOutput]
    public class GetExpirationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetPkpTokenIdOutputDTO : GetPkpTokenIdOutputDTOBase { }

    [FunctionOutput]
    public class GetPkpTokenIdOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class GetRecordOutputDTO : GetRecordOutputDTOBase { }

    [FunctionOutput]
    public class GetRecordOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetRoleAdminOutputDTO : GetRoleAdminOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleAdminOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }





    public partial class HasOwnerOutputDTO : HasOwnerOutputDTOBase { }

    [FunctionOutput]
    public class HasOwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class HasRoleOutputDTO : HasRoleOutputDTOBase { }

    [FunctionOutput]
    public class HasRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsOwnerOutputDTO : IsOwnerOutputDTOBase { }

    [FunctionOutput]
    public class IsOwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsRoutedOutputDTO : IsRoutedOutputDTOBase { }

    [FunctionOutput]
    public class IsRoutedOutputDTOBase : IFunctionOutputDTO 
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


}
