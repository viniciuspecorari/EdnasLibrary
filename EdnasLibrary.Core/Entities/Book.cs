using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdnasLibrary.Core.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sinopse { get; set; }
        public string Author { get; set; }
        public int QuantityRegistered { get; set; }
        public int QuantityAvailable { get; set; }
        public string RegisteredBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
