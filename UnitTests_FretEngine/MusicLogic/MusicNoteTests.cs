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
    class MusicNoteTests
    {
        [TestCase(AbstractMusicNote.BSharpCNatural, 0)]
        [TestCase(AbstractMusicNote.DNatural, 2)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 6)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 8)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 10)]
        public void MusicNote_WhenConstructingWithValidAbstractMusicNoteAndValidOctave_ShouldNotThrowException(AbstractMusicNote value, int octave)
        {
            Assert.DoesNotThrow(() => {
                new MusicNote(value, octave);
            });
        }

        [TestCase(AbstractMusicNote.CSharpDFlat)]
	    [TestCase(AbstractMusicNote.DSharpEFlat)]
	    [TestCase(AbstractMusicNote.ESharpFNatural)]
	    [TestCase(AbstractMusicNote.GNatural)]
	    [TestCase(AbstractMusicNote.ANatural)]
	    [TestCase(AbstractMusicNote.BNaturalCFlat)]
        public void MusicNote_WhenConstructingWithValidAbstractMusicNoteAndNoOctave_ShouldNotThrowException(AbstractMusicNote value)
        {
            Assert.DoesNotThrow(() => {
                new MusicNote(value);
            });
        }
    }
}
