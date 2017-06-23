using Terraria.ModLoader;

namespace tgwaifus
{
	class tgwaifus : Mod
	{
		public tgwaifus()
		{
			Properties = new ModProperties()
			{
				Autoload = true,
				AutoloadGores = true,
				AutoloadSounds = true
			};
		}
	}
}
