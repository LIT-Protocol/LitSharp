using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.BackupRecovery.ContractDefinition
{
    public partial class BackupRecoveryState : BackupRecoveryStateBase { }

    public class BackupRecoveryStateBase 
    {
        [Parameter("bytes", "sessionId", 1)]
        public virtual byte[] SessionId { get; set; }
        [Parameter("bytes", "bls12381G1EncKey", 2)]
        public virtual byte[] Bls12381G1EncKey { get; set; }
        [Parameter("bytes", "secp256K1EcdsaPubKey", 3)]
        public virtual byte[] Secp256K1EcdsaPubKey { get; set; }
        [Parameter("uint256", "partyThreshold", 4)]
        public virtual BigInteger PartyThreshold { get; set; }
        [Parameter("address[]", "partyMembers", 5)]
        public virtual List<string> PartyMembers { get; set; }
    }
}
