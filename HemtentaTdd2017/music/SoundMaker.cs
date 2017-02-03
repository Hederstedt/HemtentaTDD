using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemtentaTdd2017.music
{
    // Spelar musik. Implementera eller mocka.
    public class SoundMaker : ISoundMaker
    {
        public string nowpplaying { get; set; }
        // Titeln på sången som spelas just nu. Ska vara
        // tom sträng om ingen sång spelas.

        public string NowPlaying
        {
            get
            {
                return nowpplaying;
            }
        }

        public void Play(ISong song)
        {
            if (song == null)
            {
                nowpplaying = "";
                
            }
            else
            {
                nowpplaying = song.Title;
            }
           
        }

        public void Stop()
        {
            if (string.IsNullOrEmpty(nowpplaying))
            {
                throw new NoSongOrWrongFormatException();
            }
        }
    }
}
