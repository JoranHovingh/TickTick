using Engine;
using Microsoft.Xna.Framework;
using System.Reflection.Emit;

class PowerUp : SpriteGameObject
{ 
    private Level level; 
    
    private const int speedBoost = 600;
    private float timer;
   
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
                timer -= (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (timer <= 0)
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
        timer = 3f;
        Visible = true;
    }
}
