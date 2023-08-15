using RestSharp;
using RestSharp.Authenticators;

namespace requester;

public class Requester
{
    private readonly string _url;
    private readonly string _accessToken;
    private readonly string _username, _password;

    private readonly RestClientOptions _options;
    
    public Requester(string url)
    {
        _url = url;
        _options = new RestClientOptions(_url);
    }

    public Requester(string url, string accessToken)
    {
        _url = url;
        _accessToken = accessToken;
        _options = new RestClientOptions(_url)
        {
            Authenticator = new JwtAuthenticator(_accessToken)
        };
    }
    
    public Requester(string url, string username, string password)
    {
        _url = url;
        _username = username;
        _password = password;
        _options = new RestClientOptions(_url)
        {
            Authenticator = new HttpBasicAuthenticator(_username, _password)
        };

    }
    
    public T? MakeRequest<T>(Method httpMethod, string? resource) where T: new()
    {
        var client = new RestClient(_options);
        var request = new RestRequest(resource, httpMethod);
        var result = client.Execute<T>(request);
        return result.Data;
    }


    public async Task<T?> MakeRequestAsync<T>(Method httpMethod, string? resource, CancellationToken cancellationToken = default) where T : new()
    {
        var client = new RestClient(_options);
        var request = new RestRequest(resource, httpMethod);
        var response = await client.ExecuteAsync<T>(request, cancellationToken);
        var result = response.Data;
        return result;
    }
}