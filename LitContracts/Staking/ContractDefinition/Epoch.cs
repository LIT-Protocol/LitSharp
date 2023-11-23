using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.Staking.ContractDefinition
{
    public partial class Epoch : EpochBase { }

    public class EpochBase 
    {
        [Parameter("uint256", "epochLength", 1)]
        public virtual BigInteger EpochLength { get; set; }
        [Parameter("uint256", "number", 2)]
        public virtual BigInteger Number { get; set; }
        [Parameter("uint256", "endTime", 3)]
        public virtual BigInteger EndTime { get; set; }
        [Parameter("uint256", "retries", 4)]
        public virtual BigInteger Retries { get; set; }
        [Parameter("uint256", "timeout", 5)]
        public virtual BigInteger Timeout { get; set; }
    }
}
