using System;
using UnityEngine;
using UnityEngine.UI;
using FromBossToCrook.Model;

namespace FromBossToCrook.View
{
    public class ItemView : MonoBehaviour
    {
        public Button button;
        public Text title;
        public Text cost;
        public Text value;

        private ItemStats _itemStats;

        public void InitItem(ItemStats stats, Action<ItemStats> callback)
        {
            _itemStats = stats;
            title.text = stats.Title;
            cost.text = string.Concat("Cost: ", stats.Cost.ToString());
            value.text = string.Concat("Value: ", stats.Value.ToString());

            button.onClick.AddListener(() => callback?.Invoke(_itemStats));
        }
    }
}