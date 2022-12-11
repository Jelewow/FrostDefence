namespace Jelewow.FrostDefence.Data
{
    public class CameraPositionOnLevel
    {
        public string Level;
        public Vector3Data Position;

        public CameraPositionOnLevel(string level, Vector3Data position)
        {
            Level = level;
            Position = position;
        }
    }
}