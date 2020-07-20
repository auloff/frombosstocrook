using System;
using UnityEngine;
using UnityEngine.UI;
using FromBossToCrook.Model;

namespace FromBossToCrook.View
{
    public class JobShopView : MonoBehaviour, IJobShopView<JobStats>
    {
        [SerializeField]
        private GameObject _jobViewPrefab;
        [SerializeField]
        private GridLayoutGroup _grid;
        [SerializeField]
        private Text _currentJobTitle;

        private void Start()
        {
            _currentJobTitle.text = string.Empty;
        }

        public void InitializeShopList(JobStats[] jobs, Action<JobStats> callback)
        {
            foreach (var job in jobs)
            {
                var j = Instantiate(_jobViewPrefab, _grid.transform);
                j.GetComponent<JobView>().InitItem(job, callback);
            }
        }

        public void ShowCurrenctJob(string job)
        {
            _currentJobTitle.text = job;
        }
    }
}