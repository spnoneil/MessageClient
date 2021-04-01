using System.Collections.Generic;
using System;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel;
namespace MessageClient.Models
{
  public class BMessage
  {
    public int MessageId { get; private set; }
    public string Message { get; set; }
    public DateTime Posted { get; set; }
    public int GroupId { get; set; }

  }

}