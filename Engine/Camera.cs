using Engine;
using Microsoft.Xna.Framework;
using System;
namespace Engine
{

    public class Camera
    {
        private Vector2 cameraPosition;
        
        public Camera()
        {
        }

        public void Follow(Vector2 player)
        {
            Vector2 screenSize = new Vector2(1024, 768);
            cameraPosition = new Vector2(
                player.X / 2 - screenSize.X / 2,
               player.Y / 2 - screenSize.Y / 2
            );
            //cameraPosition = new Vector2(200, 0);

            Console.WriteLine($"Camera position: {cameraPosition}"); // Controle voor debuggen
        }

        public Vector2 CameraPosition{ get { return cameraPosition; } }
    }
}
