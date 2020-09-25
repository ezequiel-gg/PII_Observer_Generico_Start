namespace Observer
{
    public interface IObservable<K>
    {
        void Subscribe(IObserver<K> observer);

        void Unsubscribe(IObserver<K> observer);
    }
}