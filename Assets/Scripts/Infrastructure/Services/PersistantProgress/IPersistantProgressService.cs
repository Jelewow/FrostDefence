using Jelewow.FrostDefence.Data;

namespace Jelewow.FrostDefence.Infrastructure.Services
{
    public interface IPersistantProgressService : IService
    {
        public PlayerProgress Progress { get; set; }
    }
}