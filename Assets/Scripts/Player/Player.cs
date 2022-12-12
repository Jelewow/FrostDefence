using Jelewow.FrostDefence.Auxiliary.Extensions;
using Jelewow.FrostDefence.Data;
using Jelewow.FrostDefence.Services.PersistantProgress;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class Player : MonoBehaviour, ISavedProgress
    {
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
        }

        public void UpdateProgress(PlayerProgress progress)
        {
            progress.WorldData.CameraPositionOnLevel = new CameraPositionOnLevel(GetLevelName(),
               transform.position.AsVectorData());
        }

        public void LoadProgress(PlayerProgress progress)
        {
            if (GetLevelName() != progress.WorldData.CameraPositionOnLevel.Level)
            {
                return;
            }
            
            var savedPosition = progress.WorldData.CameraPositionOnLevel.Position;

            if (savedPosition == null)
            {
                return;
            }
            
            transform.position = savedPosition.AsUnityVector();
        }

        private string GetLevelName()
        {
            return SceneManager.GetActiveScene().name;
        }
    }
}