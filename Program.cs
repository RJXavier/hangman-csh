using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication6
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random((int)DateTime.Now.Ticks);

            string[] wordBank = { "Blue", "Black", "Yellow", "Orange", "Green", "Red", "White", "Purple", "Brown" };

            string wordToGuess = wordBank[random.Next(0, wordBank.Length)];
            string wordToGuessUppercase = wordToGuess.ToUpper();

            StringBuilder displayToPlayer = new StringBuilder(wordToGuess.Length);
            for (int i = 0; i < wordToGuess.Length; i++)
                displayToPlayer.Append('_');

            List<char> correctGuesses = new List<char>();
            List<char> incorrectGuesses = new List<char>();

            int lives = 6;
            bool won = false;
            int lettersRevealed = 0;

            string input;
            char guess;

            Console.WriteLine("Welcome to Hangman.");
            Console.WriteLine("Guess the Color correctly and you Win!.\n");
            while (!won && lives >= 0)
            {
                Console.Write("Guess a letter: ");

                input = Console.ReadLine().ToUpper();
                guess = input[0];

                if (correctGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was correct!", guess);
                    continue;
                }
                else if (incorrectGuesses.Contains(guess))
                {
                    Console.WriteLine("You've already tried '{0}', and it was wrong!", guess);
                    continue;
                }

                if (wordToGuessUppercase.Contains(guess))
                {
                    correctGuesses.Add(guess);

                    for (int i = 0; i < wordToGuess.Length; i++)
                    {
                        if (wordToGuessUppercase[i] == guess)
                        {
                            displayToPlayer[i] = wordToGuess[i];
                            lettersRevealed++;
                        }
                    }

                    if (lettersRevealed == wordToGuess.Length)
                        won = true;
                }
                else
                {
                    incorrectGuesses.Add(guess);

                    Console.WriteLine("Nope, there's no '{0}' in it!", guess);
                    if (lives == 6)
                    {
                        Console.WriteLine("...................");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" .             O");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine("...");

                    }
                    else if (lives == 5)
                    {
                        Console.WriteLine("...................");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" .             O");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine("...");
                    }
                    else if (lives == 4)
                    {
                        Console.WriteLine("...................");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" .             O");
                        Console.WriteLine(" .            /|");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine("...");
                    }
                    else if (lives == 3)
                    {
                        Console.WriteLine("...................");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" .             O");
                        Console.WriteLine(" .            /|/ ");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine("...");
                    }
                    else if (lives == 2)
                    {
                        Console.WriteLine("...................");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" .             O");
                        Console.WriteLine(" .            /|/ ");
                        Console.WriteLine(" .            /");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine("...");
                    }
                    else if (lives == 1)
                    {
                        Console.WriteLine("...................");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" .             O");
                        Console.WriteLine(" .            /|/ ");
                        Console.WriteLine(" .            / /");
                        Console.WriteLine(" . ");
                        Console.WriteLine(" . ");
                        Console.WriteLine("...");
                    }
                    else if (lives == 0)
                    {
                        Console.WriteLine("...................");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" .             |");
                        Console.WriteLine(" .             O");
                        Console.WriteLine(" .            /|/ ");
                        Console.WriteLine(" .            / /");
                        Console.WriteLine("...");
                    }

                    lives--;

                }

                Console.WriteLine(displayToPlayer.ToString());
            }

            if (won)
                Console.WriteLine("You won!");
            else
                Console.WriteLine("You lost! It was '{0}'", wordToGuess);

            Console.Write("Press ENTER to exit...");
            Console.ReadLine();
        }
    }
}