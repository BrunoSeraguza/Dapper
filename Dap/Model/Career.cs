using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dap.Model
{
    public class Career
    {
    public Career()
    {
       Itens = new List<CareerItem>();
    }

        public Guid Id;
        public string Title;
        public IList<CareerItem> Itens;
    }
}