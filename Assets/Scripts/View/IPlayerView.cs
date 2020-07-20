using FromBossToCrook.Model;

namespace FromBossToCrook.View
{
    public interface IPlayerView
    {
        void UpdateView(IPlayerModel model);
        void DeathView();
    }
}