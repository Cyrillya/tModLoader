using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.GameContent.Creative;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace ExampleMod.Content.Items
{
	public class ExampleSoul : ModItem
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Soul of Exampleness");
			Tooltip.SetDefault("'The essence of example creatures'");

			// Registers a vertical animation with 4 frames and each one will last 5 ticks (1/12 second)
			Main.RegisterItemAnimation(Item.type, new DrawAnimationVertical(5, 4));
			ItemID.Sets.AnimatesAsSoul[Item.type] = true; // Makes the item have an animation while in world (not held.). Use in combination with RegisterItemAnimation

			ItemID.Sets.ItemIconPulse[Item.type] = true; // The item pulses while in the player's inventory
			ItemID.Sets.ItemNoGravity[Item.type] = true; // Makes the item have no gravity

			CreativeItemSacrificesCatalog.Instance.SacrificeCountNeededByItemId[Type] = 25; // Configure the amount of this item that's needed to research it in Journey mode.
		}

		public override void SetDefaults() {
			Item.width = 18;
			Item.height = 18;
			Item.maxStack = 999;
			Item.value = 1000; // Makes the item worth 1 gold.
			Item.rare = ItemRarityID.Orange;
		}

		public override void PostDrawInInventory(SpriteBatch spriteBatch, Vector2 position, Rectangle frame, Color drawColor, Color itemColor, Vector2 origin, float scale) {
			base.PostDrawInInventory(spriteBatch, position, frame, drawColor, itemColor, origin, scale);

			float posx = 600f;
			Test(spriteBatch, "Erhöht", ref posx);
			Test(spriteBatch, "daño", ref posx);
			Test(spriteBatch, "arobabilità", ref posx);
			Test(spriteBatch, "aéveillé", ref posx);
			Test(spriteBatch, "aedução", ref posx);
			Test(spriteBatch, "abrażeń", ref posx);
			Test(spriteBatch, "потратитьбоеприпасы", ref posx);
		}

		private void Test(SpriteBatch spriteBatch, string name, ref float posX) {
			var texture = ModContent.Request<Texture2D>("ExampleMod/Content/Items/" + name, ReLogic.Content.AssetRequestMode.ImmediateLoad).Value;
			spriteBatch.Draw(texture, new Vector2(posX, 500f), Color.White);
			posX += 50f;
		}

		public override void PostUpdate() {
			Lighting.AddLight(Item.Center, Color.WhiteSmoke.ToVector3() * 0.55f * Main.essScale); // Makes this item glow when thrown out of inventory.
		}

		// Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
		public override void AddRecipes() {
			CreateRecipe()
				.AddIngredient<ExampleItem>()
				.AddTile<Tiles.Furniture.ExampleWorkbench>()
				.Register();
		}
	}
}
