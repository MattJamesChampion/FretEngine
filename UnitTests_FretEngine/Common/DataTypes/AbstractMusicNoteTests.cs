using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FretEngine.Common.DataTypes;

namespace UnitTests_FretEngine.Common.DataTypes
{
    [TestFixture]
    class AbstractMusicNoteUtilitiesTests
    {
        [TestCase(AbstractMusicNote.BSharpCNatural, 7, AbstractMusicNote.GNatural)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 1, AbstractMusicNote.ENaturalFFlat)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 9, AbstractMusicNote.ASharpBFlat)]
        [TestCase(AbstractMusicNote.ANatural, 30, AbstractMusicNote.DSharpEFlat)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 14, AbstractMusicNote.ASharpBFlat)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 4, AbstractMusicNote.ANatural)]
        [TestCase(AbstractMusicNote.FSharpGFlat, -5, AbstractMusicNote.CSharpDFlat)]
        [TestCase(AbstractMusicNote.DNatural, 0, AbstractMusicNote.DNatural)]
        public void Sharpened_WhenIncrementingWithoutOctaveShift_ShouldReturnCorrectAbstractMusicNote(AbstractMusicNote initialAbstractMusicNote, int incrementQuantity, AbstractMusicNote expectedAbstractMusicNote)
        {
            Assert.AreEqual(expectedAbstractMusicNote, initialAbstractMusicNote.Sharpened(incrementQuantity));
        }

        [TestCase(AbstractMusicNote.ANatural, 0, AbstractMusicNote.ANatural)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 4, AbstractMusicNote.DSharpEFlat)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 12, AbstractMusicNote.FSharpGFlat)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 9, AbstractMusicNote.DNatural)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 1, AbstractMusicNote.ENaturalFFlat)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 32, AbstractMusicNote.GSharpAFlat)]
        [TestCase(AbstractMusicNote.GNatural, -20, AbstractMusicNote.BNaturalCFlat)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -0, AbstractMusicNote.ENaturalFFlat)]
        public void Sharpened_WhenIncrementingWithOctaveShift_ShouldReturnCorrectAbstractMusicNote(AbstractMusicNote initialAbstractMusicNote, int incrementQuantity, AbstractMusicNote expectedAbstractMusicNote)
        {
            int returnedOctaveShift;
            Assert.AreEqual(expectedAbstractMusicNote, initialAbstractMusicNote.Sharpened(incrementQuantity, out returnedOctaveShift));
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, 5, 0)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 1, 1)]
        [TestCase(AbstractMusicNote.DNatural, 72, 6)]
        [TestCase(AbstractMusicNote.ANatural, 1000, 84)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 13, 2)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -12, -1)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0, 0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 17, 1)]
        public void Sharpened_WhenIncrementingWithOctaveShift_ShouldReturnCorrectOctaveShift(AbstractMusicNote initialAbstractMusicNote, int incrementQuantity, int expectedOctaveShift)
        {
            int returnedOctaveShift;
            initialAbstractMusicNote.Sharpened(incrementQuantity, out returnedOctaveShift);
            Assert.AreEqual(expectedOctaveShift, returnedOctaveShift);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 4, AbstractMusicNote.DNatural)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 1000, AbstractMusicNote.BSharpCNatural)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 72, AbstractMusicNote.GSharpAFlat)]
        [TestCase(AbstractMusicNote.ANatural, -5, AbstractMusicNote.DNatural)]
        [TestCase(AbstractMusicNote.DNatural, 1, AbstractMusicNote.CSharpDFlat)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 7, AbstractMusicNote.ESharpFNatural)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 0, AbstractMusicNote.CSharpDFlat)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 17, AbstractMusicNote.ASharpBFlat)]
        public void Flattened_WhenDecrementingWithoutOctaveShift_ShouldReturnCorrectAbstractMusicNote(AbstractMusicNote initialAbstractMusicNote, int decrementQuantity, AbstractMusicNote expectedAbstractMusicNote)
        {
            Assert.AreEqual(expectedAbstractMusicNote, initialAbstractMusicNote.Flattened(decrementQuantity));
        }

        [TestCase(AbstractMusicNote.GNatural, 3, AbstractMusicNote.ENaturalFFlat)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -9999, AbstractMusicNote.DSharpEFlat)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 4, AbstractMusicNote.ANatural)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -13, AbstractMusicNote.ESharpFNatural)]
        [TestCase(AbstractMusicNote.ANatural, 7, AbstractMusicNote.DNatural)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 20, AbstractMusicNote.GNatural)]
        [TestCase(AbstractMusicNote.DNatural, -(-(-(2))), AbstractMusicNote.ENaturalFFlat)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 12, AbstractMusicNote.GSharpAFlat)]
        public void Flattened_WhenDecrementingWithOctaveShift_ShouldReturnCorrectAbstractMusicNote(AbstractMusicNote initialAbstractMusicNote, int decrementQuantity, AbstractMusicNote expectedAbstractMusicNote)
        {
            int returnedOctaveShift;
            Assert.AreEqual(expectedAbstractMusicNote, initialAbstractMusicNote.Flattened(decrementQuantity, out returnedOctaveShift));
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 1, 0)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 1, -1)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -12, 1)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 11, 0)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 72, -6)]
        [TestCase(AbstractMusicNote.GNatural, 0, 0)]
        [TestCase(AbstractMusicNote.ANatural, 48, -4)]
        [TestCase(AbstractMusicNote.DNatural, -1000, 83)]
        public void Flattened_WhenDecrementing_ShouldReturnCorrectOctaveShift(AbstractMusicNote initialAbstractMusicNote, int decrementQuantity, int expectedOctaveShift)
        {
            int returnedOctaveShift;
            initialAbstractMusicNote.Flattened(decrementQuantity, out returnedOctaveShift);
            Assert.AreEqual(expectedOctaveShift, returnedOctaveShift);
        }
    }
}
