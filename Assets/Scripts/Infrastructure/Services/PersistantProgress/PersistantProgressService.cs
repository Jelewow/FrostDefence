using Jelewow.FrostDefence.Data;

namespace Jelewow.FrostDefence.Infrastructure.Services
{
    public class PersistantProgressService : IPersistantProgressService
    {
        public PlayerProgress Progress { get; set; }
    }
}