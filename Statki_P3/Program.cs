﻿using Statki_P3;
using System;
using System.Collections.Generic;

namespace Statki
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Gra w statki: Dwóch graczy");

            var player1Board = new Board();
            var player2Board = new Board();

            Console.WriteLine("Gracz 1: Rozmieść swoje statki.");
            player1Board.SetupShips();
            Console.Clear();

            Console.WriteLine("Gracz 2: Rozmieść swoje statki.");
            player2Board.SetupShips();
            Console.Clear();

            Console.WriteLine("Rozpoczynamy grę!");
            var game = new GameLogic(player1Board, player2Board);
            game.StartGame();
        }
    }
}