using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaloDaVelha
{
    /// <summary>
    /// Class where most of the game logic will run
    /// </summary>
    public class Game
    {
        //Creating all the necessary variables for the game
        private Piece[] availablePieces;
        private Piece pickedPiece;
        private Piece[,] board;
        private bool gameWon = false;
        private int turnCounter = 1;
        private string player1;
        private string player2;
        private bool player1Turn = true;
        private int row;
        private int column;
        private ConditionsChecker checker = new ConditionsChecker();

        /// <summary>
        /// Method to start the game and to run the main game loop
        /// </summary>
        public void Start()
        {
            //Instantiates a new Setup and gets the necessary variables
            Setup setup = new Setup();
            (availablePieces, board, player1, player2) = setup.GameSetup();

            //Main game loop that keeps going as long as there isn't a winner or
            //a draw
            while (turnCounter < 17)
            {
                //Calling the necessary methods
                GameTurn();
                GameState();
                gameWon = checker.CheckWin(board, row, column);

                //if one of the players made a winning move, the loop breaks and
                //the game ends
                if (gameWon)
                {
                    break;
                }

                //switching the turns
                player1Turn = !player1Turn;

                //counting the turns to end the game on a draw if it reaches max
                //turns
                turnCounter++;
            }

            //Showing the players the outcome of the game
            if (gameWon)
            {
                if (player1Turn)
                {
                    Console.WriteLine($"{player1} won!");
                }
                else
                {
                    Console.WriteLine($"{player2} won!");
                }
            }
            else
            {
                Console.WriteLine("Game Over! It was a draw!");
            }
        }

        /// <summary>
        /// Shows the current game state to the user
        /// Iterates through all the rows and columns to show if there are
        /// pieces placed and where they are
        /// </summary>
        private void GameState()
        {
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    if (j == board.GetLength(1) - 1)
                    {
                        if (board[i, j] == null)
                        {
                            Console.WriteLine("  ");
                        }
                        else
                        {
                            Console.WriteLine(board[i, j].GetSymbol());
                        }
                    }
                    else
                    {
                        if (board[i, j] == null)
                        {
                            Console.Write("  |");
                        }
                        else
                        {
                            Console.Write($"{board[i, j].GetSymbol()}|");
                        }
                    }
                }
                if (i < board.GetLength(0) - 1)
                {
                    Console.WriteLine("-----------");
                }
            }
            // Explaining symbols to the player
            Console.WriteLine("Label:");
            Console.WriteLine("\u25A1 = Big Squares"); // □
            Console.WriteLine("\u25C7 = Small Squares"); // ◇
            Console.WriteLine("\u25CB = Big Circles"); // ○
            Console.WriteLine("\u25BD = Small Circles"); // ▽
            Console.WriteLine("\u25E6 = Holes"); //◦
            Console.WriteLine("- = No Holes"); //-
        }

        /// <summary>
        /// Method to manage player turns and choices
        /// </summary>
        private void GameTurn()
        {
            //if its player 1's turn
            if (player1Turn)
            {
                // Declaring player's turn
                Console.WriteLine("\n--------------------//--------------------");
                Console.WriteLine($"\nIt's {player1}'s turn!");
                Console.WriteLine($"{player2}, please pick a piece to be played.");
                //show the players which Pieces are available
                Console.WriteLine("\nThese are the pieces available:");
                foreach (Piece x in availablePieces)
                {
                    if (x == null)
                    {
                        continue;
                    }

                    Console.WriteLine($"{x.GetName()} = {x.GetSymbol()}");
                }

                string userInput;
                bool validInput = false;

                //Loop to ask the player to choose a piece and check
                //if its valid
                while (true)
                {
                    Console.Write("\nPiece: ");
                    userInput = Console.ReadLine();

                    //checks if the user input is valid
                    for (int i = 0; i < availablePieces.Length; i++)
                    {
                        if (availablePieces[i] == null)
                        {
                            continue;
                        }

                        if (availablePieces[i].GetName() == userInput)
                        {
                            //if the picked piece is available, removes it from
                            //the available pieces
                            pickedPiece = availablePieces[i];
                            availablePieces[i] = null;
                            validInput = true;
                            break;
                        }
                    }

                    //if its a valid piece, breaks the loop
                    if (validInput)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("\nThat piece does not exist");
                        Console.WriteLine(" or was already played.");
                        Console.WriteLine("Please insert another one.");
                    }
                }

                bool validSpace = false;

                //loop to ask the player where they want to place the piece and
                //checking if its an available space
                while (!validSpace)
                {
                    //Shows the game state to the user for easier placement
                    GameState();
                    Console.Write($"\n{player1}, in which row do you want to");
                    Console.WriteLine(" place the piece?");
                    Console.Write("Please insert a number between 1 and 4: ");
                    row = int.Parse(Console.ReadLine()) - 1;
                    Console.Write($"{player1}, in which column do you want to");
                    Console.WriteLine(" place the piece?");
                    Console.Write("Please insert a number between 1 and 4: ");
                    column = int.Parse(Console.ReadLine()) - 1;

                    //if the player picked a position out of the board, they
                    // have to pick another position
                    if (row > 3 || row < 0 || column > 3 || column < 0)
                    {
                        Console.WriteLine("\n - Not a valid position! - \n");
                        continue;
                    }

                    //if the space is available, places the piece and stops the
                    //loop
                    if (board[row, column] == null)
                    {
                        board[row, column] = pickedPiece;
                        validSpace = true;
                    }
                    else
                    {
                        Console.WriteLine("\n - Not a valid position! - \n");
                    }
                }
            }
            //if its player 2's turn
            //does the same thing as previously explained on player 1's turn but
            //the roles are reversed
            else 
            {
                Console.WriteLine("--------------------//--------------------");
                Console.WriteLine($"\nIt's {player2}'s turn!");
                Console.WriteLine($"{player1}, please pick a piece to be played.");

                foreach (Piece x in availablePieces)
                {
                    if (x == null)
                    {
                        continue;
                    }

                    Console.WriteLine(x.GetName());
                }

                string userInput;
                bool validInput = false;

                while (true)
                {
                    Console.Write("\nPiece: ");
                    userInput = Console.ReadLine();



                    //checks if the user input is valid
                    for (int i = 0; i < availablePieces.Length; i++)
                    {
                        if (availablePieces[i] == null)
                        {
                            continue;
                        }

                        if (availablePieces[i].GetName() == userInput)
                        {
                            pickedPiece = availablePieces[i];
                            availablePieces[i] = null;
                            validInput = true;
                            break;
                        }
                    }

                    if (validInput)
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("\nThat piece does not exist");
                        Console.WriteLine("or was already played.");
                        Console.WriteLine("Please insert another one.");
                    }
                }

                bool validSpace = false;

                while (!validSpace)
                {
                    GameState();
                    Console.Write($"\n{player2}, in which row do you want to");
                    Console.WriteLine(" place the piece?");
                    Console.Write("Please insert a number between 1 and 4: ");
                    row = int.Parse(Console.ReadLine()) - 1;
                    Console.Write($"{player2}, in which column do you want to");
                    Console.WriteLine(" place the piece?");
                    Console.Write("Please insert a number between 1 and 4: ");
                    column = int.Parse(Console.ReadLine()) - 1;

                    if (row > 3 || row < 0 || column > 3 || column < 0)
                    {
                        Console.WriteLine("\n - Not a valid position! - \n");
                        continue;
                    }
                    if (board[row, column] == null)
                    {
                        board[row, column] = pickedPiece;
                        validSpace = true;
                    }
                    else
                    {
                        Console.WriteLine("\n - Not a valid position - \n");
                    }
                }
            }
        }
    }
}