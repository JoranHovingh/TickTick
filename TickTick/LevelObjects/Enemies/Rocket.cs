﻿using Engine;
using Microsoft.Xna.Framework;

/// <summary>
/// Represents a rocket enemy that flies horizontally through the screen.
/// </summary>
class Rocket : AnimatedGameObject
{
    Level level;
    Vector2 startPosition;
    const float speed = 500;
    public bool IsAlive { get; private set; }

    public Rocket(Level level, Vector2 startPosition, bool facingLeft) 
        : base(TickTick.Depth_LevelObjects)
    {
        if (!IsAlive)
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
        IsAlive = false;
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
                if (PlayerCollidesOnTop(level.Player) && level.Player.IsFalling)
                {
                    IsAlive = true;
                    Visible = false;
                }
                else
                {
                    if (!IsAlive)
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
        Rectangle rocketTop = new Rectangle(BoundingBox.X, BoundingBox.Y, Width, 1);
        return rocketTop.Intersects(player.BoundingBox); 
    }
}

