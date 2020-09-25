namespace Observer
{
    public interface IObserver<K>
    {
        void Update(K value);
    }
}