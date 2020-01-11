using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        public string Nick { get; private set; }
        public uint Score { get; private set; }

        public Player (string nick)
        {
            this.Nick = nick;
            this.Score = 0;
        }

        public void AddScore ()
        {
            this.Score++;
        }
    }
}
