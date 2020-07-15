using UnityEngine;
using UnityEngine.UI;

namespace FromBossToCrook.View
{
    public class SimplePlayerView : MonoBehaviour, IPlayerView
    {
        [SerializeField]
        private Text _healthText = null;

        [SerializeField]
        private Text _happinessText = null;

        [SerializeField]
        private Text _ageText = null;

        [SerializeField]
        private Text _moneyText = null;

        public void DeathView()
        {
            _happinessText.text = "DEAD";
            _healthText.text = "DEAD";
            _moneyText.text = "DEAD";
            _ageText.text = "DEAD";

        }

        public void UpdateAge(int value)
        {
            _ageText.text = string.Concat("Age: ", value);
        }

        public void UpdateHappiness(float value)
        {
            _happinessText.text = string.Concat("Happiness: ", value);
        }

        public void UpdateHealth(float value)
        {
            _healthText.text = string.Concat("Health: ", value);
        }

        public void UpdateMoney(float value)
        {
            _moneyText.text = string.Concat("Money: ", value);
        }
    }
}