namespace FromBossToCrook.Model
{
    public interface IInventory<T>
    {
        T[] Items { get; }
    }
}