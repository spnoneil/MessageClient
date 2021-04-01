using System.Threading.Tasks;
using RestSharp;
using System;

namespace MessageClient.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups/all", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Get(string id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newGroup)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newGroup);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(string groupName, string jsonBody)
    {
      Console.WriteLine ("Groupname = " + groupName + "jsonBody" + jsonBody);
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups/{groupName}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(jsonBody);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5000/api");
      RestRequest request = new RestRequest($"groups/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}