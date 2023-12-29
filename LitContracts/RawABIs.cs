using System.Reflection;
using Nethereum.Contracts;
namespace LitContracts;

public static class RawABI {
    public static ContractBuilder get_staking_contract_abi(string address) {

        string abi_resource_name = "LitContracts.ABIs.Staking.abi";
        Assembly assembly =  Assembly.GetExecutingAssembly();
        Stream stream = assembly.GetManifestResourceStream(abi_resource_name);        
        StreamReader reader = new StreamReader(stream);
        string abi_data = reader.ReadToEnd();
        ContractBuilder contractBuilder = new ContractBuilder(abi_data,address);
        return contractBuilder;
    }    
}

