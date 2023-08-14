namespace requester;

public class Requester
{
    private string _url;
    private string _authKey;
    private string _username, _password;
    
    public Requester(string url)
    {
        _url = url;
    }

    public Requester(string url, string withAuthKey)
    {
        _url = url;
        _authKey = withAuthKey;
    }
    
    public Requester(string url, string username, string password)
    {
        _url = url;
        _username = username;
        _password = password;
    }
    
    public T MakeRequest<T>(HttpMethod httpMethod) where T: new()
    {
        var result = new T();
        
        return result;
    }


    public async Task<T> MakeRequestAsync<T>() where T : new()
    {
        var result = new T();
        
        return result;
    }
}