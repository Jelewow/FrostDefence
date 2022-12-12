using DefaultNamespace;
using Jelewow.FrostDefence.Infrastructure.Services;
using Jelewow.FrostDefence.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Jelewow.FrostDefence.Core
{
    public class SaveTrigger : MonoBehaviour
    {
        [SerializeField] private BoxCollider _collider;
        
        private ISaveLoadService _saveLoadService;

        private void Awake()
        {
            _saveLoadService = AllServices.Container.Single<ISaveLoadService>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.gameObject.TryGetComponent(out Player player))
            {
                return;
            }
            
            _saveLoadService.SaveProgress();
            gameObject.SetActive(false);
            
            Debug.Log("Progress saved!");
        }

        private void OnDrawGizmos()
        {
            if (!_collider)
            {
                return;
            }
            
            Gizmos.color = new Color32(30, 200, 30, 130);
            Gizmos.DrawCube(transform.position + _collider.center, _collider.size);
        }
    }
}