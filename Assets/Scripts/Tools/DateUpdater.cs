using FromBossToCrook.Tools.Calendar;
using UnityEngine;
using UnityEngine.UI;

namespace FromBossToCrook.Tools
{
    public class DateUpdater : MonoBehaviour
    {
        [SerializeField]
        private Text _dateText = null;

        void Start()
        {
            UpdateDate();
            SimpleGameCalendar.Instance.DayEnd += () => UpdateDate();
        }

        public void UpdateDate()
        {
            _dateText.text = SimpleGameCalendar.Instance.CurrentDate.ToString("dd.MM.yyyy");
        }
    }
}