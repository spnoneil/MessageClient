using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
namespace MessageClient.Models
{
  public class Group
  {
    public Group(string groupName)
    {
      Name = groupName;
    }
    public int GroupId { get; private set; }
    [JsonProperty("GroupName")]
    public string Name { get; set; }
    public ICollection<BMessage> BMessages { get; set; }

    public static List<Group> GetGroups()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;
      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Group> groupList = JsonConvert.DeserializeObject<List<Group>>(jsonResponse.ToString());
      return groupList;
    }

    public static Group GetDetails(string id)
    {
      var apiCallTask = ApiHelper.Get(id);
      Group group = JsonConvert.DeserializeObject<Group>(apiCallTask.Result);
      // Console.WriteLine("apiCallTask =" + apiCallTask);
      // Console.WriteLine("Apicalltask.result" + apiCallTask.Result);
      // var result = apiCallTask.Result;
      // Console.WriteLine("result= " + result);
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(apiCallTask.Result);
      // Console.WriteLine("jsonResponse=" + jsonResponse);

      // int count = group.GetType().GetProperties().Count();

      JsonTextReader reader = new JsonTextReader(new StringReader(jsonResponse.ToString()));
      // while (reader.Read())
      // { 
      //     if (reader.Value != null)
      //     {
      //         Console.WriteLine("Token: {0}, Value: {1}", reader.TokenType, reader.Value);
      //     }
      //     else
      //     {
      //         Console.WriteLine("Token: {0}", reader.TokenType);
      //     }
      // }
      return group;
    }

    public static void Post(Group group)
    {
      string jsonGroup = JsonConvert.SerializeObject(group);
      // Can hover over a var and get data type and change later if desired
      System.Threading.Tasks.Task apiCallTask = ApiHelper.Post(jsonGroup);
      Console.WriteLine(apiCallTask.GetType());
    }

    public static void Put(string groupName, Group group)
    {
      Console.WriteLine("groupName = " + groupName);
      Console.WriteLine("Group.GroupName = " + group.Name);
      string jsonGroup = JsonConvert.SerializeObject(group);
      var apiCallTask = ApiHelper.Put(groupName, jsonGroup);
    }
    //     public static void Put(Animal animal)
    // {
    //   string jsonAnimal = JsonConvert.SerializeObject(animal);
    //   var apiCallTask = ApiHelper.Put(animal.AnimalId, jsonAnimal);
    // }
  }
}
