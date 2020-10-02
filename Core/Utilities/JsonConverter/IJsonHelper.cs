using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.JsonConverter
{
    public interface IJsonHelper
    {
        string SerializeObject(object obj);
        object DeserializeObject(string s);
    }
}
