using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;

namespace UtopiaMG
{
	class Music
	{
		ContentManager Content;

		public void Update(GameTime gameTime, float volume)
		{
            MediaPlayer.Volume = volume;
			//System.Console.WriteLine("Music Volume: {0}", volume);
		}

		public void Play(ContentManager Content)
		{
			this.Content = Content;
			Song menuMusic = Content.Load<Song>("Audio/Music/menumusic");
			MediaPlayer.IsRepeating = true;
			MediaPlayer.Play(menuMusic);
		}
	}
}
