using Jelewow.FrostDefence.Auxiliary;
using Jelewow.FrostDefence.Infrastructure.AssetManagement;
using Jelewow.FrostDefence.Infrastructure.Services;
using Jelewow.FrostDefence.Infrastructure.Services.SaveLoad;

namespace Jelewow.FrostDefence.Infrastructure.States
{
    public class BootstrapState : IState
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly AllServices _services;

        public BootstrapState(GameStateMachine gameStateMachine, SceneLoader sceneLoader, AllServices services)
        {
            _stateMachine = gameStateMachine;
            _sceneLoader = sceneLoader;
            _services = services;
            
            RegisterServices();
        }

        public void Enter()
        {
            _sceneLoader.Load(GameConstants.Scenes.Initial, EnterLoadLevel);
        }
        
        public void Exit()
        {
            
        }
        
        private void EnterLoadLevel()
        {
            _stateMachine.Enter<LoadProgressState>();
        }
        
        private void RegisterServices()
        {
            _services.RegisterSingle<IAssetProvider>(new AssetProvider());
            
            _services.RegisterSingle<IPersistantProgressService>(new PersistantProgressService());
            
            _services.RegisterSingle<IGameFactory>(new GameFactory(_services.Single<IAssetProvider>()));

            _services.RegisterSingle<ISaveLoadService>(new SaveLoadService(_services.Single<IPersistantProgressService>(), _services.Single<IGameFactory>()));
        }
    }
}