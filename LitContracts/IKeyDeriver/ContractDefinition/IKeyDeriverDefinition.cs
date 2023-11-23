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

namespace LitContracts.IKeyDeriver.ContractDefinition
{


    public partial class IKeyDeriverDeployment : IKeyDeriverDeploymentBase
    {
        public IKeyDeriverDeployment() : base(BYTECODE) { }
        public IKeyDeriverDeployment(string byteCode) : base(byteCode) { }
    }

    public class IKeyDeriverDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public IKeyDeriverDeploymentBase() : base(BYTECODE) { }
        public IKeyDeriverDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class ComputeHDPubKeyFunction : ComputeHDPubKeyFunctionBase { }

    [Function("computeHDPubKey", typeof(ComputeHDPubKeyOutputDTO))]
    public class ComputeHDPubKeyFunctionBase : FunctionMessage
    {
        [Parameter("bytes32", "derivedKeyId", 1)]
        public virtual byte[] DerivedKeyId { get; set; }
        [Parameter("tuple[]", "rootHDKeys", 2)]
        public virtual List<RootKey> RootHDKeys { get; set; }
        [Parameter("uint256", "keyType", 3)]
        public virtual BigInteger KeyType { get; set; }
    }

    public partial class ComputeHDPubKeyOutputDTO : ComputeHDPubKeyOutputDTOBase { }

    [FunctionOutput]
    public class ComputeHDPubKeyOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
        [Parameter("bytes", "", 2)]
        public virtual byte[] ReturnValue2 { get; set; }
    }
}
