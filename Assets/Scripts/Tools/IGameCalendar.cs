using System;

namespace FromBossToCrook.Tools.Calendar
{
    public interface IGameCalendar
    {
        DateTime CurrentDate { get; }
        int DaysInCurrentMonth { get; }

        event Action DayEnd;
        event Action MonthEnd;
        event Action YearEnd;
    }
}