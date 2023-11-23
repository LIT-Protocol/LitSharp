using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.PKPHelper.ContractDefinition
{
    public partial class Signature : SignatureBase { }

    public class SignatureBase 
    {
        [Parameter("bytes32", "r", 1)]
        public virtual byte[] R { get; set; }
        [Parameter("bytes32", "s", 2)]
        public virtual byte[] S { get; set; }
        [Parameter("uint8", "v", 3)]
        public virtual byte V { get; set; }
    }
}
