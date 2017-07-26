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
        
        [TestCase(AbstractMusicNote.GNatural, 2)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 3)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -6)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 14)]
        [TestCase(AbstractMusicNote.ANatural, 0)]
        public void Equals_WhenComparingWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            Assert.IsFalse(testMusicString.Equals(null));
        }

        [TestCase(AbstractMusicNote.DNatural, 19)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -28)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 4)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 7)]
        public void Equals_WhenComparingEqualMusicStrings_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString.Equals(secondMusicString));
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 3, AbstractMusicNote.GSharpAFlat, -3)]
        [TestCase(AbstractMusicNote.GNatural, 5, AbstractMusicNote.FSharpGFlat, 5)]
        [TestCase(AbstractMusicNote.ANatural, 7, AbstractMusicNote.GSharpAFlat, 7)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 2, AbstractMusicNote.ANatural, 19)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 5, AbstractMusicNote.ESharpFNatural, 6)]
        public void Equals_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsFalse(firstMusicString.Equals(secondMusicString));
        }

        [TestCase(AbstractMusicNote.GNatural, 2)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 7)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -9)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 14)]
        public void GetHashCode_WhenGeneratedForEqualMusicStrings_ShouldBeEqual(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.AreEqual(firstMusicString.GetHashCode(), secondMusicString.GetHashCode());
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 3, AbstractMusicNote.BNaturalCFlat, 4)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, AbstractMusicNote.ENaturalFFlat, 1)]
        [TestCase(AbstractMusicNote.GNatural, 2, AbstractMusicNote.BNaturalCFlat, 9)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 7, AbstractMusicNote.GSharpAFlat, 8)]
        [TestCase(AbstractMusicNote.ANatural, -4, AbstractMusicNote.ANatural, 4)]
        public void GetHashCode_WhenGeneratedForUnequalMusicStrings_ShouldNotBeEqual(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.AreNotEqual(firstMusicString.GetHashCode(), secondMusicString.GetHashCode());
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, -4)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 2)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 4)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 17)]
        public void EqualityOperator_WhenComparingWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            Assert.IsFalse(testMusicString == null);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, -4)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 3)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 0)]
        [TestCase(AbstractMusicNote.ANatural, 6)]
        [TestCase(AbstractMusicNote.DNatural, 15)]
        public void EqualityOperator_WhenComparingEqualMusicStrings_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString == secondMusicString);
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, -4, AbstractMusicNote.BSharpCNatural, 4)]
        [TestCase(AbstractMusicNote.DNatural, 3, AbstractMusicNote.DNatural, 5)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, AbstractMusicNote.GSharpAFlat, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -2, AbstractMusicNote.GSharpAFlat, -7)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 5, AbstractMusicNote.BSharpCNatural, 3)]
        public void EqualityOperator_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsFalse(firstMusicString == secondMusicString);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 1)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 9)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 14)]
        [TestCase(AbstractMusicNote.GNatural, -12)]
        public void InequalityOperator_WhenComparingWithNull_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            Assert.IsTrue(testMusicString != null);
        }

        [TestCase(AbstractMusicNote.GNatural, 7)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 5)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -24)]
        [TestCase(AbstractMusicNote.ANatural, 0)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 19)]
        public void InequalityOperator_WhenComparingEqualMusicStrings_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsFalse(firstMusicString != secondMusicString);
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, 12, AbstractMusicNote.BSharpCNatural, 3)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 4, AbstractMusicNote.DSharpEFlat, -8)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 6, AbstractMusicNote.BNaturalCFlat, 16)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 3, AbstractMusicNote.BNaturalCFlat, 3)]
        [TestCase(AbstractMusicNote.DNatural, -17, AbstractMusicNote.DNatural, 17)]
        public void InequalityOperator_WhenComparingUnequalMusicStrings_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);
            
            Assert.IsTrue(firstMusicString != secondMusicString);
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, 3, AbstractMusicNote.BSharpCNatural, 2)]
        [TestCase(AbstractMusicNote.GNatural, 1, AbstractMusicNote.GNatural, -1)]
        [TestCase(AbstractMusicNote.ANatural, 2, AbstractMusicNote.GSharpAFlat, 2)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 30, AbstractMusicNote.GNatural, -9)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 0, AbstractMusicNote.BSharpCNatural, 0)]
        [TestCase(AbstractMusicNote.GNatural, 8, AbstractMusicNote.DSharpEFlat, 8)]
        public void CompareTo_WhenComparingUnequalMusicStringsCastAsObject_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString.CompareTo((object)secondMusicString) > 0);
        }

        [TestCase(AbstractMusicNote.DSharpEFlat, 5)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 13)]
        [TestCase(AbstractMusicNote.CSharpDFlat, 1)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -7)]
        [TestCase(AbstractMusicNote.GNatural, 0)]
        public void CompareTo_WhenComparingEqualMusicStringsCastAsObject_ShouldReturnZero(AbstractMusicNote firstAbstractMusicNote, int firstOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString.CompareTo((object)secondMusicString) == 0);
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, -9, AbstractMusicNote.CSharpDFlat, 9)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 1, AbstractMusicNote.FSharpGFlat, 2)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 5, AbstractMusicNote.BNaturalCFlat, 5)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 0, AbstractMusicNote.BNaturalCFlat, 8)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -12, AbstractMusicNote.CSharpDFlat, -4)]
        public void CompareTo_WhenComparingUnequalMusicStringsCastAsObject_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString.CompareTo((object)secondMusicString) < 0);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 0)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 14)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 6)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 7)]
        [TestCase(AbstractMusicNote.ANatural, -9)]
        public void CompareTo_WhenComparingMusicStringWithNullCastAsObject_ShouldReturnGreaterThanZero(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            MusicString secondMusicString = null;

            Assert.IsTrue(firstMusicString.CompareTo((object)secondMusicString) > 0);
        }

        [TestCase(AbstractMusicNote.BNaturalCFlat, 2)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 19)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 6)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -8)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0)]
        public void CompareTo_WhenComparingMusicStringWithNonMusicStringCastAsObject_ShouldThrowArgumentException(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicString = "Test";

            Assert.Throws<ArgumentException>(() => {
                firstMusicString.CompareTo(secondMusicString);
            });
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 0, AbstractMusicNote.FSharpGFlat, -8)]
        [TestCase(AbstractMusicNote.DNatural, -8, AbstractMusicNote.DNatural, -9)]
        [TestCase(AbstractMusicNote.GNatural, 7, AbstractMusicNote.GNatural, -7)]
        [TestCase(AbstractMusicNote.GNatural, 12, AbstractMusicNote.ENaturalFFlat, 9)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 2, AbstractMusicNote.ESharpFNatural, 2)]
        public void CompareTo_WhenComparingUnequalMusicStrings_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString.CompareTo(secondMusicString) > 0);
        }

        [TestCase(AbstractMusicNote.ENaturalFFlat, 2)]
        [TestCase(AbstractMusicNote.CSharpDFlat, -8)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 6)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 22)]
        [TestCase(AbstractMusicNote.GNatural, 0)]
        public void CompareTo_WhenComparingEqualMusicStrings_ShouldReturnZero(AbstractMusicNote firstAbstractMusicNote, int firstOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString.CompareTo(secondMusicString) == 0);
        }

        [TestCase(AbstractMusicNote.BSharpCNatural, 9, AbstractMusicNote.ENaturalFFlat, 11)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -17, AbstractMusicNote.GSharpAFlat, -7)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 2, AbstractMusicNote.BSharpCNatural, 3)]
        [TestCase(AbstractMusicNote.DNatural, 0, AbstractMusicNote.GNatural, 0)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, -1, AbstractMusicNote.ENaturalFFlat, 1)]
        public void CompareTo_WhenComparingUnequalMusicStrings_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int firstOctave, AbstractMusicNote secondAbstractMusicNote, int secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString.CompareTo(secondMusicString) < 0);
        }

        [TestCase(AbstractMusicNote.ESharpFNatural, 7)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 15)]
        [TestCase(AbstractMusicNote.ANatural, 0)]
        [TestCase(AbstractMusicNote.GNatural, 9)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -5)]
        public void CompareTo_WhenComparingMusicStringWithNull_ShouldReturnGreaterThanZero(AbstractMusicNote testAbstractMusicNote, int testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            MusicString secondMusicString = null;

            Assert.IsTrue(firstMusicString.CompareTo(secondMusicString) > 0);
        }
    }
}
