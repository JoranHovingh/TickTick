using Engine;
using Microsoft.Xna.Framework;
using System.Reflection.Emit;

class PowerUp : SpriteGameObject
{ 
    private Level level;
    private float powerUpDuration = 200f; 
    private int speedBoost = 2000;
    private float timer = 0f;
    Vector2 startPosition;
    public bool IsActive { get; private set; }
    public bool IsAlive { get; private set;  }


    public PowerUp(Level level, Vector2 startPosition) : base("Sprites/LevelObjects/PowerUp.png", TickTick.Depth_LevelObjects) 
    {
        this.level = level;
        this.startPosition = startPosition;
        SetOriginToCenter();
        Reset();
    }

    public override void Update(GameTime gameTime)
    {
        if (IsAlive)
        {
            base.Update(gameTime);
            if (Visible && level.Player.CanCollideWithObjects && HasPixelPreciseCollision(level.Player))
            {
                // Activeren van de boost voor de speler
                level.Player.IncreaseSpeed(speedBoost);
                IsActive = false;
                Visible = false;
            }

            // Als de boost actief is, start timer en reset de snelheid na afloop
            if (!IsActive)
            {
                timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timer >= powerUpDuration)
                {
                    level.Player.DecreaseSpeed(speedBoost);
                    IsAlive = false;
                }
            }
        }
    }

    public override void Reset()
    {
        localPosition = startPosition;
        IsAlive = true;
        IsActive = true;
        timer = 0.0f;
        Visible = true;
    }
}
