using System.Linq;

namespace System.Collections.Generic
{
    [Serializable]
    public class ThreadSafeList<T>
    {
        protected List<T> TSList;

        protected object _lock = new object();

        public ThreadSafeList()
        {
            TSList = new List<T>();
        }

        public ThreadSafeList(ThreadSafeList<T> threadSafeList)
        {
            TSList = new List<T>(threadSafeList.TSList);
        }

        public ThreadSafeList(params T[] items)
        {
            TSList = new List<T>(items);
        }

        public T this[int index]
        {
            get
            {
                lock (_lock)
                {
                    return TSList[index];
                }
            }
            set
            {
                lock (_lock)
                {
                    TSList[index] = value;
                }
            }
        }

        public int Count
        {
            get
            {
                lock (_lock)
                {
                    return TSList.Count;
                }
            }
        }

        public bool IsReadOnly => false;

        public void Add(T value)
        {
            lock (_lock)
            {
                TSList.Add(value);
            }
        }

        public void AddIfNotPresent(T value)
        {
            lock (_lock)
            {
                if (!TSList.Contains(value))
                {
                    TSList.Add(value);
                }
            }
        }

        public void AddRange(List<T> values)
        {
            lock (_lock)
            {
                TSList.AddRange(values);
            }
        }

        public void AddRange(IEnumerable<T> values)
        {
            lock (_lock)
            {
                TSList.AddRange(values);
            }
        }

        public void AddRange(ThreadSafeList<T> values)
        {
            lock (_lock)
            {
                for (int i = 0; i < values.Count; i++)
                {
                    Add(values[i]);
                }
            }
        }

        public bool Any(Func<T, bool> value)
        {
            lock (_lock)
            {
                return TSList.Any(value);
            }
        }

        public void Clear()
        {
            lock (_lock)
            {
                TSList.Clear();
            }
        }

        public bool Contains(T value)
        {
            lock (_lock)
            {
                return TSList.Contains(value);
            }
        }

        public bool ContainsAll(params T[] values)
        {
            lock (_lock)
            {
                foreach (T value in values)
                {
                    if (!TSList.Contains(value))
                        return false;
                }

                return true;
            }
        }

        public bool ContainsAll(List<T> values)
        {
            lock (_lock)
            {
                foreach (T value in values)
                {
                    if (!TSList.Contains(value))
                        return false;
                }

                return true;
            }
        }

        public bool ContainsAny(params T[] values)
        {
            lock (_lock)
            {
                foreach (T value in values)
                {
                    if (TSList.Contains(value))
                        return true;
                }

                return false;
            }
        }

        public bool ContainsOnly(params T[] values)
        {
            lock (_lock)
            {
                if (TSList.Count != values.Length)
                {
                    return false;
                }

                foreach (T value in values)
                {
                    if (!TSList.Contains(value))
                        return false;
                }

                return true;
            }
        }

        public bool ContainsOnly(List<T> values)
        {
            lock (_lock)
            {
                if (TSList.Count != values.Count)
                {
                    return false;
                }

                foreach (T value in values)
                {
                    if (!TSList.Contains(value))
                        return false;
                }

                return true;
            }
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            lock (_lock)
            {
                TSList.CopyTo(array, arrayIndex);
            }
        }

        public ThreadSafeList<T> Copy()
        {
            lock (_lock)
            {
                ThreadSafeList<T> newList = new ThreadSafeList<T>();
                newList.AddRange(TSList);
                return newList;
            }
        }

        public int CountSafe(Func<T, bool> value)
        {
            lock (_lock)
            {
                return TSList.Count(value);
            }
        }

        public T ElementAt(int index)
        {
            lock (_lock)
            {
                return TSList[index];
            }
        }

        public T First()
        {
            lock (_lock)
            {
                return TSList[0];
            }
        }

        public T First(Func<T, bool> value)
        {
            lock (_lock)
            {
                return TSList.Where(value).First();
            }
        }

        public T FirstOrDefault()
        {
            lock (_lock)
            {
                return TSList.FirstOrDefault();
            }
        }

        public T FirstOrDefault(Func<T, bool> value)
        {
            lock (_lock)
            {
                return TSList.Where(value).FirstOrDefault();
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            lock (_lock)
            {
                return TSList.GetEnumerator();
            }
        }

        public int IndexOf(T value)
        {
            lock (_lock)
            {
                return TSList.IndexOf(value);
            }
        }

        public void Insert(int index, T value)
        {
            lock (_lock)
            {
                TSList.Insert(index, value);
            }
        }

        public T Last()
        {
            lock (_lock)
            {
                return TSList[TSList.Count - 1];
            }
        }

        public T Last(Func<T, bool> value)
        {
            lock (_lock)
            {
                return TSList.Where(value).Last();
            }
        }

        public T LastOrDefault(Func<T, bool> value)
        {
            lock (_lock)
            {
                return TSList.Where(value).LastOrDefault();
            }
        }

        public T LastOrDefault()
        {
            lock (_lock)
            {
                return TSList.LastOrDefault();
            }
        }

        public ThreadSafeList<T> OrderBy<TResult>(Func<T, TResult> value)
        {
            lock (_lock)
            {
                return (ThreadSafeList<T>)TSList.OrderBy(value);
            }
        }

        public bool Remove(T value)
        {
            lock (_lock)
            {
                return TSList.Remove(value);
            }
        }

        public void RemoveAt(int index)
        {
            lock (_lock)
            {
                TSList.RemoveAt(index);
            }
        }

        public void RemoveRange(int index, int count)
        {
            lock (_lock)
            {
                TSList.RemoveRange(index, count);
            }
        }

        public IEnumerable<TResult> Select<TResult>(Func<T, TResult> value)
        {
            lock (_lock)
            {
                return TSList.Select(value);
            }
        }

        public void Sort()
        {
            lock (_lock)
            {
                TSList.Sort();
            }
        }

        public ThreadSafeList<T> ToList()
        {
            lock (_lock)
            {
                return (ThreadSafeList<T>)TSList.AsEnumerable();
            }
        }

        public IEnumerable<T> Where(Func<T, bool> value)
        {
            lock (_lock)
            {
                return TSList.Where(value);
            }
        }
    }
}
