using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria;

namespace tgwaifus.Buffs
{
    class NurseWaifu : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Nurse Waifu");
            Description.SetDefault("The nurse will occasionally heal you.");
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
        }
        public override void Update(Player player, ref int buffIndex)
        {
            if (player.ownedProjectileCounts[mod.ProjectileType("NurseWaifu")] <= 0)
            {
                Projectile.NewProjectile(player.position.X, player.position.Y, 0, 0, mod.ProjectileType("NurseWaifu"), 0, 0, player.whoAmI);
            }
        }
    }
}
