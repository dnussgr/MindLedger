﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindLedger.Domain
{
    public class Session : NoteBase
    {
        public int SessionNumber { get; set; }
    }

    public class Charakter : NoteBase { }
    public class Npc : NoteBase { }
    public class Location : NoteBase { }
    public class WorldNote : NoteBase { }

}
