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

namespace LitContracts.Allowlist.ContractDefinition
{


    public partial class AllowlistDeployment : AllowlistDeploymentBase
    {
        public AllowlistDeployment() : base(BYTECODE) { }
        public AllowlistDeployment(string byteCode) : base(byteCode) { }
    }

    public class AllowlistDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public AllowlistDeploymentBase() : base(BYTECODE) { }
        public AllowlistDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class AddAdminFunction : AddAdminFunctionBase { }

    [Function("addAdmin")]
    public class AddAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "newAdmin", 1)]
        public virtual string NewAdmin { get; set; }
    }

    public partial class AllowAllFunction : AllowAllFunctionBase { }

    [Function("allowAll", "bool")]
    public class AllowAllFunctionBase : FunctionMessage
    {

    }

    public partial class AllowedItemsFunction : AllowedItemsFunctionBase { }

    [Function("allowedItems", "bool")]
    public class AllowedItemsFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class IsAllowedFunction : IsAllowedFunctionBase { }

    [Function("isAllowed", "bool")]
    public class IsAllowedFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "key", 1)]
        public virtual byte[] Key { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class RemoveAdminFunction : RemoveAdminFunctionBase { }

    [Function("removeAdmin")]
    public class RemoveAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "newAdmin", 1)]
        public virtual string NewAdmin { get; set; }
    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SetAllowAllFunction : SetAllowAllFunctionBase { }

    [Function("setAllowAll")]
    public class SetAllowAllFunctionBase : FunctionMessage
    {
        [Parameter("bool", "_allowAll", 1)]
        public virtual bool AllowAll { get; set; }
    }

    public partial class SetAllowedFunction : SetAllowedFunctionBase { }

    [Function("setAllowed")]
    public class SetAllowedFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "key", 1)]
        public virtual byte[] Key { get; set; }
    }

    public partial class SetNotAllowedFunction : SetNotAllowedFunctionBase { }

    [Function("setNotAllowed")]
    public class SetNotAllowedFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "key", 1)]
        public virtual byte[] Key { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class AdminAddedEventDTO : AdminAddedEventDTOBase { }

    [Event("AdminAdded")]
    public class AdminAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "newAdmin", 1, true )]
        public virtual string NewAdmin { get; set; }
    }

    public partial class AdminRemovedEventDTO : AdminRemovedEventDTOBase { }

    [Event("AdminRemoved")]
    public class AdminRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "newAdmin", 1, true )]
        public virtual string NewAdmin { get; set; }
    }

    public partial class ItemAllowedEventDTO : ItemAllowedEventDTOBase { }

    [Event("ItemAllowed")]
    public class ItemAllowedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "key", 1, true )]
        public virtual byte[] Key { get; set; }
    }

    public partial class ItemNotAllowedEventDTO : ItemNotAllowedEventDTOBase { }

    [Event("ItemNotAllowed")]
    public class ItemNotAllowedEventDTOBase : IEventDTO
    {
        [Parameter("bytes32", "key", 1, true )]
        public virtual byte[] Key { get; set; }
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



    public partial class AllowAllOutputDTO : AllowAllOutputDTOBase { }

    [FunctionOutput]
    public class AllowAllOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class AllowedItemsOutputDTO : AllowedItemsOutputDTOBase { }

    [FunctionOutput]
    public class AllowedItemsOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsAllowedOutputDTO : IsAllowedOutputDTOBase { }

    [FunctionOutput]
    public class IsAllowedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }












}
