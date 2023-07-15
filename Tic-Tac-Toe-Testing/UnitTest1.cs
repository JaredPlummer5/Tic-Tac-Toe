using System;

using Lab4TicTacToe;
namespace Tic_Tac_Toe_Testing
{
    public class TicTacToeTests
    {
        [Theory]
        [InlineData("X", "X", "X", "", "", "", "", "", "", "X")]
        [InlineData("", "", "", "O", "O", "O", "", "", "", "O")]
        [InlineData("O", "", "", "O", "", "", "O", "", "", "O")]
        public void Test_WinnerOfTheGame_Row(string a, string b, string c, string d, string e, string f, string g, string h, string i, string expectedWinner)
        {
            // Arrange
            Program.Board = new string[][] {
                new string[] {a, b, c},
                new string[] {d, e, f},
                new string[] {g, h, i}
            };

            // Act
            string winner = Program.WinnerOfTheGame();

            // Assert
            Assert.Equal(expectedWinner, winner);
        }

        [Theory]
        [InlineData("O", "X", "X", "O", "X", "", "", "X", "", "X")]
        [InlineData("O", "X", "",
                    "O", "X", "",
                    "O", "", "", "O")]
        [InlineData("", "X", "O",
                    "", "X", "O",
                    "", "X", "", "X")]
        public void Test_WinnerOfTheGame_Column(string a, string b, string c, string d, string e, string f, string g, string h, string i, string expectedWinner)
        {
            // Arrange
            Program.Board = new string[][] {
        new string[] {a, b, c},
        new string[] {d, e, f},
        new string[] {g, h, i}
    };

            // Act
            string winner = Program.WinnerOfTheGame();

            // Assert
            Assert.Equal(expectedWinner, winner);
        }



        [Theory]
        [InlineData("O", "X", "X","O", "X", "", "X", "", "O", "X")]
        [InlineData("O", "X", "X",
                    "O", "X", "",
                     "", "X", "O","X")]
        public void Test_WinnerOfTheGame_Diagonal(string a, string b, string c, string d, string e, string f, string g, string h, string i, string expectedWinner)
        {
            // Arrange
            Program.Board = new string[][] {
                new string[] {a, b, c},
                new string[] {d, e, f},
                new string[] {g, h, i}
            };

            // Act
            string winner = Program.WinnerOfTheGame();

            // Assert
            Assert.Equal(expectedWinner, winner);
        }

        [Theory]
        [InlineData("O", "X", "X",
                    "O", "", "",
                    "X","", "O", "")]
        [InlineData("O", "X", "X",
                    "O", "X", "",
                    "", "", "O", "")]
        public void Test_WinnerOfTheGame_NoWinner(string a, string b, string c, string d, string e, string f, string g, string h, string i, string expectedWinner)
        {
            // Arrange
            Program.Board = new string[][] {
                new string[] {a, b, c},
                new string[] {d, e, f},
                new string[] {g, h, i}
            };

            // Act
            string winner = Program.WinnerOfTheGame();

            // Assert
            Assert.Equal(expectedWinner, winner);
        }

        [Theory]
        [InlineData("Player1", "Player2", "Player2", "Player1")]
        [InlineData("Alice", "Bob", "Bob", "Alice")]
        public void Test_SwitchPlayers(string player1Name, string player2Name, string expectedPlayer1Name, string expectedPlayer2Name)
        {
            // Arrange
            Player player1 = new Player(player1Name, "X");
            Player player2 = new Player(player2Name, "O");

            // Act
            Program.SwitchPlayers(ref player1, ref player2);

            // Assert
            Assert.Equal(expectedPlayer1Name, player1.Name);
            Assert.Equal(expectedPlayer2Name, player2.Name);
        }


        [Theory]
        [InlineData("1", 0, 0)]
        [InlineData("2", 0, 1)]
        [InlineData("3", 0, 2)]
        [InlineData("4", 1, 0)]
        [InlineData("5", 1, 1)]
        [InlineData("6", 1, 2)]
        [InlineData("7", 2, 0)]
        [InlineData("8", 2, 1)]
        [InlineData("9", 2, 2)]
        public void Test_SelectionToIndexes(string selectedSlot, int expectedRow, int expectedColumn)
        {
            // Act
            int[] indexes = Program.SelectionToIndexes(selectedSlot);

            // Assert
            Assert.Equal(expectedRow, indexes[0]);
            Assert.Equal(expectedColumn, indexes[1]);
        }

        [Theory]
        [InlineData("9", "O", true)]
        [InlineData("1", "X", false)]
        public void Test_SelectionIsValid(string selectedSlot, string slotValue, bool expectedIsValid)
        {
            // Arrange
            Program.Board = new string[][] {
        new string[] {"O", "X", "X"},
        new string[] {"O", "X", ""},
        new string[] {"", "X", ""}
    };

            // Act
            bool isValid = Program.SelectionIsValid(selectedSlot, slotValue);

            // Assert
            Assert.Equal(expectedIsValid, isValid);
        }


        [Theory]
        [InlineData("O,X,X,O,X,O,X,O,X", true)]
        [InlineData("X,O,X,O,X,O,X,O,X", true)]
        public void Test_BoardIsFull(string boardString, bool expectedIsFull)
        {
            // Convert the boardString to a multi-dimensional array
            string[] boardArray = boardString.Split(',');
            string[][] gameBoard = new string[3][];
            for (int i = 0; i < 3; i++)
            {
                gameBoard[i] = new string[3];
                for (int j = 0; j < 3; j++)
                {
                    gameBoard[i][j] = boardArray[i * 3 + j];
                }
            }

            // Arrange
            Program.Board = gameBoard;

            // Act
            bool result = Program.BoardIsFull();

            // Assert
            Assert.Equal(expectedIsFull, result);
        }


    }
}
