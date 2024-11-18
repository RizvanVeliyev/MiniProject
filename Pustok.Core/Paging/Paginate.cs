namespace Pustok.Core.Paging
{
    using System.Collections;
    using System.Collections.Generic;

    public class Paginate<T> : IPaginate<T>, IEnumerable<T>
    {
        public Paginate()
        {
            Items = new List<T>();
        }

        public int Index { get; set; }
        public int Size { get; set; }
        public int Count { get; set; }
        public int Pages { get; set; }
        public IList<T> Items { get; set; }
        public bool HasPrevious => Index > 0;
        public bool HasNext => Index + 1 < Pages;

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }


    public interface IPaginate<T>
    {

    }
}
