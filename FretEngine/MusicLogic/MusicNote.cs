using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FretEngine.Common.DataTypes;

namespace FretEngine.MusicLogic
{
    public class MusicNote
    {
        public AbstractMusicNote Value;
        public int Octave;

        public MusicNote(AbstractMusicNote value, int octave = 4)
        {
            Value = value;
            Octave = octave;
        }
    }
}
