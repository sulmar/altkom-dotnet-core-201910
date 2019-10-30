using System;
using System.Collections.Generic;
using System.Text;

namespace Altkom.DotnetCore.Models
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Color { get; set; }
    }
}
