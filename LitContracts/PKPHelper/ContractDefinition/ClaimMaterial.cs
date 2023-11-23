using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.PKPHelper.ContractDefinition
{
    public partial class ClaimMaterial : ClaimMaterialBase { }

    public class ClaimMaterialBase 
    {
        [Parameter("uint256", "keyType", 1)]
        public virtual BigInteger KeyType { get; set; }
        [Parameter("bytes32", "derivedKeyId", 2)]
        public virtual byte[] DerivedKeyId { get; set; }
        [Parameter("tuple[]", "signatures", 3)]
        public virtual List<Signature> Signatures { get; set; }
    }
}
