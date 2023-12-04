### LitSharp

This tool is runs entirely in the browser and requires only a the resolver contract address (or staker contract address) and access to the base chain in order to self configure.
To view node information, the nodes must support metrics collection. The other exploration functions will continue to work, however.
This tool was written in C# using Blazor technology and the Nethereum library - a web3 or ethers equivalent for C#.


The default settings are to use the local Anvil configuration, wtih a deterministic address for the resolver contract.

Configuration

Chain url:
https://localhost:8545
Resolver Contract Address:
0x5FbDB2315678afecb367f032d93F642f64180aa3
Private Key:  (The first key found in the Anvil/HardHat projects).
0xac0974bec39a17e36ba4a6b4d238ff944bacb478cbed5efcae784d7bf4f2ff80
