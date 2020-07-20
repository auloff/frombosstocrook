using UnityEngine;

namespace FromBossToCrook.Model
{
    [CreateAssetMenu]
    public class ItemShopModel : ScriptableObject, IInventory<ItemStats>
    {
        [SerializeField]
        private ItemStats[] _items = null;
        public ItemStats[] Items => _items;
    }
}