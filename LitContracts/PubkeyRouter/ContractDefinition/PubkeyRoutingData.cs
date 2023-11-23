using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.PubkeyRouter.ContractDefinition
{
    public partial class PubkeyRoutingData : PubkeyRoutingDataBase { }

    public class PubkeyRoutingDataBase 
    {
        [Parameter("bytes", "pubkey", 1)]
        public virtual byte[] Pubkey { get; set; }
        [Parameter("uint256", "keyType", 2)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("bytes32", "derivedKeyId", 3)]
        public virtual byte[] DerivedKeyId { get; set; }
    }
}
