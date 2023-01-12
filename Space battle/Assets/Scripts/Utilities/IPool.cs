namespace SpaceBattle
{
    public interface IPool<T>
    {
        T Get();

        void Destroy(T poolObject);
    }
}
