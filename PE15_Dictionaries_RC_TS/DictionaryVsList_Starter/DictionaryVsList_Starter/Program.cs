using System;
using System.Collections.Generic;

namespace DictionaryVsList_Starter
{
	class Program
	{
		static void Main(string[] args)
		{
			// Creates a new file reader, which loads a file of words
			// into both a list and a dictionary
			PracticeExerciseFileReader reader = new PracticeExerciseFileReader();

			// Get the two data structures needed for the exercise
			List<String> wordList = reader.WordList;
			Dictionary<String, bool> wordDictionary = reader.WordDictionary;

			// *********************
			// TODO: Put your code between here...
			//Create StopWatch Object to check runtimes
			System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
			//Get User Input
			string input  = SmartConsole.GetStringInput("Do you want to search the (L)ist or (D)ictionary?").ToUpper();
			//Check User Input
            switch (input)
            {
				case "L":
				case "LIST":
					//Search for double words in list and time it
					watch.Start();
					foreach(string word in wordList)
                    {
						string doubleWord = word + word;
                        if (wordList.Contains(doubleWord))
                        {
							Console.WriteLine(doubleWord);
                        }
                    }
					watch.Stop();
					Console.WriteLine("List search for all double words took {0}ms/n",
						watch.Elapsed.TotalMilliseconds);
					Console.WriteLine();
					break;
				case "D":
				case "DICTIONARY":
					//Search for double words in dictionary and time it
					watch.Start();
					foreach(string word in wordList)
                    {
						string doubleWord = word + word;
                        if (wordDictionary.ContainsKey(doubleWord))
                        {
							Console.WriteLine(doubleWord);
							wordDictionary[doubleWord] = true;
                        }
                    }
					watch.Stop();
					Console.WriteLine("Dictionary search for all double words took {0}ms/n",
						watch.Elapsed.TotalMilliseconds);
					Console.WriteLine();
					//Create quit bool
					bool quit = false;
					//Loop through scenario
                    while (!quit)
                    {
						//Get user input
						input = SmartConsole.GetStringInput("Which word do you want to check(or enter quit)?").ToLower();
						//Check if user entered quit
						if (input == "quit")
						{
							quit = true;
						}
						//Check if user input is in dictionary
						else if (wordDictionary.ContainsKey(input))
                        {
							//Check if user input is a double word
                            if (wordDictionary[input])
                            {
								Console.WriteLine("{0} is a double word!",
									input);
                            }else if (!wordDictionary[input])
                            {
								Console.WriteLine("{0} is not a double word!",
									input);
                            }
						}
						else if (!wordDictionary.ContainsKey(input))
                        {
							Console.WriteLine("{0} doesn't exist in the dictionary!",
								input);
                        }
                    }
					break;
				default:
					Console.WriteLine("Invalid");
					break;
            }
			// ...and here.
			// *********************

		}
	}
}
