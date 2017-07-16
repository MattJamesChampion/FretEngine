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
        public void MusicNote_WhenConstructingWithValidAbstractMusicNoteAndValidOctave_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            Assert.DoesNotThrow(() => {
                new MusicNote(testAbstractMusicNote, testOctave);
            });
        }

        [TestCase(AbstractMusicNote.CSharpDFlat)]
	    [TestCase(AbstractMusicNote.DSharpEFlat)]
	    [TestCase(AbstractMusicNote.ESharpFNatural)]
	    [TestCase(AbstractMusicNote.GNatural)]
	    [TestCase(AbstractMusicNote.ANatural)]
	    [TestCase(AbstractMusicNote.BNaturalCFlat)]
        public void MusicNote_WhenConstructingWithValidAbstractMusicNoteAndNoOctave_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote)
        {
            Assert.DoesNotThrow(() => {
                new MusicNote(testAbstractMusicNote);
            });
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, -0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 7)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -2)]
        [TestCase(AbstractMusicNote.ANatural, 12)]
        public void MusicNote_WhenConstructingWithValidAbstractMusicNoteAndValidOctave_ShouldContainCorrectValues(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsTrue((testMusicNote.Value == testAbstractMusicNote) && (testMusicNote.Octave == testOctave));
        }

        [TestCase(AbstractMusicNote.ESharpFNatural)]
        [TestCase(AbstractMusicNote.DNatural)]
        [TestCase(AbstractMusicNote.BNaturalCFlat)]
        [TestCase(AbstractMusicNote.ANatural)]
        [TestCase(AbstractMusicNote.ENaturalFFlat)]
        [TestCase(AbstractMusicNote.GSharpAFlat)]
        public void MusicNote_WhenConstructingWithValidAbstractMusicNoteAndNoOctave_ShouldContainCorrectValues(AbstractMusicNote testAbstractMusicNote)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote);

            Assert.IsTrue(testMusicNote.Value == testAbstractMusicNote);
        }

        [TestCase(AbstractMusicNote.DNatural, 4)]
        [TestCase(AbstractMusicNote.GNatural, 1)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 20)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -7)]
        [TestCase(AbstractMusicNote.ANatural, 0)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -0)]
        public void ToString_WhenCalledOnAValidMusicNote_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.DoesNotThrow(() =>
            {
                testMusicNote.ToString();
            });
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 0)]
        [TestCase(AbstractMusicNote.DNatural, -4)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 2)]
        public void Equals_WhenComparingWithNullCastAsObject_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            MusicNote secondMusicNote = null;

            Assert.IsFalse(firstMusicNote.Equals((object)secondMusicNote));
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 3)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 14)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 7)]
        [TestCase(AbstractMusicNote.ANatural, 3)]
        [TestCase(AbstractMusicNote.DNatural, -20)]
        public void Equals_WhenComparingEqualMusicNotesCastAsObject_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsTrue(firstMusicNote.Equals((object)secondMusicNote));
        }

        [TestCase(AbstractMusicNote.GNatural, 2, AbstractMusicNote.GNatural, 1)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 4, AbstractMusicNote.BNaturalCFlat, 4)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 8, AbstractMusicNote.ENaturalFFlat, 7)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -12, AbstractMusicNote.BNaturalCFlat, 12)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 0, AbstractMusicNote.ESharpFNatural, 20)]
        public void Equals_WhenComparingUnequalMusicNotesCastAsObject_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsFalse(firstMusicNote.Equals((object)secondMusicNote));
        }

        [TestCase(AbstractMusicNote.ANatural, 8)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0)]
        public void Equals_WhenComparingWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            MusicNote secondMusicNote = null;

            Assert.IsFalse(firstMusicNote.Equals(secondMusicNote));
        }

        [TestCase(AbstractMusicNote.GNatural, 30)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -4)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 12)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0)]
        [TestCase(AbstractMusicNote.DNatural, 2)]
        public void Equals_WhenComparingEqualMusicNotes_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsTrue(firstMusicNote.Equals(secondMusicNote));
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 7, AbstractMusicNote.GSharpAFlat, -7)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, AbstractMusicNote.ENaturalFFlat, 1)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 4, AbstractMusicNote.CSharpDFlat, 4)]
        [TestCase(AbstractMusicNote.GNatural, 20, AbstractMusicNote.GNatural, 19)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -10, AbstractMusicNote.ESharpFNatural, 10)]
        public void Equals_WhenComparingUnequalMusicNotes_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsFalse(firstMusicNote.Equals(secondMusicNote));
        }

        [TestCase(AbstractMusicNote.DNatural, 9)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 13)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 1)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -4)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0)]
        public void GetHashCode_WhenGeneratedForEqualMusicNotes_ShouldBeEqual(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.AreEqual(firstMusicNote.GetHashCode(), secondMusicNote.GetHashCode());
        }

        [TestCase(AbstractMusicNote.DNatural, 9, AbstractMusicNote.CSharpDFlat, 2)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 13, AbstractMusicNote.BNaturalCFlat, 2)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 1, AbstractMusicNote.GSharpAFlat, 2)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -4, AbstractMusicNote.CSharpDFlat, 4)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, AbstractMusicNote.ESharpFNatural, 0)]
        public void GetHashCode_WhenGeneratedForUnequalMusicNotes_ShouldNotBeEqual(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.AreNotEqual(firstMusicNote.GetHashCode(), secondMusicNote.GetHashCode());
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 1)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 40)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -3)]
        public void EqualityOperator_WhenComparingWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsFalse(testMusicNote == null);
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, 4)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 50)]
        [TestCase(AbstractMusicNote.GNatural, -12)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0)]
        [TestCase(AbstractMusicNote.ANatural, 2)]
        public void EqualityOperator_WhenComparingEqualMusicNotes_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsTrue(firstMusicNote == secondMusicNote);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 90, AbstractMusicNote.GSharpAFlat, 12)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 3, AbstractMusicNote.GNatural, 3)]
        [TestCase(AbstractMusicNote.ANatural, 17, AbstractMusicNote.DSharpEFlat, -17)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -20, AbstractMusicNote.ENaturalFFlat, 20)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 0, AbstractMusicNote.ENaturalFFlat, 0)]
        public void EqualityOperator_WhenComparingUnequalMusicNotes_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsFalse(firstMusicNote == secondMusicNote);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 3)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 20)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -1)]
        public void InequalityOperator_WhenComparingWithNull_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsTrue(testMusicNote != null);
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 9)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 1)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 12)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 7)]
        [TestCase(AbstractMusicNote.GNatural, 3)]
        public void InequalityOperator_WhenComparingEqualMusicNotes_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsFalse(firstMusicNote != secondMusicNote);
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 9, AbstractMusicNote.GSharpAFlat, 4)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 1, AbstractMusicNote.FSharpGFlat, 4)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 12, AbstractMusicNote.CSharpDFlat, -12)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 7, AbstractMusicNote.ENaturalFFlat, 7)]
        [TestCase(AbstractMusicNote.GNatural, 3, AbstractMusicNote.GNatural, 2)]
        public void InequalityOperator_WhenComparingUnequalMusicNotes_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote != secondMusicNote);
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 4, AbstractMusicNote.CSharpDFlat, 3)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 20, AbstractMusicNote.ANatural, 20)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 0, AbstractMusicNote.FSharpGFlat, -2)]
        [TestCase(AbstractMusicNote.GNatural, -4, AbstractMusicNote.BNaturalCFlat, -5)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 11, AbstractMusicNote.DNatural, -11)]
        public void CompareTo_WhenComparingUnequalMusicNotes_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote) > 0);
        }

        [TestCase(AbstractMusicNote.ASharpBFlat, 9)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -7)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 3)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 14)]
        public void CompareTo_WhenComparingEqualMusicNotes_ShouldReturnZero(AbstractMusicNote firstAbstractMusicNote, int firstOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote) == 0);
        }

        [TestCase(AbstractMusicNote.DNatural, 1, AbstractMusicNote.DNatural, 2)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0, AbstractMusicNote.BNaturalCFlat, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -7, AbstractMusicNote.ENaturalFFlat, 7)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 40, AbstractMusicNote.CSharpDFlat, 50)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 19, AbstractMusicNote.BNaturalCFlat, 20)]
        public void CompareTo_WhenComparingUnequalMusicNotes_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote) < 0);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 10)]
        [TestCase(AbstractMusicNote.ANatural, -32)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 3)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 47)]
        public void CompareTo_WhenComparingWithNull_ShouldReturnGreaterThanZero(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsTrue(testMusicNote.CompareTo(null) > 0);
        }

        [TestCase(AbstractMusicNote.DNatural, 3, AbstractMusicNote.DNatural, 2)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 5, AbstractMusicNote.BNaturalCFlat, 4)]
        [TestCase(AbstractMusicNote.ANatural, -3, AbstractMusicNote.GSharpAFlat, -4)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 10, AbstractMusicNote.FSharpGFlat, 9)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 30, AbstractMusicNote.BNaturalCFlat, -17)]
        public void GreaterThanOperator_WhenComparingUnequalMusicNotes_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote > secondMusicNote);
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, -15)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 0)]
        [TestCase(AbstractMusicNote.GNatural, 5)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -2)]
        [TestCase(AbstractMusicNote.DNatural, 14)]
        public void GreaterThanOperator_WhenComparingEqualMusicNotes_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsFalse(firstMusicNote > secondMusicNote);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 3, AbstractMusicNote.FSharpGFlat, 4)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -5, AbstractMusicNote.BSharpCNatural, 4)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 1, AbstractMusicNote.BSharpCNatural, 2)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 3, AbstractMusicNote.FSharpGFlat, 3)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 2, AbstractMusicNote.ASharpBFlat, 4)]
        public void GreaterThanOperator_WhenComparingUnequalMusicNotes_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsFalse(firstMusicNote > secondMusicNote);
        }

        [TestCase(AbstractMusicNote.DSharpEFlat, 24)]
        [TestCase(AbstractMusicNote.FSharpGFlat, -17)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 4)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 12)]
        public void GreaterThanOperator_WhenComparingWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsFalse(testMusicNote > null);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 4, AbstractMusicNote.ESharpFNatural, 5)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0, AbstractMusicNote.BNaturalCFlat, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 5, AbstractMusicNote.ANatural, 6)]
        [TestCase(AbstractMusicNote.GNatural, -10, AbstractMusicNote.ESharpFNatural, 4)]
        [TestCase(AbstractMusicNote.ANatural, 30, AbstractMusicNote.DSharpEFlat, 31)]
        public void LessThanOperator_WhenComparingUnequalMusicNotes_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote < secondMusicNote);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, -1)]
        [TestCase(AbstractMusicNote.ANatural, 3)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -9)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 11)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 0)]
        public void LessThanOperator_WhenComparingEqualMusicNotes_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsFalse(firstMusicNote < secondMusicNote);
        }

        [TestCase(AbstractMusicNote.DSharpEFlat, 12, AbstractMusicNote.FSharpGFlat, 11)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 4, AbstractMusicNote.ENaturalFFlat, 3)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -3, AbstractMusicNote.CSharpDFlat, -4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0, AbstractMusicNote.FSharpGFlat, -1)]
        [TestCase(AbstractMusicNote.ANatural, -14, AbstractMusicNote.ANatural, -14)]
        public void LessThanOperator_WhenComparingUnequalMusicNotes_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsFalse(firstMusicNote < secondMusicNote);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 9)]
        [TestCase(AbstractMusicNote.DNatural, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -6)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 20)]
        [TestCase(AbstractMusicNote.GNatural, 1)]
        public void LessThanOperator_WhenComparingWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsFalse(testMusicNote < null);
        }

        [TestCase(AbstractMusicNote.ANatural, 4, 1, AbstractMusicNote.ASharpBFlat, 4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 14, 0, AbstractMusicNote.FSharpGFlat, 14)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -2, 14, AbstractMusicNote.ASharpBFlat, -1)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 3, -7, AbstractMusicNote.ANatural, 2)]
        [TestCase(AbstractMusicNote.DNatural, 4, -0, AbstractMusicNote.DNatural, 4)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 30, -84, AbstractMusicNote.CSharpDFlat, 23)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -20, 12, AbstractMusicNote.BNaturalCFlat, -19)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 0, 5, AbstractMusicNote.ASharpBFlat, 0)]
        public void Sharpened_WhenGivenValidIncrementQuantity_ShouldUpdateCorrectly(AbstractMusicNote startNote, int startOctave, int incrementQuantity, AbstractMusicNote expectedAbstractMusicNote, int expectedOctave)
        {
            var initialMusicNote = new MusicNote(startNote, startOctave);
            var sharpenedMusicNote = initialMusicNote.Sharpened(incrementQuantity);

            var expectedMusicNote = new MusicNote(expectedAbstractMusicNote, expectedOctave);

            Assert.AreEqual(expectedMusicNote, sharpenedMusicNote);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 4, -18, AbstractMusicNote.BSharpCNatural, 6)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 20, 10, AbstractMusicNote.FSharpGFlat, 19)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -7, 5, AbstractMusicNote.ASharpBFlat, -8)]
        [TestCase(AbstractMusicNote.GNatural, 100, -40, AbstractMusicNote.BNaturalCFlat, 103)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 5, 2, AbstractMusicNote.ANatural, 5)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 12, 7, AbstractMusicNote.CSharpDFlat, 12)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0, 14, AbstractMusicNote.ASharpBFlat, -2)]
        [TestCase(AbstractMusicNote.ANatural, 3, 10, AbstractMusicNote.BNaturalCFlat, 2)]
        public void Flattened_WhenGivenValidDecrementQuantity_ShouldUpdateCorrectly(AbstractMusicNote startNote, int startOctave, int decrementQuantity, AbstractMusicNote expectedAbstractMusicNote, int expectedOctave)
        {
            var initialMusicNote = new MusicNote(startNote, startOctave);
            var flattenedMusicNote = initialMusicNote.Flattened(decrementQuantity);

            var expectedMusicNote = new MusicNote(expectedAbstractMusicNote, expectedOctave);

            Assert.AreEqual(expectedMusicNote, flattenedMusicNote);
        }
    }
}
