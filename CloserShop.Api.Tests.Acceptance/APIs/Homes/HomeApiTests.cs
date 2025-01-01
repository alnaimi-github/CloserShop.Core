using CloserShop.Api.Tests.Acceptance.Brokers;
using FluentAssertions;

namespace CloserShop.Api.Tests.Acceptance.APIs.Homes;

[Collection(nameof(ApiTestCollection))]
public class HomeApiTests
{
    private readonly CloserShopApiBroker _closerShopApiBroker;

    public HomeApiTests(CloserShopApiBroker closerShopApiBroker) =>
        _closerShopApiBroker = closerShopApiBroker;

    [Fact]
    public async Task ShouldReturnHomeMessageAsync()
    {
        // given
        var expectedMessage =
            "Hello, waisa. The princesse is in another castle.";

        // when
        var actualMessage =
            await _closerShopApiBroker.GetHomeMessageAsync();

        // then
        actualMessage.Should().BeEquivalentTo(expectedMessage);
    }
}