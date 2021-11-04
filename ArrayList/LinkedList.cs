using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class LinkedList
    {
        public int Lenght { get; set; }
        public int this[int index]
        {
            get
            {
                Node current=_root;
                //TODO ошибки
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                return current.Value;
            }
            set 
            {
                Node current = _root;
                //TODO ошибки
                for (int i = 1; i <= index; i++)
                {
                    current = current.Next;
                }
                current.Value= value;
            }
        }
        private Node _root;
        private Node _tail;
        public LinkedList()
        {
            Lenght = 0;
            _root = null;
            _tail = null;
        }
        public LinkedList(int value)
        {
            Lenght = 1;
            _root = new Node(value);
            _tail = _root;
        }
        public LinkedList(int [] values)
        {
            Lenght = values.Length;
            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;
                for (int i = 0; i < values.Length; i++)
                {
                    _tail.Next = new Node(values[i]);
                    _tail = _tail.Next;
                }
            }
            else
            {
                _root = null;
                _tail = null;
            }

        }
            public void AddLast(int value)
            {
                Lenght++;
                _tail.Next = new Node(value);
                _tail = _tail.Next;

            }
    }
}
