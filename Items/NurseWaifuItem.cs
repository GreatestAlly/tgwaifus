using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria;

namespace tgwaifus.Items
{
    class NurseWaifuItem : ModItem
    {
        public override string Texture
        {
            get
            {
                return "Terraria/Item_499";
            }
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Waifu in a Health Potion");
            Tooltip.SetDefault("The mod creater is an uncreative fuck.");
        }

        public override void SetDefaults()
        {
            item.accessory = true;
            item.width = 30;
            item.height = 30;
            item.value = 150000;
            item.rare = 5;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            player.AddBuff(mod.BuffType("NurseWaifu"), 2);
            base.UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(mod.ItemType("WaifuEssence"));
            recipe.AddIngredient(ItemID.NurseHat);
            recipe.AddIngredient(ItemID.NurseShirt);
            recipe.AddIngredient(ItemID.NursePants);
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();

            /*
            recipe = new ModRecipe(mod);
            recipe.AddIngredient(ItemID.Wood);
            recipe.SetResult(this, 1);
            recipe.AddRecipe();
            */
            
        }
    }
}
