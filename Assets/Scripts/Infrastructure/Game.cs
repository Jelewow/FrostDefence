using Jelewow.FrostDefence.Core;
using Jelewow.FrostDefence.Infrastructure.Services;
using Jelewow.FrostDefence.Infrastructure.States;

namespace Jelewow.FrostDefence.Infrastructure
{
    public class Game
    {
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain loadingCurtain)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), loadingCurtain, AllServices.Container); 
        }
    }
}