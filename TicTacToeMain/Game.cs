using System;
using System.Collections.Generic;
using System.Text;
using static TicTacToe.Board;

namespace TicTacToe
{
    public class Game
    {
        Player PlayerX;
        Player PlayerO;

        public Player CurrentPlayer { get; private set; }
        public Player Winner { get; private set; }
        public bool IsFull { get; private set; }
        public bool IsEnd { get; private set; }

        private Board Board;

        public Game (Player playerX, Player playerO)
        {
            this.PlayerX = playerX;
            this.PlayerO = playerO;
            this.CurrentPlayer = playerX;
            this.Board = new Board();
        }

        public BOARD_VALUE MakeMove (short row, short col)
        {
            Board.BOARD_VALUE value = CurrentPlayer == PlayerX ? Board.BOARD_VALUE.X : Board.BOARD_VALUE.O;

            if (Board.Set(row, col, value)) {
                this.ChangeTurn();
                return value;
            }
            return Board.BOARD_VALUE.EMPTY;
        }

        private void CheckWinner ()
        {
            IsEnd = Board.IsEnd;
            IsFull = Board.IsFull;

            if (IsEnd && !IsFull)
            {
                Player previousPlayer = CurrentPlayer == PlayerX ? PlayerO : PlayerX;
                if (previousPlayer == PlayerX)
                    Winner = PlayerX;
                else
                    Winner = PlayerO;
            }
        }

        private void ChangeTurn ()
        {
            if (CurrentPlayer == PlayerX)
                CurrentPlayer = PlayerO;
            else
                CurrentPlayer = PlayerX;

            CheckWinner();
        }

        public void Restart ()
        {
            Board = new Board();
            IsEnd = false;
            IsFull = false;
            Winner = null;
        }
    }
}
