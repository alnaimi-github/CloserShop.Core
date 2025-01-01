namespace CloserShop.Api.Tests.Acceptance.Brokers;

public partial class CloserShopApiBroker
{
    private const string HomeRelativeUrl = "api/home";
    
    public async ValueTask<string> GetHomeMessageAsync() =>
        await _apiFactoryClient.GetContentStringAsync(HomeRelativeUrl);
}