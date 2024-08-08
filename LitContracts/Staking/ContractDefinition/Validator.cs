using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.Staking.ContractDefinition
{
    public partial class Validator : ValidatorBase { }

    public class ValidatorBase 
    {
        [Parameter("uint32", "ip", 1)]
        public virtual uint Ip { get; set; }
        [Parameter("uint128", "ipv6", 2)]
        public virtual BigInteger Ipv6 { get; set; }
        [Parameter("uint32", "port", 3)]
        public virtual uint Port { get; set; }
        [Parameter("address", "nodeAddress", 4)]
        public virtual string NodeAddress { get; set; }
        [Parameter("uint256", "reward", 5)]
        public virtual BigInteger Reward { get; set; }
        [Parameter("uint256", "senderPubKey", 6)]
        public virtual BigInteger SenderPubKey { get; set; }
        [Parameter("uint256", "receiverPubKey", 7)]
        public virtual BigInteger ReceiverPubKey { get; set; }
        [Parameter("uint256", "lastActiveEpoch", 8)]
        public virtual BigInteger LastActiveEpoch { get; set; }
    }
}
