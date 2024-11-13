using Microsoft.Xna.Framework;

namespace Engine
{
    public class Camera
    {
        public Vector2 Position { get; private set; }
        public Rectangle Viewport { get; private set; }

        // Stel de camera in voor de grootte van het scherm (viewport)
        public Camera(int viewportWidth, int viewportHeight)
        {
            Position = Vector2.Zero; // Begin de camera op de 0,0 positie
            Viewport = new Rectangle(0, 0, viewportWidth, viewportHeight);
        }

        // Volg de speler en bereken tegelijkertijd de offset voor het tekenen
        public Vector2 CameraOffset(Vector2 playerPosition)
        {
            // Volg de speler zodat deze in het midden van het scherm blijft
            Position = playerPosition - new Vector2(Viewport.Width / 2, Viewport.Height / 2);

            // Retourneer de offset op basis van de camera-positie
            return Position; // Negatief omdat we van de wereldpositie de camera-positie aftrekken
        }
    }
}
