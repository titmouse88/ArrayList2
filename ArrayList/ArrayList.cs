using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArrayList
{
    public class ArrayList
    {

        private int[] _array;
        private int _currentLength;
        private const int _minLength = 10;
        public ArrayList()
        {
            _array = new int[10];
            _currentLength = 0;
        }

        public ArrayList(int value)
        {
            _array = new int[10];
            _currentLength = 1;
            _array[0] = value;
        }

        public ArrayList(int[] array)
        {
            _array = new int[10];
            _currentLength = 0;
            MakeBiggerMyArray();
            for (int i = 0; i < array.Length; i++)
            {
                _array[i] = array[i];
            }
            _currentLength += array.Length;
        }

        private void MakeBiggerMyArray()
        {
            int needLenght = _currentLength;
            if (needLenght <= _array.Length)
            {
                return;
            }

            int tmp = _array.Length;

            while (tmp < needLenght)
            {
                tmp = 3 * tmp / 2;

            }
            int[] newArray = new int[tmp];
            for (int i = 0; i < _currentLength; i++)
            {
                newArray[i] = _array[i];
            }

            _array = newArray;
        }

        public void MakeShorterArray()
        {
            int targetLength = _array.Length;

            while (targetLength > _minLength && targetLength > _currentLength)
            {
                if (targetLength * 2 % 3 == 0)
                {
                    targetLength = targetLength * 2 / 3;
                }
                else
                {
                    targetLength = targetLength * 2 / 3 + 1;
                }

            }
            if (targetLength < _currentLength)
            {
                targetLength = targetLength * 3 / 2;
            }
            if (targetLength == _array.Length)
            {
                return;
            }
            int[] newArray = new int[targetLength];
            for (int i = 0; i < _currentLength; i++)
            {
                newArray[i] = _array[i];
            }
            _array = newArray;
        }

        public int GetLength()
        {
            return _currentLength;
        }

        public int[] ToArray()
        {
            int[] newArr = new int[_currentLength];
            for (int i = 0; i < _currentLength; i++)
            {
                newArr[i] = _array[i];
            }
            return newArr;
        }

        public void AddFirst(int value) //добавление в начало списка
        {

            _currentLength++;
            if (_currentLength == _array.Length)
            {
                MakeBiggerMyArray();
            }
            for (int i = _currentLength - 1; i > 0; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[0] = value;

        }




        // TODOто же самое, но слияние двух списков, с самодел классом
        public void AddFirst(ArrayList list)
        {
            _currentLength = list._currentLength + _currentLength;


            MakeBiggerMyArray();


            for (int i = 0; i < _currentLength; i++)
            {
                _array[i + list._currentLength] = _array[i];
            }
            for (int i = 0; i < list._currentLength; i++)
            {
                _array[i] = list._array[i];
            }


        }

        public void AddLast(int value) //добавление в конец списка
        {
            int oldLenght = _currentLength;
            _currentLength++;

            _array[oldLenght] = value;

        }
        // TODOто же самое, но слияние двух списков, с самодел классом
        public void AddLast(ArrayList list)
        {
            _currentLength = list._currentLength + _currentLength;
            MakeBiggerMyArray();
            for (int i = _currentLength - list._currentLength; i < _currentLength; i++)
            {
                _array[i] = list._array[i - (_currentLength - list._currentLength)];
            }



        }
        public void AddAt(int idx, int value) // вставка по указанному индексу
        {
            if (idx < 0 || idx > _currentLength)
            {
                throw new IndexOutOfRangeException();
            }
            int oldLenght = _currentLength;
            _currentLength++;
            if (_currentLength == _array.Length)
            {
                MakeBiggerMyArray();
            }
            for (int i = _currentLength - 1; i >= idx; i--)
            {
                _array[i] = _array[i - 1];
            }
            _array[idx] = value;

        }


        // TODOто же самое, но слияние двух списков, с самодел классом
        public void AddAt(int idx, ArrayList list)
        {

            if (idx >= _currentLength)
            {
                throw new IndexOutOfRangeException("Такого индекса нет");
            }

            _currentLength = list._currentLength + _currentLength;
            if (_currentLength == _array.Length)
            {
                MakeBiggerMyArray();
            }

            for (int i = idx; i < _currentLength - list._currentLength; i++)
            {
                _array[list._currentLength + i] = _array[i];
            }
            for (int i = idx; i < list._currentLength + idx; i++)
            {
                _array[i] = list._array[i - idx];
            }

        }



        public void Set(int idx, int value) //поменять значение элемента по указанному индексу
        {
            if (idx < 0 || idx > _currentLength)
            {
                throw new IndexOutOfRangeException();
            }
            _array[idx] = value;
        }

        public void RemoveFirst() //удаление первого элемента
        {
            for (int i = 0; i < _currentLength; i++)
            {
                _array[i] = _array[i + 1];
            }
            _currentLength--;
        }
        public void RemoveLast() //удаление последнего
        {
            _currentLength--;
        }

        public void RemoveAt(int idx) //удаление по индексу
        {

            if (idx < 0 || idx > _currentLength)
            {
                throw new IndexOutOfRangeException();
            }
            for (int i = idx; i < _currentLength; i++)
            {
                _array[i] = _array[i + 1];
            }
            _currentLength--;
        }

        public void RemoveFirstMultiple(int n) // - удаление первых n элементов
        {
            if (n > _currentLength)
            {
                throw new Exception("Число больше, чем длина нашего массива");
            }

            for (int i = n; i < _currentLength; i++)
            {
                _array[i - n] = _array[i];
            }
            _currentLength -= n;
        }

        public void RemoveLastMultiple(int n) //- удаление последних n элементов
        {
            if (n > _currentLength)
            {
                throw new Exception("Число больше, чем длина нашего массива");
            }

            _currentLength -= n;
        }

        public void RemoveAtMultiple(int idx, int n) //- удаление n элементов, начиная с указанного индекса
        {
            if (idx < 0 || idx >= _currentLength)
            {
                throw new IndexOutOfRangeException();
            }
            if (n < 0)
            {
                throw new ArgumentException("Элементов должно быть больше 0");
            }
            if (n == 0)
            {
                return;
            }
            if (n + idx > _currentLength)
            {
                throw new IndexOutOfRangeException();
            }

            for (int i = _currentLength - 1; i >= idx + n; i--)
            {
                _array[i - n] = _array[i];
            }
            _currentLength -= n;
            MakeShorterArray();

        }




        public int RemoveFirst(int val) // удалить первый попавшийся элемент(равный валью) и вернуть индекс
        {
            int index = -1;
            for (int i = 0; i < _currentLength; i++)
            {
                if (_array[i] == val)
                {
                    RemoveAt(i);
                    index = i;
                    return index;

                }

            }
            _currentLength--;
            MakeShorterArray();
            return index;


        }

        public int RemoveAll(int value)
        {
            int counter = 0;
            for (int i = 0; i < _currentLength; i++)
            {
                if (_array[i] == value)
                {
                    RemoveAt(i);
                    counter++;
                }

            }
            _currentLength--;
            MakeShorterArray();
            return counter;

        }
        public bool Contains(int value)
        {
            for (int i = 0; i < _currentLength; i++)
            {
                if (_array[i] == value)
                {
                    return true;
                }
            }
            return false;
        }

        public int IndexOf(int value)
        {
            int index = -1;
            for (int i = 0; i < _currentLength; i++)
            {
                if (_array[i] == value)
                {
                    index = i;
                    return index;

                }

            }


            return index;
        }

        public int GetFirst()
        {
            return _array[0];
        }

        public int GetLast()
        {
            return _array[_currentLength - 1];
        }

        public int Get(int index)
        {
            if (index >= _currentLength - 1)
            {
                throw new IndexOutOfRangeException("Нет такого индекса");
            }
            return _array[index];
        }

        public void Reverse()
        {
            for (int i = 0; i < _currentLength / 2; i++)
            {
                int tmp = _array[i];
                _array[i] = _array[_currentLength - 1 - i];
                _array[_currentLength - 1 - i] = tmp;
            }
        }
        public int Max()
        {
            int max = _array[0];
            for (int index = 0; index < _currentLength; index++)
            {
                if (_array[index] > max)
                {
                    max = _array[index];
                }
            }
            return max;
        }

        public int Min()
        {
            int min = _array[0];
            for (int index = 0; index < _currentLength; index++)
            {
                if (_array[index] < min)
                {
                    min = _array[index];
                }
            }
            return min;
        }

        public int IndexOfMax()
        {
            int maxValue = _array[0];
            int index = 0;
            for (int i = 0; i < _currentLength; i++)
            {
                if (_array[i] > maxValue)
                {
                    maxValue = _array[i];
                    index = i;
                }
            }
            return index;
        }
        public int IndexOfMin()
        {
            int minValue = _array[0];
            int index = 0;
            for (int i = 0; i < _currentLength; i++)
            {
                if (_array[i] < minValue)
                {
                    minValue = _array[i];
                    index = i;
                }
            }
            return index;
        }

        public void Sort() // - сортировка по возрастанию пузырьком
        {
            int b, c;
            for (b = 0; b < _currentLength; b++)
            {
                for (int i = 0; i < _currentLength - 1; i++)
                {
                    if (_array[i] > _array[i + 1])
                    {
                        c = _array[i];
                        _array[i] = _array[i + 1];
                        _array[i + 1] = c;
                    }
                }
            }
        }

        public void SortDec() // - сортировка по убыванию Select
        {
            int min = _array[0];
            int temp = 0;
            int idx = 0;
            for (int i = 0; i < _currentLength - 1; i++)
            {
                idx = i;
                for (int j = i + 1; j < _currentLength; j++)
                {
                    if (_array[idx] < _array[j])
                    {

                        idx = j;
                    }

                }
                temp = _array[i];
                _array[i] = _array[idx];
                _array[idx] = temp;
            }
        }



    }
}
