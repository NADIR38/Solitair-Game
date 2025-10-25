using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireGame.Backend
{
    public class Commands
    {
        public Action Excecute {  get; set; }
        public Action Undo { get; set; }
        public Commands(Action Execute,Action Undo) 
        { 
            this.Excecute = Execute;
            this.Undo = Undo;

        }
        public Commands()
        {
        }
    }
}
