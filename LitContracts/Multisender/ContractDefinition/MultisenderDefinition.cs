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

namespace LitContracts.Multisender.ContractDefinition
{


    public partial class MultisenderDeployment : MultisenderDeploymentBase
    {
        public MultisenderDeployment() : base(BYTECODE) { }
        public MultisenderDeployment(string byteCode) : base(byteCode) { }
    }

    public class MultisenderDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public MultisenderDeploymentBase() : base(BYTECODE) { }
        public MultisenderDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class RenounceOwnershipFunction : RenounceOwnershipFunctionBase { }

    [Function("renounceOwnership")]
    public class RenounceOwnershipFunctionBase : FunctionMessage
    {

    }

    public partial class SendEthFunction : SendEthFunctionBase { }

    [Function("sendEth")]
    public class SendEthFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_recipients", 1)]
        public virtual List<string> Recipients { get; set; }
    }

    public partial class SendTokensFunction : SendTokensFunctionBase { }

    [Function("sendTokens")]
    public class SendTokensFunctionBase : FunctionMessage
    {
        [Parameter("address[]", "_recipients", 1)]
        public virtual List<string> Recipients { get; set; }
        [Parameter("address", "tokenContract", 2)]
        public virtual string TokenContract { get; set; }
    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class WithdrawFunction : WithdrawFunctionBase { }

    [Function("withdraw")]
    public class WithdrawFunctionBase : FunctionMessage
    {

    }

    public partial class WithdrawTokensFunction : WithdrawTokensFunctionBase { }

    [Function("withdrawTokens")]
    public class WithdrawTokensFunctionBase : FunctionMessage
    {
        [Parameter("address", "tokenContract", 1)]
        public virtual string TokenContract { get; set; }
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

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }












}
