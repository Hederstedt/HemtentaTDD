using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HemtentaTdd2017.music
{ 
    // Ska testas och implementeras.
    public class MusicPlayer : IMusicPlayer
    {
        private Song Song;
        private SoundMaker SoundMaker;
        public MusicPlayer(SoundMaker soundMaker, Song song)
        {
            this.Song = song;
            this.SoundMaker = soundMaker;
        }
        private IList<Song> fakeDbList = new List<Song>
        {
            new Song() { Title = "hello" },
            new Song() { Title = "world" },
            new Song() { Title = "search"}

        };
        public IList<Song> AddSongToPlayList(Song s)
        {
            IList<Song> playlist = new List<Song>();
            playlist.Add(s);
            return playlist;
          
        }
        // Antal sånger som finns i spellistan.
        // Returnerar alltid ett heltal >= 0.
        private int numSongsInQueue;

        public int NumSongsInQueue
        {
            get { return numSongsInQueue; }
            set { numSongsInQueue = value; }
        }

        // Söker i databasen efter sångtitlar som
        // innehåller "search" och lägger till alla
        // sökträffar i spellistan.
        public void LoadSongs(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new NoSongOrWrongFormatException();
            }
            foreach (var s in fakeDbList)
            {
                if (s.Title == search)
                {
                    AddSongToPlayList(s);
                }
            }
        }
        // Om ingen låt spelas för tillfället ska
        // nästa sång i kön börja spelas. Om en låt
        // redan spelas har funktionen ingen effekt.
        public void NextSong()
        {
            throw new NotImplementedException();
        }
        // Om en sång spelas ska den sluta spelas.
        // Sången ligger kvar i spellistan. Om ingen
        // sång spelas har funktionen ingen effekt.
        public string NowPlaying()
        {
            return SoundMaker.NowPlaying;
        }
        // Börjar spela nästa sång i kön. Om kön är tom
        // har funktionen samma effekt som Stop().
        public void Play()
        {
            if (fakeDbList.Count <=0)
            {
                Stop();
            }
            else
            {
                foreach (var s in fakeDbList)
                {
                    SoundMaker.Play(s);
                }
            }
        }
        // Returnerar strängen "Tystnad råder" om ingen
        // sång spelas, annars "Spelar <namnet på sången>".
        // Exempel: "Spelar Born to run".
        public void Stop()
        {
            if (SoundMaker.NowPlaying == null)
            {
                SoundMaker.nowpplaying = "Tystnad råder";
            }
            else
            {
                SoundMaker.nowpplaying = "Spelar Born to run";
            }            
        }
    }
}
