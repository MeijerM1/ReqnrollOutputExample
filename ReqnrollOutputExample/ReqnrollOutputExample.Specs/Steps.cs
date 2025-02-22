using System.Net;
using FluentAssertions;
using Reqnroll;

namespace ReqnrollOutputExample.Specs;

[Binding]
public class Steps(ApiWebApplicationFactory<Program> factory, IReqnrollOutputHelper outputHelper)
{
    private HttpResponseMessage? _responseMessage;
    
    [When(@"I request the weather forecast")]
    public async Task WhenIRequestTheWeatherForecast()
    {
        outputHelper.WriteLine("Ceating client");
        var client = factory.CreateClient();
        outputHelper.WriteLine("Making request");
        _responseMessage = await client.GetAsync("WeatherForecast");
    }

    [Then(@"the response should be OK")]
    public void ThenTheResponseShouldBeOk()
    {
        _responseMessage?.StatusCode.Should().Be(HttpStatusCode.OK);
    }
}
