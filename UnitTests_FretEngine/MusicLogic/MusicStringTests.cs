using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FretEngine.Common.DataTypes;
using FretEngine.MusicLogic;

namespace UnitTests_FretEngine.MusicLogic
{
    [TestFixture]
    class MusicStringTests
    {
        [TestCase(AbstractMusicNote.BSharpCNatural, 4)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 7)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 30)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -9)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0)]
        public void MusicString_WhenConstructingWithValidMusicNote_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.DoesNotThrow(() =>
            {
                new MusicString(testMusicNote);
            });
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, 4)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 17)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 2)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -8)]
        public void MusicString_WhenConstructingWithValidMusicNote_ShouldContainCorrectValues(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote);

            Assert.AreEqual(testMusicNote, testMusicString.RootNote);
        }

        [TestCase(AbstractMusicNote.DNatural, 4)]
        [TestCase(AbstractMusicNote.GNatural, 1)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 20)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -7)]
        [TestCase(AbstractMusicNote.ANatural, 0)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -0)]
        public void ToString_WhenCalledOnAValidMusicString_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            Assert.DoesNotThrow(() =>
            {
                testMusicString.ToString();
            });
        }
    }
}
