using Engine;
using Microsoft.Xna.Framework;
using System;
using System.Security.Cryptography.X509Certificates;

/// <summary>
/// Represents a rocket enemy that flies horizontally through the screen.
/// </summary>
class Rocket : AnimatedGameObject
{
    Level level;
    Vector2 startPosition;
    const float speed = 500;
    private bool IsDead = false;

    public Rocket(Level level, Vector2 startPosition, bool facingLeft) 
        : base(TickTick.Depth_LevelObjects)
    {
        if (!IsDead)
        {
            this.level = level;

            LoadAnimation("Sprites/LevelObjects/Rocket/spr_rocket@3", "rocket", true, 0.1f);
            PlayAnimation("rocket");
            SetOriginToCenter();

            sprite.Mirror = facingLeft;
            if (sprite.Mirror)
            {
                velocity.X = -speed;
                this.startPosition = startPosition + new Vector2(2 * speed, 0);
            }
            else
            {
                velocity.X = speed;
                this.startPosition = startPosition - new Vector2(2 * speed, 0);
            }
            Reset();
        }
    }

    public override void Reset()
    {
        // go back to the starting position
        LocalPosition = startPosition;
        // Makes the rocket visible
        IsDead = false;
        Visible = true;
    }

    public override void Update(GameTime gameTime)

    {
        base.Update(gameTime);

        // if the rocket has left the screen, reset it
        if (sprite.Mirror && BoundingBox.Right < level.BoundingBox.Left)
            Reset();
        else if (!sprite.Mirror && BoundingBox.Left > level.BoundingBox.Right)
            Reset();

        // If the player touches the top of the rocket, the rocket dies
        // Else the pplayer dies
        if (level.Player.CanCollideWithObjects)
        {
            if (HasPixelPreciseCollision(level.Player))
            {
                if (PlayerCollidesOnTop(level.Player))
                {
                    IsDead = true;
                    Visible = false;
                }
                else
                {
                    if (!IsDead)
                    {
                        level.Player.Die();
                    }
                }
            }

        }
    }

    // Checks if the player collides with the upper 3 pixels of the rocketboundingbox
    public bool PlayerCollidesOnTop(Player player)
    {
        Rectangle rocketTop = new Rectangle(BoundingBox.X, BoundingBox.Y, Width, 3);
        return rocketTop.Intersects(player.BoundingBox); 
    }
}

