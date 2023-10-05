using System;
using System.Collections.Generic;
using System.Linq;

class HangmanGame
{
    private string wordToGuess;
    private List<char> guessedLetters;
    private int maxAttempts;
    private int attemptsLeft;

    public HangmanGame(string word, int maxAttempts)
    {
        wordToGuess = word.ToUpper();
        this.maxAttempts = maxAttempts;
        attemptsLeft = maxAttempts;
        guessedLetters = new List<char>();
    }

    public void StartGame()
    {
        Console.WriteLine("Welcome to Hangman!");
        DisplayWordStatus();

        while (attemptsLeft > 0 && !IsWordGuessed())
        {
            Console.Write("Guess a letter: ");
            char guess = char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine();

            if (char.IsLetter(guess))
            {
                if (!guessedLetters.Contains(guess))
                {
                    guessedLetters.Add(guess);

                    if (wordToGuess.Contains(guess))
                    {
                        Console.WriteLine("Correct guess!");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect guess. You have " + --attemptsLeft + " attempts left.");
                    }
                }
                else
                {
                    Console.WriteLine("You already guessed that letter.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid letter.");
            }

            DisplayWordStatus();
        }

        if (IsWordGuessed())
        {
            Console.WriteLine("Congratulations! You've guessed the word: " + wordToGuess);
        }
        else
        {
            Console.WriteLine("Out of attempts! The word was: " + wordToGuess);
        }
    }

    private bool IsWordGuessed()
    {
        return wordToGuess.All(letter => guessedLetters.Contains(letter));
    }

    private void DisplayWordStatus()
    {
        foreach (char letter in wordToGuess)
        {
            if (guessedLetters.Contains(letter))
            {
                Console.Write(letter + " ");
            }
            else
            {
                Console.Write("_ ");
            }
        }
        Console.WriteLine("\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        string[] words = { "programming", "hangman", "computer", "keyboard", "algorithm" };
        Random random = new Random();
        string wordToGuess = words[random.Next(0, words.Length)];
        int maxAttempts = 6;

        HangmanGame game = new HangmanGame(wordToGuess, maxAttempts);
        game.StartGame();

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }
}
