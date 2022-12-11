 using Jelewow.FrostDefence.Infrastructure.Services;
 using UnityEngine;

namespace Jelewow.FrostDefence.Infrastructure.AssetManagement
{
    public interface IAssetProvider : IService
    {
        public void Instantiate(string path);
        public GameObject Instantiate(string path, Vector3 position);
    }
}