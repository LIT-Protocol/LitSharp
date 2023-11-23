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

namespace LitContracts.ReleaseRegister.ContractDefinition
{


    public partial class ReleaseRegisterDeployment : ReleaseRegisterDeploymentBase
    {
        public ReleaseRegisterDeployment() : base(BYTECODE) { }
        public ReleaseRegisterDeployment(string byteCode) : base(byteCode) { }
    }

    public class ReleaseRegisterDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public ReleaseRegisterDeploymentBase() : base(BYTECODE) { }
        public ReleaseRegisterDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint8", "env", 1)]
        public virtual byte Env { get; set; }
    }

    public partial class ActivatorRoleFunction : ActivatorRoleFunctionBase { }

    [Function("ACTIVATOR_ROLE", "bytes32")]
    public class ActivatorRoleFunctionBase : FunctionMessage
    {

    }

    public partial class AdminRoleFunction : AdminRoleFunctionBase { }

    [Function("ADMIN_ROLE", "bytes32")]
    public class AdminRoleFunctionBase : FunctionMessage
    {

    }

    public partial class BurnerRoleFunction : BurnerRoleFunctionBase { }

    [Function("BURNER_ROLE", "bytes32")]
    public class BurnerRoleFunctionBase : FunctionMessage
    {

    }

    public partial class CreatorRoleFunction : CreatorRoleFunctionBase { }

    [Function("CREATOR_ROLE", "bytes32")]
    public class CreatorRoleFunctionBase : FunctionMessage
    {

    }

    public partial class DeactivatorRoleFunction : DeactivatorRoleFunctionBase { }

    [Function("DEACTIVATOR_ROLE", "bytes32")]
    public class DeactivatorRoleFunctionBase : FunctionMessage
    {

    }

    public partial class DefaultAdminRoleFunction : DefaultAdminRoleFunctionBase { }

    [Function("DEFAULT_ADMIN_ROLE", "bytes32")]
    public class DefaultAdminRoleFunctionBase : FunctionMessage
    {

    }

    public partial class ReleaseOptionRoFunction : ReleaseOptionRoFunctionBase { }

    [Function("RELEASE_OPTION_RO", "uint256")]
    public class ReleaseOptionRoFunctionBase : FunctionMessage
    {

    }

    public partial class ReleaseOptionSshFunction : ReleaseOptionSshFunctionBase { }

    [Function("RELEASE_OPTION_SSH", "uint256")]
    public class ReleaseOptionSshFunctionBase : FunctionMessage
    {

    }

    public partial class ReleaseOptionUsersFunction : ReleaseOptionUsersFunctionBase { }

    [Function("RELEASE_OPTION_USERS", "uint256")]
    public class ReleaseOptionUsersFunctionBase : FunctionMessage
    {

    }

    public partial class AddAllowedAdminSigningPublicKeyFunction : AddAllowedAdminSigningPublicKeyFunctionBase { }

    [Function("addAllowedAdminSigningPublicKey")]
    public class AddAllowedAdminSigningPublicKeyFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "pubKey", 1)]
        public virtual byte[] PubKey { get; set; }
    }

    public partial class AddAllowedEnvFunction : AddAllowedEnvFunctionBase { }

    [Function("addAllowedEnv")]
    public class AddAllowedEnvFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "env", 1)]
        public virtual byte Env { get; set; }
    }

    public partial class AddAllowedSubnetFunction : AddAllowedSubnetFunctionBase { }

    [Function("addAllowedSubnet")]
    public class AddAllowedSubnetFunctionBase : FunctionMessage
    {
        [Parameter("address", "subnet", 1)]
        public virtual string Subnet { get; set; }
    }

    public partial class BurnReleaseFunction : BurnReleaseFunctionBase { }

    [Function("burnRelease")]
    public class BurnReleaseFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "releaseId", 1)]
        public virtual byte[] ReleaseId { get; set; }
    }

    public partial class CreateReleaseFunction : CreateReleaseFunctionBase { }

    [Function("createRelease")]
    public class CreateReleaseFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "releaseId", 1)]
        public virtual byte[] ReleaseId { get; set; }
        [Parameter("uint8", "status", 2)]
        public virtual byte Status { get; set; }
        [Parameter("uint8", "env", 3)]
        public virtual byte Env { get; set; }
        [Parameter("uint8", "typ", 4)]
        public virtual byte Typ { get; set; }
        [Parameter("bytes", "kind", 5)]
        public virtual byte[] Kind { get; set; }
        [Parameter("uint8", "platform", 6)]
        public virtual byte Platform { get; set; }
        [Parameter("uint256", "options", 7)]
        public virtual BigInteger Options { get; set; }
        [Parameter("bytes", "id_key_digest", 8)]
        public virtual byte[] IdKeyDigest { get; set; }
        [Parameter("bytes", "public_key", 9)]
        public virtual byte[] PublicKey { get; set; }
        [Parameter("bytes", "cid", 10)]
        public virtual byte[] Cid { get; set; }
        [Parameter("uint256", "date", 11)]
        public virtual BigInteger Date { get; set; }
    }

    public partial class GetActiveReleaseFunction : GetActiveReleaseFunctionBase { }

    [Function("getActiveRelease", "bytes32")]
    public class GetActiveReleaseFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "env", 1)]
        public virtual byte Env { get; set; }
        [Parameter("uint8", "typ", 2)]
        public virtual byte Typ { get; set; }
        [Parameter("bytes", "kind", 3)]
        public virtual byte[] Kind { get; set; }
        [Parameter("uint8", "platform", 4)]
        public virtual byte Platform { get; set; }
    }

    public partial class GetActiveReleasesFunction : GetActiveReleasesFunctionBase { }

    [Function("getActiveReleases", "bytes32[]")]
    public class GetActiveReleasesFunctionBase : FunctionMessage
    {

    }

    public partial class GetCreatorDomainFunction : GetCreatorDomainFunctionBase { }

    [Function("getCreatorDomain", "bytes")]
    public class GetCreatorDomainFunctionBase : FunctionMessage
    {

    }

    public partial class GetReleaseFunction : GetReleaseFunctionBase { }

    [Function("getRelease", typeof(GetReleaseOutputDTO))]
    public class GetReleaseFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "releaseId", 1)]
        public virtual byte[] ReleaseId { get; set; }
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

    public partial class HasAllowedAdminSigningPublicKeyFunction : HasAllowedAdminSigningPublicKeyFunctionBase { }

    [Function("hasAllowedAdminSigningPublicKey", "bool")]
    public class HasAllowedAdminSigningPublicKeyFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "pubKey", 1)]
        public virtual byte[] PubKey { get; set; }
    }

    public partial class HasAllowedAuthorKeyDigestFunction : HasAllowedAuthorKeyDigestFunctionBase { }

    [Function("hasAllowedAuthorKeyDigest", "bool")]
    public class HasAllowedAuthorKeyDigestFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "digest", 1)]
        public virtual byte[] Digest { get; set; }
    }

    public partial class HasAllowedEnvFunction : HasAllowedEnvFunctionBase { }

    [Function("hasAllowedEnv", "bool")]
    public class HasAllowedEnvFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "env", 1)]
        public virtual byte Env { get; set; }
    }

    public partial class HasAllowedSubnetFunction : HasAllowedSubnetFunctionBase { }

    [Function("hasAllowedSubnet", "bool")]
    public class HasAllowedSubnetFunctionBase : FunctionMessage
    {
        [Parameter("address", "subnet", 1)]
        public virtual string Subnet { get; set; }
    }

    public partial class HasCreatorInitFunction : HasCreatorInitFunctionBase { }

    [Function("hasCreatorInit", "bool")]
    public class HasCreatorInitFunctionBase : FunctionMessage
    {

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

    public partial class InitCreatorFunction : InitCreatorFunctionBase { }

    [Function("initCreator")]
    public class InitCreatorFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "env", 1)]
        public virtual byte Env { get; set; }
        [Parameter("address", "subnetId", 2)]
        public virtual string SubnetId { get; set; }
        [Parameter("bytes", "domain", 3)]
        public virtual byte[] Domain { get; set; }
        [Parameter("bytes", "authorKeyDigest", 4)]
        public virtual byte[] AuthorKeyDigest { get; set; }
    }

    public partial class RemoveAllowedAdminSigningPublicKeyFunction : RemoveAllowedAdminSigningPublicKeyFunctionBase { }

    [Function("removeAllowedAdminSigningPublicKey")]
    public class RemoveAllowedAdminSigningPublicKeyFunctionBase : FunctionMessage
    {
        [Parameter("bytes", "pubKey", 1)]
        public virtual byte[] PubKey { get; set; }
    }

    public partial class RemoveAllowedEnvFunction : RemoveAllowedEnvFunctionBase { }

    [Function("removeAllowedEnv")]
    public class RemoveAllowedEnvFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "env", 1)]
        public virtual byte Env { get; set; }
    }

    public partial class RemoveAllowedSubnetFunction : RemoveAllowedSubnetFunctionBase { }

    [Function("removeAllowedSubnet")]
    public class RemoveAllowedSubnetFunctionBase : FunctionMessage
    {
        [Parameter("address", "subnet", 1)]
        public virtual string Subnet { get; set; }
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

    public partial class SetReleaseStatusFunction : SetReleaseStatusFunctionBase { }

    [Function("setReleaseStatus")]
    public class SetReleaseStatusFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "releaseId", 1)]
        public virtual byte[] ReleaseId { get; set; }
        [Parameter("uint8", "status", 2)]
        public virtual byte Status { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class AllowedAdminSigningPublicKeyAddedEventDTO : AllowedAdminSigningPublicKeyAddedEventDTOBase { }

    [Event("AllowedAdminSigningPublicKeyAdded")]
    public class AllowedAdminSigningPublicKeyAddedEventDTOBase : IEventDTO
    {
        [Parameter("bytes", "pubKey", 1, false )]
        public virtual byte[] PubKey { get; set; }
    }

    public partial class AllowedAdminSigningPublicKeyRemovedEventDTO : AllowedAdminSigningPublicKeyRemovedEventDTOBase { }

    [Event("AllowedAdminSigningPublicKeyRemoved")]
    public class AllowedAdminSigningPublicKeyRemovedEventDTOBase : IEventDTO
    {
        [Parameter("bytes", "pubKey", 1, false )]
        public virtual byte[] PubKey { get; set; }
    }

    public partial class AllowedAuthorKeyDigestAddedEventDTO : AllowedAuthorKeyDigestAddedEventDTOBase { }

    [Event("AllowedAuthorKeyDigestAdded")]
    public class AllowedAuthorKeyDigestAddedEventDTOBase : IEventDTO
    {
        [Parameter("bytes", "digest", 1, false )]
        public virtual byte[] Digest { get; set; }
    }

    public partial class AllowedAuthorKeyDigestRemovedEventDTO : AllowedAuthorKeyDigestRemovedEventDTOBase { }

    [Event("AllowedAuthorKeyDigestRemoved")]
    public class AllowedAuthorKeyDigestRemovedEventDTOBase : IEventDTO
    {
        [Parameter("bytes", "digest", 1, false )]
        public virtual byte[] Digest { get; set; }
    }

    public partial class AllowedEnvAddedEventDTO : AllowedEnvAddedEventDTOBase { }

    [Event("AllowedEnvAdded")]
    public class AllowedEnvAddedEventDTOBase : IEventDTO
    {
        [Parameter("uint8", "env", 1, false )]
        public virtual byte Env { get; set; }
    }

    public partial class AllowedEnvRemovedEventDTO : AllowedEnvRemovedEventDTOBase { }

    [Event("AllowedEnvRemoved")]
    public class AllowedEnvRemovedEventDTOBase : IEventDTO
    {
        [Parameter("uint8", "env", 1, false )]
        public virtual byte Env { get; set; }
    }

    public partial class AllowedSubnetAddedEventDTO : AllowedSubnetAddedEventDTOBase { }

    [Event("AllowedSubnetAdded")]
    public class AllowedSubnetAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "subnet", 1, false )]
        public virtual string Subnet { get; set; }
    }

    public partial class AllowedSubnetRemovedEventDTO : AllowedSubnetRemovedEventDTOBase { }

    [Event("AllowedSubnetRemoved")]
    public class AllowedSubnetRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "subnet", 1, false )]
        public virtual string Subnet { get; set; }
    }

    public partial class InitCreatorEventDTO : InitCreatorEventDTOBase { }

    [Event("InitCreator")]
    public class InitCreatorEventDTOBase : IEventDTO
    {
        [Parameter("bytes", "domain", 1, false )]
        public virtual byte[] Domain { get; set; }
        [Parameter("bytes", "authorKeyDigest", 2, false )]
        public virtual byte[] AuthorKeyDigest { get; set; }
    }

    public partial class ReleaseBurnedEventDTO : ReleaseBurnedEventDTOBase { }

    [Event("ReleaseBurned")]
    public class ReleaseBurnedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "releaseId", 1, false )]
        public virtual byte[] ReleaseId { get; set; }
    }

    public partial class ReleaseCreatedEventDTO : ReleaseCreatedEventDTOBase { }

    [Event("ReleaseCreated")]
    public class ReleaseCreatedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "releaseId", 1, false )]
        public virtual byte[] ReleaseId { get; set; }
        [Parameter("uint8", "status", 2, false )]
        public virtual byte Status { get; set; }
        [Parameter("uint8", "env", 3, false )]
        public virtual byte Env { get; set; }
        [Parameter("uint8", "typ", 4, false )]
        public virtual byte Typ { get; set; }
        [Parameter("bytes", "kind", 5, false )]
        public virtual byte[] Kind { get; set; }
        [Parameter("uint256", "date", 6, false )]
        public virtual BigInteger Date { get; set; }
        [Parameter("uint8", "platform", 7, false )]
        public virtual byte Platform { get; set; }
        [Parameter("uint256", "options", 8, false )]
        public virtual BigInteger Options { get; set; }
        [Parameter("bytes", "id_key_digest", 9, false )]
        public virtual byte[] IdKeyDigest { get; set; }
        [Parameter("bytes", "public_key", 10, false )]
        public virtual byte[] PublicKey { get; set; }
        [Parameter("bytes", "cid", 11, false )]
        public virtual byte[] Cid { get; set; }
    }

    public partial class ReleaseStatusChangeEventDTO : ReleaseStatusChangeEventDTOBase { }

    [Event("ReleaseStatusChange")]
    public class ReleaseStatusChangeEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "releaseId", 1, false )]
        public virtual byte[] ReleaseId { get; set; }
        [Parameter("uint8", "status", 2, false )]
        public virtual byte Status { get; set; }
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

    public partial class ActivatorRoleRequiredError : ActivatorRoleRequiredErrorBase { }
    [Error("ActivatorRoleRequired")]
    public class ActivatorRoleRequiredErrorBase : IErrorDTO
    {
    }

    public partial class AdminRoleRequiredError : AdminRoleRequiredErrorBase { }
    [Error("AdminRoleRequired")]
    public class AdminRoleRequiredErrorBase : IErrorDTO
    {
    }

    public partial class BurnerRoleRequiredError : BurnerRoleRequiredErrorBase { }
    [Error("BurnerRoleRequired")]
    public class BurnerRoleRequiredErrorBase : IErrorDTO
    {
    }

    public partial class CreatorRoleRequiredError : CreatorRoleRequiredErrorBase { }
    [Error("CreatorRoleRequired")]
    public class CreatorRoleRequiredErrorBase : IErrorDTO
    {
    }

    public partial class DeactivatorRoleRequiredError : DeactivatorRoleRequiredErrorBase { }
    [Error("DeactivatorRoleRequired")]
    public class DeactivatorRoleRequiredErrorBase : IErrorDTO
    {
    }

    public partial class InvalidEnvError : InvalidEnvErrorBase { }
    [Error("InvalidEnv")]
    public class InvalidEnvErrorBase : IErrorDTO
    {
    }

    public partial class InvalidStatusError : InvalidStatusErrorBase { }
    [Error("InvalidStatus")]
    public class InvalidStatusErrorBase : IErrorDTO
    {
    }

    public partial class ReleaseNotFoundError : ReleaseNotFoundErrorBase { }
    [Error("ReleaseNotFound")]
    public class ReleaseNotFoundErrorBase : IErrorDTO
    {
    }

    public partial class ActivatorRoleOutputDTO : ActivatorRoleOutputDTOBase { }

    [FunctionOutput]
    public class ActivatorRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class AdminRoleOutputDTO : AdminRoleOutputDTOBase { }

    [FunctionOutput]
    public class AdminRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class BurnerRoleOutputDTO : BurnerRoleOutputDTOBase { }

    [FunctionOutput]
    public class BurnerRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class CreatorRoleOutputDTO : CreatorRoleOutputDTOBase { }

    [FunctionOutput]
    public class CreatorRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class DeactivatorRoleOutputDTO : DeactivatorRoleOutputDTOBase { }

    [FunctionOutput]
    public class DeactivatorRoleOutputDTOBase : IFunctionOutputDTO 
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

    public partial class ReleaseOptionRoOutputDTO : ReleaseOptionRoOutputDTOBase { }

    [FunctionOutput]
    public class ReleaseOptionRoOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ReleaseOptionSshOutputDTO : ReleaseOptionSshOutputDTOBase { }

    [FunctionOutput]
    public class ReleaseOptionSshOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class ReleaseOptionUsersOutputDTO : ReleaseOptionUsersOutputDTOBase { }

    [FunctionOutput]
    public class ReleaseOptionUsersOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }











    public partial class GetActiveReleaseOutputDTO : GetActiveReleaseOutputDTOBase { }

    [FunctionOutput]
    public class GetActiveReleaseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetActiveReleasesOutputDTO : GetActiveReleasesOutputDTOBase { }

    [FunctionOutput]
    public class GetActiveReleasesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32[]", "", 1)]
        public virtual List<byte[]> ReturnValue1 { get; set; }
    }

    public partial class GetCreatorDomainOutputDTO : GetCreatorDomainOutputDTOBase { }

    [FunctionOutput]
    public class GetCreatorDomainOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class GetReleaseOutputDTO : GetReleaseOutputDTOBase { }

    [FunctionOutput]
    public class GetReleaseOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("tuple", "", 1)]
        public virtual Release ReturnValue1 { get; set; }
    }

    public partial class GetRoleAdminOutputDTO : GetRoleAdminOutputDTOBase { }

    [FunctionOutput]
    public class GetRoleAdminOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }



    public partial class HasAllowedAdminSigningPublicKeyOutputDTO : HasAllowedAdminSigningPublicKeyOutputDTOBase { }

    [FunctionOutput]
    public class HasAllowedAdminSigningPublicKeyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class HasAllowedAuthorKeyDigestOutputDTO : HasAllowedAuthorKeyDigestOutputDTOBase { }

    [FunctionOutput]
    public class HasAllowedAuthorKeyDigestOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class HasAllowedEnvOutputDTO : HasAllowedEnvOutputDTOBase { }

    [FunctionOutput]
    public class HasAllowedEnvOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class HasAllowedSubnetOutputDTO : HasAllowedSubnetOutputDTOBase { }

    [FunctionOutput]
    public class HasAllowedSubnetOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class HasCreatorInitOutputDTO : HasCreatorInitOutputDTOBase { }

    [FunctionOutput]
    public class HasCreatorInitOutputDTOBase : IFunctionOutputDTO 
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















    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
