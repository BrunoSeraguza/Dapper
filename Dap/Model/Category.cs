using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dap.Model
{
    public class Category
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string Url { get; set; }
        public int Order { get; set; }
        public string summary { get; set; }
        public string Description { get; set; }
        public bool Featured { get; set; }
    }
}