using System;
using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure
{
    public class GameRunner : MonoBehaviour
    {
        [SerializeField] private GameBootstrapper _bootstrapperPrefab;
        
        private void Awake()
        {
            var bootstrapper = FindObjectOfType<GameBootstrapper>();

            if (bootstrapper != null)
            {
                return;
            }
            
            Instantiate(_bootstrapperPrefab);
        }
    }
}