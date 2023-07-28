using System.Collections;

namespace FibonacciIterator
{
    /// <summary>
    /// Represents an enumerator object to iterate over the Fibonacci sequence numbers.
    /// </summary>
    public sealed class FibonacciEnumerator : IEnumerator<int>
    {
        private readonly int count;
        private readonly int skipCount;
        private int current;
        private int previous;
        private int index;

        public FibonacciEnumerator(int count, int skipCount)
        {
            this.count = count;
            this.skipCount = skipCount;
            this.current = 0;
            this.previous = 1;
            this.index = 0;
        }

        public int Current
        {
            get
            {
                if (this.index == 0)
                {
                    throw new InvalidOperationException("Enumeration has not started. Call MoveNext().");
                }

                if (this.index > this.count)
                {
                    throw new InvalidOperationException("Enumeration has already ended.");
                }

                return this.current;
            }
        }

        object IEnumerator.Current
        {
            get { return this.Current; }
        }

        public bool MoveNext()
        {
            if (this.index >= this.count)
            {
                return false;
            }

            if (this.index < this.skipCount)
            {
                this.current += this.previous;
                this.previous = this.current - this.previous;
                this.index++;
                return this.MoveNext();
            }

            if (this.index == this.skipCount)
            {
                this.index++;
                return true;
            }

            if (this.current > int.MaxValue - this.previous)
            {
#pragma warning disable CS1717
#pragma warning disable SA1101
                this.current = current;
#pragma warning restore SA1101
#pragma warning restore CS1717
            }
            else
            {
                this.current += this.previous;
            }

            this.previous = this.current - this.previous;
            this.index++;
            return true;
        }

        public void Reset()
        {
            this.current = 0;
            this.previous = 1;
            this.index = 0;
        }

#pragma warning disable S1186
        public void Dispose()
#pragma warning restore S1186
        {
        }
    }
}
