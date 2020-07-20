using FromBossToCrook.Model;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace FromBossToCrook.View
{
    public class ItemsShopView : MonoBehaviour, IItemsShopView<ItemStats>
    {
        [SerializeField]
        private GameObject _itemViewPrefab;
        [SerializeField]
        private GridLayoutGroup _grid;

        public void InitializeShopList(ItemStats[] items, Action<ItemStats> callback)
        {
            foreach (var item in items)
            {
                var j = Instantiate(_itemViewPrefab, _grid.transform);
                j.GetComponent<ItemView>().InitItem(item, callback);
            }
        }
    }
}