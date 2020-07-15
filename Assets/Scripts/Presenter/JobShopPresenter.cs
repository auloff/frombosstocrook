using FromBossToCrook.Model;
using FromBossToCrook.Tools.Calendar;
using FromBossToCrook.View;
using System;
using UnityEditor;
using UnityEngine;

namespace FromBossToCrook.Presenter
{
    public class JobShopPresenter : MonoBehaviour
    {
        public JobStats[] jobs;
        public GameObject jobViewPrefab;
        public Transform grid;

        public event Action<float> GetSalary;

        private JobStats _currentJob;
        private int monthInJob = 3;

        void Start()
        {
            SimpleGameCalendar.Instance.MonthEnd += Instance_MonthEnd;
            foreach (var job in jobs)
            {
                var j = GameObject.Instantiate(jobViewPrefab, grid);
                j.GetComponent<JobView>().InitItem(job, AcceptJob);
            }
        }

        private void Instance_MonthEnd()
        {
            if (_currentJob == null) return;

            monthInJob++;

            GetSalary?.Invoke(_currentJob.Salary);
        }

        private void AcceptJob(JobStats stats)
        {
            if (_currentJob != stats && monthInJob >= 3)
            {
                monthInJob = 0;
                _currentJob = stats;
            }
        }
    }
}