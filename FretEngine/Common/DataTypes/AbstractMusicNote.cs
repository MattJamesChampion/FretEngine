using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FretEngine.Common.DataTypes
{
    public enum AbstractMusicNote
    {
        BSharpCNatural,
        CSharpDFlat,
        DNatural,
        DSharpEFlat,
        ENaturalFFlat,
        ESharpFNatural,
        FSharpGFlat,
        GNatural,
        GSharpAFlat,
        ANatural,
        ASharpBFlat,
        BNaturalCFlat
    }

    public static class AbstractMusicNoteExtensions
    {
        private static AbstractMusicNote ModifyAbstractMusicNote(AbstractMusicNote initialAbstractMusicNote, int modifyQuantity, out int octaveShift)
        {
            var numberOfElements = Enum.GetNames(typeof(AbstractMusicNote)).Length;
            var abstractMusicNoteValue = (int)initialAbstractMusicNote;

            var modifiedAbstractMusicNoteValue = ((abstractMusicNoteValue + modifyQuantity) % numberOfElements);
            var totalOctaveShifts = (abstractMusicNoteValue + modifyQuantity) / numberOfElements;

            if (modifiedAbstractMusicNoteValue < 0)
            {
                modifiedAbstractMusicNoteValue = numberOfElements + modifiedAbstractMusicNoteValue;
                totalOctaveShifts -= 1;
            }

            octaveShift = totalOctaveShifts;
            return (AbstractMusicNote)modifiedAbstractMusicNoteValue;
        }

        public static AbstractMusicNote Sharpened(this AbstractMusicNote initialAbstractMusicNote, int incrementQuantity, out int octaveShift)
        {
            int returnedOctaveShift;

            var sharpenedAbstractMusicNote = ModifyAbstractMusicNote(initialAbstractMusicNote, incrementQuantity, out returnedOctaveShift);
            octaveShift = returnedOctaveShift;

            return sharpenedAbstractMusicNote;
        }

        public static AbstractMusicNote Sharpened(this AbstractMusicNote initialAbstractMusicNote, int incrementQuantity)
        {
            int returnedOctaveShift;

            return Sharpened(initialAbstractMusicNote, incrementQuantity, out returnedOctaveShift);
        }

        public static AbstractMusicNote Flattened(this AbstractMusicNote initialAbstractMusicNote, int decrementQuantity, out int octaveShift)
        {
            int returnedOctaveShift;

            decrementQuantity = -decrementQuantity;

            var flattenedAbstractMusicNote = ModifyAbstractMusicNote(initialAbstractMusicNote, decrementQuantity, out returnedOctaveShift);
            octaveShift = returnedOctaveShift;

            return flattenedAbstractMusicNote;
        }

        public static AbstractMusicNote Flattened(this AbstractMusicNote initialAbstractMusicNote, int decrementQuantity)
        {
            int returnedOctaveShift;

            return Flattened(initialAbstractMusicNote, decrementQuantity, out returnedOctaveShift);
        }
    }
}
