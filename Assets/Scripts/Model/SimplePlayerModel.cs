using System;

namespace FromBossToCrook.Model
{
    public class SimplePlayerModel : IPlayerModel
    {
        private int _maxAge;
        public int MaxAge { get => _age; }

        private int _age;
        public int Age { get => _age; }
        public float Money { get; set; }
        public float Health { get; set; }
        public float Happiness { get; set; }

        public event Action Death;

        public SimplePlayerModel(int currentAge, int maxAge)
        {
            _maxAge = maxAge;
            _age = currentAge;
        }

        public void IncreaseAge()
        {
            if (Health <= 5) _age++;
            if (Happiness <= 5) _age++;

            if (++_age > _maxAge)
            {
                Death?.Invoke();
            }
        }
    }
}