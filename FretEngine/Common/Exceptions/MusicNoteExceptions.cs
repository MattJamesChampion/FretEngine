using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FretEngine.Common.Exceptions
{
    /// <summary>
    /// Contains the declarations for MusicNote specific custom exceptions.
    /// </summary>
    public class MusicNoteExceptions
    {
        /// <summary>
        /// The exception that is thrown when an attempt is made to compare
        /// two MusicNotes that cannot be compared.
        /// </summary>
        public class InvalidMusicNoteComparisonException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the
            /// MusicNoteExceptions.InvalidMusicNoteComparisonException class.
            /// </summary>
            public InvalidMusicNoteComparisonException()
            {
            }

            /// <summary>
            /// Initializes a new instance of the
            /// MusicNoteExceptions.InvalidMusicNoteComparisonException class
            /// with a specified error message.
            /// </summary>
            /// <param name="message">
            /// The message that describes the error.
            /// </param>
            public InvalidMusicNoteComparisonException(string message) : base(message)
            {
            }

            /// <summary>
            /// Initializes a new instance of the
            /// MusicNoteExceptions.InvalidMusicNoteComparisonException class
            /// with a specified error message and a reference to the inner
            /// exception that is the cause of this exception.
            /// </summary>
            /// <param name="message">
            /// The error message that explains the reason for the exception.
            /// </param>
            /// <param name="inner">
            /// The exception that is the cause of the current exception, or a
            /// null reference if no inner exception is specified.
            /// </param>
            public InvalidMusicNoteComparisonException(string message, Exception inner) : base(message, inner)
            {
            }
        }
    }
}
