using System;
using UnityEngine;

namespace Jelewow.FrostDefence.Data
{
    [Serializable]
    public class WorldData
    {
        public CameraPositionOnLevel CameraPositionOnLevel;

        public WorldData(string initialLevel)
        {
            Debug.Log("world data");
            CameraPositionOnLevel = new CameraPositionOnLevel(initialLevel);
            Debug.Log("create");
            Debug.Log(CameraPositionOnLevel);
        }
    }
}