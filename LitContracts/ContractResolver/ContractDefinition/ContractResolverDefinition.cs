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

namespace LitContracts.ContractResolver.ContractDefinition
{


    public partial class ContractResolverDeployment : ContractResolverDeploymentBase
    {
        public ContractResolverDeployment() : base(BYTECODE) { }
        public ContractResolverDeployment(string byteCode) : base(byteCode) { }
    }

    public class ContractResolverDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public ContractResolverDeploymentBase() : base(BYTECODE) { }
        public ContractResolverDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("uint8", "env", 1)]
        public virtual byte Env { get; set; }
    }

    public partial class AdminRoleFunction : AdminRoleFunctionBase { }

    [Function("ADMIN_ROLE", "bytes32")]
    public class AdminRoleFunctionBase : FunctionMessage
    {

    }

    public partial class AllowlistContractFunction : AllowlistContractFunctionBase { }

    [Function("ALLOWLIST_CONTRACT", "bytes32")]
    public class AllowlistContractFunctionBase : FunctionMessage
    {

    }

    public partial class BackupRecoveryContractFunction : BackupRecoveryContractFunctionBase { }

    [Function("BACKUP_RECOVERY_CONTRACT", "bytes32")]
    public class BackupRecoveryContractFunctionBase : FunctionMessage
    {

    }

    public partial class DefaultAdminRoleFunction : DefaultAdminRoleFunctionBase { }

    [Function("DEFAULT_ADMIN_ROLE", "bytes32")]
    public class DefaultAdminRoleFunctionBase : FunctionMessage
    {

    }

    public partial class DomainWalletOracleFunction : DomainWalletOracleFunctionBase { }

    [Function("DOMAIN_WALLET_ORACLE", "bytes32")]
    public class DomainWalletOracleFunctionBase : FunctionMessage
    {

    }

    public partial class DomainWalletRegistryFunction : DomainWalletRegistryFunctionBase { }

    [Function("DOMAIN_WALLET_REGISTRY", "bytes32")]
    public class DomainWalletRegistryFunctionBase : FunctionMessage
    {

    }

    public partial class HdKeyDeriverContractFunction : HdKeyDeriverContractFunctionBase { }

    [Function("HD_KEY_DERIVER_CONTRACT", "bytes32")]
    public class HdKeyDeriverContractFunctionBase : FunctionMessage
    {

    }

    public partial class LitTokenContractFunction : LitTokenContractFunctionBase { }

    [Function("LIT_TOKEN_CONTRACT", "bytes32")]
    public class LitTokenContractFunctionBase : FunctionMessage
    {

    }

    public partial class MultiSenderContractFunction : MultiSenderContractFunctionBase { }

    [Function("MULTI_SENDER_CONTRACT", "bytes32")]
    public class MultiSenderContractFunctionBase : FunctionMessage
    {

    }

    public partial class PkpHelperContractFunction : PkpHelperContractFunctionBase { }

    [Function("PKP_HELPER_CONTRACT", "bytes32")]
    public class PkpHelperContractFunctionBase : FunctionMessage
    {

    }

    public partial class PkpNftContractFunction : PkpNftContractFunctionBase { }

    [Function("PKP_NFT_CONTRACT", "bytes32")]
    public class PkpNftContractFunctionBase : FunctionMessage
    {

    }

    public partial class PkpNftMetadataContractFunction : PkpNftMetadataContractFunctionBase { }

    [Function("PKP_NFT_METADATA_CONTRACT", "bytes32")]
    public class PkpNftMetadataContractFunctionBase : FunctionMessage
    {

    }

    public partial class PkpPermissionsContractFunction : PkpPermissionsContractFunctionBase { }

    [Function("PKP_PERMISSIONS_CONTRACT", "bytes32")]
    public class PkpPermissionsContractFunctionBase : FunctionMessage
    {

    }

    public partial class PubKeyRouterContractFunction : PubKeyRouterContractFunctionBase { }

    [Function("PUB_KEY_ROUTER_CONTRACT", "bytes32")]
    public class PubKeyRouterContractFunctionBase : FunctionMessage
    {

    }

    public partial class RateLimitNftContractFunction : RateLimitNftContractFunctionBase { }

    [Function("RATE_LIMIT_NFT_CONTRACT", "bytes32")]
    public class RateLimitNftContractFunctionBase : FunctionMessage
    {

    }

    public partial class ReleaseRegisterContractFunction : ReleaseRegisterContractFunctionBase { }

    [Function("RELEASE_REGISTER_CONTRACT", "bytes32")]
    public class ReleaseRegisterContractFunctionBase : FunctionMessage
    {

    }

    public partial class StakingBalancesContractFunction : StakingBalancesContractFunctionBase { }

    [Function("STAKING_BALANCES_CONTRACT", "bytes32")]
    public class StakingBalancesContractFunctionBase : FunctionMessage
    {

    }

    public partial class StakingContractFunction : StakingContractFunctionBase { }

    [Function("STAKING_CONTRACT", "bytes32")]
    public class StakingContractFunctionBase : FunctionMessage
    {

    }

    public partial class AddAdminFunction : AddAdminFunctionBase { }

    [Function("addAdmin")]
    public class AddAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "newAdmin", 1)]
        public virtual string NewAdmin { get; set; }
    }

    public partial class AddAllowedEnvFunction : AddAllowedEnvFunctionBase { }

    [Function("addAllowedEnv")]
    public class AddAllowedEnvFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "env", 1)]
        public virtual byte Env { get; set; }
    }

    public partial class GetContractFunction : GetContractFunctionBase { }

    [Function("getContract", "address")]
    public class GetContractFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "typ", 1)]
        public virtual byte[] Typ { get; set; }
        [Parameter("uint8", "env", 2)]
        public virtual byte Env { get; set; }
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

    public partial class RemoveAdminFunction : RemoveAdminFunctionBase { }

    [Function("removeAdmin")]
    public class RemoveAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "adminBeingRemoved", 1)]
        public virtual string AdminBeingRemoved { get; set; }
    }

    public partial class RemoveAllowedEnvFunction : RemoveAllowedEnvFunctionBase { }

    [Function("removeAllowedEnv")]
    public class RemoveAllowedEnvFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "env", 1)]
        public virtual byte Env { get; set; }
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

    public partial class SetContractFunction : SetContractFunctionBase { }

    [Function("setContract")]
    public class SetContractFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "typ", 1)]
        public virtual byte[] Typ { get; set; }
        [Parameter("uint8", "env", 2)]
        public virtual byte Env { get; set; }
        [Parameter("address", "addr", 3)]
        public virtual string Addr { get; set; }
    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class TypeAddressesFunction : TypeAddressesFunctionBase { }

    [Function("typeAddresses", "address")]
    public class TypeAddressesFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
        [Parameter("uint8", "", 2)]
        public virtual byte ReturnValue2 { get; set; }
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

    public partial class SetContractEventDTO : SetContractEventDTOBase { }

    [Event("SetContract")]
    public class SetContractEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "typ", 1, false )]
        public virtual byte[] Typ { get; set; }
        [Parameter("uint8", "env", 2, false )]
        public virtual byte Env { get; set; }
        [Parameter("address", "addr", 3, false )]
        public virtual string Addr { get; set; }
    }

    public partial class AdminRoleRequiredError : AdminRoleRequiredErrorBase { }
    [Error("AdminRoleRequired")]
    public class AdminRoleRequiredErrorBase : IErrorDTO
    {
    }

    public partial class AdminRoleOutputDTO : AdminRoleOutputDTOBase { }

    [FunctionOutput]
    public class AdminRoleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class AllowlistContractOutputDTO : AllowlistContractOutputDTOBase { }

    [FunctionOutput]
    public class AllowlistContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class BackupRecoveryContractOutputDTO : BackupRecoveryContractOutputDTOBase { }

    [FunctionOutput]
    public class BackupRecoveryContractOutputDTOBase : IFunctionOutputDTO 
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

    public partial class DomainWalletOracleOutputDTO : DomainWalletOracleOutputDTOBase { }

    [FunctionOutput]
    public class DomainWalletOracleOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class DomainWalletRegistryOutputDTO : DomainWalletRegistryOutputDTOBase { }

    [FunctionOutput]
    public class DomainWalletRegistryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class HdKeyDeriverContractOutputDTO : HdKeyDeriverContractOutputDTOBase { }

    [FunctionOutput]
    public class HdKeyDeriverContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class LitTokenContractOutputDTO : LitTokenContractOutputDTOBase { }

    [FunctionOutput]
    public class LitTokenContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class MultiSenderContractOutputDTO : MultiSenderContractOutputDTOBase { }

    [FunctionOutput]
    public class MultiSenderContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class PkpHelperContractOutputDTO : PkpHelperContractOutputDTOBase { }

    [FunctionOutput]
    public class PkpHelperContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class PkpNftContractOutputDTO : PkpNftContractOutputDTOBase { }

    [FunctionOutput]
    public class PkpNftContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class PkpNftMetadataContractOutputDTO : PkpNftMetadataContractOutputDTOBase { }

    [FunctionOutput]
    public class PkpNftMetadataContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class PkpPermissionsContractOutputDTO : PkpPermissionsContractOutputDTOBase { }

    [FunctionOutput]
    public class PkpPermissionsContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class PubKeyRouterContractOutputDTO : PubKeyRouterContractOutputDTOBase { }

    [FunctionOutput]
    public class PubKeyRouterContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class RateLimitNftContractOutputDTO : RateLimitNftContractOutputDTOBase { }

    [FunctionOutput]
    public class RateLimitNftContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class ReleaseRegisterContractOutputDTO : ReleaseRegisterContractOutputDTOBase { }

    [FunctionOutput]
    public class ReleaseRegisterContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class StakingBalancesContractOutputDTO : StakingBalancesContractOutputDTOBase { }

    [FunctionOutput]
    public class StakingBalancesContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class StakingContractOutputDTO : StakingContractOutputDTOBase { }

    [FunctionOutput]
    public class StakingContractOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }





    public partial class GetContractOutputDTO : GetContractOutputDTOBase { }

    [FunctionOutput]
    public class GetContractOutputDTOBase : IFunctionOutputDTO 
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











    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class TypeAddressesOutputDTO : TypeAddressesOutputDTOBase { }

    [FunctionOutput]
    public class TypeAddressesOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }
}
