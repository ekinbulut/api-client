# Generic Api Client with .NET 7.0

A simple class helps for making REST API calls from given url and resources.
It both works sync and async. Under the hood, class uses RestSharp library.

## Sample Usage

```c#
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
```

```c#
// Make sync call
_sut = new Requester("https://www.anapioficeandfire.com");
List<Data> data = _sut.MakeRequest<List<Data>>(Method.Get,"/api/characters");

// Make aysnc call
_sut = new Requester("https://www.anapioficeandfire.com");
List<Data> data = await _sut.MakeRequestAsync<List<Data>>(Method.Get, "/api/characters");
```

## Contribution

* Fork the project from master branch.
* Create a new branch with a name: [TASK NAME] - {Description}
* Push branch to forked project.
* Create a pull request for master branch 