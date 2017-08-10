using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using FretEngine.Common.DataTypes;
using FretEngine.MusicLogic;
using FretEngine.Common.Exceptions;

namespace UnitTests_FretEngine.MusicLogic
{
    [TestFixture]
    class MusicNoteTests
    {
        [TestCase(AbstractMusicNote.BSharpCNatural, 0)]
        [TestCase(AbstractMusicNote.DNatural, -7)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 17)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 8)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 10)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null)]
        public void MusicNote_WhenConstructingWithValidAbstractMusicNoteAndValidOctave_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.DNatural, null)]
        public void MusicNote_WhenConstructingWithValidAbstractMusicNoteAndValidOctave_ShouldContainCorrectValues(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.CSharpDFlat, null)]
        public void ToString_WhenCalledOnAValidMusicNote_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.BSharpCNatural, null)]
        public void Equals_WhenComparingMusicNoteWithNullCastAsObject_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.CSharpDFlat, null)]
        public void Equals_WhenComparingEqualMusicNotesCastAsObject_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.FSharpGFlat, 7)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -3, AbstractMusicNote.CSharpDFlat, null)]
        [TestCase(AbstractMusicNote.DNatural, null, AbstractMusicNote.BSharpCNatural, null)]
        public void Equals_WhenComparingUnequalMusicNotesCastAsObject_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsFalse(firstMusicNote.Equals((object)secondMusicNote));
        }

        [TestCase(AbstractMusicNote.ANatural, 8)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0)]
        [TestCase(AbstractMusicNote.GNatural, null)]
        public void Equals_WhenComparingMusicNoteWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.FSharpGFlat, null)]
        public void Equals_WhenComparingEqualMusicNotes_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.ANatural, null, AbstractMusicNote.FSharpGFlat, 9)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -8, AbstractMusicNote.BSharpCNatural, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, AbstractMusicNote.DSharpEFlat, null)]
        public void Equals_WhenComparingUnequalMusicNotes_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.GSharpAFlat, null)]
        public void GetHashCode_WhenGeneratedForEqualMusicNotes_ShouldBeEqual(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.ANatural, null, AbstractMusicNote.FSharpGFlat, -7)]
        [TestCase(AbstractMusicNote.GNatural, 8, AbstractMusicNote.GNatural, null)]
        [TestCase(AbstractMusicNote.DNatural, null, AbstractMusicNote.BSharpCNatural, null)]
        public void GetHashCode_WhenGeneratedForUnequalMusicNotes_ShouldNotBeEqual(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.AreNotEqual(firstMusicNote.GetHashCode(), secondMusicNote.GetHashCode());
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 1)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 40)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -3)]
        [TestCase(AbstractMusicNote.GNatural, null)]
        public void EqualityOperator_WhenComparingMusicNoteWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsFalse(testMusicNote == null);
        }

        [Test]
        public void EqualityOperator_WhenComparingBothNull_ShouldReturnTrue()
        {
            MusicNote firstMusicNote = null;
            MusicNote secondMusicNote = null;

            Assert.IsTrue(firstMusicNote == secondMusicNote);
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, 4)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 50)]
        [TestCase(AbstractMusicNote.GNatural, -12)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0)]
        [TestCase(AbstractMusicNote.ANatural, 2)]
        [TestCase(AbstractMusicNote.GNatural, null)]
        public void EqualityOperator_WhenComparingEqualMusicNotes_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, AbstractMusicNote.GNatural, -14)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 6, AbstractMusicNote.BSharpCNatural, null)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.DSharpEFlat, null)]
        public void EqualityOperator_WhenComparingUnequalMusicNotes_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsFalse(firstMusicNote == secondMusicNote);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 3)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 20)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -1)]
        [TestCase(AbstractMusicNote.ANatural, null)]
        public void InequalityOperator_WhenComparingMusicNoteWithNull_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsTrue(testMusicNote != null);
        }

        [Test]
        public void InequalityOperator_WhenComparingBothNull_ShouldReturnFalse()
        {
            MusicNote firstMusicNote = null;
            MusicNote secondMusicNote = null;

            Assert.IsFalse(firstMusicNote != secondMusicNote);
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 9)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 1)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 12)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 7)]
        [TestCase(AbstractMusicNote.GNatural, 3)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null)]
        public void InequalityOperator_WhenComparingEqualMusicNotes_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.DNatural, null, AbstractMusicNote.CSharpDFlat, -26)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 30, AbstractMusicNote.DSharpEFlat, null)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, AbstractMusicNote.GNatural, null)]
        public void InequalityOperator_WhenComparingUnequalMusicNotes_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote != secondMusicNote);
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, 3, AbstractMusicNote.BSharpCNatural, 2)]
        [TestCase(AbstractMusicNote.GNatural, 16, AbstractMusicNote.GNatural, 15)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 4, AbstractMusicNote.BNaturalCFlat, -4)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -9, AbstractMusicNote.BSharpCNatural, -9)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 13, AbstractMusicNote.CSharpDFlat, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 11, AbstractMusicNote.GNatural, null)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -17, AbstractMusicNote.GNatural, null)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, AbstractMusicNote.CSharpDFlat, null)]
        public void CompareTo_WhenComparingUnequalMusicNotesCastAsObject_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote.CompareTo((object)secondMusicNote) > 0);
        }

        [TestCase(AbstractMusicNote.GNatural, 2)]
        [TestCase(AbstractMusicNote.FSharpGFlat, -9)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 0)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -14)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 7)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null)]
        public void CompareTo_WhenComparingEqualMusicNotesCastAsObject_ShouldReturnZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);

            Assert.IsTrue(firstMusicNote.CompareTo((object)secondMusicNote) == 0);
        }

        [TestCase(AbstractMusicNote.GNatural, 3, AbstractMusicNote.GNatural, 4)]
        [TestCase(AbstractMusicNote.DNatural, 17, AbstractMusicNote.DSharpEFlat, 17)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -8, AbstractMusicNote.ENaturalFFlat, 8)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -1, AbstractMusicNote.GSharpAFlat, 0)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -2, AbstractMusicNote.ESharpFNatural, 4)]
        [TestCase(AbstractMusicNote.ESharpFNatural, null, AbstractMusicNote.GSharpAFlat, 5)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, AbstractMusicNote.ESharpFNatural, -14)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.ANatural, null)]
        public void CompareTo_WhenComparingUnequalMusicNotesCastAsObject_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote.CompareTo((object)secondMusicNote) < 0);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 14)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 2)]
        [TestCase(AbstractMusicNote.ANatural, 0)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -3)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -6)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null)]
        public void CompareTo_WhenComparingMusicNoteWithNullCastAsObject_ShouldReturnGreaterThanZero(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            MusicNote secondMusicNote = null;

            Assert.IsTrue(firstMusicNote.CompareTo((object)secondMusicNote) > 0);
        }

        [TestCase(AbstractMusicNote.GNatural, 4)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 17)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 0)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -2)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -9)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null)]
        public void CompareTo_WhenComparingWithNonMusicNoteCastAsObject_ShouldThrowArgumentException(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicNote = "Test";

            Assert.Throws<ArgumentException>(() => {
                firstMusicNote.CompareTo(secondMusicNote);
            });
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 4, AbstractMusicNote.CSharpDFlat, 3)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 20, AbstractMusicNote.ANatural, 20)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 0, AbstractMusicNote.FSharpGFlat, -2)]
        [TestCase(AbstractMusicNote.GNatural, -4, AbstractMusicNote.BNaturalCFlat, -5)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 11, AbstractMusicNote.DNatural, -11)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -18, AbstractMusicNote.GNatural, null)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 14, AbstractMusicNote.BNaturalCFlat, null)]
        [TestCase(AbstractMusicNote.ANatural, null, AbstractMusicNote.GNatural, null)]
        public void CompareTo_WhenComparingUnequalMusicNotes_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.BNaturalCFlat, null)]
        public void CompareTo_WhenComparingEqualMusicNotes_ShouldReturnZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave)
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
        [TestCase(AbstractMusicNote.ANatural, null, AbstractMusicNote.DNatural, -2)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, AbstractMusicNote.ENaturalFFlat, 5)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, AbstractMusicNote.GNatural, null)]
        public void CompareTo_WhenComparingUnequalMusicNotes_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.FSharpGFlat, null)]
        public void CompareTo_WhenComparingMusicNoteWithNull_ShouldReturnGreaterThanZero(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            MusicNote secondMusicNote = null;

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote) > 0);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 3, AbstractMusicNote.BNaturalCFlat, 1)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 30, AbstractMusicNote.BNaturalCFlat, 5)]
        [TestCase(AbstractMusicNote.DNatural, -16, AbstractMusicNote.ENaturalFFlat, -9)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 16, AbstractMusicNote.ANatural, null)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, AbstractMusicNote.GNatural, -12)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, AbstractMusicNote.DSharpEFlat, null)]
        public void CompareTo_WhenComparingUnequalValuesWithCompareOctaveSetToFalse_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var compareOctave = false;

            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote, compareOctave) < 0);
        }

        [TestCase(AbstractMusicNote.ANatural, 4, -4)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 7, 7)]
        [TestCase(AbstractMusicNote.DNatural, 12, -1)]
        [TestCase(AbstractMusicNote.DNatural, -3, -11)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, null)]
        [TestCase(AbstractMusicNote.GNatural, null, -8)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, null)]
        public void CompareTo_WhenComparingEqualValuesWithCompareOctaveSetToFalse_ShouldReturnZero(AbstractMusicNote testAbstractMusicNote, int? firstOctave, int? secondOctave)
        {
            var compareOctave = false;

            var firstMusicNote = new MusicNote(testAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(testAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote, compareOctave) == 0);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 14, AbstractMusicNote.DSharpEFlat, 7)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -12, AbstractMusicNote.DSharpEFlat, 18)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 0, AbstractMusicNote.ENaturalFFlat, 0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, AbstractMusicNote.ESharpFNatural, 6)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -9, AbstractMusicNote.BSharpCNatural, null)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, AbstractMusicNote.BSharpCNatural, null)]
        public void CompareTo_WhenComparingUnequalValuesWithCompareOctaveSetToFalse_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var compareOctave = false;

            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote, compareOctave) > 0);
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 5, AbstractMusicNote.FSharpGFlat, 7)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 8, AbstractMusicNote.GNatural, 8)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, AbstractMusicNote.ASharpBFlat, null)]
        [TestCase(AbstractMusicNote.GNatural, -18, AbstractMusicNote.DSharpEFlat, 0)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -8, AbstractMusicNote.DNatural, -3)]
        public void CompareTo_WhenComparingUnequalValuesWithCompareOctaveSetToTrue_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var compareOctave = true;

            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote, compareOctave) < 0);
        }

        [TestCase(AbstractMusicNote.DNatural, 4)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 19)]
        [TestCase(AbstractMusicNote.ANatural, 0)]
        [TestCase(AbstractMusicNote.GNatural, -12)]
        public void CompareTo_WhenComparingEqualValuesWithCompareOctaveSetToTrue_ShouldReturnZero(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var compareOctave = true;

            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote, compareOctave) == 0);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 0, AbstractMusicNote.ENaturalFFlat, 0)]
        [TestCase(AbstractMusicNote.DNatural, null, AbstractMusicNote.CSharpDFlat, null)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 17, AbstractMusicNote.FSharpGFlat, 8)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -6, AbstractMusicNote.ENaturalFFlat, -14)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 2, AbstractMusicNote.DNatural, -1)]
        public void CompareTo_WhenComparingUnequalValuesWithCompareOctaveSetToTrue_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var compareOctave = true;

            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.IsTrue(firstMusicNote.CompareTo(secondMusicNote, compareOctave) > 0);
        }

        [TestCase(AbstractMusicNote.DNatural, 3, AbstractMusicNote.DNatural, 2)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 5, AbstractMusicNote.BNaturalCFlat, 4)]
        [TestCase(AbstractMusicNote.ANatural, -3, AbstractMusicNote.GSharpAFlat, -4)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 10, AbstractMusicNote.FSharpGFlat, 9)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 30, AbstractMusicNote.BNaturalCFlat, -17)]
        [TestCase(AbstractMusicNote.FSharpGFlat, -18, AbstractMusicNote.BSharpCNatural, null)]
        [TestCase(AbstractMusicNote.DNatural, 14, AbstractMusicNote.DNatural, null)]
        [TestCase(AbstractMusicNote.ASharpBFlat, null, AbstractMusicNote.GNatural, null)]
        public void GreaterThanOperator_WhenComparingUnequalMusicNotes_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.ENaturalFFlat, null)]
        public void GreaterThanOperator_WhenComparingEqualMusicNotes_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.ANatural, null, AbstractMusicNote.GNatural, -10)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, AbstractMusicNote.ESharpFNatural, 18)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.BNaturalCFlat, null)]
        public void GreaterThanOperator_WhenComparingUnequalMusicNotes_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.ANatural, null)]
        public void GreaterThanOperator_WhenComparingMusicNoteWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);

            Assert.IsFalse(testMusicNote > null);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 4, AbstractMusicNote.ESharpFNatural, 5)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0, AbstractMusicNote.BNaturalCFlat, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 5, AbstractMusicNote.ANatural, 6)]
        [TestCase(AbstractMusicNote.GNatural, -10, AbstractMusicNote.ESharpFNatural, 4)]
        [TestCase(AbstractMusicNote.ANatural, 30, AbstractMusicNote.DSharpEFlat, 31)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, AbstractMusicNote.GNatural, 6)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, AbstractMusicNote.BSharpCNatural, -19)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.BNaturalCFlat, null)]
        public void LessThanOperator_WhenComparingUnequalMusicNotes_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.CSharpDFlat, null)]
        public void LessThanOperator_WhenComparingEqualMusicNotes_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.DNatural, -7, AbstractMusicNote.ESharpFNatural, null)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 7, AbstractMusicNote.ENaturalFFlat, null)]
        [TestCase(AbstractMusicNote.ASharpBFlat, null, AbstractMusicNote.GNatural, null)]
        public void LessThanOperator_WhenComparingUnequalMusicNotes_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.DSharpEFlat, null)]
        public void LessThanOperator_WhenComparingMusicNoteWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.ASharpBFlat, null, 23, AbstractMusicNote.ANatural, null)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, 0, AbstractMusicNote.BSharpCNatural, null)]
        [TestCase(AbstractMusicNote.GNatural, null, -47, AbstractMusicNote.GSharpAFlat, null)]
        public void Sharpened_WhenGivenValidIncrementQuantity_ShouldUpdateCorrectly(AbstractMusicNote startNote, int? startOctave, int incrementQuantity, AbstractMusicNote expectedAbstractMusicNote, int? expectedOctave)
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
        [TestCase(AbstractMusicNote.DNatural, null, 18, AbstractMusicNote.GSharpAFlat, null)]
        [TestCase(AbstractMusicNote.ESharpFNatural, null, 0, AbstractMusicNote.ESharpFNatural, null)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 19, AbstractMusicNote.FSharpGFlat, null)]
        public void Flattened_WhenGivenValidDecrementQuantity_ShouldUpdateCorrectly(AbstractMusicNote startNote, int? startOctave, int decrementQuantity, AbstractMusicNote expectedAbstractMusicNote, int? expectedOctave)
        {
            var initialMusicNote = new MusicNote(startNote, startOctave);
            var flattenedMusicNote = initialMusicNote.Flattened(decrementQuantity);

            var expectedMusicNote = new MusicNote(expectedAbstractMusicNote, expectedOctave);

            Assert.AreEqual(expectedMusicNote, flattenedMusicNote);
        }

        [TestCase(AbstractMusicNote.DNatural, 4, AbstractMusicNote.DSharpEFlat, 4, 1)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0, AbstractMusicNote.FSharpGFlat, 0, 0)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -4, AbstractMusicNote.BNaturalCFlat, -4, 11)]
        [TestCase(AbstractMusicNote.ANatural, 6, AbstractMusicNote.GNatural, 9, 34)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 9, AbstractMusicNote.GNatural, 4, -64)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, AbstractMusicNote.ENaturalFFlat, null, 3)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, AbstractMusicNote.CSharpDFlat, null, -10)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.GNatural, null, 0)]
        public void GetSemitoneDistance_WhenGivenValidMusicNotes_ShouldReturnCorrectResult(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave, int expectedDistance)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            var actualDistance = firstMusicNote.GetSemitoneDistance(secondMusicNote);
            
            Assert.AreEqual(expectedDistance, actualDistance);
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 1)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 7)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -4)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 0)]
        [TestCase(AbstractMusicNote.ANatural, 2)]
        [TestCase(AbstractMusicNote.DNatural, null)]
        public void GetSemitoneDistance_WhenGivenNull_ShouldThrowArgumentException(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            MusicNote secondMusicNote = null;

            Assert.Throws<ArgumentException>(() => {
                firstMusicNote.GetSemitoneDistance(secondMusicNote);
            });
        }

        [TestCase(AbstractMusicNote.ANatural, null, AbstractMusicNote.FSharpGFlat, 17)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -2, AbstractMusicNote.DNatural, null)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, AbstractMusicNote.ESharpFNatural, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 29, AbstractMusicNote.BNaturalCFlat, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, AbstractMusicNote.ENaturalFFlat, -14)]
        public void GetSemitoneDistance_WhenGivenIncomparableMusicNotes_ShouldThrowInvalidMusicNoteComparisonException(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);

            Assert.Throws<MusicNoteExceptions.InvalidMusicNoteComparisonException>(() => {
                firstMusicNote.GetSemitoneDistance(secondMusicNote);
            });
        }
    }
}
