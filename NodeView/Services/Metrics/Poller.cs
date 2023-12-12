using System.Net;
using Blazored.LocalStorage;
using  Services.Metrics.Models;
using SharedService;
namespace Services.Metrics;

public class Poller {
    private ILocalStorageService localStorage { get; }
    public const int DefaultTimeSpan = 500;
    public LitContracts.Staking.ContractDefinition.Validator[]? nodes;
    PeriodicTimer periodicTimer = new (TimeSpan.FromMilliseconds(DefaultTimeSpan));
    public NetworkHistory? history;

    public Poller(ILocalStorageService localStorageService) {
        localStorage = localStorageService;
    }

    public async Task StartAsync() {
        await LoadNodes();
        RunTimer();
    }

    public async Task RestartAsync() {
        periodicTimer.Dispose();
        periodicTimer = new PeriodicTimer(TimeSpan.FromMilliseconds(DefaultTimeSpan));
        await LoadNodes();
        RunTimer();
    }
    
    async Task<bool> LoadNodes() {
        try
        {        
            var resolver = new Resolver(localStorage);
            var stakingService = await resolver.GetStakingService();            
            var validators = await stakingService.GetValidatorsStructsInCurrentEpochQueryAsync();   
            nodes = validators.ReturnValue1.Select(x => new LitContracts.Staking.ContractDefinition.Validator
                {
                    Ip = x.Ip,
                    Ipv6 = x.Ipv6,
                    NodeAddress = x.NodeAddress,
                    Port = x.Port,
                }).ToArray();

            if ( history == null )
                history = new NetworkHistory(5, nodes.Length);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return false;
        }
        return true;
    }

    async void RunTimer()
    {
        List<NodeMetricRoot> new_metrics = new List<NodeMetricRoot>();
        List<String> raw_metrics = new List<String>();
        HttpClient client = new HttpClient();
        client.Timeout = TimeSpan.FromMilliseconds(1000);
        

        while (await periodicTimer.WaitForNextTickAsync()) { 
            if (history == null) {
                continue;
            };

            new_metrics.Clear();
            raw_metrics.Clear();
            if(nodes != null) {
                var combined_output = new System.Text.StringBuilder();
                List<Task> handles = new List<Task>();
                foreach ( var node in nodes ) {
                    var handle = Task.Run(async () => {
                        try {
                            var response = await client.GetAsync("http://127.0.0.1:" + node.Port.ToString() +  "/web/rt/metrics");
                            if (response.StatusCode == System.Net.HttpStatusCode.OK) {
                                var result = await response.Content.ReadAsStringAsync();
                                raw_metrics.Add(result);
                                var metric = System.Text.Json.JsonSerializer.Deserialize<NodeMetricRoot>(result);                            
                                if (metric != null )                                
                                    new_metrics.Add(metric);
                            }
                        } catch (Exception e) {
                            Console.WriteLine("Error gathering data: " + e.Message);
                        }
                    });

                    handles.Add(handle);

                }

                await Task.WhenAll(handles);
                history.add(new_metrics, raw_metrics);

                // Console.WriteLine(history.get_lastest_metrics().Count); 

            }
        }    
    }


    public void Dispose()
    {
        periodicTimer?.Dispose();
    }
}