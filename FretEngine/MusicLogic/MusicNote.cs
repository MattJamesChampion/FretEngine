using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FretEngine.Common.DataTypes;
using FretEngine.Common.Exceptions;

namespace FretEngine.MusicLogic
{
    /// <summary>
    /// This class is an abstraction of an individual note in the English
    /// chromatic scale using scientific pitch notation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Due to the complexity of musical notes and the numerous subtleties that
    /// exist based on each variation, this class is intended to abstract away
    /// a number of the specifics. As such, this class is not intended to be
    /// used for the faithful representation of every possible musical note,
    /// but rather as a way to gloss over the details in situations where
    /// strict adherence to the reality of the situation is not necessary.
    /// </para>
    /// <para>
    /// This class is immutable and should only ever return new instances of
    /// itself in order to prevent multiple references to the same object being
    /// modified at the same time. Immutability also better fits the reality of
    /// what's being modeled in this class; musical notes in real life are
    /// immutable and changing the note that is currently being represented
    /// does not mean changing the actual value of the note, which is a subtle
    /// but important distinction.
    /// </para>
    /// </remarks>
    public class MusicNote : IComparable, IComparable<MusicNote>
    {
        /// <summary>
        /// Represents the internal note value.
        /// </summary>
        public readonly AbstractMusicNote Value;

        /// <summary>
        /// Represents the internal note octave in scientific pitch notation.
        /// </summary>
        public readonly int? Octave;

        /// <summary>
        /// Instantiates a new instance of the <see cref="MusicNote"/> class.
        /// </summary>
        /// <param name="value">
        /// The <see cref="AbstractMusicNote"/> to be assigned to the new
        /// instance.
        /// </param>
        /// <param name="octave">
        /// A nullable <see cref="int"/> representing an octave in scientific
        /// pitch notation. A value of null represents a
        /// <see cref="MusicNote"/> with no octave. Default value is null.
        /// </param>
        /// <remarks>
        /// MusicNotes that have no octave (octave is set to null) are
        /// considered to precede MusicNotes that have an octave when it comes
        /// to sort order.
        /// </remarks>
        public MusicNote(AbstractMusicNote value, int? octave = null)
        {
            Value = value;
            Octave = octave;
        }

        /// <summary>
        /// Returns a <see cref="bool"/> representing whether this instance of
        /// <see cref="MusicNote"/> has an Octave or not.
        /// </summary>
        /// <returns>
        /// A <see cref="bool"/> representing whether this instance of
        /// <see cref="MusicNote"/> has an Octave or not.
        /// </returns>
        public bool HasOctave()
        {
            return Octave.HasValue;
        }

        /// <summary>
        /// Creates a <see cref="string"/> representation of this instance.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> representation of this instance.
        /// </returns>
        public override string ToString()
        {
            if (HasOctave())
            {
                return string.Format("{0} {1}", Value, Octave);
            }
            else
            {
                return string.Format("{0}", Value);
            }   
        }

        /// <summary>
        /// Determines whether a specified <see cref="object"/> has the same
        /// value as the current instance.
        /// </summary>
        /// <param name="obj">
        /// The <see cref="object"/> to compare with the current instance, or
        /// null.
        /// </param>
        /// <returns>
        /// true if the value of <paramref name="obj"/> is the same as the
        /// current instance; otherwise, false. If <paramref name="obj"/> is
        /// null, or cannot be cast as a valid <see cref="MusicNote"/>, the
        /// method returns false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            MusicNote targetMusicNote = obj as MusicNote;

            if ((object)targetMusicNote == null)
            {
                return false;
            }

            return Equals(targetMusicNote);
        }

        /// <summary>
        /// Determines whether a specified <see cref="MusicNote"/> object has
        /// the same value as the current instance.
        /// </summary>
        /// <param name="targetMusicNote">
        /// The <see cref="MusicNote"/> to compare with the current instance,
        /// or null.
        /// </param>
        /// <returns>
        /// true if the value of <paramref name="targetMusicNote"/> is the same
        /// as the current instance; otherwise, false. If
        /// <paramref name="targetMusicNote"/> is null, the method returns false.
        /// </returns>
        public bool Equals(MusicNote targetMusicNote)
        {
            if ((object)targetMusicNote == null)
            {
                return false;
            }

            return ((Value == targetMusicNote.Value) && (Octave == targetMusicNote.Octave));
        }

        /// <summary>
        /// Returns the hash code for this <see cref="MusicNote"/>.
        /// </summary>
        /// <returns>
        /// The hash code for the current <see cref="MusicNote"/>.
        /// </returns>
        public override int GetHashCode()
        {
            if (HasOctave())
            {
                return new { Value, Octave }.GetHashCode();
            }
            else
            {
                return Value.GetHashCode();
            }
        }

        /// <summary>
        /// Determines whether two specified instances of
        /// <see cref="MusicNote"/> have the same value.
        /// </summary>
        /// <param name="firstMusicNote">
        /// The first <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicNote">
        /// The second <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <returns>
        /// true if the value of <paramref name="firstMusicNote"/> is the same
        /// as the value of <paramref name="secondMusicNote"/>; otherwise,
        /// false.
        /// </returns>
        public static bool operator == (MusicNote firstMusicNote, MusicNote secondMusicNote)
        {
            if (ReferenceEquals(firstMusicNote, secondMusicNote))
            {
                return true;
            }

            if (((object)firstMusicNote == null) || ((object)secondMusicNote == null))
            {
                return false;
            }

            return firstMusicNote.Equals(secondMusicNote);
        }

        /// <summary>
        /// Determines whether two specified instances of
        /// <see cref="MusicNote"/> do not have the same value.
        /// </summary>
        /// <param name="firstMusicNote">
        /// The first <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicNote">
        /// The second <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <returns>
        /// true if the value of <paramref name="firstMusicNote"/> is not the
        /// same as the value of <paramref name="secondMusicNote"/>; otherwise,
        /// false.
        /// </returns>
        public static bool operator != (MusicNote firstMusicNote, MusicNote secondMusicNote)
        {
            return !(firstMusicNote == secondMusicNote);
        }

        /// <summary>
        /// Compares this instance with a specified <see cref="object"/> and
        /// indicates whether this instance precedes, follows, or appears in
        /// the same position in the sort order as the specified
        /// <see cref="object"/>.
        /// </summary>
        /// <param name="obj">
        /// An <see cref="object"/> that evaluates to <see cref="MusicNote"/>,
        /// or null.
        /// </param>
        /// <returns>
        /// An <see cref="int"/> that indicates whether this instance precedes,
        /// follows, or appears in the same position in the sort order as the
        /// <paramref name="obj"/> parameter. Less than zero indicates that
        /// this instance precedes <paramref name="obj"/>. Zero indicates that
        /// this instance has the same position in the sort order as
        /// <paramref name="obj"/>. Greater than zero indicates that this
        /// instance follows <paramref name="obj"/> or that
        /// <paramref name="obj"/> is null.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="obj"/> is not a <see cref="MusicNote"/>.
        /// </exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var targetMusicNote = obj as MusicNote;

            if (targetMusicNote != null)
            {
                return CompareTo(targetMusicNote);
            }
            else
            {
                throw new ArgumentException("Object must be of type MusicNote.");
            }
        }

        /// <summary>
        /// Compares this instance with a specified <see cref="MusicNote"/> and
        /// indicates whether this instance precedes, follows, or appears in
        /// the same position in the sort order as the specified
        /// <see cref="MusicNote"/>.
        /// </summary>
        /// <param name="targetMusicNote">
        /// The <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <returns>
        /// An <see cref="int"/> that indicates whether this instance precedes,
        /// follows, or appears in the same position in the sort order as the
        /// <paramref name="targetMusicNote"/> parameter. Less than zero
        /// indicates that this instance precedes
        /// <paramref name="targetMusicNote"/>. Zero indicates that this
        /// instance has the same position in the sort order as
        /// <paramref name="targetMusicNote"/>. Greater than zero indicates
        /// that this instance follows <paramref name="targetMusicNote"/> or
        /// that <paramref name="targetMusicNote"/> is null.
        /// </returns>
        public int CompareTo(MusicNote targetMusicNote)
        {
            if (targetMusicNote == null)
            {
                return 1;
            }

            if (HasOctave() && targetMusicNote.HasOctave())
            {
                if (Octave == targetMusicNote.Octave)
                {
                    return Value.CompareTo(targetMusicNote.Value);
                }
                else
                {
                    return ((int)Octave).CompareTo((int)targetMusicNote.Octave);
                }
            }
            else if (!HasOctave() && !targetMusicNote.HasOctave())
            {
                return Value.CompareTo(targetMusicNote.Value);
            }
            else
            {
                if (!HasOctave() && targetMusicNote.HasOctave())
                {
                    //Octaveless MusicNotes precede MusicNotes that have octaves.
                    return -1;
                }
                else
                {
                    //MusicNotes that have octaves follow octaveless MusicNotes.
                    return 1;
                }
            }
        }

        /// <summary>
        /// Compares this instance with a specified <see cref="MusicNote"/> and
        /// indicates whether this instance precedes, follows, or appears in
        /// the same position in the sort order as the specified
        /// <see cref="MusicNote"/>. The value of
        /// <paramref name="compareOctave"/> will control whether or not the
        /// <see cref="Octave"/> will factor into the comparison.
        /// </summary>
        /// <param name="targetMusicNote">
        /// The <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <param name="compareOctave">
        /// A <see cref="bool"/> representing whether or not the
        /// <see cref="Octave"/> will factor into the comparison.
        /// </param>
        /// <returns>
        /// An <see cref="int"/> that indicates whether this instance precedes,
        /// follows, or appears in the same position in the sort order as the
        /// <paramref name="targetMusicNote"/> parameter. Less than zero
        /// indicates that this instance precedes
        /// <paramref name="targetMusicNote"/>. Zero indicates that this
        /// instance has the same position in the sort order as
        /// <paramref name="targetMusicNote"/>. Greater than zero indicates
        /// that this instance follows <paramref name="targetMusicNote"/> or
        /// that <paramref name="targetMusicNote"/> is null.
        /// </returns>
        public int CompareTo(MusicNote targetMusicNote, bool compareOctave=true)
        {
            if (compareOctave)
            {
                return CompareTo(targetMusicNote);
            }
            else
            {
                return Value.CompareTo(targetMusicNote.Value);
            }
        }

        /// <summary>
        /// Compares two instances of <see cref="MusicNote"/> and indicates
        /// whether <paramref name="firstMusicNote"/> is greater than
        /// <paramref name="secondMusicNote"/>.
        /// </summary>
        /// <param name="firstMusicNote">
        /// The first <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicNote">
        /// The second <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <returns>
        /// A boolean that indicates whether <paramref name="firstMusicNote"/>
        /// is greater than <paramref name="secondMusicNote"/>. true indicates
        /// that <paramref name="firstMusicNote"/> is greater than
        /// <paramref name="secondMusicNote"/>. false indicates that
        /// <paramref name="firstMusicNote"/> is less than or equal to
        /// <paramref name="secondMusicNote"/>.
        /// </returns>
        public static bool operator > (MusicNote firstMusicNote, MusicNote secondMusicNote)
        {
            if ((firstMusicNote == null) || (secondMusicNote == null))
            {
                return false;
            }

            var result = firstMusicNote.CompareTo(secondMusicNote);

            if (result == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Compares two instances of <see cref="MusicNote"/> and indicates
        /// whether <paramref name="firstMusicNote"/> is less than
        /// <paramref name="secondMusicNote"/>.
        /// </summary>
        /// <param name="firstMusicNote">
        /// The first <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicNote">
        /// The second <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <returns>
        /// A boolean that indicates whether
        /// <paramref name="firstMusicNote"/> is less than
        /// <paramref name="secondMusicNote"/>. true indicates that
        /// <paramref name="firstMusicNote"/> is less than
        /// <paramref name="secondMusicNote"/>. false indicates that
        /// <paramref name="firstMusicNote"/> is greater than or equal to
        /// <paramref name="secondMusicNote"/>.
        /// </returns>
        public static bool operator < (MusicNote firstMusicNote, MusicNote secondMusicNote)
        {
            if ((firstMusicNote == null) || (secondMusicNote == null))
            {
                return false;
            }

            var result = firstMusicNote.CompareTo(secondMusicNote);

            if (result == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Compares two instances of <see cref="MusicNote"/> and indicates
        /// whether <paramref name="firstMusicNote"/> is greater than or equal
        /// to <paramref name="secondMusicNote"/>.
        /// </summary>
        /// <param name="firstMusicNote">
        /// The first <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicNote">
        /// The second <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <returns>
        /// A boolean that indicates whether
        /// <paramref name="firstMusicNote"/> is greater than or equal to
        /// <paramref name="secondMusicNote"/>. true indicates that
        /// <paramref name="firstMusicNote"/> is greater than or equal to
        /// <paramref name="secondMusicNote"/>. false indicates that
        /// <paramref name="firstMusicNote"/> is less than
        /// <paramref name="secondMusicNote"/>.
        /// </returns>
        public static bool operator >= (MusicNote firstMusicNote, MusicNote secondMusicNote)
        {
            if ((firstMusicNote == null) || (secondMusicNote == null))
            {
                return false;
            }

            return ((firstMusicNote > secondMusicNote) || (firstMusicNote == secondMusicNote));
        }

        /// <summary>
        /// Compares two instances of <see cref="MusicNote"/> and indicates
        /// whether <paramref name="firstMusicNote"/> is less than or equal to
        /// <paramref name="secondMusicNote"/>.
        /// </summary>
        /// <param name="firstMusicNote">
        /// The first <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicNote">
        /// The second <see cref="MusicNote"/> to compare, or null.
        /// </param>
        /// <returns>
        /// A boolean that indicates whether
        /// <paramref name="firstMusicNote"/> is less than or equal to
        /// <paramref name="secondMusicNote"/>. true indicates that
        /// <paramref name="firstMusicNote"/> is less than or equal to
        /// <paramref name="secondMusicNote"/>. false indicates that
        /// <paramref name="firstMusicNote"/> is greater than
        /// <paramref name="secondMusicNote"/>.
        /// </returns>
        public static bool operator <= (MusicNote firstMusicNote, MusicNote secondMusicNote)
        {
            if ((firstMusicNote == null) || (secondMusicNote == null))
            {
                return false;
            }

            return ((firstMusicNote < secondMusicNote) || (firstMusicNote == secondMusicNote));
        }

        /// <summary>
        /// Returns a new sharpened instance of the current
        /// <see cref="MusicNote"/>.
        /// </summary>
        /// <param name="incrementQuantity">
        /// An <see cref="int"/> representing the number of semitones to
        /// sharpen this instance of <see cref="MusicNote"/> by.
        /// </param>
        /// <returns>
        /// A new sharpened instance of the current <see cref="MusicNote"/>.
        /// </returns>
        /// <remarks>
        /// Depending on the starting <see cref="MusicNote"/> and the
        /// <paramref name="incrementQuantity"/>, both <see cref="Value"/> and
        /// <see cref="Octave"/> may be changed. This is based on whether the
        /// new <see cref="MusicNote"/> <see cref="Value"/> would cross over an
        /// octave boundary, therefore modifying the related
        /// <see cref="Octave"/>.
        /// </remarks>
        public MusicNote Sharpened(int incrementQuantity)
        {
            int returnedOctaveShift;

            AbstractMusicNote sharpenedAbstractMusicNote = Value.Sharpened(incrementQuantity, out returnedOctaveShift);

            if (HasOctave())
            {
                return new MusicNote(sharpenedAbstractMusicNote, Octave + returnedOctaveShift);
            }
            else
            {
                return new MusicNote(sharpenedAbstractMusicNote, null);
            }
        }

        /// <summary>
        /// Returns a new flattened instance of the current
        /// <see cref="MusicNote"/>.
        /// </summary>
        /// <param name="decrementQuantity">
        /// An <see cref="int"/> representing the number of semitones to
        /// flatten this instance of <see cref="MusicNote"/> by.
        /// </param>
        /// <returns>
        /// A new flattened instance of the current <see cref="MusicNote"/>.
        /// </returns>
        /// <remarks>
        /// Depending on the starting <see cref="MusicNote"/> and the
        /// <paramref name="decrementQuantity"/>, both <see cref="Value"/> and
        /// <see cref="Octave"/> may be changed. This is based on whether the
        /// new <see cref="MusicNote"/> <see cref="Value"/> would cross over an
        /// octave boundary, therefore modifying the related
        /// <see cref="Octave"/>.
        /// </remarks>
        public MusicNote Flattened(int decrementQuantity)
        {
            int returnedOctaveShift;

            AbstractMusicNote flattenedAbstractMusicNote = Value.Flattened(decrementQuantity, out returnedOctaveShift);

            if (HasOctave())
            {
                return new MusicNote(flattenedAbstractMusicNote, Octave + returnedOctaveShift);
            }
            else
            {
                return new MusicNote(flattenedAbstractMusicNote, null);
            }
        }

        /// <summary>
        /// Get the number of semitones between this instance and
        /// <paramref name="targetMusicNote"/>.
        /// </summary>
        /// <param name="targetMusicNote">
        /// The <see cref="MusicNote"/> whose semitone distance from this
        /// instance will be returned, or null.
        /// </param>
        /// <returns>
        /// An <see cref="int"/> representing the number of semitones between
        /// this instance and <paramref name="targetMusicNote"/>.
        /// </returns>
        /// <exception cref="ArgumentException">
        /// <paramref name="targetMusicNote"/> is null.
        /// </exception>
        /// <exception cref="MusicNoteExceptions.InvalidMusicNoteComparisonException">
        /// This instance of <see cref="MusicNote"/> does not have a valid
        /// Octave whilst <paramref name="targetMusicNote"/> does, or vice
        /// versa.
        /// </exception>
        /// <remarks>
        /// The result reflects how far this instance would need to be either
        /// flattened or sharpened to get to
        /// <paramref name="targetMusicNote"/>.
        /// </remarks>
        public int GetSemitoneDistance(MusicNote targetMusicNote)
        {
            if (targetMusicNote == null)
            {
                throw new ArgumentException("Target music note must not be null.");
            }

            var noteDifferenceInSemitones = targetMusicNote.Value - Value;

            if (HasOctave() && targetMusicNote.HasOctave())
            {
                var octaveDifference = (int)targetMusicNote.Octave - (int)Octave;
                var octaveDifferenceInSemitones = octaveDifference * AbstractMusicNoteUtilities.GetNotesPerOctave();

                return octaveDifferenceInSemitones + noteDifferenceInSemitones;
            }
            else if (!HasOctave() && !targetMusicNote.HasOctave())
            {
                return noteDifferenceInSemitones;
            }
            else
            {
                var errorMessage = "Cannot compare a MusicNote with an octaveless MusicNote.";
                throw new MusicNoteExceptions.InvalidMusicNoteComparisonException(errorMessage);
            }
        }
    }
}
