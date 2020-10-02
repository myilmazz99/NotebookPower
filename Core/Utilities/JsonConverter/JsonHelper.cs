using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.JsonConverter
{
    public class JsonHelper : IJsonHelper
    {
        public object DeserializeObject(string s)
        {
            return JsonConvert.DeserializeObject(s);
        }

        public string SerializeObject(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
