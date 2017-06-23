using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;
using Terraria.ID;
using Microsoft.Xna.Framework;

namespace tgwaifus.Projectiles.Minions
{
    public abstract class WaifuTemplet : ModProjectile
    {
        public override void AI()
        {
            Player owner = Main.player[projectile.owner];
            if (!owner.active)
            {
                projectile.active = false;
            }
            Vector2 targetPos = owner.Center + new Vector2(owner.direction * (-150f), -100f);
            Vector2 toTarget = targetPos - projectile.Center;
            float maxSpeed = 10;
            projectile.velocity = projectile.velocity + Vector2.Multiply(toTarget, 1);
            if (projectile.velocity.Length() > maxSpeed)
            {
                projectile.velocity = Vector2.Multiply(projectile.velocity, maxSpeed / projectile.velocity.Length());
            }
            if (toTarget.Length() < 100)
            {
                projectile.velocity = Vector2.Multiply(projectile.velocity, toTarget.Length() * toTarget.Length() / 1000f / projectile.velocity.Length());
            }
            projectile.direction = Math.Sign(projectile.velocity.X);
            projectile.spriteDirection = projectile.direction;
        }
    }
}
