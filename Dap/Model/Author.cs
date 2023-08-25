using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;

namespace Dap.Model
{
    public class Author
    {
    
        public Guid Id;
        public string Name { get; set; }
        public string Title { get; set; }

    }
}