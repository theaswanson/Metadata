using Microsoft.WindowsAPICodePack.Shell.PropertySystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metadata
{
    public class MyKey
    {
        public PropertyKey Key { get; set; }
        public string Name { get; set; }

        public MyKey(PropertyKey newKey, string name)
        {
            Key = newKey;
            Name = name;
        }
    }
}
