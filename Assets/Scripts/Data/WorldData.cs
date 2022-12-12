using System;

namespace Jelewow.FrostDefence.Data
{
    [Serializable]
    public class WorldData
    {
        public CameraPositionOnLevel CameraPositionOnLevel;

        public WorldData(string initialLevel)
        {
            CameraPositionOnLevel = new CameraPositionOnLevel(initialLevel);
        }
    }
}