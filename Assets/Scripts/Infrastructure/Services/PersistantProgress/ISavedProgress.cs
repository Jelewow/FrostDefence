using Jelewow.FrostDefence.Data;

namespace Jelewow.FrostDefence.Services.PersistantProgress
{
    public interface ISavedProgress : ISavedProgressReader
    {
        public void UpdateProgress(PlayerProgress progress);
    }
}