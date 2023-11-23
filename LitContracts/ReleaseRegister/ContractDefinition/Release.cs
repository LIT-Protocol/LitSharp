using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.ReleaseRegister.ContractDefinition
{
    public partial class Release : ReleaseBase { }

    public class ReleaseBase 
    {
        [Parameter("uint8", "status", 1)]
        public virtual byte Status { get; set; }
        [Parameter("uint8", "env", 2)]
        public virtual byte Env { get; set; }
        [Parameter("uint8", "typ", 3)]
        public virtual byte Typ { get; set; }
        [Parameter("bytes", "kind", 4)]
        public virtual byte[] Kind { get; set; }
        [Parameter("uint256", "date", 5)]
        public virtual BigInteger Date { get; set; }
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
    }
}
