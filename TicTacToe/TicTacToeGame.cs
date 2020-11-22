using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    //possible cell condition
    public enum State
    {
        Cross,
        Zero,
        Unset
    }
    //possible game winner
    public enum Winner
    {
        Crosses,
        Zeroes,
        Draw,
        GameIsUnfinished
    }

    //class made for game logic only
    class TicTacToeGame
    {
        private State[] board = new State[9];//one-dimensional array for our board
        public int MovesCounter { get; private set; }

        //fill our board with "Unset" status
        public TicTacToeGame()
        {
            for(int i=0; i < board.Length; i++)
            {
                board[i] = State.Unset;
            }
        }
        
        public void MakeMove(int index)
        {
            board[index - 1] = MovesCounter % 2 ==0 ? State.Cross : State.Zero;//our index will start from 1 to make it more simple for users

            MovesCounter++;
        }

        public State GetState(int index)
        {
            return board[index - 1];
        }

        public Winner GetWinner()
        {   
            //winning combinations
            return GetWinner(1,4,7,2,5,8,3,6,9,
                1,2,3,4,5,6,7,8,9,
                1,5,9, 3,5,7);
        }

        //finding the winner
        private Winner GetWinner(params int[] indexes)
        {
            for(int i=0; i < indexes.Length; i += 3)
            {
                bool same = AreSame(indexes[i], indexes [i+1], indexes[i+2]);
                
                //our status has not be "Unset"
                if (same)
                {
                    State state = GetState(indexes[i]);
                    if (state != State.Unset)
                    {
                        return state == State.Cross ? Winner.Crosses : Winner.Zeroes;
                    }
                }
            }
            if(MovesCounter < 9)
            {
                return Winner.GameIsUnfinished;
            }
            return Winner.Draw;
        }

        //method helps us to find the same cell status
        private bool AreSame(int a, int b, int c)
        {
            return GetState(a) == GetState(b) && GetState(a) == GetState(c);
        }
    }
}
