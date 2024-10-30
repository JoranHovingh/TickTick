using Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
namespace Engine
{

    public class Camera
    {
        public Vector2 position;

        public Camera(Vector2 position)
        {
            this.position = position;
        }

        public void CameraFollow(Rectangle m, Vector2 ScreenSize)
        {
            position = new Vector2(m.X + (ScreenSize.X / 2 - m.Width / 2), m.Y + (ScreenSize.Y / 2 - m.Height / 2));

        }
    }
}
