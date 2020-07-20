using System;
using FromBossToCrook.Tools.Calendar;
using FromBossToCrook.Model;
using FromBossToCrook.View;

namespace FromBossToCrook.Presenter
{
    public class JobShopPresenter
    {
        private IInventory<JobStats> _jobShopModel;
        private IJobShopView<JobStats> _jobShopView;
        
        public event Action<float> GetSalary;

        private JobStats _currentJob;
        private int monthInJob = 3;

        public JobShopPresenter(IInventory<JobStats> jobShopModel, IJobShopView<JobStats> jobShopView)
        {
            _jobShopModel = jobShopModel;
            _jobShopView = jobShopView;

            _jobShopView.InitializeShopList(_jobShopModel.Items, AcceptJob);

            SimpleGameCalendar.Instance.MonthEnd += Instance_MonthEnd;
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
                _jobShopView.ShowCurrenctJob(_currentJob.Title);
            }
        }
    }
}