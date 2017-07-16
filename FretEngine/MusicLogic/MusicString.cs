using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FretEngine.Common.DataTypes;

namespace FretEngine.MusicLogic
{
    /// <summary>
    /// This class is an abstraction of a string on a fretted instrument.
    /// </summary>
    /// <remarks>
    /// This class is mutable to reflect the fact that a given string continues
    /// to be the same string no matter which note it is tuned to.
    /// </remarks>
    public class MusicString
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
        public MusicString(MusicNote rootNote)
        {
            RootNote = rootNote;
        }
    }
}
