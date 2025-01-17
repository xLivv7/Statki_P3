﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki_P3
{
    internal class GameLogic
    {
        private Board player1Board;
        private Board player2Board;

        public GameLogic(Board player1Board, Board player2Board)
        {
            this.player1Board = player1Board;
            this.player2Board = player2Board;
        }

        public void StartGame()
        {
            bool player1Turn = true;

            while (true)
            {
               Thread.Sleep(4000);
                Board currentBoard = player1Turn ? player2Board : player1Board;
                Board ownBoard = player1Turn ? player1Board : player2Board;

                Console.WriteLine(player1Turn ? "Tura gracza 1" : "Tura gracza 2");
                Console.WriteLine("Twoja plansza:");
                ownBoard.Display(false);
                Console.WriteLine("Widok przeciwnika:");
                currentBoard.Display(true);

                Console.Write("Podaj współrzędne do ataku (x y): ");
                string[] input = Console.ReadLine().Split();
                int x = int.Parse(input[0]);
                int y = int.Parse(input[1]);

                if (currentBoard.Attack(x, y))
                {
                    if (currentBoard.AllShipsSunk())
                    {
                        Console.WriteLine(player1Turn ? "Gracz 1 wygrywa!" : "Gracz 2 wygrywa!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Następuje zmiana tury.");
                }

                player1Turn = !player1Turn;
            }
        }
    }
}
