using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FretEngine.Common.Exceptions
{
    /// <summary>
    /// Contains the declaration for MusicString specific custom exceptions.
    /// </summary>
    public class MusicStringExceptions
    {
        /// <summary>
        /// The exception that is thrown when an invalid music string position
		/// is used.
        /// </summary>
        public class InvalidMusicStringPositionException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the
			/// MusicStringExceptions.InvalidMusicStringPositionException
			/// class.
            /// </summary>
            public InvalidMusicStringPositionException()
            {
            }

            /// <summary>
            /// Initializes a new instance of the
			/// MusicStringExceptions.InvalidMusicStringPositionException
            /// class with a specified error message.
            /// </summary>
            /// <param name="message">
            /// The message that describes the error.
            /// </param>
            public InvalidMusicStringPositionException(string message) : base(message)
            {
            }

            /// <summary>
            /// Initializes a new instance of the
            /// MusicStringExceptions.InvalidMusicStringPositionException class
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
            public InvalidMusicStringPositionException(string message, Exception inner) : base(message, inner)
            {
            }
        }

        /// <summary>
        /// The exception that is thrown when a music note is referenced that
        /// does not exist on a given music string.
        /// </summary>
        public class MusicStringHasNoSuchMusicNoteException : Exception
        {
            /// <summary>
            /// Initializes a new instance of the
			/// MusicStringExceptions.MusicStringHasNoSuchMusicNoteException
			/// class.
            /// </summary>
            public MusicStringHasNoSuchMusicNoteException()
            {
            }

            /// <summary>
            /// Initializes a new instance of the
			/// MusicStringExceptions.MusicStringHasNoSuchMusicNoteException
            /// class with a specified error message.
            /// </summary>
            /// <param name="message">
            /// The message that describes the error.
            /// </param>
            public MusicStringHasNoSuchMusicNoteException(string message) : base(message)
            {
            }

            /// <summary>
            /// Initializes a new instance of the
            /// MusicStringExceptions.MusicStringHasNoSuchMusicNoteException class
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
            public MusicStringHasNoSuchMusicNoteException(string message, Exception inner) : base(message, inner)
            {
            }
        }
    }
}
