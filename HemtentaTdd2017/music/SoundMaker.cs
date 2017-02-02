using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemtentaTdd2017.music
{
    public class SoundMaker : ISoundMaker
    {
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
