using System;

namespace FromBossToCrook.Model
{
    public interface IPlayerModel
    {
        int Age { get; }
        int MaxAge { get; }
        float Money { get; set; }
        float Health { get; set; }
        float Happiness { get; set; }

        event Action Death;

        void IncreaseAge();
    }
}