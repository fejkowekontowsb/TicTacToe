using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Board
    {
        public enum BOARD_VALUE {
            EMPTY = 0,
            X = 1,
            O = 2
        }

        short[,] WIN_TABLE = new short[,] {
            {0, 1, 2}, // row 1
            {3, 4, 5}, // row 2
            {6, 7, 8}, // row 3

            {0, 3, 6}, // col 1
            {1, 4, 7}, // col 2
            {2, 5, 8}, // col 3

            {0, 4, 8}, // \
            {2, 4, 6}  // /
        };

        public bool IsFull { get; private set; }
        public bool IsEnd { get; private set; }

        private BOARD_VALUE[] Map = new BOARD_VALUE[9];

        public Board ()
        {
            ClearMap();
        }

        public void ClearMap ()
        {
            IsFull = false;
            IsEnd = false;
            for (int i = 0; i < Map.Length; i++)
            {
                Map[i] = BOARD_VALUE.EMPTY;
            }
        }

        public bool Set (short row, short col, BOARD_VALUE val)
        {
            int index = row * 3 + col;

            if (Map[index] == BOARD_VALUE.EMPTY)
            {
                Map[index] = val;

                CheckWinner();

                return true;
            }
            return false;
        }

        private bool CheckWinner ()
        {
            for (int x = 0; x < WIN_TABLE.GetLength(0); x++)
            {

                if (Map[WIN_TABLE[x, 0]] == BOARD_VALUE.EMPTY)
                    continue;

                Console.WriteLine(Map[WIN_TABLE[x, 0]] + " " + Map[WIN_TABLE[x, 1]] + " " + Map[WIN_TABLE[x, 2]]);

                if (Map[WIN_TABLE[x, 0]] == Map[WIN_TABLE[x, 1]] && Map[WIN_TABLE[x, 0]] == Map[WIN_TABLE[x, 2]])
                {
                    IsEnd = true;
                    return true;
                }
            }

            for (int i = 0; i < Map.Length; i++)
            {
                if (Map[i] == BOARD_VALUE.EMPTY)
                    return false;
            }

            IsFull = true;
            IsEnd = true;
            return false;
        }
    }
}
