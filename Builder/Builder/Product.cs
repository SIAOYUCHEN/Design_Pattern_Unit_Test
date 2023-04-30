using System;
using System.Collections.Generic;

namespace Builder
{
    public class Product
    {
        List<string> parts = new List<string>();
        public void Add(string part)
        {
            parts.Add(part);
        }

        public string Show()
        {
            string result = "";
            foreach (var part in parts)
            {
                result += part;
            }
            
            return result;
        }
    }
}