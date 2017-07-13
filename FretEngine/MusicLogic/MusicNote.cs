using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FretEngine.Common.DataTypes;

namespace FretEngine.MusicLogic
{
    public class MusicNote : IComparable, IComparable<MusicNote>
    {
        public readonly AbstractMusicNote Value;
        public readonly int Octave;

        public MusicNote(AbstractMusicNote value, int octave = 4)
        {
            Value = value;
            Octave = octave;
        }

        public override string ToString()
        {
            return string.Format("{0} {1}", Value, Octave);
        }

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

            return ((Value == targetMusicNote.Value) && (Octave == targetMusicNote.Octave));
        }

        public bool Equals(MusicNote targetMusicNote)
        {
            if ((object)targetMusicNote == null)
            {
                return false;
            }

            return ((Value == targetMusicNote.Value) && (Octave == targetMusicNote.Octave));
        }

        public override int GetHashCode()
        {
            return new { Value, Octave }.GetHashCode();
        }

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

        public static bool operator != (MusicNote firstMusicNote, MusicNote secondMusicNote)
        {
            return !(firstMusicNote == secondMusicNote);
        }

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

        public int CompareTo(MusicNote targetMusicNote)
        {
            if (targetMusicNote == null)
            {
                return 1;
            }

            if (Octave == targetMusicNote.Octave)
            {
                if (Value == targetMusicNote.Value)
                {
                    return 0;
                }
                else
                {
                    return Value.CompareTo(targetMusicNote.Value);
                }
            }
            else
            {
                return Octave.CompareTo(targetMusicNote.Octave);
            }
        }

        public MusicNote Sharpened(int incrementQuantity)
        {
            int returnedOctaveShift;

            AbstractMusicNote sharpenedAbstractMusicNote = Value.Sharpened(incrementQuantity, out returnedOctaveShift);

            return new MusicNote(sharpenedAbstractMusicNote, Octave + returnedOctaveShift);
        }

        public MusicNote Flattened(int decrementQuantity)
        {
            int returnedOctaveShift;

            AbstractMusicNote flattenedAbstractMusicNote = Value.Flattened(decrementQuantity, out returnedOctaveShift);

            return new MusicNote(flattenedAbstractMusicNote, Octave + returnedOctaveShift);
        }
    }
}
