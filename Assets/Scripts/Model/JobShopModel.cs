using UnityEngine;

namespace FromBossToCrook.Model
{
    [CreateAssetMenu]
    public class JobShopModel : ScriptableObject, IInventory<JobStats>
    {
        [SerializeField]
        private JobStats[] _jobs = null;
        public JobStats[] Items => _jobs;
    }
}