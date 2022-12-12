using Jelewow.FrostDefence.Data;
using UnityEngine;

namespace Jelewow.FrostDefence.Auxiliary.Extensions
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

        public static T ToDeserialized<T>(this string json)
        {
            return JsonUtility.FromJson<T>(json);
        }

        public static string ToJson(this object obj)
        {
            return JsonUtility.ToJson(obj);
        }
    }
}