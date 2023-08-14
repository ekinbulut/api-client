using requester;
using RestSharp;

namespace requester_test_xunit;

// API's to try for free: https://documenter.getpostman.com/view/8854915/Szf7znEe#intro

public class RequesterUnitTests
{
    private Requester? _sut;
    
    [Fact]
    public void Test_Make_A_Request()
    {
        _sut = new Requester("https://www.anapioficeandfire.com");
        var actual = _sut.MakeRequest<List<Data>>(Method.Get,"/api/characters");
        var expected = 10;

        Assert.NotNull(actual);
        if (actual != null) Assert.Equal(expected, actual.Count);
    }
    
    [Fact]
    public async Task Test_Make_A_Request_Async()
    {
        _sut = new Requester("https://www.anapioficeandfire.com");
        var actual = await _sut.MakeRequestAsync<List<Data>>(Method.Get, "/api/characters");

        Assert.NotNull(actual);
    }
}

public class Data
{
    public string url { get; set; }
    public string name { get; set; }
    public string gender { get; set; }
    public string culture { get; set; }
    public string born { get; set; }
    public string died { get; set; }
    public List<string> titles { get; set; }
    public List<string> aliases { get; set; }
    public string father { get; set; }
    public string mother { get; set; }
    public string spouse { get; set; }
    public List<string> allegiances { get; set; }
    public List<string> books { get; set; }
    public List<object> povBooks { get; set; }
    public List<string> tvSeries { get; set; }
    public List<string> playedBy { get; set; }
}