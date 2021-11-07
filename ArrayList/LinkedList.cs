using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class LinkedList
    {
        public int Lenght { get; private set; }

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
        //public LinkedList(int[] arr)
        //{
        //    if (arr == null)
        //        return;
        //    for (int i = 0; i < arr.Length; i++)
        //    {
        //        AddLast(arr[i]);
        //    }
        //}
        public LinkedList(int[] values)
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

        public int GetLength() //узнать кол-во элементов в списке
        {
            int lenght = 0;
            if (_root == null && _tail == null)
            {
                return lenght;
            }
            else
            {
                Node current = _root;
                while (current.Next != null)
                {
                    current = current.Next;
                    lenght += 1;
                }
            }
            return lenght;
        }

        public int[] ToArray() //вернёт хранимые данные в виде массива
        {
            int length = GetLength();
            int[] array = new int[length];
            if (length == 0)
            {
                return array;
            }

            //array[0] = _root.Value;
            Node current = _root;
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = current.Value;
                current = current.Next;
            }
            return array;
        }

        public void AddFirst(int val) //добавление в начало списка
        {
            if (_root == null && _tail == null)
            {
                _root = new Node(val);
                _tail = _root;
                return;
            }
            Node tmp = new Node(val);
            tmp.Next = _root;
            _root = tmp;
        }
        public void AddFirst(LinkedList list) //то же самое, но с вашим самодельным классом (т.е. слияние двух списков)
        {
            list._tail.Next = _root;
            _root = list._root;
        }
        public void AddLast(int value) //добавление в конец списка
        {

            _tail.Next = new Node(value);
            _tail = _tail.Next;

        }

        public void AddLast(LinkedList list) //то же самое, но с вашим самодельным классом (т.е. слияние двух списков)
        {
            _tail.Next = list._root;
            _tail = list._tail;
        }

        public void AddAt(int idx, int val) //вставка по указанному индексу
        {
            int length = GetLength();
            if (idx > length)
            {
                throw new IndexOutOfRangeException("Такого индекса нет");
            }
            Node current = _root;
            if (idx == 0)
            {
                AddFirst(val);
            }
            for (int i = 1; i < idx; i++)
            {
                current = current.Next;
            }
            Node tmp = new Node(val);
            tmp.Next = current.Next;
            current.Next = tmp;
        }
        public void AddAt(int idx, LinkedList list) // то же самое, но с вашим самодельным классом
        {
            int length = GetLength();
            if (idx > length)
            {
                throw new IndexOutOfRangeException("Такого индекса нет");
            }
            Node current = _root;
            if (idx == 0)
            {
                AddFirst(list);
            }
            for (int i = 1; i < idx; i++)
            {
                current = current.Next;
            }

            list._tail.Next = current.Next;
            current.Next = list._root;
        }

        public void Set(int idx, int val) //поменять значение элемента с указанным индексом
        {
            int length = GetLength();
            if (idx >= length)
            {
                throw new IndexOutOfRangeException("Такого индекса нет");
            }
            Node current = _root;
            if (idx == 0)
            {
                AddFirst(val);
            }
            for (int i = 0; i <= idx; i++)//can be zero
            {
                current = current.Next;
            }
            current.Value = val;
           
        }

        public void RemoveFirst() //- удаление первого элемента
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root.Next == null)
            {
                _root = null;
                _tail = null;
                return;
            }

            _tail = _root.Next;

        }

        public void RemoveLast() //удаление последнего элемента
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root.Next == null)
            {
                _root = null;
                _tail = null;
                return;
            }
            Node current = _root;
            while (current.Next.Next != null)
            {
                current = current.Next;
            }
            _tail = current;
            current.Next = null;
        }
        //public int RemoveFirst(int val)
        //{
        //    int index = -1;
        //    Node current = _root;
        //    if (_root.Value == val)
        //    {
        //        RemoveFirst();
        //        return index = 0;
        //    }
        //    else
        //    {
        //        int tmp = 0;
        //        while (current.Next != null)
        //        {
        //            current = current.Next;
        //            tmp += 1;
        //            if (current.Value == val)
        //            {
        //                if (current == _tail)
        //                {
        //                    RemoveLast();
        //                    index = tmp;
        //                    return index;
        //                }
        //                RemoveAt(tmp);
        //                index = tmp;
        //                return index;
        //            }
        //        }
        //        return index;
        //}

        public void RemoveAt(int idx) // удаление по индексу
        {
            int length = GetLength();
            if (idx > length)
            {
                throw new IndexOutOfRangeException("Попробуйте другое число");
            }
            if (idx == 0)
            {
                RemoveFirst();
                return;
            }
            Node current = _root;

            for (int i = 1; i < idx; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
        }

        public void RemoveFirstMultiple(int n) //- удаление первых n элементов
        {

        }

        public void RemoveLastMultiple(int n) //- удаление последних n элементов
        {

        }
        public void RemoveAtMultiple(int idx, int n) //- удаление n элементов, начиная с указанного индекса
        {

        }

        public void RemoveFirst(int val) //- удалить первый попавшийся элемент, значение которого равно val(вернуть индекс удалённого элемента)
        {

        }

        public int RemoveAll(int val) //удалить все элементы, равные val (вернуть кол-во удалённых элементов)
        {
            int sum = 0;
            Node current = _root;
            while (current.Next != null)
            {
                if (current.Value == val)
                {
                    sum += 1;
                }
                current = current.Next;
            }
            while (current.Next != null)
            {
                if (current.Value == val)
                {

                }
                current = current.Next;
            }

            return sum;
        }
        public bool Contains(int val) //- проверка, есть ли элемент в списке
        {
            Node current = _root;
            while (current.Next != null)
            {
                if (current.Value == val)
                {
                    return true; ;
                }
                current = current.Next;
            }
            return false;

        }

        //public int IndexOf(int val) //- вернёт индекс первого найденного элемента, равного val(или -1,
        //                            //если элементов с таким значением в списке нет)
        //{

        //}
        public int GetFirst() //вернёт значение первого элемента списка
        {
            Node current = _root;
            return current.Value;
        }
        public int GetLast() //- вернёт значение последнего элемента списка
        {
            Node current = _tail;
            return current.Value;
        }

        //Sort() - сортировка по возрастанию

       
        public void Sort()
        {
            if (_root == null)
                return;
            Node tempPrev, prev, tempCurrent, current, temp;
            
            tempPrev = prev = _root;
            while (prev.Next != null)
            {
                tempCurrent = current = prev.Next;
                while (current != null)
                {
                    if (prev.Value > current.Value)
                    {
                        if (prev.Next == current)
                        {
                            if (prev == _root)
                            {
                                prev.Next = current.Next;
                                current.Next = prev;
                                //swap:
                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                _root = prev;

                                current = current.Next;
                            }

                            else
                            {
                                prev.Next = current.Next;
                                current.Next = prev;
                                tempPrev.Next = current;
                                // Swap
                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;
                            }
                        }
                        else
                        {
                            if (prev == _root)
                            {
                                temp = prev.Next;
                                prev.Next = current.Next;
                                current.Next = temp;
                                tempCurrent.Next = prev;

                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;

                                _root = prev;
                            }

                            // prev != _head
                            else
                            {
                                temp = prev.Next;
                                prev.Next = current.Next;
                                current.Next = temp;
                                tempCurrent.Next = prev;
                                tempPrev.Next = current;

                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;
                            }
                        }
                    }
                    else
                    {
                        tempCurrent = current;
                        current = current.Next;
                    }
                }
                tempPrev = prev;
                prev = prev.Next;
            }
            _tail = _root;
            while (_tail.Next != null)
                _tail = _tail.Next;
        }

        //SortDesc() - сортировка по убыванию
        public void SortDesc()
        {
            if (_root == null)
                return;
            Node tempPrev, prev, tempCurrent, current, temp;

            tempPrev = prev = _root;
            while (prev.Next != null)
            {
                tempCurrent = current = prev.Next;
                while (current != null)
                {
                    if (prev.Value < current.Value)
                    {
                        if (prev.Next == current)
                        {
                            if (prev == _root)
                            {
                                prev.Next = current.Next;
                                current.Next = prev;
                                //swap:
                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                _root = prev;

                                current = current.Next;
                            }

                            else
                            {
                                prev.Next = current.Next;
                                current.Next = prev;
                                tempPrev.Next = current;
                                // Swap
                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;
                            }
                        }
                        else
                        {
                            if (prev == _root)
                            {
                                temp = prev.Next;
                                prev.Next = current.Next;
                                current.Next = temp;
                                tempCurrent.Next = prev;

                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;

                                _root = prev;
                            }

                            // prev != _head
                            else
                            {
                                temp = prev.Next;
                                prev.Next = current.Next;
                                current.Next = temp;
                                tempCurrent.Next = prev;
                                tempPrev.Next = current;

                                temp = prev;
                                prev = current;
                                current = temp;

                                tempCurrent = current;

                                current = current.Next;
                            }
                        }
                    }
                    else
                    {
                        tempCurrent = current;
                        current = current.Next;
                    }
                }
                tempPrev = prev;
                prev = prev.Next;
            }
            _tail = _root;
            while (_tail.Next != null)
                _tail = _tail.Next;
        }

    }



}
