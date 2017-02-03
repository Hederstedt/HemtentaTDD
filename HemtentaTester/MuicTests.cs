using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HemtentaTdd2017.music;
using NUnit.Framework;

namespace HemtentaTester
{
    [TestFixture]
   public class MuicTests
    {
        private Song s;
        private SoundMaker sm;
        private FakeMediaDatabase db;
        private MusicPlayer mp;
        [SetUp]
        public void SetUp()
        {
            s = new Song();
            sm = new SoundMaker();
            db = new FakeMediaDatabase();
            mp = new MusicPlayer(sm,s);
        }
        #region DbTests
        [Test]
        public void FakeDb_throws_DatabaseClosedException()
        {
            Assert.That(() => db.CloseConnection(),
                Throws.TypeOf<DatabaseClosedException>());
        }
        [Test]
        public void FakeDb_CloseConnection_Sets_IsConnected_TO_False()
        {
            db.OpenConnection();
            db.CloseConnection();
            Assert.That(db.IsConnected, Is.False);
        }
        [Test]
        public void FakeDb_OpenConnection_Throws_DatabaseAlreadyOpenException()
        {
            db.OpenConnection();
            Assert.That(() => db.OpenConnection(),
                Throws.TypeOf<DatabaseAlreadyOpenException>());
        }
        [Test]
        public void FakeDb_OpenConnection_Sets_IsConnected_TO_true()
        {
            db.OpenConnection();
            Assert.That(db.IsConnected, Is.True);
        }
        
        [Test]
        public void FakeDb_FetchSongs_Throws_NoSongOrWrongFormatException()
        {
            Assert.That(() => db.FetchSongs(null), Throws.TypeOf<NoSongOrWrongFormatException>());
        }
        [Test]
      
        public void FakeDb_FetchSongs_Returns_Song_If_Match()
        {
            //var result = db.FetchSongs("wee");
            //Assert.That(result, Contains.Substring("wee"));
        }
        #endregion

        #region MusicPlayerTest
        [Test]
        public void MusicPlayer_NumSongsInQueue_Returns_0()
        {
            Assert.AreEqual(mp.NumSongsInQueue, (0));
        }
        [Test]
        public void MusicPlayer_LoadSongs_Throws_NoSongOrWrongFormatException()
        {
            Assert.That(() => mp.LoadSongs(null), Throws.TypeOf<NoSongOrWrongFormatException>());
        }
        [Test]
        public void MusicPlayer_LoadSongs_Returns_songs_if_match()
        {
            


        }
        #endregion
    }
    #region FakeDb   
    // Databasen som har alla sånger.
    // Om man försöker använda databasen när den
    // är stängd, eller öppna den när den redan
    // är öppen, ska funktionen kasta motsvarande
    // exception. Ska inte implementeras. 
    public class FakeMediaDatabase : IMediaDatabase
    {
        private bool isConnected;

        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        // Stänger anslutning till databasen
        public void CloseConnection()
        {
            if (IsConnected == true)
            {
                IsConnected = false;         
            }
            else
            {
                throw new DatabaseClosedException();
            }
        }
        // Returnerar alla sånger i databasen som
        // matchar söksträngen.
        // Tips: använd string.Contains(string)
        public List<ISong> FetchSongs(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                throw new NoSongOrWrongFormatException();
            }
            if (IsConnected == false)
            {
                throw new DatabaseClosedException();
            }
            var songs = new List<ISong>
            {
                new Song() { Title = "wee" },
                new Song() { Title = "dee" },

            };
            var matchsongs = new List<ISong>();
            foreach (var s in songs)
            {
                if (s.Title == search)
                {
                    matchsongs.Add(s);
                }
            }
            return matchsongs;          
        }
        // Ansluter till databasen
        public void OpenConnection()
        {
            if (IsConnected == false)
            {
                IsConnected = true;
            }
            else
            {
                throw new DatabaseAlreadyOpenException();               
            }
        }
    }
    #endregion
}
