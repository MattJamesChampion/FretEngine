using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FretEngine.Common.DataTypes;

namespace FretEngine.MusicLogic
{
    public class MusicString
    {
        public MusicNote RootNote;

        public MusicString(MusicNote rootNote)
        {
            RootNote = rootNote;
        }
    }
}
