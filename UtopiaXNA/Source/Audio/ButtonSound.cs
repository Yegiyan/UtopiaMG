using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework;

namespace UtopiaMG
{
	class ButtonSound
	{
		ContentManager Content;

		public void Update(GameTime gameTime, float volume)
		{
			SoundEffect.MasterVolume = volume;
			//System.Console.WriteLine("SFX Volume: {0}", volume);
		}

		public void Play(ContentManager Content)
		{
			this.Content = Content;
			SoundEffect buttonSound = Content.Load<SoundEffect>("Audio/SFX/BUTTON_SOUND");
			buttonSound.Play();
		}
	}
}
