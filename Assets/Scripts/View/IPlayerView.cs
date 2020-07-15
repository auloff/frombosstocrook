namespace FromBossToCrook.View
{
    public interface IPlayerView
    {
        void UpdateHealth(float value);
        void UpdateHappiness(float value);
        void UpdateMoney(float value);
        void UpdateAge(int value);
        void DeathView();
    }
}