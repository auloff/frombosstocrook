using FromBossToCrook.Model;
using FromBossToCrook.View;
using FromBossToCrook.Tools.Calendar;

namespace FromBossToCrook.Presenter
{
    public class PlayerPresenter
    {
        private IPlayerModel _model;
        private IPlayerView _view;

        private int _dayOfDebuff;

        public PlayerPresenter(IPlayerModel model, IPlayerView view)
        {
            _model = model;
            _view = view;
            RandomDebuffDay();
            Subscribe();
            UpdateView();
        }

        private void Subscribe()
        {
            SimpleGameCalendar.Instance.DayEnd += () =>
            {
                if (SimpleGameCalendar.Instance.CurrentDate.Day == _dayOfDebuff)
                    Debuff();
            };

            SimpleGameCalendar.Instance.MonthEnd += () => RandomDebuffDay();

            SimpleGameCalendar.Instance.YearEnd += () => { 
                _model.IncreaseAge();
                _view.UpdateAge(_model.Age);
            };

            _model.Death += () => _view.DeathView();
        }

        private void Debuff()
        {
            _model.Happiness -= _model.Age / 15;
            _model.Health -= _model.Age / 10;

            _view.UpdateHealth(_model.Health);
            _view.UpdateHappiness(_model.Happiness);
        }

        private void RandomDebuffDay()
        {
            _dayOfDebuff = UnityEngine.Random.Range(SimpleGameCalendar.Instance.CurrentDate.Day, SimpleGameCalendar.Instance.DaysInCurrentMonth + 1);
        }

        private void UpdateView()
        {
            _view.UpdateMoney(_model.Money);
            _view.UpdateHealth(_model.Health);
            _view.UpdateHappiness(_model.Happiness);
            _view.UpdateAge(_model.Age);
        }

        public void GetMoney(float money)
        {
            _model.Money += money;
            _view.UpdateMoney(_model.Money);
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

        public void ChangeHealth(float value)
        {
            _model.Health += value;
            if (_model.Health >= 100) _model.Health = 100;
            if (_model.Health <= 0) _model.Health = 100;

            _view.UpdateHealth(_model.Health);
        }

        public void ChangeHappiness(float value)
        {
            _model.Happiness += value;
            if (_model.Happiness >= 100) _model.Happiness = 100;
            if (_model.Happiness <= 0) _model.Happiness = 100;


            _view.UpdateHappiness(_model.Happiness);
        }
    }
}