using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace LitContracts.Staking.ContractDefinition
{
    public partial class AddressMapping : AddressMappingBase { }

    public class AddressMappingBase 
    {
        [Parameter("address", "nodeAddress", 1)]
        public virtual string NodeAddress { get; set; }
        [Parameter("address", "stakerAddress", 2)]
        public virtual string StakerAddress { get; set; }
    }
}
