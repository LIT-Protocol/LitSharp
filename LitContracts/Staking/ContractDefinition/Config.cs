using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.Staking.ContractDefinition
{
    public partial class Config : ConfigBase { }

    public class ConfigBase 
    {
        [Parameter("uint256", "tokenRewardPerTokenPerEpoch", 1)]
        public virtual BigInteger TokenRewardPerTokenPerEpoch { get; set; }
        [Parameter("uint256", "complaintTolerance", 2)]
        public virtual BigInteger ComplaintTolerance { get; set; }
        [Parameter("uint256", "complaintIntervalSecs", 3)]
        public virtual BigInteger ComplaintIntervalSecs { get; set; }
        [Parameter("uint256[]", "keyTypes", 4)]
        public virtual List<BigInteger> KeyTypes { get; set; }
        [Parameter("uint256", "minimumValidatorCount", 5)]
        public virtual BigInteger MinimumValidatorCount { get; set; }
    }
}
