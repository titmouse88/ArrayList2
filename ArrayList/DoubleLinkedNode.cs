using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class DoubleLinkedNode
    {
        public int Value { get; set; }
        public DoubleLinkedNode Next { get; set; }
        public DoubleLinkedNode Previous { get; set; }
        public DoubleLinkedNode(int value)
        {
            Value = value;
            Next = null;
            Previous = null;
        }
    }
}
