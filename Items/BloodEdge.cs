using Terraria.ID;
using Terraria.ModLoader;
using Terraria;

namespace JenSaneFourPoint.Items
{
	public class BloodEdge : ModItem
	{
		public override void SetStaticDefaults() 
		{
			// DisplayName.SetDefault("MoltenTrident"); // By default, capitalization in classnames will add spaces to the display name. You can customize the display name here by uncommenting this line.
			Tooltip.SetDefault("Bloodedge...");
		}

		public override void SetDefaults() 
		{
			Item.damage = 10;
			Item.DamageType = DamageClass.Melee/* tModPorter Suggestion: Consider MeleeNoSpeed for no attack speed scaling */;
			//Item.DamageType = DamageClass.Magic;
			Item.width = 40;
			Item.height = 40;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.value = Item.buyPrice(gold: 100);

			//item.shoot = mod.ProjectileID.TridentBolt;
			//item.shoot = mod.ProjectileType("TridentBolt");
		}

        //public override void OnHitNPC() 
        // CheckDead()
        // public void CheckDead(Player player, NPC target, ref int damage, ref float knockBack, ref bool crit)
        public void OnHitNPC(Player player, NPC target, int buffIndex)
        {
           // int buffID = BuffID.Regeneration; //This changes what buff you're applying to the player
           // int duration = 60; //How long the buff will last. Note that this value is in frames, so if you want the buff to last 1 second, put in 60 frames for the duration
           // player.AddBuff(buffID, duration);
           // player.GetDamage(DamageClass.Generic) *= 2f;
            Item.damage += 1;
            ExamplePlayer p = player.GetModPlayer<ExamplePlayer>();
            // p.RefKillCount += player.statLifeMax2;
            player.statLifeMax2 += p.RefKillCount;
            player.statLifeMax2 *= 2;
        }
	}
}