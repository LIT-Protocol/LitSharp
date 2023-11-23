using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.Staking.ContractDefinition
{
    public partial class Version : VersionBase { }

    public class VersionBase 
    {
        [Parameter("uint256", "major", 1)]
        public virtual BigInteger Major { get; set; }
        [Parameter("uint256", "minor", 2)]
        public virtual BigInteger Minor { get; set; }
        [Parameter("uint256", "patch", 3)]
        public virtual BigInteger Patch { get; set; }
    }
}
