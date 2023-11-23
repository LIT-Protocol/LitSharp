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

namespace LitContracts.KeyDeriver.ContractDefinition
{


    public partial class KeyDeriverDeployment : KeyDeriverDeploymentBase
    {
        public KeyDeriverDeployment() : base(BYTECODE) { }
        public KeyDeriverDeployment(string byteCode) : base(byteCode) { }
    }

    public class KeyDeriverDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public KeyDeriverDeploymentBase() : base(BYTECODE) { }
        public KeyDeriverDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class HdKdfFunction : HdKdfFunctionBase { }

    [Function("HD_KDF", "address")]
    public class HdKdfFunctionBase : FunctionMessage
    {

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

    public partial class HdKdfOutputDTO : HdKdfOutputDTOBase { }

    [FunctionOutput]
    public class HdKdfOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
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
