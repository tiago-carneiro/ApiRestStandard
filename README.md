# ApiRestStandard

```
var client = new ApiRest("http://www.mocky.io");
var response = await client.GetAsync<ResponseData>("/v2/5c9575723600006300941f57");
```

```
 [Preserve(AllMembers = true)]/*Sdk and User Assemblies*/
    public class ResponseData
    {
        [JsonProperty("key")]
        public string Key { get; set; }
    }
```

```
public async Task<TResponse> PostAsync<TResponse>(string requestUri, 
                                                  object body, 
                                                  Dictionary<string, string> headers = null)
{
    ...
}
```

```
public async Task<TResponse> PutAsync<TResponse>(string requestUri, 
                                                 object body, 
                                                 Dictionary<string, string> headers = null)
{
    ...
}
```

```
public async Task<TResponse> GetAsync<TResponse>(string requestUri, 
                                                 Dictionary<string, string> headers = null)
{
    ...
}
```
