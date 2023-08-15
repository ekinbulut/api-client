using RestSharp;
using RestSharp.Authenticators;

namespace requester;

public class Requester
{
    private readonly RestClientOptions _options;
    
    public Requester(string url)
    {
        _options = new RestClientOptions(url);
    }

    public Requester(string url, string accessToken)
    {
        _options = new RestClientOptions(url)
        {
            Authenticator = new JwtAuthenticator(accessToken)
        };
    }
    
    public Requester(string url, string username, string password)
    {
        _options = new RestClientOptions(url)
        {
            Authenticator = new HttpBasicAuthenticator(username, password)
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