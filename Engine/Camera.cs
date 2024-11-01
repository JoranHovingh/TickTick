using Engine;
using Microsoft.Xna.Framework;
namespace Engine
{

    public class Camera
    {
        private Vector2 cameraPosition;

        public Camera()
        {
        }

        public void Follow(Rectangle player)
        {
            Vector2 screenSize = new Vector2(1024, 768);
            cameraPosition = new Vector2(player.X +player.Width / 2 - screenSize.X / 2, player.Y + player.Height / 2 - screenSize.Y / 2);
        }

        public Vector2 CameraPosition
        { get { return cameraPosition; } }
    }
}
