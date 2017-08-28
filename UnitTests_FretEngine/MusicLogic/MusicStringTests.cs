using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FretEngine.Common.DataTypes;
using FretEngine.Common.Exceptions;
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
        [TestCase(AbstractMusicNote.BNaturalCFlat, null)]
        public void MusicString_WhenConstructingWithValidMusicNote_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.DoesNotThrow(() =>
            {
                new MusicString(testMusicNote);
            });
        }

        [TestCase(AbstractMusicNote.GNatural, 0, 0)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 11, 4)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 8, 71)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -12, 13)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, 28)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -3, null)]
        [TestCase(AbstractMusicNote.DNatural, null, null)]
        public void MusicString_WhenConstructingWithValidMusicNoteAndLastPosition_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.DoesNotThrow(() =>
            {
                new MusicString(testMusicNote, testLastPosition);
            });
        }

        [Test]
        public void MusicString_WhenConstructingWithNullMusicNote_ShouldThrowArgumentException()
        {
            MusicNote testMusicNote = null;

            Assert.Throws<ArgumentException>(() =>
            {
                new MusicString(testMusicNote);
            });
        }

        [TestCase(0)]
        [TestCase(4)]
        [TestCase(37)]
        [TestCase(76)]
        [TestCase(123)]
        [TestCase(null)]
        public void MusicString_WhenConstructingWithNullMusicNoteAndValidLastPosition_ShouldThrowArgumentException(int? testLastPosition)
        {
            MusicNote testMusicNote = null;

            Assert.Throws<ArgumentException>(() =>
            {
                new MusicString(testMusicNote, testLastPosition);
            });
        }

        [TestCase(AbstractMusicNote.DSharpEFlat, 0, -7)]
        [TestCase(AbstractMusicNote.GNatural, -4, -12)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 17, -1)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, -3)]
        public void MusicString_WhenConstructingWithValidMusicNoteAndInvalidLastPosition_ShouldThrowArgumentException(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.Throws<ArgumentException>(() =>
            {
                new MusicString(testMusicNote, testLastPosition);
            });
        }

        [TestCase(-1)]
        [TestCase(-12)]
        [TestCase(-30)]
        [TestCase(-47)]
        [TestCase(-100)]
        public void MusicString_WhenConstructingWithNullMusicNoteAndInvalidLastPosition_ShouldThrowArgumentException(int? testLastPosition)
        {
            MusicNote testMusicNote = null;

            Assert.Throws<ArgumentException>(() =>
            {
                new MusicString(testMusicNote, testLastPosition);
            });
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, 4)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 17)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 2)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -8)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null)]
        public void MusicString_WhenConstructingWithValidMusicNote_ShouldContainCorrectValues(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote);

            Assert.AreEqual(testMusicNote, testMusicString.RootNote);
        }

        [TestCase(AbstractMusicNote.ANatural, 14, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, 16)]
        [TestCase(AbstractMusicNote.DNatural, -8, 4)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 3, 51)]
        [TestCase(AbstractMusicNote.GNatural, -20, 40)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, 5)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 9, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, null)]
        public void MusicString_WhenConstructingWithValidMusicNoteAndLastPosition_ShouldContainCorrectMusicNote(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.AreEqual(testMusicNote, testMusicString.RootNote);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 16, 40)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 4, 0)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, 6)]
        [TestCase(AbstractMusicNote.ANatural, -12, 28)]
        [TestCase(AbstractMusicNote.GNatural, -2, 11)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, 37)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 11, null)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, null)]
        public void MusicString_WhenConstructingWithValidMusicNoteAndLastPosition_ShouldContainCorrectLastPosition(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.AreEqual(testLastPosition, testMusicString.LastPosition);
        }

        [TestCase(AbstractMusicNote.DNatural, 4, 30)]
        [TestCase(AbstractMusicNote.GNatural, 1, 6)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 20, 4)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -7, 0)]
        [TestCase(AbstractMusicNote.ANatural, 0, 100)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -0, 80)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 17)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -18, null)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, null)]
        public void ToString_WhenCalledOnAValidMusicString_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.DoesNotThrow(() =>
            {
                testMusicString.ToString();
            });
        }
        
        [TestCase(AbstractMusicNote.GNatural, 2, 0)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 3, 10)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -6, 37)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 14, 109)]
        [TestCase(AbstractMusicNote.ANatural, 0, 18)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, 41)]
        [TestCase(AbstractMusicNote.DNatural, -21, null)]
        [TestCase(AbstractMusicNote.ASharpBFlat, null, null)]
        public void Equals_WhenComparingValidMusicStringsWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.IsFalse(testMusicString.Equals(null));
        }

        [TestCase(AbstractMusicNote.DNatural, 19, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -28, 14)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 4, 12)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 0, 2)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 7, 48)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, 125)]
        [TestCase(AbstractMusicNote.GNatural, -7, null)]
        [TestCase(AbstractMusicNote.ANatural, null, null)]
        public void Equals_WhenComparingEqualMusicStrings_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsTrue(firstMusicString.Equals(secondMusicString));
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 3, 10, AbstractMusicNote.GSharpAFlat, -3, 10)]
        [TestCase(AbstractMusicNote.GNatural, 5, 17, AbstractMusicNote.FSharpGFlat, 5, 17)]
        [TestCase(AbstractMusicNote.ANatural, 7, 38, AbstractMusicNote.ANatural, 7, 39)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 2, 50, AbstractMusicNote.ANatural, 19, 2)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 5, 100, AbstractMusicNote.ESharpFNatural, 6, 100)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 16, 12, AbstractMusicNote.BSharpCNatural, null, 10)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, 14, AbstractMusicNote.ENaturalFFlat, -23, null)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, 94, AbstractMusicNote.FSharpGFlat, null, 94)]
        [TestCase(AbstractMusicNote.DNatural, -17, null, AbstractMusicNote.DNatural, -17, 5)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -4, null, AbstractMusicNote.ENaturalFFlat, -4, null)]
        public void Equals_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsFalse(firstMusicString.Equals(secondMusicString));
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 5, 0)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -6, 100)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0, 17)]
        [TestCase(AbstractMusicNote.ANatural, 14, 65)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 2, 48)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, 10)]
        [TestCase(AbstractMusicNote.DNatural, -18, null)]
        [TestCase(AbstractMusicNote.GNatural, null, null)]
        public void Equals_WhenComparingMusicStringWithNullCastAsObject_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            MusicString secondMusicString = null;

            Assert.IsFalse(firstMusicString.Equals((object)secondMusicString));
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 4, 30)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 0, 5)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 14, 0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 19, 18)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -17, 75)]
        [TestCase(AbstractMusicNote.GNatural, null, 111)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -5, null)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, null)]
        public void Equals_WhenComparingEqualMusicStringsCastAsObject_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsTrue(firstMusicString.Equals((object)secondMusicString));
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 7, 100, AbstractMusicNote.CSharpDFlat, -7, 100)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, 47, AbstractMusicNote.ESharpFNatural, 0, 47)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 2, null, AbstractMusicNote.BNaturalCFlat, 2, 14)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 19, 31, AbstractMusicNote.GNatural, 9, 47)]
        [TestCase(AbstractMusicNote.GNatural, -4, 16, AbstractMusicNote.DSharpEFlat, -4, 0)]
        [TestCase(AbstractMusicNote.ANatural, 14, 71, AbstractMusicNote.DSharpEFlat, null, 72)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, 10, AbstractMusicNote.GSharpAFlat, -12, null)]
        [TestCase(AbstractMusicNote.GNatural, null, null, AbstractMusicNote.FSharpGFlat, null, 58)]
        public void Equals_WhenComparingUnequalMusicStringsCastAsObject_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsFalse(firstMusicString.Equals((object)secondMusicString));
        }

        [TestCase(AbstractMusicNote.GNatural, 2, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 7, 38)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, 151)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -9, 17)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 14, 98)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, 10)]
        public void GetHashCode_WhenGeneratedForEqualMusicStrings_ShouldBeEqual(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.AreEqual(firstMusicString.GetHashCode(), secondMusicString.GetHashCode());
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 3, 10, AbstractMusicNote.BNaturalCFlat, 4, 10)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, 4, AbstractMusicNote.ENaturalFFlat, 0, 14)]
        [TestCase(AbstractMusicNote.GNatural, 2, 7, AbstractMusicNote.BNaturalCFlat, 9, 51)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 8, 13, AbstractMusicNote.GNatural, 8, 13)]
        [TestCase(AbstractMusicNote.ANatural, 4, 51, AbstractMusicNote.ANatural, 4, null)]
        [TestCase(AbstractMusicNote.DNatural, -17, 30, AbstractMusicNote.DSharpEFlat, null, 17)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, 5, AbstractMusicNote.ASharpBFlat, 18, 0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, 38, AbstractMusicNote.GNatural, null, 38)]
        public void GetHashCode_WhenGeneratedForUnequalMusicStrings_ShouldNotBeEqual(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.AreNotEqual(firstMusicString.GetHashCode(), secondMusicString.GetHashCode());
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, -4, 10)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 2, 38)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -0, 0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 4, 15)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 17, 100)]
        [TestCase(AbstractMusicNote.ESharpFNatural, null, 54)]
        [TestCase(AbstractMusicNote.ANatural, -30, null)]
        [TestCase(AbstractMusicNote.DNatural, null, null)]
        public void EqualityOperator_WhenComparingMusicStringWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.IsFalse(testMusicString == null);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, -4, 10)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 3, 17)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0, 4)]
        [TestCase(AbstractMusicNote.ANatural, 6, 81)]
        [TestCase(AbstractMusicNote.DNatural, 15, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, 99)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -22, null)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, null)]
        public void EqualityOperator_WhenComparingEqualMusicStrings_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsTrue(firstMusicString == secondMusicString);
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, -4, 10, AbstractMusicNote.BSharpCNatural, 4, 10)]
        [TestCase(AbstractMusicNote.DNatural, 3, null, AbstractMusicNote.DNatural, 3, 10)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, 18, AbstractMusicNote.GSharpAFlat, 0, 18)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -2, 36, AbstractMusicNote.GSharpAFlat, -7, 39)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 5, 28, AbstractMusicNote.BSharpCNatural, 3, 61)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 13, 24, AbstractMusicNote.ENaturalFFlat, null, 72)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, 18, AbstractMusicNote.FSharpGFlat, -17, null)]
        [TestCase(AbstractMusicNote.GNatural, null, 19, AbstractMusicNote.ASharpBFlat, null, 21)]
        public void EqualityOperator_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsFalse(firstMusicString == secondMusicString);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 1, 9)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 9, 0)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, 39)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 14, 17)]
        [TestCase(AbstractMusicNote.GNatural, -12, 8)]
        [TestCase(AbstractMusicNote.DNatural, null, 14)]
        [TestCase(AbstractMusicNote.FSharpGFlat, -22, null)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, null)]
        public void InequalityOperator_WhenComparingMusicStringWithNull_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.IsTrue(testMusicString != null);
        }

        [TestCase(AbstractMusicNote.GNatural, 7, 109)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 5, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -24, 17)]
        [TestCase(AbstractMusicNote.ANatural, 0, 4)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 19, 13)]
        [TestCase(AbstractMusicNote.DNatural, null, 68)]
        public void InequalityOperator_WhenComparingEqualMusicStrings_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsFalse(firstMusicString != secondMusicString);
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, 12, null, AbstractMusicNote.BSharpCNatural, 3, 51)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 4, 3, AbstractMusicNote.DSharpEFlat, -8, 18)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 6, 37, AbstractMusicNote.BNaturalCFlat, 16, 37)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 3, 61, AbstractMusicNote.BNaturalCFlat, 3, 61)]
        [TestCase(AbstractMusicNote.DNatural, 17, 10, AbstractMusicNote.DNatural, 17, 100)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 19, null, AbstractMusicNote.DNatural, null, 11)]
        [TestCase(AbstractMusicNote.GNatural, null, 14, AbstractMusicNote.GSharpAFlat, -9, 18)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, 75, AbstractMusicNote.CSharpDFlat, null, null)]
        public void InequalityOperator_WhenComparingUnequalMusicStrings_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);
            
            Assert.IsTrue(firstMusicString != secondMusicString);
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, 3, 10, AbstractMusicNote.BSharpCNatural, 2, 10)]
        [TestCase(AbstractMusicNote.GNatural, 1, 30, AbstractMusicNote.GNatural, 1, 12)]
        [TestCase(AbstractMusicNote.ANatural, 2, 14, AbstractMusicNote.GSharpAFlat, 2, 14)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 30, 68, AbstractMusicNote.GNatural, -9, null)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 0, 22, AbstractMusicNote.BSharpCNatural, 0, 22)]
        [TestCase(AbstractMusicNote.GNatural, 8, 108, AbstractMusicNote.DSharpEFlat, 8, 55)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 11, 19, AbstractMusicNote.ESharpFNatural, null, 12)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -6, 0, AbstractMusicNote.BSharpCNatural, null, null)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, null, AbstractMusicNote.DNatural, null, 2)]
        public void CompareTo_WhenComparingUnequalMusicStringsCastAsObject_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsTrue(firstMusicString.CompareTo((object)secondMusicString) > 0);
        }

        [TestCase(AbstractMusicNote.DSharpEFlat, 5, 0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 13, 101)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 1, 51)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -7, 48)]
        [TestCase(AbstractMusicNote.GNatural, 0, 93)]
        [TestCase(AbstractMusicNote.DNatural, null, 55)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -28, null)]
        [TestCase(AbstractMusicNote.ANatural, null, null)]
        public void CompareTo_WhenComparingEqualMusicStringsCastAsObject_ShouldReturnZero(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsTrue(firstMusicString.CompareTo((object)secondMusicString) == 0);
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, -9, 73, AbstractMusicNote.CSharpDFlat, 9, 73)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 1, 54, AbstractMusicNote.FSharpGFlat, 1, 69)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 5, 31, AbstractMusicNote.BNaturalCFlat, 5, 31)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 0, 46, AbstractMusicNote.BNaturalCFlat, 8, 22)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -12, 44, AbstractMusicNote.CSharpDFlat, -4, 89)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, 0, AbstractMusicNote.ENaturalFFlat, 4, null)]
        [TestCase(AbstractMusicNote.GNatural, null, 1, AbstractMusicNote.BSharpCNatural, -7, null)]
        [TestCase(AbstractMusicNote.DNatural, null, null, AbstractMusicNote.ESharpFNatural, null, 11)]
        public void CompareTo_WhenComparingUnequalMusicStringsCastAsObject_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsTrue(firstMusicString.CompareTo((object)secondMusicString) < 0);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 0, 0)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 14, 18)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 6, 22)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 7, 84)]
        [TestCase(AbstractMusicNote.ANatural, -9, 33)]
        [TestCase(AbstractMusicNote.ASharpBFlat, null, 2)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -13, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, null)]
        public void CompareTo_WhenComparingMusicStringWithNullCastAsObject_ShouldReturnGreaterThanZero(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            MusicString secondMusicString = null;

            Assert.IsTrue(firstMusicString.CompareTo((object)secondMusicString) > 0);
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 2, 78)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 19, 2)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 6, 83)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -8, 15)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, 66)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 20)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -14, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, null)]
        public void CompareTo_WhenComparingMusicStringWithNonMusicStringCastAsObject_ShouldThrowArgumentException(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicString = "Test";

            Assert.Throws<ArgumentException>(() => {
                firstMusicString.CompareTo(secondMusicString);
            });
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 0, 0, AbstractMusicNote.FSharpGFlat, -8, 0)]
        [TestCase(AbstractMusicNote.DNatural, -8, 14, AbstractMusicNote.DNatural, -8, 1)]
        [TestCase(AbstractMusicNote.GNatural, 7, 6, AbstractMusicNote.BSharpCNatural, 7, 6)]
        [TestCase(AbstractMusicNote.GNatural, 12, 38, AbstractMusicNote.ENaturalFFlat, 9, 22)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 2, null, AbstractMusicNote.ESharpFNatural, 2, 15)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 9, 44, AbstractMusicNote.GSharpAFlat, null, null)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -20, 72, AbstractMusicNote.DSharpEFlat, null, 63)]
        [TestCase(AbstractMusicNote.ANatural, null, null, AbstractMusicNote.DSharpEFlat, null, null)]
        public void CompareTo_WhenComparingUnequalMusicStrings_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsTrue(firstMusicString.CompareTo(secondMusicString) > 0);
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, 2, 62)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -8, 1)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 6, 8)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 22, 44)]
        [TestCase(AbstractMusicNote.GNatural, 0, 247)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, 61)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -30, null)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, null)]
        public void CompareTo_WhenComparingEqualMusicStrings_ShouldReturnZero(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsTrue(firstMusicString.CompareTo(secondMusicString) == 0);
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, 9, 93, AbstractMusicNote.ENaturalFFlat, 11, 58)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -17, 55, AbstractMusicNote.GSharpAFlat, -7, 55)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 2, 12, AbstractMusicNote.BNaturalCFlat, 3, 12)]
        [TestCase(AbstractMusicNote.DNatural, 0, 0, AbstractMusicNote.GNatural, 0, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 1, null, AbstractMusicNote.ENaturalFFlat, 1, 6)]
        [TestCase(AbstractMusicNote.GNatural, null, 214, AbstractMusicNote.DNatural, 15, 64)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 44, AbstractMusicNote.ASharpBFlat, -14, 49)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, 95, AbstractMusicNote.ANatural, null, 61)]
        public void CompareTo_WhenComparingUnequalMusicStrings_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsTrue(firstMusicString.CompareTo(secondMusicString) < 0);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 7, 11)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 15, 0)]
        [TestCase(AbstractMusicNote.ANatural, 0, 30)]
        [TestCase(AbstractMusicNote.GNatural, 9, 77)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -5, 17)]
        [TestCase(AbstractMusicNote.DNatural, null, 48)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 23, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, null)]
        public void CompareTo_WhenComparingMusicStringWithNull_ShouldReturnGreaterThanZero(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            MusicString secondMusicString = null;

            Assert.IsTrue(firstMusicString.CompareTo(secondMusicString) > 0);
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 13, 18, AbstractMusicNote.BSharpCNatural, 13, 18)]
        [TestCase(AbstractMusicNote.ANatural, 0, 22, AbstractMusicNote.DSharpEFlat, -2, 22)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 10, 49, AbstractMusicNote.FSharpGFlat, 10, 41)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 4, 86, AbstractMusicNote.FSharpGFlat, 1, 27)]
        [TestCase(AbstractMusicNote.DNatural, 7, 84, AbstractMusicNote.DNatural, 6, 84)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 1, 51, AbstractMusicNote.CSharpDFlat, null, 42)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -19, 19, AbstractMusicNote.ENaturalFFlat, null, 27)]
        [TestCase(AbstractMusicNote.ASharpBFlat, null, 63, AbstractMusicNote.GNatural, null, 19)]
        public void GreaterThanOperator_WhenComparingUnequalMusicStrings_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsTrue(firstMusicString > secondMusicString);
        }

        [TestCase(AbstractMusicNote.GNatural, 12, 51)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 4, 0)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -9, 17)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 0, 38)]
        [TestCase(AbstractMusicNote.FSharpGFlat, -1, 4)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 12)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -22, null)]
        [TestCase(AbstractMusicNote.DNatural, null, null)]
        public void GreaterThanOperator_WhenComparingEqualMusicStrings_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsFalse(firstMusicString > secondMusicString);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 14, 7, AbstractMusicNote.GSharpAFlat, 15, 7)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 7, 15, AbstractMusicNote.ESharpFNatural, 7, 15)]
        [TestCase(AbstractMusicNote.DNatural, 3, 18, AbstractMusicNote.FSharpGFlat, 9, 107)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 0, 71, AbstractMusicNote.ENaturalFFlat, 14, 89)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 8, 53, AbstractMusicNote.BNaturalCFlat, 8, 97)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, null, AbstractMusicNote.GNatural, 10, 77)]
        [TestCase(AbstractMusicNote.ANatural, null, 83, AbstractMusicNote.CSharpDFlat, -11, 12)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 5, AbstractMusicNote.GNatural, null, null)]
        public void GreaterThanOperator_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsFalse(firstMusicString > secondMusicString);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 0, 99)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 17, 62)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 4, 294)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -8, 16)]
        [TestCase(AbstractMusicNote.FSharpGFlat, -2, 33)]
        [TestCase(AbstractMusicNote.GNatural, null, 8)]
        [TestCase(AbstractMusicNote.DNatural, -24, null)]
        [TestCase(AbstractMusicNote.ANatural, null, null)]
        public void GreaterThanOperator_WhenComparingMusicStringWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.IsFalse(testMusicString > null);
        }

        [TestCase(AbstractMusicNote.DNatural, 14, 0, AbstractMusicNote.DSharpEFlat, 14, 0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0, 24, AbstractMusicNote.FSharpGFlat, 6, 24)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 2, 8, AbstractMusicNote.DSharpEFlat, 2, 30)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 4, 42, AbstractMusicNote.GNatural, 7, 81)]
        [TestCase(AbstractMusicNote.ANatural, 8, 9, AbstractMusicNote.ENaturalFFlat, 10, null)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, 59, AbstractMusicNote.BNaturalCFlat, 11, 17)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, null, AbstractMusicNote.FSharpGFlat, -6, 0)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, 98, AbstractMusicNote.GNatural, null, 6)]
        public void LessThanOperator_WhenComparingUnequalMusicStrings_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsTrue(firstMusicString < secondMusicString);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 4, 17)]
        [TestCase(AbstractMusicNote.DNatural, 8, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 0, 4)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -9, 11)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 15, 30)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 84)]
        [TestCase(AbstractMusicNote.ANatural, -11, null)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, 47)]
        public void LessThanOperator_WhenComparingEqualMusicStrings_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsFalse(firstMusicString < secondMusicString);
        }

        [TestCase(AbstractMusicNote.ASharpBFlat, -9, 16, AbstractMusicNote.BNaturalCFlat, -11, 98)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 4, 76, AbstractMusicNote.ASharpBFlat, 4, 76)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, 19, AbstractMusicNote.DSharpEFlat, -2, null)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -5, null, AbstractMusicNote.BSharpCNatural, -6, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 10, 18, AbstractMusicNote.FSharpGFlat, 10, 7)]
        [TestCase(AbstractMusicNote.ANatural, 11, 19, AbstractMusicNote.CSharpDFlat, null, 108)]
        [TestCase(AbstractMusicNote.DNatural, -18, 6, AbstractMusicNote.DSharpEFlat, null, 8)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, 44, AbstractMusicNote.GNatural, null, 0)]
        public void LessThanOperator_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsFalse(firstMusicString < secondMusicString);
        }

        [TestCase(AbstractMusicNote.DNatural, 3, 78)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, 4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 8, 22)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -12, 0)]
        [TestCase(AbstractMusicNote.GNatural, 14, 19)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, 6)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -23, null)]
        [TestCase(AbstractMusicNote.ANatural, null, null)]
        public void LessThanOperator_WhenComparingMusicStringWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.IsFalse(testMusicString < null);
        }
        
        [TestCase(AbstractMusicNote.ESharpFNatural, 4, 73, AbstractMusicNote.BSharpCNatural, 4, 73)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 7, 13, AbstractMusicNote.FSharpGFlat, 2, 13)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -15, 38, AbstractMusicNote.BNaturalCFlat, -20, 7)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, 91, AbstractMusicNote.ASharpBFlat, 0, 37)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 9, 17, AbstractMusicNote.ESharpFNatural, -9, 0)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 8, null, AbstractMusicNote.BNaturalCFlat, null, 5)]
        [TestCase(AbstractMusicNote.DNatural, -1, 7, AbstractMusicNote.GNatural, null, 24)]
        [TestCase(AbstractMusicNote.GNatural, null, 12, AbstractMusicNote.FSharpGFlat, null, null)]
        public void GreaterThanOrEqualToOperator_WhenComparingUnequalMusicStrings_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsTrue(firstMusicString >= secondMusicString);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 16, 48)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 2, 16)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 0, 9)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -3, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, 10)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -31, null)]
        [TestCase(AbstractMusicNote.GNatural, null, null)]
        public void GreaterThanOrEqualToOperator_WhenComparingEqualMusicStrings_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsTrue(firstMusicString >= secondMusicString);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 9, 21, AbstractMusicNote.ANatural, 9, 21)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -17, 11, AbstractMusicNote.CSharpDFlat, 4, 11)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 6, 73, AbstractMusicNote.BSharpCNatural, 12, 39)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 0, 20, AbstractMusicNote.ESharpFNatural, 1, 66)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -3, 19, AbstractMusicNote.GSharpAFlat, -3, 31)]
        [TestCase(AbstractMusicNote.GNatural, null, 1, AbstractMusicNote.DNatural, 13, null)]
        [TestCase(AbstractMusicNote.DNatural, null, 70, AbstractMusicNote.ENaturalFFlat, -9, 70)]
        [TestCase(AbstractMusicNote.ESharpFNatural, null, 12, AbstractMusicNote.GNatural, null, 5)]
        public void GreaterThanOrEqualToOperator_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsFalse(firstMusicString >= secondMusicString);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 16, 56)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 5, 0)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -7, 4)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, 22)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, 7)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -18, null)]
        [TestCase(AbstractMusicNote.ANatural, null, null)]
        public void GreaterThanOrEqualToOperator_WhenComparingMusicStringWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.IsFalse(testMusicString >= null);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 4, null, AbstractMusicNote.DNatural, 8, 32)]
        [TestCase(AbstractMusicNote.GNatural, 14, 18, AbstractMusicNote.GSharpAFlat, 14, 18)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -8, 51, AbstractMusicNote.ENaturalFFlat, 10, 22)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 6, 19, AbstractMusicNote.ASharpBFlat, 6, 91)]
        [TestCase(AbstractMusicNote.ANatural, -5, 71, AbstractMusicNote.ANatural, 12, 71)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, 6, AbstractMusicNote.ENaturalFFlat, 5, 18)]
        [TestCase(AbstractMusicNote.DNatural, null, null, AbstractMusicNote.BNaturalCFlat, -18, 5)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, 8, AbstractMusicNote.ANatural, null, 66)]
        public void LessThanOrEqualToOperator_WhenComparingUnequalMusicStrings_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsTrue(firstMusicString <= secondMusicString);
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 8, 16)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -11, 108)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 20, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 0, 32)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, 48)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -18, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, null)]
        public void LessThanOrEqualToOperator_WhenComparingEqualMusicStrings_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote, testLastPosition);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote, testLastPosition);

            Assert.IsTrue(firstMusicString <= secondMusicString);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 5, 16, AbstractMusicNote.GNatural, 1, 9)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 14, 27, AbstractMusicNote.ENaturalFFlat, 14, 27)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -12, null, AbstractMusicNote.ASharpBFlat, -15, null)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 20, 48, AbstractMusicNote.CSharpDFlat, 20, 1)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 4, 5, AbstractMusicNote.ESharpFNatural, -7, 42)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 1, 28, AbstractMusicNote.CSharpDFlat, null, null)]
        [TestCase(AbstractMusicNote.GNatural, -7, 6, AbstractMusicNote.GNatural, null, 14)]
        [TestCase(AbstractMusicNote.DNatural, null, 28, AbstractMusicNote.BSharpCNatural, null, 9)]
        public void LessThanOrEqualToOperator_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, int? firstLastPosition, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int? secondLastPosition)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote, firstLastPosition);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote, secondLastPosition);

            Assert.IsFalse(firstMusicString <= secondMusicString);
        }

        [TestCase(AbstractMusicNote.ANatural, 17, 13)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 3, 201)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, 55)]
        [TestCase(AbstractMusicNote.GNatural, -8, 98)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, 12)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -6, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, null)]
        public void LessThanOrEqualToOperator_WhenComparingMusicStringWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, int? testLastPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote, testLastPosition);

            Assert.IsFalse(testMusicString <= null);
        }

        [TestCase(AbstractMusicNote.GNatural, 4, null, 17, AbstractMusicNote.BSharpCNatural, 6, null)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, 14, 3, AbstractMusicNote.CSharpDFlat, 1, 14)]
        [TestCase(AbstractMusicNote.DNatural, -7, 6, 74, AbstractMusicNote.ENaturalFFlat, -1, 6)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 23, 111, -23, AbstractMusicNote.BSharpCNatural, 22, 111)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 9, 25, 0, AbstractMusicNote.GSharpAFlat, 9, 25)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, 71, 19, AbstractMusicNote.BNaturalCFlat, null, 71)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 28, 2, AbstractMusicNote.DSharpEFlat, null, 28)]
        [TestCase(AbstractMusicNote.ANatural, null, 0, -8, AbstractMusicNote.CSharpDFlat, null, 0)]
        public void Sharpen_WhenGivenValidIncrementQuantity_ShouldUpdateCorrectly(AbstractMusicNote startNote, int? startOctave, int? startLastPosition, int incrementQuantity, AbstractMusicNote expectedAbstractMusicNote, int? expectedOctave, int? expectedLastPosition)
        {
            var expectedMusicNote = new MusicNote(expectedAbstractMusicNote, expectedOctave);
            var expectedMusicString = new MusicString(expectedMusicNote, expectedLastPosition);

            var actualMusicNote = new MusicNote(startNote, startOctave);
            var actualMusicString = new MusicString(actualMusicNote, startLastPosition);

            actualMusicString.Sharpen(incrementQuantity);

            Assert.AreEqual(expectedMusicString, actualMusicString);
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, 4, 21, AbstractMusicNote.GNatural, 2)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 7, 0, AbstractMusicNote.BNaturalCFlat, 7)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0, 7, AbstractMusicNote.BNaturalCFlat, -1)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -12, -20, AbstractMusicNote.ENaturalFFlat, -10)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 16, 72, AbstractMusicNote.DSharpEFlat, 10)]
        [TestCase(AbstractMusicNote.ESharpFNatural, null, 29, AbstractMusicNote.BSharpCNatural, null)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, 0, AbstractMusicNote.BSharpCNatural, null)]
        [TestCase(AbstractMusicNote.ANatural, null, -13, AbstractMusicNote.ASharpBFlat, null)]
        public void Flatten_WhenGivenValidDecrementQuantity_ShouldUpdateCorrectly(AbstractMusicNote startNote, int? startOctave, int decrementQuantity, AbstractMusicNote expectedAbstractMusicNote, int? expectedOctave)
        {
            var expectedMusicNote = new MusicNote(expectedAbstractMusicNote, expectedOctave);
            var expectedMusicString = new MusicString(expectedMusicNote);

            var actualMusicNote = new MusicNote(startNote, startOctave);
            var actualMusicString = new MusicString(actualMusicNote);

            actualMusicString.Flatten(decrementQuantity);

            Assert.AreEqual(expectedMusicString, actualMusicString);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(7)]
        [TestCase(54)]
        [TestCase(200)]
        public void IsValidMusicStringPosition_WhenGivenValidMusicStringPosition_ShouldReturnTrue(int musicStringPosition)
        {
            Assert.IsTrue(MusicString.IsValidMusicStringPosition(musicStringPosition));
        }

        [TestCase(-1)]
        [TestCase(-3)]
        [TestCase(-8)]
        [TestCase(-50)]
        [TestCase(-132)]
        public void IsValidMusicStringPosition_WhenGivenInvalidMusicStringPosition_ShouldReturnFalse(int musicStringPosition)
        {
            Assert.IsFalse(MusicString.IsValidMusicStringPosition(musicStringPosition));
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 4, 40, AbstractMusicNote.ANatural, 7)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 17, 12, AbstractMusicNote.BSharpCNatural, 18)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 0, 1, AbstractMusicNote.BSharpCNatural, 1)]
        [TestCase(AbstractMusicNote.GNatural, -12, 0, AbstractMusicNote.GNatural, -12)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 9, 92, AbstractMusicNote.BSharpCNatural, 17)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, 38, AbstractMusicNote.ASharpBFlat, null)]
        [TestCase(AbstractMusicNote.ASharpBFlat, null, 0, AbstractMusicNote.ASharpBFlat, null)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 86, AbstractMusicNote.DSharpEFlat, null)]
        public void GetMusicNoteAtMusicStringPosition_WhenGivenValidMusicStringPosition_ShouldReturnCorrectValues(AbstractMusicNote startAbstractMusicNote, int? startOctave, int musicStringPosition, AbstractMusicNote expectedAbstractMusicNote, int? expectedOctave)
        {
            var expectedMusicNote = new MusicNote(expectedAbstractMusicNote, expectedOctave);

            var testMusicNote = new MusicNote(startAbstractMusicNote, startOctave);
            var testMusicString = new MusicString(testMusicNote);

            var actualMusicNote = testMusicString.GetMusicNoteAtMusicStringPosition(musicStringPosition);

            Assert.AreEqual(expectedMusicNote, actualMusicNote);
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, 0, -1)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 4, -6)]
        [TestCase(AbstractMusicNote.GNatural, 14, -271)]
        [TestCase(AbstractMusicNote.ANatural, -12, -9)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 8, -30)]
        public void GetMusicNoteAtMusicStringPosition_WhenGivenInvalidMusicStringPosition_ShouldThrowInvalidMusicStringPositionException(AbstractMusicNote testAbstractMusicNote, int testOctave, int musicStringPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            Assert.Throws<MusicStringExceptions.InvalidMusicStringPositionException>(() => {
                testMusicString.GetMusicNoteAtMusicStringPosition(musicStringPosition);
            });
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 8, 0, 12)]
        [TestCase(AbstractMusicNote.ANatural, 0, 7, 7)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -6, 34, 37)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 17, 100, 200)]
        [TestCase(AbstractMusicNote.DNatural, 4, 2, 10)]
        [TestCase(AbstractMusicNote.GNatural, null, 11, 48)]
        public void GetMusicNotes_WhenGivenValidValues_ShouldReturnCorrectValues(AbstractMusicNote testAbstractMusicNote, int? testOctave, int startPosition, int endPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote);

            var expectedMusicNotes = new List<MusicNote>();
            var actualMusicNotes = new List<MusicNote>();

            for (var currentPosition = startPosition; currentPosition <= endPosition; currentPosition++)
            {
                var expectedMusicNote = testMusicString.RootNote.Sharpened(currentPosition);
                expectedMusicNotes.Add(expectedMusicNote);
            }

            foreach (var actualMusicNote in testMusicString.GetMusicNotes(startPosition, endPosition))
            {
                actualMusicNotes.Add(actualMusicNote);
            }

            Assert.AreEqual(expectedMusicNotes, actualMusicNotes);
        }

        [TestCase(AbstractMusicNote.GNatural, -8, 100, 10)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 5, 9, 8)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 0, 3, 2)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -2, 20, 10)]
        [TestCase(AbstractMusicNote.ANatural, 13, 7, 2)]
        [TestCase(AbstractMusicNote.DNatural, null, 18, 17)]
        public void GetMusicNotes_WhenEndPositionIsGreaterThanStartPosition_ShouldThrowArgumentException(AbstractMusicNote testAbstractMusicNote, int? testOctave, int startPosition, int endPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote);

            Assert.Throws<ArgumentException>(() =>
            {
                foreach (var musicNote in testMusicString.GetMusicNotes(startPosition, endPosition))
                {
                    //This loop is only required to trigger the exception.
                }
            });
        }

        [TestCase(AbstractMusicNote.GNatural, 8, -3, 20)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 21, -1, 7)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -7, -20, 2)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 14, -93, 12)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, -14, 0)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, -80, 16)]
        public void GetMusicNotes_WhenGivenInvalidStartPosition_ShouldThrowInvalidMusicStringPositionException(AbstractMusicNote testAbstractMusicNote, int? testOctave, int startPosition, int endPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote);

            Assert.Throws<MusicStringExceptions.InvalidMusicStringPositionException>(() =>
            {
                foreach (var musicNote in testMusicString.GetMusicNotes(startPosition, endPosition))
                {
                    //This loop is only required to trigger the exception.
                }
            });
        }

        [TestCase(AbstractMusicNote.DSharpEFlat, 17, 12, -1)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 4, 6, -8)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -3, 2, -200)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, 0, -49)]
        [TestCase(AbstractMusicNote.GNatural, -11, 50, -17)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, 17, -90)]
        public void GetMusicNotes_WhenGivenInvalidEndPosition_ShouldThrowInvalidMusicStringPositionException(AbstractMusicNote testAbstractMusicNote, int? testOctave, int startPosition, int endPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote);

            Assert.Throws<MusicStringExceptions.InvalidMusicStringPositionException>(() =>
            {
                foreach (var musicNote in testMusicString.GetMusicNotes(startPosition, endPosition))
                {
                    //This loop is only required to trigger the exception.
                }
            });
        }
        
        [TestCase(AbstractMusicNote.ESharpFNatural, -8, 0)]
        [TestCase(AbstractMusicNote.GNatural, 7, 5)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 5, 13)]
        [TestCase(AbstractMusicNote.ANatural, 0, 30)]
        [TestCase(AbstractMusicNote.DNatural, 19, 19)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, 47)]
        public void GetMusicNotes_WhenGivenValidEndPosition_ShouldReturnCorrectValues(AbstractMusicNote testAbstractMusicNote, int? testOctave, int endPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote);

            var expectedMusicNotes = new List<MusicNote>();
            var actualMusicNotes = new List<MusicNote>();

            for (var currentPosition = 0; currentPosition <= endPosition; currentPosition++)
            {
                var expectedMusicNote = testMusicString.RootNote.Sharpened(currentPosition);
                expectedMusicNotes.Add(expectedMusicNote);
            }

            foreach (var actualMusicNote in testMusicString.GetMusicNotes(endPosition))
            {
                actualMusicNotes.Add(actualMusicNote);
            }

            Assert.AreEqual(expectedMusicNotes, actualMusicNotes);
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, -1)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 15, -29)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 2, -7)]
        [TestCase(AbstractMusicNote.GNatural, 7, -96)]
        [TestCase(AbstractMusicNote.ANatural, -12, -4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, -35)]
        public void GetMusicNotes_WhenGivenInvalidEndPosition_ShouldThrowInvalidMusicStringPositionException(AbstractMusicNote testAbstractMusicNote, int? testOctave, int endPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            var testMusicString = new MusicString(testMusicNote);

            Assert.Throws<MusicStringExceptions.InvalidMusicStringPositionException>(() =>
            {
                foreach (var musicNote in testMusicString.GetMusicNotes(endPosition))
                {
                    //This loop is only required to trigger the exception.
                }
            });
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, -19, AbstractMusicNote.FSharpGFlat, -6)]
        [TestCase(AbstractMusicNote.DNatural, null, AbstractMusicNote.ESharpFNatural, null)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 4, AbstractMusicNote.ESharpFNatural, 4)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, AbstractMusicNote.ANatural, null)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, AbstractMusicNote.ASharpBFlat, 0)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.GNatural, null)]
        public void HasMusicNote_WhenGivenValidMusicNote_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave, AbstractMusicNote targetAbstractMusicNote, int? targetOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            var targetMusicNote = new MusicNote(targetAbstractMusicNote, targetOctave);

            Assert.IsTrue(testMusicString.HasMusicNote(targetMusicNote));
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, 19, AbstractMusicNote.ENaturalFFlat, 18)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 7, AbstractMusicNote.GNatural, 7)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -12, AbstractMusicNote.CSharpDFlat, -13)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 0, AbstractMusicNote.CSharpDFlat, -6)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -2, AbstractMusicNote.DSharpEFlat, -2)]
        public void HasMusicNote_WhenGivenNonexistentMusicNote_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, AbstractMusicNote targetAbstractMusicNote, int? targetOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            var targetMusicNote = new MusicNote(targetAbstractMusicNote, targetOctave);

            Assert.IsFalse(testMusicString.HasMusicNote(targetMusicNote));
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, null, AbstractMusicNote.DNatural, 0)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 3, AbstractMusicNote.DNatural, null)]
        [TestCase(AbstractMusicNote.ASharpBFlat, null, AbstractMusicNote.FSharpGFlat, -7)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 30, AbstractMusicNote.ANatural, null)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.GNatural, 19)]
        public void HasMusicNote_WhenGivenIncomparableMusicStringAndMusicNote_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave, AbstractMusicNote targetAbstractMusicNote, int? targetOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            var targetMusicNote = new MusicNote(targetAbstractMusicNote, targetOctave);

            Assert.IsFalse(testMusicString.HasMusicNote(targetMusicNote));
        }

        [TestCase(AbstractMusicNote.ANatural, 4, AbstractMusicNote.DNatural, 6, 17)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, AbstractMusicNote.GNatural, null, 11)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -9, AbstractMusicNote.BNaturalCFlat, -9, 7)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, AbstractMusicNote.ENaturalFFlat, null, 3)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 19, AbstractMusicNote.CSharpDFlat, 30, 130)]
        public void GetMusicStringPositionOfMusicNote_WhenGivenValidMusicNote_ShouldReturnCorrectMusicStringPosition(AbstractMusicNote testAbstractMusicNote, int? testOctave, AbstractMusicNote targetAbstractMusicNote, int? targetOctave, int expectedMusicStringPosition)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            var targetMusicNote = new MusicNote(targetAbstractMusicNote, targetOctave);

            var actualMusicStringPosition = testMusicString.GetMusicStringPositionOfMusicNote(targetMusicNote);

            Assert.AreEqual(expectedMusicStringPosition, actualMusicStringPosition);
        }

        [TestCase(AbstractMusicNote.DNatural, 4, AbstractMusicNote.DNatural, null)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, AbstractMusicNote.CSharpDFlat, -12)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 0, AbstractMusicNote.ASharpBFlat, null)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, AbstractMusicNote.BNaturalCFlat, -8)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 13, AbstractMusicNote.GSharpAFlat, null)]
        public void GetMusicStringPositionOfMusicNote_WhenGivenIncomparableMusicStringAndMusicNote_ShouldThrowInvalidMusicNoteComparisonException(AbstractMusicNote testAbstractMusicNote, int? testOctave, AbstractMusicNote targetAbstractMusicNote, int? targetOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            var targetMusicNote = new MusicNote(targetAbstractMusicNote, targetOctave);

            Assert.Throws<MusicNoteExceptions.InvalidMusicNoteComparisonException>(() =>
            {
                testMusicString.GetMusicStringPositionOfMusicNote(targetMusicNote);
            });
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 9, AbstractMusicNote.ESharpFNatural, 8)]
        [TestCase(AbstractMusicNote.DNatural, 10, AbstractMusicNote.CSharpDFlat, 10)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 11, AbstractMusicNote.GNatural, 7)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -6, AbstractMusicNote.DNatural, -9)]
        [TestCase(AbstractMusicNote.GNatural, 0, AbstractMusicNote.FSharpGFlat, 0)]
        public void GetMusicStringPositionOfMusicNote_WhenGivenMusicNoteNotFoundOnThisMusicString_ShouldThrowMusicStringHasNoSuchMusicNoteException(AbstractMusicNote testAbstractMusicNote, int? testOctave, AbstractMusicNote targetAbstractMusicNote, int? targetOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            var targetMusicNote = new MusicNote(targetAbstractMusicNote, targetOctave);

            Assert.Throws<MusicStringExceptions.MusicStringHasNoSuchMusicNoteException>(() =>
            {
                testMusicString.GetMusicStringPositionOfMusicNote(targetMusicNote);
            });
        }
    }
}
