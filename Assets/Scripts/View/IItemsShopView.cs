using System;

namespace FromBossToCrook.View
{
    public interface IItemsShopView<T>
    {
        void InitializeShopList(T[] items, Action<T> callback);
    }
}