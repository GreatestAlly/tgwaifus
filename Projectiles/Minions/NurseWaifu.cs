using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace tgwaifus.Projectiles.Minions
{
    class NurseWaifu : WaifuTemplet
    {
        public override void SetDefaults()
        {
            Main.projFrames[projectile.type] = 8;
            projectile.damage = 0;
            projectile.timeLeft = 18000;
            projectile.maxPenetrate = -1;
            projectile.width = 372 / 2;
            projectile.height = 546 / 2;
            projectile.friendly = true;
            projectile.netImportant = true;
            projectile.tileCollide = false;
            projectile.ignoreWater = true;
            projectile.minion = true;
        }

        public override bool PreAI()
        {
            if (Main.player[projectile.owner].FindBuffIndex(mod.BuffType("NurseWaifu")) < 0)
            {
                projectile.timeLeft = 1;
            }
            else
            {
                projectile.timeLeft = 18000;
            }
            if (projectile.frameCounter == 5)
            {
                projectile.frameCounter = 0;
                if (projectile.frame == 0)
                {
                    Player owner = Main.player[projectile.owner];
                    if (owner.statLife < owner.statLifeMax && Main.rand.Next(60) == 0)
                    {
                        projectile.frame = 1;
                    }
                }
                else
                {
                    projectile.frame = (projectile.frame + 1) % Main.projFrames[projectile.type];
                    if (projectile.frame == 2)
                    {
                        Vector2 topLeft = projectile.position;
                        if (projectile.direction == 1)
                        {
                            topLeft += new Vector2(156 / 2, 300 / 2);
                        }
                        else
                        {
                            topLeft += new Vector2(198 / 2, 300 / 2);
                        }
                        Item.NewItem(topLeft, 3, 3, ItemID.Heart);
                    }
                }
            }
            projectile.frameCounter++;
            return true;
        }

        public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
            Player player = Main.player[projectile.owner];
            if (player.lifeSteal >= 0 && Main.rand.Next(4) == 0)
            {
                int heal = 1;
                player.lifeSteal -= heal;
                player.statLife += heal;
                player.HealEffect(heal);
            }
            base.OnHitNPC(target, damage, knockback, crit);
        }

        /*
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
            projectile.velocity = projectile.velocity + Vector2.Multiply(toTarget, 1) ;
            if (projectile.velocity.Length() > maxSpeed)
            {
                projectile.velocity = Vector2.Multiply(projectile.velocity, maxSpeed / projectile.velocity.Length());
            }
            if (toTarget.Length() < 100)
            {
                projectile.velocity = Vector2.Multiply(projectile.velocity, toTarget.Length()* toTarget.Length() / 1000f / projectile.velocity.Length());
            }
            projectile.direction = Math.Sign(projectile.velocity.X);
            projectile.spriteDirection = projectile.direction;
        }
        */

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            /*
            Texture2D image = Main.projectileTexture[projectile.type];
            SpriteEffects effects = SpriteEffects.None;
            if (projectile.direction != 1)
            {
                effects = SpriteEffects.FlipHorizontally;
            }
            Vector2 position = projectile.position - Main.screenPosition;
            Vector2 center = new Vector2(0, 0);
            int frameWidth = image.Width;
            int frameHeight = image.Height / Main.projFrames[projectile.type];
            Rectangle bounds = new Rectangle(0, frameHeight * projectile.frame, frameWidth, frameHeight - 1);
            spriteBatch.Draw(image, position, bounds, projectile.GetAlpha(lightColor), projectile.rotation, center, 1f, effects, 0f);
            return false;
            */
            return base.PreDraw(spriteBatch, lightColor);
        }
    }
}
