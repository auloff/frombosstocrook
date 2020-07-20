using FromBossToCrook.Model;
using System;
using UnityEngine;
using UnityEngine.UI;

namespace FromBossToCrook.View
{
    public class JobView : MonoBehaviour
    {
        public Button button;
        public Text title;
        public Text salary;

        private JobStats _jobStats;

        public void InitItem(JobStats stats, Action<JobStats> callback)
        {
            _jobStats = stats;
            title.text = stats.Title;
            salary.text = string.Concat("Salary: ", stats.Salary.ToString());

            button.onClick.AddListener(() => callback?.Invoke(_jobStats));
        }
    }
}