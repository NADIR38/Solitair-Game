using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolitaireGame.Backend
{
    public class Commands
    {
        public Action Execute {  get; set; }
        public Action Undo { get; set; }
        public Commands(Action Execute,Action Undo) 
        { 
            this.Execute = Execute;
            this.Undo = Undo;

        }
        public Commands()
        {
        }
    }
}
