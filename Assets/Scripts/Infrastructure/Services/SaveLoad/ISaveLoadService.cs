using Jelewow.FrostDefence.Data;

namespace Jelewow.FrostDefence.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadService : IService
    {
        public PlayerProgress LoadProgress();

        public void SaveProgress();
    }
}