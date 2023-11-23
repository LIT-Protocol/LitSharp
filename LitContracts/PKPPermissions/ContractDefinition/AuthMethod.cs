using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.PKPPermissions.ContractDefinition
{
    public partial class AuthMethod : AuthMethodBase { }

    public class AuthMethodBase 
    {
        [Parameter("uint256", "authMethodType", 1)]
        public virtual BigInteger AuthMethodType { get; set; }
        [Parameter("bytes", "id", 2)]
        public virtual byte[] Id { get; set; }
        [Parameter("bytes", "userPubkey", 3)]
        public virtual byte[] UserPubkey { get; set; }
    }
}
