using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.PKPHelper.ContractDefinition
{
    public partial class AuthMethodData : AuthMethodDataBase { }

    public class AuthMethodDataBase 
    {
        [Parameter("uint256", "keyType", 1)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("bytes[]", "permittedIpfsCIDs", 2)]
        public virtual List<byte[]> PermittedIpfsCIDs { get; set; }
        [Parameter("uint256[][]", "permittedIpfsCIDScopes", 3)]
        public virtual List<List<BigInteger>> PermittedIpfsCIDScopes { get; set; }
        [Parameter("address[]", "permittedAddresses", 4)]
        public virtual List<string> PermittedAddresses { get; set; }
        [Parameter("uint256[][]", "permittedAddressScopes", 5)]
        public virtual List<List<BigInteger>> PermittedAddressScopes { get; set; }
        [Parameter("uint256[]", "permittedAuthMethodTypes", 6)]
        public virtual List<BigInteger> PermittedAuthMethodTypes { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodIds", 7)]
        public virtual List<byte[]> PermittedAuthMethodIds { get; set; }
        [Parameter("bytes[]", "permittedAuthMethodPubkeys", 8)]
        public virtual List<byte[]> PermittedAuthMethodPubkeys { get; set; }
        [Parameter("uint256[][]", "permittedAuthMethodScopes", 9)]
        public virtual List<List<BigInteger>> PermittedAuthMethodScopes { get; set; }
        [Parameter("bool", "addPkpEthAddressAsPermittedAddress", 10)]
        public virtual bool AddPkpEthAddressAsPermittedAddress { get; set; }
        [Parameter("bool", "sendPkpToItself", 11)]
        public virtual bool SendPkpToItself { get; set; }
    }
}
