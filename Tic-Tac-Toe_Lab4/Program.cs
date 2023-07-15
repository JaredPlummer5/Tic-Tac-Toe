using System;

namespace Lab4TicTacToe
{
    public class Player
    {
        public string Name;
        public string Marker;

        public Player(string name, string marker)
        {
            Name = name;
            Marker = marker;
        }
    }

    public static class Program
    {
        public static string[][] Board;

        static void Main(string[] args)
        {
            Console.WriteLine("Hi. Let's play TicTacToe!!");

            Console.Write("Player1's name: ");
            string? player1name = Console.ReadLine();
            Player player1 = new Player(player1name, "X");

            Console.Write("Player2's name: ");
            string? player2name = Console.ReadLine();
            Player player2 = new Player(player2name, "O");

            Console.WriteLine("====== {0} vs {1} =====", player1.Name, player2.Name);

            Board = new string[][] {
                new string[] {"1", "2", "3"},
                new string[] {"4", "5", "6"},
                new string[] {"7", "8", "9"}
            };

            Console.WriteLine("Here's the board");
            DisplayBoard();

            Player currentPlayer = player1;
            string? winner = null;

            while (winner == null)
            {
                Console.WriteLine("It's {0}'s turn!", currentPlayer.Name);

                Console.WriteLine("Please choose a slot.");
                DisplayBoard();
                string? selectedSlot = Console.ReadLine();

                string gameResult = WinnerOfTheGame();
                if (gameResult == player1.Marker)
                {
                    winner = player1.Name;
                    Console.WriteLine("{0} is the winner! Congratulations!", winner);
                }
                else if (gameResult == player2.Marker)
                {
                    winner = player2.Name;
                    Console.WriteLine("{0} is the winner! Congratulations!", winner);
                }
                else if (gameResult == "" && BoardIsFull())
                {
                    Console.WriteLine("The game is a draw.");
                    break;
                }

                bool isValid = SelectionIsValid(selectedSlot);
                if (isValid)
                {
                    int[] indexes = SelectionToIndexes(selectedSlot);
                    int row = indexes[0];
                    int column = indexes[1];
                    Board[row][column] = currentPlayer.Marker;
                }
                else
                {
                    continue;
                }

                SwitchPlayers(ref currentPlayer, player1, player2);
            }
        }

        public static void SwitchPlayers(ref Player currentPlayer, Player player1, Player player2)
        {
            if (currentPlayer == player1)
            {
                currentPlayer = player2;
            }
            else if (currentPlayer == player2)
            {
                currentPlayer = player1;
            }
        }

        public static void SwitchPlayers(ref Player currentPlayer, ref Player otherPlayer)
        {
            string tempName = currentPlayer.Name;
            currentPlayer.Name = otherPlayer.Name;
            otherPlayer.Name = tempName;
        }

        public static bool BoardIsFull()
        {
            // Iterate over the entire board.
            foreach (string[] row in Board)
            {
                foreach (string slot in row)
                {
                    // If we find a number (meaning the slot is not filled), the board is not full.
                    if (slot != "X" && slot != "O")
                    {
                        return false;
                    }
                }
            }

            // If we haven't found any numbers, the board is full.
            return true;
        }


        public static void DisplayBoard()
        {
            Console.WriteLine("|{0}||{1}||{2}|", Board[0][0], Board[0][1], Board[0][2]);
            Console.WriteLine("|{0}||{1}||{2}|", Board[1][0], Board[1][1], Board[1][2]);
            Console.WriteLine("|{0}||{1}||{2}|", Board[2][0], Board[2][1], Board[2][2]);
        }

        public static int[] SelectionToIndexes(string selectedSlot)
        {
            int[] indexes = new int[2];
            switch (selectedSlot)
            {
                case "1":
                    indexes[0] = 0;
                    indexes[1] = 0;
                    break;
                case "2":
                    indexes[0] = 0;
                    indexes[1] = 1;
                    break;
                case "3":
                    indexes[0] = 0;
                    indexes[1] = 2;
                    break;
                case "4":
                    indexes[0] = 1;
                    indexes[1] = 0;
                    break;
                case "5":
                    indexes[0] = 1;
                    indexes[1] = 1;
                    break;
                case "6":
                    indexes[0] = 1;
                    indexes[1] = 2;
                    break;
                case "7":
                    indexes[0] = 2;
                    indexes[1] = 0;
                    break;
                case "8":
                    indexes[0] = 2;
                    indexes[1] = 1;
                    break;
                case "9":
                    indexes[0] = 2;
                    indexes[1] = 2;
                    break;
            }

            return indexes;
        }

       public static bool SelectionIsValid(string selectedSlot)
        {
            int[] indexes = SelectionToIndexes(selectedSlot);
            int row = indexes[0];
            int column = indexes[1];
            string slotValue = Board[row][column];
            if (slotValue == "X" || slotValue == "O")
            {
                Console.WriteLine("Selection is invalid");
                return false;
            }

            return true;
        }
        public static bool SelectionIsValid(string selectedSlot, string slotValue)
        {
            int[] indexes = SelectionToIndexes(selectedSlot);
            int row = indexes[0];
            int column = indexes[1];
            string currentSlotValue = Board[row][column];
            if (currentSlotValue == "X" || currentSlotValue == "O")
            {
                Console.WriteLine("Selection is invalid");
                return false;
            }

            return true;
        }

        public static string WinnerOfTheGame()
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[i][0] == Board[i][1] && Board[i][1] == Board[i][2] && !string.IsNullOrEmpty(Board[i][0]))
                {
                    return Board[i][0];
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (Board[0][i] == Board[1][i] && Board[1][i] == Board[2][i] && !string.IsNullOrEmpty(Board[0][i]))
                {
                    return Board[0][i];
                }
            }

            if (Board[0][0] == Board[1][1] && Board[1][1] == Board[2][2] && !string.IsNullOrEmpty(Board[0][0]))
            {
                return Board[0][0];
            }

            if (Board[0][2] == Board[1][1] && Board[1][1] == Board[2][0] && !string.IsNullOrEmpty(Board[0][2]))
            {
                return Board[0][2];
            }

            return "";
        }


    }
}
