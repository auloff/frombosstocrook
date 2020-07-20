using FromBossToCrook.Tools.Calendar;
using FromBossToCrook.Model;
using FromBossToCrook.View;

namespace FromBossToCrook.Presenter
{
    public class PlayerPresenter
    {
        private IPlayerModel _model;
        private IPlayerView _view;

        private int _dayOfDebuff;
        private bool _isDead = false;

        public PlayerPresenter(IPlayerModel model, IPlayerView view)
        {
            _model = model;
            _view = view;

            _model.ModelChanged += () => _view.UpdateView(model);

            RandomDebuffDay();
            Subscribe();
            _view.UpdateView(model);
        }

        private void Subscribe()
        {
            SimpleGameCalendar.Instance.DayEnd += CalculateBuff;

            SimpleGameCalendar.Instance.MonthEnd += RandomDebuffDay;

            SimpleGameCalendar.Instance.YearEnd += IncreaseAge;

            _model.Death += () =>
            {
                _isDead = true;
                Unsubcribe();
                _view.DeathView();
            };
        }
        private void Unsubcribe()
        {
            SimpleGameCalendar.Instance.DayEnd -= CalculateBuff;

            SimpleGameCalendar.Instance.MonthEnd -= RandomDebuffDay;

            SimpleGameCalendar.Instance.YearEnd -= IncreaseAge;
        }

        private void CalculateBuff()
        {
            if (SimpleGameCalendar.Instance.CurrentDate.Day == _dayOfDebuff)
                Debuff();
        }

        private void IncreaseAge()
        {
            _model.IncreaseAge();
        }

        private void Debuff()
        {
            _model.Happiness -= _model.Age / 15;
            _model.Health -= _model.Age / 10;
        }

        private void RandomDebuffDay()
        {
            _dayOfDebuff = UnityEngine.Random.Range(SimpleGameCalendar.Instance.CurrentDate.Day, SimpleGameCalendar.Instance.DaysInCurrentMonth + 1);
        }

        public void GetMoney(float money)
        {
            if (_isDead) return;

            _model.Money += money;
        }

        public bool SpendMoney(float money)
        {
            if (_model.Money > money)
            {
                _model.Money -= money;
                return true;
            }
            return false;
        }

        public void GetBuff(ItemStats stats)
        {
            if (!SpendMoney(stats.Cost)) return;

            switch(stats.TargetField)
            {
                case TargetField.Happiness:
                    _model.Happiness += stats.Value;
                    break;
                case TargetField.Health:
                    _model.Health += stats.Value;
                    break;
            }
        }
    }
}