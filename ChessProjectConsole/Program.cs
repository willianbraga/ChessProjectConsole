﻿using ChessProjectConsole.Entities.board;
using ChessProjectConsole.Entities.Chess;
using ChessProjectConsole.Entities.Exceptions;
using System;

namespace ChessProjectConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ChessMatch chessMatch = new ChessMatch();

                while (!chessMatch.finished)
                {
                    try
                    {
                        Console.Clear();
                        Screen.PrintMatch(chessMatch);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.GetChessPosition().toPosition();
                        chessMatch.ValidateOriginPosition(origin);

                        bool[,] PositionMoves = chessMatch.board.piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.PrintBoard(chessMatch.board, PositionMoves);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.GetChessPosition().toPosition();
                        chessMatch.ValidateDestinyPosition(origin, destiny);

                        chessMatch.MovingPieces(origin, destiny);
                    }
                    catch (BoardException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();

                    }
                }
                Console.Clear();
                Screen.PrintMatch(chessMatch);

            }
            catch (BoardException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();

        }
    }
}
