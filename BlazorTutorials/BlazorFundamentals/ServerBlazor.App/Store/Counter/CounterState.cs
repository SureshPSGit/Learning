namespace ServerBlazor.Store.Counter
{
    public class CounterState
    {
        public int CurrentCount { get; }

        public CounterState(int currentCount)
        {
            CurrentCount = currentCount;
        }
    }
}