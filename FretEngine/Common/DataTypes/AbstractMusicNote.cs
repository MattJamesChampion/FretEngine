using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FretEngine.Common.DataTypes
{
    /// <summary>
    /// This is an abstraction of all of the possible individual notes in
	/// the English chromatic scale using scientific pitch notation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The reason that the lowest value in <see cref="AbstractMusicNote"/> is
	/// <see cref="BSharpCNatural"/> and the highest is
	/// <see cref="BNaturalCFlat"/> is because it matches how scientific pitch
	/// notation represents them; B sharp/C natural is the lowest note in an
	/// octave, whilst B natural/C flat is the highest.
    /// </para>
    /// </remarks>
    public enum AbstractMusicNote
    {
        /// <summary>
        /// An abstract note representing B sharp and C natural.
        /// </summary>
        BSharpCNatural,
        /// <summary>
        /// An abstract note representing C sharp and D flat.
        /// </summary>
        CSharpDFlat,
        /// <summary>
        /// An abstract note representing D natural.
        /// </summary>
        DNatural,
        /// <summary>
        /// An abstract note representing D sharp and E flat.
        /// </summary>
        DSharpEFlat,
        /// <summary>
        /// An abstract note representing E natural and F flat.
        /// </summary>
        ENaturalFFlat,
        /// <summary>
        /// An abstract note representing E sharp and F natural.
        /// </summary>
        ESharpFNatural,
        /// <summary>
        /// An abstract note representing F sharp and G flat.
        /// </summary>
        FSharpGFlat,
        /// <summary>
        /// An abstract note representing G natural.
        /// </summary>
        GNatural,
        /// <summary>
        /// An abstract note representing G sharp and A flat.
        /// </summary>
        GSharpAFlat,
        /// <summary>
        /// An abstract note representing A natural.
        /// </summary>
        ANatural,
        /// <summary>
        /// An abstract note representing A sharp and B flat.
        /// </summary>
        ASharpBFlat,
        /// <summary>
        /// An abstract note representing B natural and C flat.
        /// </summary>
        BNaturalCFlat
    }

    /// <summary>
    /// A collection of extension methods designed to operate on
	/// <see cref="AbstractMusicNote"/>.
    /// </summary>
    public static class AbstractMusicNoteExtensions
    {
        /// <summary>
        /// Takes an <paramref name="initialAbstractMusicNote"/> and returns a new <see cref="AbstractMusicNote"/>
        /// that has been shifted by <paramref name="shiftQuantity"/> semitones.
        /// </summary>
        /// <param name="initialAbstractMusicNote">
        /// The initial <see cref="AbstractMusicNote"/> that the shift will
		/// start from.
        /// </param>
        /// <param name="shiftQuantity">
        /// An <see cref="int"/> representing the number of semitones to shift
		/// <paramref name="initialAbstractMusicNote"/>.
        /// </param>
        /// <param name="octaveShift">
        /// An <see cref="int"/> out value representing how many octaves
		/// <paramref name="initialAbstractMusicNote"/> has been shifted.
        /// </param>
        /// <returns>
        /// A new <see cref="AbstractMusicNote"/> representing
		/// <paramref name="initialAbstractMusicNote"/>
        /// shifted by <paramref name="shiftQuantity"/> semitones.
        /// </returns>
        private static AbstractMusicNote GetShiftedAbstractMusicNote(AbstractMusicNote initialAbstractMusicNote, int shiftQuantity, out int octaveShift)
        {
            var numberOfElements = Enum.GetNames(typeof(AbstractMusicNote)).Length;
            var abstractMusicNoteValue = (int)initialAbstractMusicNote;

            var modifiedAbstractMusicNoteValue = ((abstractMusicNoteValue + shiftQuantity) % numberOfElements);
            var totalOctaveShifts = (abstractMusicNoteValue + shiftQuantity) / numberOfElements;

            if (modifiedAbstractMusicNoteValue < 0)
            {
                modifiedAbstractMusicNoteValue = numberOfElements + modifiedAbstractMusicNoteValue;
                totalOctaveShifts -= 1;
            }

            octaveShift = totalOctaveShifts;
            return (AbstractMusicNote)modifiedAbstractMusicNoteValue;
        }

        /// <summary>
        /// Returns an <see cref="AbstractMusicNote"/> representing
        /// <paramref name="initialAbstractMusicNote"/> sharpened by
        /// <paramref name="incrementQuantity"/> semitones.
        /// </summary>
        /// <param name="initialAbstractMusicNote">
        /// The starting <see cref="AbstractMusicNote"/> that will be
		/// sharpened.
        /// </param>
        /// <param name="incrementQuantity">
        /// An <see cref="int"/> representing the number of semitones to
        /// sharpen <paramref name="initialAbstractMusicNote"/> by.
        /// </param>
        /// <param name="octaveShift">
        /// An <see cref="int"/> out value representing how many octaves
		/// <paramref name="initialAbstractMusicNote"/> has shifted.
        /// </param>
        /// <returns>
        /// A new <see cref="AbstractMusicNote"/> representing
		/// <paramref name="initialAbstractMusicNote"/>
        /// sharpened by <paramref name="incrementQuantity"/> semitones.
        /// </returns>
        public static AbstractMusicNote Sharpened(this AbstractMusicNote initialAbstractMusicNote, int incrementQuantity, out int octaveShift)
        {
            int returnedOctaveShift;

            var sharpenedAbstractMusicNote = GetShiftedAbstractMusicNote(initialAbstractMusicNote, incrementQuantity, out returnedOctaveShift);
            octaveShift = returnedOctaveShift;

            return sharpenedAbstractMusicNote;
        }

        /// <summary>
        /// Returns an <see cref="AbstractMusicNote"/> representing
        /// <paramref name="initialAbstractMusicNote"/> sharpened by
        /// <paramref name="incrementQuantity"/> semitones.
        /// </summary>
        /// <param name="initialAbstractMusicNote">
        /// The starting <see cref="AbstractMusicNote"/> that will be
		/// sharpened.
        /// </param>
        /// <param name="incrementQuantity">
        /// An <see cref="int"/> representing the number of semitones to
        /// sharpen <paramref name="initialAbstractMusicNote"/> by.
        /// </param>
        /// <returns>
        /// A new <see cref="AbstractMusicNote"/> representing
		/// <paramref name="initialAbstractMusicNote"/> sharpened by
		/// <paramref name="incrementQuantity"/> semitones.
        /// </returns>
        public static AbstractMusicNote Sharpened(this AbstractMusicNote initialAbstractMusicNote, int incrementQuantity)
        {
            int returnedOctaveShift;

            return Sharpened(initialAbstractMusicNote, incrementQuantity, out returnedOctaveShift);
        }

        /// <summary>
        /// Returns an <see cref="AbstractMusicNote"/> representing
        /// <paramref name="initialAbstractMusicNote"/> flattened by
        /// <paramref name="decrementQuantity"/> semitones.
        /// </summary>
        /// <param name="initialAbstractMusicNote">
        /// The starting <see cref="AbstractMusicNote"/> that will be
		/// flattened.
        /// </param>
        /// <param name="decrementQuantity">
        /// An <see cref="int"/> representing the number of semitones to
        /// flatten <paramref name="initialAbstractMusicNote"/> by.
        /// </param>
        /// <param name="octaveShift">
        /// An <see cref="int"/> out value representing how many octaves
        /// <paramref name="initialAbstractMusicNote"/> has shifted.
        /// </param>
        /// <returns>
        /// A new <see cref="AbstractMusicNote"/> representing
		/// <paramref name="initialAbstractMusicNote"/> flattened by
		/// <paramref name="decrementQuantity"/> semitones.
        /// </returns>
        public static AbstractMusicNote Flattened(this AbstractMusicNote initialAbstractMusicNote, int decrementQuantity, out int octaveShift)
        {
            int returnedOctaveShift;

            decrementQuantity = -decrementQuantity;

            var flattenedAbstractMusicNote = GetShiftedAbstractMusicNote(initialAbstractMusicNote, decrementQuantity, out returnedOctaveShift);
            octaveShift = returnedOctaveShift;

            return flattenedAbstractMusicNote;
        }

        /// <summary>
        /// Returns an <see cref="AbstractMusicNote"/> representing
        /// <paramref name="initialAbstractMusicNote"/> flattened by
        /// <paramref name="decrementQuantity"/> semitones.
        /// </summary>
        /// <param name="initialAbstractMusicNote">
        /// The starting <see cref="AbstractMusicNote"/> that will be
		/// flattened.
        /// </param>
        /// <param name="decrementQuantity">
        /// An <see cref="int"/> representing the number of semitones to
        /// flatten <paramref name="initialAbstractMusicNote"/> by.
        /// </param>
        /// <returns>
        /// A new <see cref="AbstractMusicNote"/> representing
		/// <paramref name="initialAbstractMusicNote"/> flattened by
		/// <paramref name="decrementQuantity"/> semitones.
        /// </returns>
        public static AbstractMusicNote Flattened(this AbstractMusicNote initialAbstractMusicNote, int decrementQuantity)
        {
            int returnedOctaveShift;

            return Flattened(initialAbstractMusicNote, decrementQuantity, out returnedOctaveShift);
        }
    }
}
