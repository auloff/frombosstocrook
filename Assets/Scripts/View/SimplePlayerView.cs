using FromBossToCrook.Model;
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

        public void UpdateView(IPlayerModel model)
        {
            _moneyText.text = string.Concat("Money: ", model.Money);
            _healthText.text = string.Concat("Health: ", model.Health);
            _happinessText.text = string.Concat("Happiness: ", model.Happiness);
            _ageText.text = string.Concat("Age: ", model.Age);

        }
    }
}