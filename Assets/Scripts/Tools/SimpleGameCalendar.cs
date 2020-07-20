using System;
using UnityEngine;
using System.Collections;
using FromBossToCrook.Tools.Generics;

namespace FromBossToCrook.Tools.Calendar
{
    public class SimpleGameCalendar : Singleton<SimpleGameCalendar>, IGameCalendar
    {
        [SerializeField]
        private float _calendarDayInRealSeconds = 1f;

        public int DaysInCurrentMonth { get => DateTime.DaysInMonth(CurrentDate.Year, CurrentDate.Month); }

        public event Action MonthEnd;
        public event Action YearEnd;
        public event Action DayEnd;

        public DateTime CurrentDate { get; private set; }

        private void Start()
        {
            CurrentDate = DateTime.Now.AddDays(-DateTime.Now.Day + 1);
            StartCount();
        }

        public void StartCount()
        {
            StartCoroutine(StartCalendar());
        }

        public void StopCount()
        {
            StopCoroutine(StartCalendar());
        }

        private IEnumerator StartCalendar()
        {
            while (true)
            {
                DateTime tempDate = CurrentDate.AddDays(1);

                if (tempDate.Year > CurrentDate.Year)
                    YearEnd?.Invoke();

                CurrentDate = tempDate;
                DayEnd?.Invoke();

                if (CurrentDate.Day == 1)
                    MonthEnd?.Invoke();

                yield return new WaitForSecondsRealtime(_calendarDayInRealSeconds);
            }
        }
    }
}