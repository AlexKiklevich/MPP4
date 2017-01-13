using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mpp.RssReader
{
    public class Filters
    {
        public string Name { get; set; }
        public string method { get; set; }
        public List<string> items { get; set; }
        public Filters (string name, string Method)
        {
            Name = name;
            method = Method;
        }
    }
}
