using UnityEngine;

namespace Jelewow.FrostDefence.Auxiliary
{
    public static class GameConstants
    {
        public static class Scenes
        {
            public const string Initial = nameof(Initial);
            
            public const string Main = nameof(Main);
        }

        public static class Tags
        {
            public const string InitialPoint = nameof(InitialPoint);
        }

        public static class Resources
        {
            public const string Hud = "HUD/HUD";
            
            public const string Player = "Test/TestPlayer";
        }

        public static class PrefKeys
        {
            public const string Progress = nameof(Progress);
        }

        public static class Animation
        {
            public static readonly int Die = Animator.StringToHash(nameof(Die));
        }
    }
}