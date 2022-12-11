using Jelewow.FrostDefence.Auxiliary.Ententions;
using Jelewow.FrostDefence.Data;
using Jelewow.FrostDefence.Services.PersistantProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Player : ISavedProgress
    {
        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.CameraPositionOnLevel = new CameraPositionOnLevel(GetLevelName(),
                Camera.main.transform.position.AsVectorData());
        }

        private static string GetLevelName()
        {
            return SceneManager.GetActiveScene().name;
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (GetLevelName() != progress.WorldData.CameraPositionOnLevel.Level)
            {
                return;
            }
            
            var savedPosition = progress.WorldData.CameraPositionOnLevel.Position;
            Camera.main.transform.position = savedPosition.AsUnityVector();
        }
    }
}