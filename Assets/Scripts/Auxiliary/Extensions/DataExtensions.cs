using Jelewow.FrostDefence.Data;
using UnityEngine;

namespace Jelewow.FrostDefence.Auxiliary.Ententions
{
    public static class DataExtensions
    {
        public static Vector3Data AsVectorData(this Vector3 position)
        {
            return new Vector3Data(position.x, position.y, position.z);
        }

        public static Vector3 AsUnityVector(this Vector3Data position)
        {
            return new Vector3(position.X, position.Y, position.Z);
        }
    }
}