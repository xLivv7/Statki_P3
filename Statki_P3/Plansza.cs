using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Statki_P3
{
    internal class Board
    {
        private const int Size = 9;
        private char[,] grid;
        private char[,] enemyView;
        private Ship[] ships;

        public Board()
        {
            grid = new char[Size, Size];
            enemyView = new char[Size, Size];
            InitializeGrid(grid, '~');
            InitializeGrid(enemyView, '?');
        }

        public void SetupShips()
        {
            int[] shipSizes = { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };
            ships = new Ship[shipSizes.Length];

            for (int i = 0; i < shipSizes.Length; i++)
            {
                while (true)
                {
                    Display();
                    Console.WriteLine($"Ustaw statek o długości {shipSizes[i]}.");
                    Console.Write("Podaj współrzędne (x y) i kierunek (h/v): ");
                    string[] input = Console.ReadLine().Split();
                    int x = int.Parse(input[0]);
                    int y = int.Parse(input[1]);
                    bool horizontal = input[2].ToLower() == "h";

                    if (PlaceShip(x, y, shipSizes[i], horizontal))
                    {
                        ships[i] = new Ship(shipSizes[i], x, y, horizontal);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Nieprawidłowe ustawienie. Spróbuj ponownie.");
                    }
                }
            }
        }

        public bool PlaceShip(int x, int y, int length, bool horizontal)
        {
            if (horizontal && x + length > Size || !horizontal && y + length > Size)
                return false;

            for (int i = 0; i < length; i++)
            {
                int dx = horizontal ? i : 0;
                int dy = horizontal ? 0 : i;

                if (grid[y + dy, x + dx] != '~')
                    return false;
            }

            for (int i = 0; i < length; i++)
            {
                int dx = horizontal ? i : 0;
                int dy = horizontal ? 0 : i;
                grid[y + dy, x + dx] = 'S';
            }

            return true;
        }

        public bool Attack(int x, int y)
        {
            if (grid[y, x] == 'S')
            {
                grid[y, x] = 'X';
                Console.WriteLine("Trafiony!");
                return true;
            }
            else if (grid[y, x] == '~')
            {
                grid[y, x] = 'O';
                Console.WriteLine("Pudło.");
                return false;
            }

            Console.WriteLine("Już strzelałeś w to miejsce.");
            return false;
        }

        public bool AllShipsSunk()
        {
            foreach (var cell in grid)
                if (cell == 'S') return false;
            return true;
        }

        public void Display(bool isEnemy = false)
        {
            Console.WriteLine("  0 1 2 3 4 5 6 7 8");
            for (int y = 0; y < Size; y++)
            {
                Console.Write($"{y} ");
                for (int x = 0; x < Size; x++)
                {
                    Console.Write((isEnemy ? enemyView[y, x] : grid[y, x]) + " ");
                }
                Console.WriteLine();
            }
        }

        private void InitializeGrid(char[,] grid, char defaultChar)
        {
            for (int i = 0; i < Size; i++)
                for (int j = 0; j < Size; j++)
                    grid[i, j] = defaultChar;
        }
    }
}

