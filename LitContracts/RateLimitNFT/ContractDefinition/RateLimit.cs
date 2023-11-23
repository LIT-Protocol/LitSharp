using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.RateLimitNFT.ContractDefinition
{
    public partial class RateLimit : RateLimitBase { }

    public class RateLimitBase 
    {
        [Parameter("uint256", "requestsPerKilosecond", 1)]
        public virtual BigInteger RequestsPerKilosecond { get; set; }
        [Parameter("uint256", "expiresAt", 2)]
        public virtual BigInteger ExpiresAt { get; set; }
    }
}
