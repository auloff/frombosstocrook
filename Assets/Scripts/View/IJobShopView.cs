using System;

namespace FromBossToCrook.View
{
    public interface IJobShopView<T>
    {
        void InitializeShopList(T[] jobs, Action<T> callback);
        void ShowCurrenctJob(string job);
    }
}