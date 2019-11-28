using Blazor.Fluxor;

namespace ServerBlazor.Store.Counter
{
    public class IncrementCounterReducer : Reducer<CounterState, IncrementCounterAction>
    {
        public override CounterState Reduce(CounterState state, IncrementCounterAction action)
        {
            return new CounterState(state.CurrentCount + 1);
        }
    }
}