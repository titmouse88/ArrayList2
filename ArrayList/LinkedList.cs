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
       
        public LinkedList(int[] values)
        {
            //Lenght = values.Length;
            if (values.Length != 0)
            {
                _root = new Node(values[0]);
                _tail = _root;
                for (int i = 1; i < values.Length; i++)
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
            int length = 0;
            if (_root == null && _tail == null)
            {
                return length;
            }
            else
            {
                Node current = _root;
                length = 1;
                while (current.Next != null)
                {
                    current = current.Next;
                    length++;
                }
            }
            return length;
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
        public void AddLast(int val) //добавление в конец списка
        {

            if (_root == null && _tail == null)
            {
                _root = new Node(val);
                _tail = _root;
            }
            else
            {
                _tail.Next = new Node(val);
                _tail = _tail.Next;
            }

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
            for (int i = 1; i <= idx; i++)
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

            _root = _root.Next;

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
        

        public void RemoveAt(int idx) // удаление по индексу
        {
            int length = GetLength();
            if (idx >= length)
            {
                throw new IndexOutOfRangeException("Попробуйте другое число");
            }
            if (idx == 0)
            {
                RemoveFirst();
                return;
            }
            if (idx == length - 1)
            {
                RemoveLast();
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
            int length = GetLength();
            if (n > length || _root == null)
            {
                throw new Exception();
            }
            if (n == length)
            {
                _root = null;
                _tail = null;
                return;
            }
            Node current = _root;

            for (int i = 1; i < n; i++)
            {
                current = current.Next;
            }
            _root = current.Next;
        }

        public void RemoveLastMultiple(int n) //- удаление последних n элементов
        {
            int length = GetLength();
            if (n > length || _root == null)
            {
                throw new Exception();
            }
            if (n == length)
            {
                _root = null;
                _tail = null;
                return;
            }
            Node current = _root;
            for (int i = 1; i < length - n; i++)
            {
                current = current.Next;
            }
            _tail = current;
            current.Next = null;
        }
         //- удаление n элементов, начиная с указанного индекса
        public void RemoveAtMultiple(int idx, int n)
        {
            int length = GetLength();
            if (idx + n > length || _root == null)
            {
                throw new Exception();
            }
            if (length - n == idx)
            {
                RemoveLastMultiple(n);
                return;
            }
            if (idx == 0)
            {
                RemoveFirstMultiple(n);
                return;
            }
            Node current = _root;
            for (int i = 1; i < idx; i++)
            {
                current = current.Next;
            }
            for (int i = 1; i <= n; i++)
            {
                current.Next = current.Next.Next;
            }
        }

        public void RemoveFirst(int val) //- удалить первый попавшийся элемент, значение которого равно val(вернуть индекс удалённого элемента)
        {
            _root = _root.Next;
        }

        public int RemoveAll(int val) //удалить все элементы, равные val (вернуть кол-во удалённых элементов)
        {
            if (_root == null)
            {
                throw new Exception();
            }
            int sum = 0;
            Node current = _root;
            Node tmp = new Node(0);
            tmp.Next = current;

            while (current != null)
            {
                if (current.Value == val)
                {
                    if (current == _root)
                    {
                        RemoveFirst();
                        sum += 1;
                    }
                    else if (current == _tail)
                    {
                        RemoveLast();
                        sum += 1;
                    }
                    else
                    {
                        tmp.Next = current.Next;
                        sum += 1;
                    }
                }
                tmp = current;
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

        public int IndexOf(int val) //- вернёт индекс первого найденного элемента, равного val(или -1,
        //                            //если элементов с таким значением в списке нет)
        {
            int counter = 0;
            Node current = _root;
            while (current.Next != null)
            {
                if (current.Value == val)
                    return counter;
                if (current.Next == null)
                    return -1;
                current = current.Next;
                counter++;
            }
            return counter;
        }
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

        public int Get(int idx)// - вернёт значение элемента списка c указанным индексом
        {
            Node current = _root;
            int counter = 0;
            while (current.Next != null)
            {
                if (counter == idx)
                    break;
                if (current.Next == null)
                    throw new IndexOutOfRangeException("индекс больше количества элементов");
                counter++;
                current = current.Next;
            }
            return current.Value;
        }

        //Reverse() - изменение порядка элементов списка на обратный
        public void Reverse()
        {
            Node previous = null;
            Node current = _root;
            Node temp;
            while (current != null)
            {
                temp = current.Next;
                current.Next = previous;
                previous = current;
                current = temp;
            }
            _root = previous;
        }

        //Max() - поиск значения максимального элемента
        public int Max()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root.Next == null)
            {
                return _root.Value;
            }
            
            int max = _root.Value;
            Node current = _root;
            while (current.Next != null)
            {
                if (max < current.Value)
                    max = current.Value;
                current = current.Next;
            }
            return max;
        }
        public int Min()
        {

            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root.Next == null)
            {
                return _root.Value;
            }
            int min = _root.Value;
            Node current = _root;
            while (current.Next != null)
            {
                if (min > current.Value)
                    min = current.Value;
                current = current.Next;
            }
            return min;
        }

        //IndexOfMax() - поиск индекс максимального элемента
        public int IndexOfMax()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root.Next == null)
            {
                return 0;
            }
            if (_root == null)
                return -1;
            int max = _root.Value;
            int counter = 0;
            int idxOfMax = 0;
            Node current = _root;
            while (current.Next != null)
            {
                if (max < current.Value)
                {
                    max = current.Value;
                    idxOfMax = counter;
                }
                counter++;
                current = current.Next;
            }
            return idxOfMax;
        }
        //IndexOfMin() - поиск индекс минимального элемента
        public int IndexOfMin()
        {
            if (_root == null)
            {
                throw new IndexOutOfRangeException();
            }
            if (_root.Next == null)
            {
                return 0;
            }
            if (_root == null)
                return -1;
            int min = _root.Value;
            int counter = 0;
            int idxOfMin = 0;
            Node current = _root;
            while (current.Next != null)
            {
                if (min > current.Value)
                {
                    min = current.Value;
                    idxOfMin = counter;
                }
                counter++;
                current = current.Next;
            }
            return idxOfMin;
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
