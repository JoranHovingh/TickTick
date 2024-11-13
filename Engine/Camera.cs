using Microsoft.Xna.Framework;

namespace Engine
{
    public class Camera
    {
        private int viewportWidth;
        private int viewportHeight;
        private Point worldSize = new Point(1024, 768);

        public Camera(int viewportWidth, int viewportHeight)
        {
            // Set the Viewport to the correct width and height
            this.viewportWidth = viewportWidth;
            this.viewportHeight = viewportHeight;
        }

        public Vector2 CameraOffset(Rectangle player)
        {
            // Calculate the camera's offset based on the player's position
            // Ensure the camera does not go outside the bounds of the world
            float cameraX = MathHelper.Clamp(player.X + player.Width / 2 - viewportWidth / 2, 0, worldSize.X - viewportWidth);
            float cameraY = MathHelper.Clamp(player.Y + player.Height / 2 - viewportHeight / 2, 0, worldSize.Y - viewportHeight);

            return new Vector2(cameraX, cameraY);
        }

        
    }
}
