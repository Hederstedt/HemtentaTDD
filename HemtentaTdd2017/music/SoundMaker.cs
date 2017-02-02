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
        // Titeln på sången som spelas just nu. Ska vara
        // tom sträng om ingen sång spelas.
        public string NowPlaying
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Play(ISong song)
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
