using Jelewow.FrostDefence.Data;

namespace Jelewow.FrostDefence.Services.PersistantProgress
{
    public interface ISavedProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }
}