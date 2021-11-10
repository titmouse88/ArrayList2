using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class DoubleLinkedList2
    {
        private DoubleLinkedNode _root;
        private DoubleLinkedNode _tail;
        public DoubleLinkedList2()
        {

            _root = null;
            _tail = null;
        }
        public DoubleLinkedList2(int value)
        {

            _root = new DoubleLinkedNode(value);
            _tail = _root;
        }

        public DoubleLinkedList2(int[] value)
        {

            if (value.Length != 0)
            {
                _root = new DoubleLinkedNode(value[0]);
                DoubleLinkedNode current;
                _tail = _root;
                for (int i = 1; i < value.Length; i++)
                {
                    _tail.Next = new DoubleLinkedNode(value[i]);
                    current = _tail;
                    _tail = _tail.Next;
                    _tail.Previous = current;

                }
            }
            else
            {
                _root = null;
                _tail = _root;
            }

        }
        public int GetLength() //узнать кол-во элементов в списке
        {
            int lenght = 0;
            if (_root != null)
            {
                DoubleLinkedNode current = _root;
                lenght += 1;
                while (current.Next != null)
                {
                    lenght += 1;
                    current = current.Next;
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
            array[0] = _root.Value;

            DoubleLinkedNode current = _root;
            for (int i = 1; i < array.Length; i++)
            {
                current = current.Next;
                array[i] = current.Value;
            }
            return array;
        }
        public void AddFirst(int val) //добавление в начало списка
        {
            if (_root == null && _tail == null)
            {
                _root = new DoubleLinkedNode(val);
                _tail = _root;
                return;
            }
            DoubleLinkedNode tmp = new DoubleLinkedNode(val);
            tmp.Next = _root;
            _root.Previous = tmp;
            _root = tmp;
        }

        public void AddFirst(DoubleLinkedList2 list) //с самод классом
        {
            list._tail.Next = _root;
            _root.Previous = list._tail;
            _root = list._root;
        }

        public void AddLast(int val) //добавление в конец списка
        {
            int length = GetLength();
            if (length == 0)
            {
                AddFirst(val);
            }
            else
            {
                DoubleLinkedNode current = _tail;
                _tail.Next = new DoubleLinkedNode(val);
                _tail = _tail.Next;
                _tail.Previous = current;
            }

        }

        public void AddLast(DoubleLinkedList2 list) //с самод классом
        {
            _tail.Next = list._root;
            list._root.Previous = _tail;
            _tail = list._tail;
        }

        //AddAt(int idx, int val) - вставка по указанному индексу
        public void AddAt(int idx, int val)
        {
            int length = GetLength();
            if (idx >= length)
            {
                throw new IndexOutOfRangeException("Такого индекса нет");
            }
            DoubleLinkedNode current = _root;
            if (idx == 0)
            {
                current = _root;
            }
            for (int i = 1; i < idx; i++)
            {
                current = current.Next;
            }
            DoubleLinkedNode tmp = new DoubleLinkedNode(val);
            tmp.Next = current.Next;
            tmp.Previous = current;
            current.Next = tmp;
            current.Next.Previous = tmp;
        }
        public void AddAt(int idx, DoubleLinkedList2 list)
        {
            int length = GetLength();
            if (idx > length)
            {
                throw new IndexOutOfRangeException("Такого индекса нет");
            }
            DoubleLinkedNode current = _root;

            for (int i = 1; i < idx; i++)
            {
                current = current.Next;
            }
            list._tail.Next = current.Next;
            current.Next.Previous = list._tail;
            current.Next = list._root;
            list._root.Previous = current;
        }
        public void Set(int idx, int val) //поменять значение элемента с указанным индексом
        {
            int length = GetLength();
            if (idx >= length)
            {
                throw new IndexOutOfRangeException("Такого индекса нет");
            }
            DoubleLinkedNode current = _root;
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
            else
            {
                DoubleLinkedNode current = _tail.Previous;
                _tail.Previous.Next = null;
                _tail = current;
            }
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
            DoubleLinkedNode current = _root;

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
            DoubleLinkedNode current = _root;

            for (int i = 1; i < n; i++)
            {
                current = current.Next;
            }
            _root = current.Next;
        }
        //RemoveLastMultiple(int n) - удаление последних n элементов
        public void RemoveLastMultiple(int n)
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
            DoubleLinkedNode current = _root;
            for (int i = 1; i < length - n; i++)
            {
                current = current.Next;
            }
            _tail = current;
            current.Previous = _tail.Previous;
            current.Next = null;
        }

        //RemoveAtMultiple(int idx, int n) - удаление n элементов, начиная с указанного индекса
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
            DoubleLinkedNode current = _root;
            for (int i = 1; i < idx; i++)
            {
                current = current.Next;
            }
            for (int i = 1; i <= n; i++)
            {
                current.Next = current.Next.Next;
                current.Next.Previous = current;
            }

        }
        // RemoveFirst(int val) - удалить первый попавшийся элемент, значение которого равно val(вернуть индекс удалённого элемента)
        public int RemoveFirst(int val)
        {
            if (_root == null)
            {
                throw new Exception();
            }
            int index = -1;
            DoubleLinkedNode current = _root;
            if (_root.Value == val)
            {
                RemoveFirst();
                return index = 0;
            }
            else
            {
                int tmp = 0;
                while (current.Next != null)
                {
                    current = current.Next;
                    tmp += 1;
                    if (current.Value == val)
                    {
                        if (current == _tail)
                        {
                            RemoveLast();
                            index = tmp;
                            return index;
                        }
                        RemoveAt(tmp);
                        index = tmp;
                        return index;
                    }
                }
                return index;
            }
        }

        public int RemoveAll(int val) //удалить все элементы, равные val (вернуть кол-во удалённых элементов)
        {
            if (_root == null)
            {
                throw new Exception();
            }
            int sum = 0;
            DoubleLinkedNode current = _root;
            DoubleLinkedNode tmp = new DoubleLinkedNode(0);
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
            DoubleLinkedNode current = _root;
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
            if (_root == null)
            {
                return -1;
            }
            int counter = 0;
            DoubleLinkedNode current = _root;
            while (current != null)
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
            DoubleLinkedNode current = _root;
            return current.Value;
        }

        public int GetLast() //- вернёт значение последнего элемента списка
        {
            DoubleLinkedNode current = _tail;
            return current.Value;
        }

        public int Get(int idx)// - вернёт значение элемента списка c указанным индексом
        {
            if (idx < 0 || _root==null)
            {
                throw new IndexOutOfRangeException();
            }
            DoubleLinkedNode current = _root;
            int counter = 0;
            while (current != null)
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
            DoubleLinkedNode current = _root;
            DoubleLinkedNode node = current;
            while (current != null)
            {
                node = current.Previous;
                current.Previous = current.Next;
                current.Next = node;
                current = current.Previous;
            }

            DoubleLinkedNode tmp = _root;
            _root = _tail;
            _tail = tmp;

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
            DoubleLinkedNode current = _root;
            while (current != null)
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
            DoubleLinkedNode current = _root;
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

            int max = _root.Value;
            int counter = 0;
            int idxOfMax = 0;
            DoubleLinkedNode current = _root;
            while (current != null)
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
            DoubleLinkedNode current = _root;
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
            DoubleLinkedNode tempPrev, prev, tempCurrent, current, temp;

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
            DoubleLinkedNode tempPrev, prev, tempCurrent, current, temp;

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









