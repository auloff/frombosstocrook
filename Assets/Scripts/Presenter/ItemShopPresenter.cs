using FromBossToCrook.Model;
using FromBossToCrook.View;
using System;
using UnityEngine;

namespace FromBossToCrook.Presenter
{
    public class ItemShopPresenter
    {
        private IInventory<ItemStats> _itemsShopModel;
        private IItemsShopView<ItemStats> _itemsShopView;

        public event Action<ItemStats> GetBuff;

        public ItemShopPresenter(IInventory<ItemStats> itemsShopModel, IItemsShopView<ItemStats> itemsShopView)
        {
            _itemsShopModel = itemsShopModel;
            _itemsShopView = itemsShopView;

            _itemsShopView.InitializeShopList(_itemsShopModel.Items, (stats) => GetBuff?.Invoke(stats));
        }
    }
}