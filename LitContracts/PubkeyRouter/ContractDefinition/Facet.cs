using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.PubkeyRouter.ContractDefinition
{
    public partial class Facet : FacetBase { }

    public class FacetBase 
    {
        [Parameter("address", "facetAddress", 1)]
        public virtual string FacetAddress { get; set; }
        [Parameter("bytes4[]", "functionSelectors", 2)]
        public virtual List<byte[]> FunctionSelectors { get; set; }
    }
}
