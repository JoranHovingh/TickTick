using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine
{
    public class Camera
    {
        private int viewportWidth;
        private int viewportHeight;
        private Point worldSize;

        public Camera(GraphicsDevice graphicsDevice, Point worldsize)
        {
            // Set the Viewport to the correct width and height
            this.viewportWidth = graphicsDevice.Viewport.Width;
            this.viewportHeight = graphicsDevice.Viewport.Height;
            this.worldSize = worldsize;
        }

        public Vector2 CameraOffset(Rectangle player)
        {
            // Calculate the camera's offset based on the player's position
            // Ensure the camera does not go outside the bounds of the world
            float cameraX = MathHelper.Clamp(player.X + player.Width / 2 - worldSize.X / 2, 0, worldSize.X - viewportWidth);
            float cameraY = MathHelper.Clamp(player.Y + player.Height / 2 - worldSize.Y / 2, -500, worldSize.Y - viewportHeight);

            return new Vector2(cameraX, cameraY);
        }

        
    }
}
