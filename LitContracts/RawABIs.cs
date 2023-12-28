using System.Reflection;
using Nethereum.ABI.Model;
using Nethereum.Contracts;
using Nethereum.Model;
namespace LitContracts;

public static class RawABI {


    public static ContractBuilder get_staking_contract_abi(string address) {

        string abi_resource_name = "LitContracts.ABIs.Staking.abi";
        Assembly assembly =  Assembly.GetExecutingAssembly();
        // Console.WriteLine(assembly.GetManifestResourceNames().Length);
        // Console.WriteLine(assembly.GetManifestResourceNames()[0] == abi_resource_name);

        Stream stream = assembly.GetManifestResourceStream(abi_resource_name);
        
        StreamReader reader = new StreamReader(stream);
        string abi_data = reader.ReadToEnd();
        ContractBuilder contractBuilder = new ContractBuilder(abi_data,address);

        
        // Console.WriteLine("Function: "  + contractBuilder.GetFunctionBuilderBySignature("0x16930f4d").FunctionABI.Name );

        // Nethereum.ABI.Model.FunctionABI function = contractBuilder.GetFunctionAbiBySignature("0x16930f4d");
        
        // List<Nethereum.ABI.FunctionEncoding.ParameterOutput> data =  function.DecodeInputDataToDefault("0x16930f4d0000000000000");        
        // foreach (var item in data)
        // {
        //     Console.WriteLine(item.Parameter.Name + " " + item.Result);
        // }
        
        return contractBuilder;
    }    
}

