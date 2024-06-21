using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Diwa.Todo.Client.Port.Driven;
using Diwa.Todo.Client.Protocol;
using Diwa.Todo.Common.DataModels;

namespace Diwa.Todo.HttpClient.Adapter.Services;

public class TodoItemService(IHttpClientFactory httpClientFactory) : IAccessTodoItemHttp
{
    private readonly System.Net.Http.HttpClient _httpClient = httpClientFactory.CreateClient("todo");
    
    public async Task<IEnumerable<Item>> Get()
    {
        var response = await _httpClient.GetAsync("api/items");

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<IEnumerable<Item>>() ?? [];
    }

    public async Task<Item?> Get(Guid id)
    {
        var response = await _httpClient.GetAsync($"api/item/{id}");

        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<Item>();
    }

    public async Task Post(CreateItemRequestDto dto)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("api/item", jsonContent);

        response.EnsureSuccessStatusCode();
    }

    public async Task Put(Guid id, UpdateItemRequestDto dto)
    {
        var jsonContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
        var response = await _httpClient.PutAsync($"api/item/{id}", jsonContent);

        response.EnsureSuccessStatusCode();
    }

    public async Task Delete(Guid id)
    {
        var response = await _httpClient.DeleteAsync($"api/item/{id}");

        response.EnsureSuccessStatusCode();
    }
}