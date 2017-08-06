﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FretEngine.Common.DataTypes;
using FretEngine.Common.Exceptions;

namespace FretEngine.MusicLogic
{
    /// <summary>
    /// This class is an abstraction of a string on a fretted instrument.
    /// </summary>
    /// <remarks>
    /// This class is mutable to reflect the fact that a given string continues
    /// to be the same string no matter which note it is tuned to.
    /// </remarks>
    public class MusicString : IComparable, IComparable<MusicString>
    {
        /// <summary>
        /// Represents the root note of the string.
        /// </summary>
        /// <remarks>
        /// Root note refers to the note that this string is tuned to without
        /// fretting the string. As such, it can also be considered the note
        /// at fret 0.
        /// </remarks>
        public MusicNote RootNote;

        /// <summary>
        /// Instantiates a new instance of the <see cref="MusicString"/> class.
        /// </summary>
        /// <param name="rootNote">
        /// The <see cref="MusicNote"/> to be assigned to the new instance.
        /// </param>
        /// <exception cref="ArgumentException">
        /// <paramref name="rootNote"/> is null.
        /// </exception>
        public MusicString(MusicNote rootNote)
        {
            if (rootNote != null)
            {
                RootNote = rootNote;
            }
            else
            {
                throw new ArgumentException("Root note must not be null.");
            }
        }

        /// <summary>
        /// Creates a <see cref="string"/> representation of this instance.
        /// </summary>
        /// <returns>
        /// The <see cref="string"/> representation of this instance.
        /// </returns>
        public override string ToString()
        {
            return string.Format("MusicString with root note: {0}", RootNote);
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
        /// null, or cannot be cast as a valid <see cref="MusicString"/>, the
        /// method returns false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            MusicString targetMusicString = obj as MusicString;

            if ((object)targetMusicString == null)
            {
                return false;
            }

            return Equals(targetMusicString);
        }

        /// <summary>
        /// Determines whether a specified <see cref="MusicString"/> object has
        /// the same value as the current instance.
        /// </summary>
        /// <param name="targetMusicString">
        /// The <see cref="MusicString"/> to compare with the current instance,
        /// or null.
        /// </param>
        /// <returns>
        /// true if the value of <paramref name="targetMusicString"/> is the
		/// same as the current instance; otherwise, false. If
		/// <paramref name="targetMusicString"/> is null, the method returns
		/// false.
        /// </returns>
        public bool Equals(MusicString targetMusicString)
        {
            if ((object)targetMusicString == null)
            {
                return false;
            }

            return (RootNote.Equals(targetMusicString.RootNote));
        }

        /// <summary>
        /// Returns the hash code for this <see cref="MusicString"/>.
        /// </summary>
        /// <returns>
        /// The hash code for the current <see cref="MusicString"/>.
        /// </returns>
        public override int GetHashCode()
        {
            return RootNote.GetHashCode();
        }

        /// <summary>
        /// Determines whether two specified instances of
        /// <see cref="MusicString"/> have the same value.
        /// </summary>
        /// <param name="firstMusicString">
        /// The first <see cref="MusicString"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicString">
        /// The second <see cref="MusicString"/> to compare, or null.
        /// </param>
        /// <returns>
        /// true if the value of <paramref name="firstMusicString"/> is the
		/// same as the value of <paramref name="secondMusicString"/>;
		/// otherwise, false.
        /// </returns>
        public static bool operator == (MusicString firstMusicString, MusicString secondMusicString)
        {
            if (ReferenceEquals(firstMusicString, secondMusicString))
            {
                return true;
            }

            if (((object)firstMusicString == null) || ((object)secondMusicString == null))
            {
                return false;
            }

            return firstMusicString.Equals(secondMusicString);
        }

        /// <summary>
        /// Determines whether two specified instances of
        /// <see cref="MusicString"/> do not have the same value.
        /// </summary>
        /// <param name="firstMusicString">
        /// The first <see cref="MusicString"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicString">
        /// The second <see cref="MusicString"/> to compare, or null.
        /// </param>
        /// <returns>
        /// true if the value of <paramref name="firstMusicString"/> is not the
        /// same as the value of <paramref name="secondMusicString"/>;
		/// otherwise, false.
        /// </returns>
        public static bool operator != (MusicString firstMusicString, MusicString secondMusicString)
        {
            return !(firstMusicString == secondMusicString);
        }

        /// <summary>
        /// Compares this instance with a specified <see cref="object"/> and
		/// indicates whether this instance precedes, follows, or appears in
		/// the same position in the sort order as the specified
		/// <see cref="object"/>.
        /// </summary>
        /// <param name="obj">
        /// An <see cref="object"/> that evaluates to
        /// <see cref="MusicString"/>, or null.
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
        /// <paramref name="obj"/> is not a <see cref="MusicString"/>.
        /// </exception>
        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }

            var targetMusicString = obj as MusicString;

            if (targetMusicString != null)
            {
                return CompareTo(targetMusicString);
            }
            else
            {
                throw new ArgumentException("Object must be of type MusicString.");
            }
        }

        /// <summary>
        /// Compares this instance with a specified <see cref="MusicString"/>
		/// and indicates whether this instance precedes, follows, or appears
		/// in the same position in the sort order as the specified
		/// <see cref="MusicString"/>.
        /// </summary>
        /// <param name="targetMusicString">
        /// The <see cref="MusicString"/> to compare, or null.
        /// </param>
        /// <returns>
        /// An <see cref="int"/> that indicates whether this instance precedes,
		/// follows, or appears in the same position in the sort order as the
		/// <paramref name="targetMusicString"/> parameter. Less than zero
		/// indicates that this instance precedes
		/// <paramref name="targetMusicString"/>. Zero indicates that this
		/// instance has the same position in the sort order as
		/// <paramref name="targetMusicString"/>. Greater than zero indicates
		/// that this instance follows <paramref name="targetMusicString"/> or
		/// that <paramref name="targetMusicString"/> is null.
        /// </returns>
        public int CompareTo(MusicString targetMusicString)
        {
            if (targetMusicString == null)
            {
                return 1;
            }

            return RootNote.CompareTo(targetMusicString.RootNote);
        }

        /// <summary>
        /// Compares two instances of <see cref="MusicString"/> and indicates
        /// whether <paramref name="firstMusicString"/> is greater than
        /// <paramref name="secondMusicString"/>.
        /// </summary>
        /// <param name="firstMusicString">
        /// The first <see cref="MusicString"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicString">
        /// The second <see cref="MusicString"/> to compare, or null.
        /// </param>
        /// <returns>
        /// A boolean that indicates whether <paramref name="firstMusicString"/>
        /// is greater than <paramref name="secondMusicString"/>. true indicates
        /// that <paramref name="firstMusicString"/> is greater than
        /// <paramref name="secondMusicString"/>. false indicates that
        /// <paramref name="firstMusicString"/> is less than or equal to
        /// <paramref name="secondMusicString"/>.
        /// </returns>
        public static bool operator > (MusicString firstMusicString, MusicString secondMusicString)
        {
            if ((firstMusicString == null) || (secondMusicString == null))
            {
                return false;
            }

            return firstMusicString.RootNote > secondMusicString.RootNote;
        }

        /// <summary>
        /// Compares two instances of <see cref="MusicString"/> and indicates
        /// whether <paramref name="firstMusicString"/> is less than
        /// <paramref name="secondMusicString"/>.
        /// </summary>
        /// <param name="firstMusicString">
        /// The first <see cref="MusicString"/> to compare, or null.
        /// </param>
        /// <param name="secondMusicString">
        /// The second <see cref="MusicString"/> to compare, or null.
        /// </param>
        /// <returns>
        /// A boolean that indicates whether
        /// <paramref name="firstMusicString"/> is less than
        /// <paramref name="secondMusicString"/>. true indicates that
        /// <paramref name="firstMusicString"/> is less than
        /// <paramref name="secondMusicString"/>. false indicates that
        /// <paramref name="firstMusicString"/> is greater than or equal to
        /// <paramref name="secondMusicString"/>.
        /// </returns>
        public static bool operator < (MusicString firstMusicString, MusicString secondMusicString)
        {
            if ((firstMusicString == null) || (secondMusicString == null))
            {
                return false;
            }

            return firstMusicString.RootNote < secondMusicString.RootNote;
        }

        /// <summary>
        /// Sharpens the <see cref="RootNote"/> of this instance by
		/// <paramref name="incrementQuantity"/> semitones.
        /// </summary>
        /// <param name="incrementQuantity">
        /// An <see cref="int"/> representing the number of semitones to
		/// sharpen the <see cref="RootNote"/> of this instance by.
        /// </param>
        public void Sharpen(int incrementQuantity)
        {
            RootNote = RootNote.Sharpened(incrementQuantity);
        }

        /// <summary>
        /// Flattens the <see cref="RootNote"/> of this instance by
		/// <paramref name="decrementQuantity"/> semitones.
        /// </summary>
        /// <param name="decrementQuantity">
        /// An <see cref="int"/> representing the number of semitones to
		/// flatten the <see cref="RootNote"/> of this instance by.
        /// </param>
        public void Flatten(int decrementQuantity)
        {
            RootNote = RootNote.Flattened(decrementQuantity);
        }

        /// <summary>
        /// Checks whether a given <paramref name="musicStringPosition"/> is
		/// valid.
        /// </summary>
        /// <param name="musicStringPosition">
        /// The music string position to check the validity of.
        /// </param>
        /// <returns>
        /// A <see cref="bool"/> representing whether the given
        /// <paramref name="musicStringPosition"/> is valid.
        /// </returns>
        public static bool IsValidMusicStringPosition(int musicStringPosition)
        {
            return (musicStringPosition >= 0);
        }

        /// <summary>
        /// Returns the <see cref="MusicNote"/> at the given
        /// <paramref name="musicStringPosition"/>.
        /// </summary>
        /// <param name="musicStringPosition">
        /// An <see cref="int"/> representing the position on this
        /// <see cref="MusicString"/> to return the <see cref="MusicNote"/>
		/// from.
        /// </param>
        /// <returns>
        /// The <see cref="MusicNote"/> at the given
        /// <paramref name="musicStringPosition"/>.
        /// </returns>
        /// <exception cref="MusicStringExceptions.InvalidMusicStringPositionException">
        /// <paramref name="musicStringPosition"/> is not a valid music string
		/// position.
        /// </exception>
        /// <remarks>
        /// <paramref name="musicStringPosition"/> refers to an abstract
		/// position on a string that is based on semitones. As such, a
        /// <paramref name="musicStringPosition"/> of x will return a
        /// <see cref="MusicNote"/> that represents <see cref="RootNote"/>
        /// sharpened by x semitones.
        /// </remarks>
        public MusicNote GetMusicNoteAtMusicStringPosition(int musicStringPosition)
        {
            if (IsValidMusicStringPosition(musicStringPosition))
            {
                return RootNote.Sharpened(musicStringPosition);
            }
            else
            {
                var exceptionMessage = string.Format("{0} is not a valid music string position.", musicStringPosition);
                throw new MusicStringExceptions.InvalidMusicStringPositionException(exceptionMessage);
            }
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{MusicNote}"/> of the
		/// <see cref="MusicNote"/> values between
		/// <paramref name="startPosition"/> and <paramref name="endPosition"/>
		/// (inclusive) on this <see cref="MusicString"/>.
        /// </summary>
        /// <param name="startPosition">
        /// The position of the first <see cref="MusicNote"/> to return.
        /// </param>
        /// <param name="endPosition">
        /// The position of the last <see cref="MusicNote"/> to return.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{MusicNote}"/> of the
		/// <see cref="MusicNote"/> values between
		/// <paramref name="startPosition"/> and <paramref name="endPosition"/>
		/// (inclusive) on this <see cref="MusicString"/>.
        /// </returns>
        /// <exception cref="MusicStringExceptions.InvalidMusicStringPositionException">
        /// <paramref name="startPosition"/> is not a valid music string
		/// position.
        /// </exception>
        /// <exception cref="MusicStringExceptions.InvalidMusicStringPositionException">
        /// <paramref name="endPosition"/> is not a valid music string
		/// position.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="startPosition"/> is greater than
		/// <paramref name="endPosition"/>.
        /// </exception>
        public IEnumerable<MusicNote> GetMusicNotes(int startPosition, int endPosition)
        {
            if (!IsValidMusicStringPosition(startPosition))
            {
                var errorMessage = string.Format("Start position ({0}) is not a valid music string position.", startPosition);
                throw new MusicStringExceptions.InvalidMusicStringPositionException(errorMessage);
            }

            if (!IsValidMusicStringPosition(endPosition))
            {
                var errorMessage = string.Format("End position ({0}) is not a valid music string position.", endPosition);
                throw new MusicStringExceptions.InvalidMusicStringPositionException(errorMessage);
            }
            
            if (startPosition > endPosition)
            {
                var errorMessage = "End position must be greater than or equal to start position.";
                throw new ArgumentException(errorMessage);
            }

            for (int currentPosition = startPosition; currentPosition <= endPosition; currentPosition++)
            {
                yield return GetMusicNoteAtMusicStringPosition(currentPosition);
            }
        }

        /// <summary>
        /// Returns an <see cref="IEnumerable{MusicNote}"/> of the
        /// <see cref="MusicNote"/> values between the root position and
		/// <paramref name="endPosition"/> (inclusive) on this
		/// <see cref="MusicString"/>.
        /// </summary>
        /// <param name="endPosition">
        /// The position of the last <see cref="MusicNote"/> to return.
        /// </param>
        /// <returns>
        /// An <see cref="IEnumerable{MusicNote}"/> of the
        /// <see cref="MusicNote"/> values between the root position and
		/// <paramref name="endPosition"/> (inclusive) on this
		/// <see cref="MusicString"/>.
        /// </returns>
        /// <exception cref="MusicStringExceptions.InvalidMusicStringPositionException">
        /// <paramref name="endPosition"/> is not a valid music string
        /// position.
        /// </exception>
        public IEnumerable<MusicNote> GetMusicNotes(int endPosition)
        {
            return GetMusicNotes(0, endPosition);
        }
    }
}
