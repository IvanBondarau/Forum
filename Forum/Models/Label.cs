using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forum.Models
{
    public class Label
    {
        public int LabelId { get; set; }
        public string Name { get; set; }

        public Label(string Name)
        {
            this.Name = Name;
        }
    }
}
