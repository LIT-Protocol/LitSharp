using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.DevKeyDeriver.ContractDefinition
{
    public partial class RootKey : RootKeyBase { }

    public class RootKeyBase 
    {
        [Parameter("bytes", "pubkey", 1)]
        public virtual byte[] Pubkey { get; set; }
        [Parameter("uint256", "keyType", 2)]
        public virtual BigInteger KeyType { get; set; }
    }
}
