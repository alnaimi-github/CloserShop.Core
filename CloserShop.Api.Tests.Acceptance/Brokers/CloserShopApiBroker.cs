using Microsoft.AspNetCore.Mvc.Testing;
using RESTFulSense.Clients;


namespace CloserShop.Api.Tests.Acceptance.Brokers;

public partial class CloserShopApiBroker
{
    private readonly WebApplicationFactory<ITestAssembly> _webApplicationFactory;
    private readonly HttpClient _httpClient;
    private readonly IRESTFulApiFactoryClient _apiFactoryClient;

    public CloserShopApiBroker()
    {
       _webApplicationFactory = new WebApplicationFactory<ITestAssembly>();
       _httpClient = _webApplicationFactory.CreateClient();
       _apiFactoryClient = new RESTFulApiFactoryClient(_httpClient);
    }
}