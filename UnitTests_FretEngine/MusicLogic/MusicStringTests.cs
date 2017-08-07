﻿using System;
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

        [Test]
        public void MusicString_WhenConstructingWithNullMusicNote_ShouldThrowArgumentException()
        {
            MusicNote testMusicNote = null;

            Assert.Throws<ArgumentException>(() =>
            {
                new MusicString(testMusicNote);
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

        [TestCase(AbstractMusicNote.DNatural, 4)]
        [TestCase(AbstractMusicNote.GNatural, 1)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 20)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -7)]
        [TestCase(AbstractMusicNote.ANatural, 0)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -0)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null)]
        public void ToString_WhenCalledOnAValidMusicString_ShouldNotThrowException(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.GSharpAFlat, null)]
        public void Equals_WhenComparingMusicStringWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.BSharpCNatural, null)]
        public void Equals_WhenComparingEqualMusicStrings_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.CSharpDFlat, 16, AbstractMusicNote.BSharpCNatural, null)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, AbstractMusicNote.ENaturalFFlat, -23)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, AbstractMusicNote.FSharpGFlat, null)]
        public void Equals_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsFalse(firstMusicString.Equals(secondMusicString));
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 5)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -6)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0)]
        [TestCase(AbstractMusicNote.ANatural, 14)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 2)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null)]
        public void Equals_WhenComparingMusicStringWithNullCastAsObject_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            MusicString secondMusicString = null;

            Assert.IsFalse(firstMusicString.Equals((object)secondMusicString));
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 4)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 14)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 19)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -17)]
        [TestCase(AbstractMusicNote.GNatural, null)]
        public void Equals_WhenComparingEqualMusicStringsCastAsObject_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString.Equals((object)secondMusicString));
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 7, AbstractMusicNote.CSharpDFlat, -7)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, AbstractMusicNote.ESharpFNatural, 0)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -2, AbstractMusicNote.BNaturalCFlat, 2)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 19, AbstractMusicNote.GNatural, 9)]
        [TestCase(AbstractMusicNote.GNatural, -4, AbstractMusicNote.DSharpEFlat, -4)]
        [TestCase(AbstractMusicNote.ANatural, 14, AbstractMusicNote.DSharpEFlat, null)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, AbstractMusicNote.GSharpAFlat, -12)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.FSharpGFlat, null)]
        public void Equals_WhenComparingUnequalMusicStringsCastAsObject_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsFalse(firstMusicString.Equals((object)secondMusicString));
        }

        [TestCase(AbstractMusicNote.GNatural, 2)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 7)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -9)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 14)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null)]
        public void GetHashCode_WhenGeneratedForEqualMusicStrings_ShouldBeEqual(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.DNatural, -17, AbstractMusicNote.DSharpEFlat, null)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, AbstractMusicNote.ASharpBFlat, 18)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, AbstractMusicNote.GNatural, null)]
        public void GetHashCode_WhenGeneratedForUnequalMusicStrings_ShouldNotBeEqual(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.ESharpFNatural, null)]
        public void EqualityOperator_WhenComparingMusicStringWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.ENaturalFFlat, null)]
        public void EqualityOperator_WhenComparingEqualMusicStrings_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.BNaturalCFlat, 13, AbstractMusicNote.ENaturalFFlat, null)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, AbstractMusicNote.FSharpGFlat, -17)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.ASharpBFlat, null)]
        public void EqualityOperator_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.DNatural, null)]
        public void InequalityOperator_WhenComparingMusicStringWithNull_ShouldReturnTrue(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.DNatural, null)]
        public void InequalityOperator_WhenComparingEqualMusicStrings_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.GSharpAFlat, 19, AbstractMusicNote.DNatural, null)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.GSharpAFlat, -9)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, AbstractMusicNote.CSharpDFlat, null)]
        public void InequalityOperator_WhenComparingUnequalMusicStrings_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.ESharpFNatural, 11, AbstractMusicNote.ESharpFNatural, null)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -6, AbstractMusicNote.BSharpCNatural, null)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, AbstractMusicNote.DNatural, null)]
        public void CompareTo_WhenComparingUnequalMusicStringsCastAsObject_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.DNatural, null)]
        public void CompareTo_WhenComparingEqualMusicStringsCastAsObject_ShouldReturnZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave)
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
        [TestCase(AbstractMusicNote.BNaturalCFlat, null, AbstractMusicNote.ENaturalFFlat, 4)]
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.BSharpCNatural, -7)]
        [TestCase(AbstractMusicNote.DNatural, null, AbstractMusicNote.ESharpFNatural, null)]
        public void CompareTo_WhenComparingUnequalMusicStringsCastAsObject_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.ASharpBFlat, null)]
        public void CompareTo_WhenComparingMusicStringWithNullCastAsObject_ShouldReturnGreaterThanZero(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.CSharpDFlat, null)]
        public void CompareTo_WhenComparingMusicStringWithNonMusicStringCastAsObject_ShouldThrowArgumentException(AbstractMusicNote testAbstractMusicNote, int? testOctave)
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
        [TestCase(AbstractMusicNote.ENaturalFFlat, 9, AbstractMusicNote.GSharpAFlat, null)]
        [TestCase(AbstractMusicNote.ESharpFNatural, -20, AbstractMusicNote.DSharpEFlat, null)]
        [TestCase(AbstractMusicNote.ANatural, null, AbstractMusicNote.DSharpEFlat, null)]
        public void CompareTo_WhenComparingUnequalMusicStrings_ShouldReturnGreaterThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.FSharpGFlat, null)]
        public void CompareTo_WhenComparingEqualMusicStrings_ShouldReturnZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave)
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
        [TestCase(AbstractMusicNote.GNatural, null, AbstractMusicNote.DNatural, 15)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, AbstractMusicNote.ASharpBFlat, -14)]
        [TestCase(AbstractMusicNote.FSharpGFlat, null, AbstractMusicNote.ANatural, null)]
        public void CompareTo_WhenComparingUnequalMusicStrings_ShouldReturnLessThanZero(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
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
        [TestCase(AbstractMusicNote.DNatural, null)]
        public void CompareTo_WhenComparingMusicStringWithNull_ShouldReturnGreaterThanZero(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            MusicString secondMusicString = null;

            Assert.IsTrue(firstMusicString.CompareTo(secondMusicString) > 0);
        }

        [TestCase(AbstractMusicNote.CSharpDFlat, 13, AbstractMusicNote.BSharpCNatural, 13)]
        [TestCase(AbstractMusicNote.ANatural, 0, AbstractMusicNote.DSharpEFlat, -2)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 10, AbstractMusicNote.FSharpGFlat, -10)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 4, AbstractMusicNote.FSharpGFlat, 1)]
        [TestCase(AbstractMusicNote.DNatural, 7, AbstractMusicNote.DNatural, 6)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 1, AbstractMusicNote.CSharpDFlat, null)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -19, AbstractMusicNote.ENaturalFFlat, null)]
        [TestCase(AbstractMusicNote.ASharpBFlat, null, AbstractMusicNote.GNatural, null)]
        public void GreaterThanOperator_WhenComparingUnequalMusicStrings_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString > secondMusicString);
        }

        [TestCase(AbstractMusicNote.GNatural, 12)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 4)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -9)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, -1)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null)]
        public void GreaterThanOperator_WhenComparingEqualMusicStrings_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsFalse(firstMusicString > secondMusicString);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 14, AbstractMusicNote.GSharpAFlat, 15)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 7, AbstractMusicNote.ESharpFNatural, 7)]
        [TestCase(AbstractMusicNote.DNatural, 3, AbstractMusicNote.FSharpGFlat, 9)]
        [TestCase(AbstractMusicNote.DSharpEFlat, 0, AbstractMusicNote.ENaturalFFlat, 14)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, -8, AbstractMusicNote.BNaturalCFlat, 8)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, AbstractMusicNote.GNatural, 10)]
        [TestCase(AbstractMusicNote.ANatural, null, AbstractMusicNote.CSharpDFlat, -11)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, AbstractMusicNote.GNatural, null)]
        public void GreaterThanOperator_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsFalse(firstMusicString > secondMusicString);
        }

        [TestCase(AbstractMusicNote.GSharpAFlat, 0)]
        [TestCase(AbstractMusicNote.ESharpFNatural, 17)]
        [TestCase(AbstractMusicNote.BSharpCNatural, 4)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -8)]
        [TestCase(AbstractMusicNote.FSharpGFlat, -2)]
        [TestCase(AbstractMusicNote.GNatural, null)]
        public void GreaterThanOperator_WhenComparingMusicStringWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            Assert.IsFalse(testMusicString > null);
        }

        [TestCase(AbstractMusicNote.DNatural, 14, AbstractMusicNote.DSharpEFlat, 14)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 0, AbstractMusicNote.FSharpGFlat, 6)]
        [TestCase(AbstractMusicNote.DSharpEFlat, -2, AbstractMusicNote.DSharpEFlat, 2)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 4, AbstractMusicNote.GNatural, 7)]
        [TestCase(AbstractMusicNote.ANatural, 8, AbstractMusicNote.ENaturalFFlat, 10)]
        [TestCase(AbstractMusicNote.BSharpCNatural, null, AbstractMusicNote.BNaturalCFlat, 11)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, AbstractMusicNote.FSharpGFlat, -6)]
        [TestCase(AbstractMusicNote.DSharpEFlat, null, AbstractMusicNote.GNatural, null)]
        public void LessThanOperator_WhenComparingUnequalMusicStrings_ShouldReturnTrue(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsTrue(firstMusicString < secondMusicString);
        }

        [TestCase(AbstractMusicNote.FSharpGFlat, 4)]
        [TestCase(AbstractMusicNote.DNatural, 8)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 0)]
        [TestCase(AbstractMusicNote.ASharpBFlat, -9)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 15)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null)]
        public void LessThanOperator_WhenComparingEqualMusicStrings_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var firstMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsFalse(firstMusicString < secondMusicString);
        }

        [TestCase(AbstractMusicNote.ASharpBFlat, -9, AbstractMusicNote.BNaturalCFlat, -11)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 4, AbstractMusicNote.ASharpBFlat, 4)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0, AbstractMusicNote.DSharpEFlat, -2)]
        [TestCase(AbstractMusicNote.BSharpCNatural, -5, AbstractMusicNote.BSharpCNatural, -6)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 10, AbstractMusicNote.FSharpGFlat, -10)]
        [TestCase(AbstractMusicNote.ANatural, 11, AbstractMusicNote.CSharpDFlat, null)]
        [TestCase(AbstractMusicNote.DNatural, -18, AbstractMusicNote.DSharpEFlat, null)]
        [TestCase(AbstractMusicNote.GSharpAFlat, null, AbstractMusicNote.GNatural, null)]
        public void LessThanOperator_WhenComparingUnequalMusicStrings_ShouldReturnFalse(AbstractMusicNote firstAbstractMusicNote, int? firstOctave, AbstractMusicNote secondAbstractMusicNote, int? secondOctave)
        {
            var firstMusicNote = new MusicNote(firstAbstractMusicNote, firstOctave);
            var firstMusicString = new MusicString(firstMusicNote);

            var secondMusicNote = new MusicNote(secondAbstractMusicNote, secondOctave);
            var secondMusicString = new MusicString(secondMusicNote);

            Assert.IsFalse(firstMusicString < secondMusicString);
        }

        [TestCase(AbstractMusicNote.DNatural, 3)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, 0)]
        [TestCase(AbstractMusicNote.FSharpGFlat, 8)]
        [TestCase(AbstractMusicNote.GSharpAFlat, -12)]
        [TestCase(AbstractMusicNote.GNatural, 14)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, null)]
        public void LessThanOperator_WhenComparingMusicStringWithNull_ShouldReturnFalse(AbstractMusicNote testAbstractMusicNote, int? testOctave)
        {
            var testMusicNote = new MusicNote(testAbstractMusicNote, testOctave);
            var testMusicString = new MusicString(testMusicNote);

            Assert.IsFalse(testMusicString < null);
        }
        
        [TestCase(AbstractMusicNote.GNatural, 4, 17, AbstractMusicNote.BSharpCNatural, 6)]
        [TestCase(AbstractMusicNote.ASharpBFlat, 0, 3, AbstractMusicNote.CSharpDFlat, 1)]
        [TestCase(AbstractMusicNote.DNatural, -7, 74, AbstractMusicNote.ENaturalFFlat, -1)]
        [TestCase(AbstractMusicNote.BNaturalCFlat, 23, -23, AbstractMusicNote.BSharpCNatural, 22)]
        [TestCase(AbstractMusicNote.GSharpAFlat, 9, 0, AbstractMusicNote.GSharpAFlat, 9)]
        [TestCase(AbstractMusicNote.ENaturalFFlat, null, 19, AbstractMusicNote.BNaturalCFlat, null)]
        [TestCase(AbstractMusicNote.CSharpDFlat, null, 2, AbstractMusicNote.DSharpEFlat, null)]
        [TestCase(AbstractMusicNote.ANatural, null, -8, AbstractMusicNote.CSharpDFlat, null)]
        public void Sharpen_WhenGivenValidIncrementQuantity_ShouldUpdateCorrectly(AbstractMusicNote startNote, int? startOctave, int incrementQuantity, AbstractMusicNote expectedAbstractMusicNote, int? expectedOctave)
        {
            var expectedMusicNote = new MusicNote(expectedAbstractMusicNote, expectedOctave);
            var expectedMusicString = new MusicString(expectedMusicNote);

            var actualMusicNote = new MusicNote(startNote, startOctave);
            var actualMusicString = new MusicString(actualMusicNote);

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
    }
}
