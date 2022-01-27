using System;
using System.Collections.Generic;
using System.Text;

namespace Blazor_Heroes.Shared
{
    public class SuperHero
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Comic Comic { get; set; }
    }
}
