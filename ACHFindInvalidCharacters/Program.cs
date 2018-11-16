using System;
using System.IO;
using System.Text.RegularExpressions;

namespace ConsoleApp4
{
	class ACHFindInvalidCharacters
	{
		public static void Main()
		{
			FindInvalidChars(@"C:\TestFiles\achtest.ach");
		}

		public static void FindInvalidChars(string filePath)
		{
			
			using (StreamReader reader = new StreamReader(filePath))
			{
				int lineNumber = 0;

				while (!reader.EndOfStream)
				{
					string fileLine = reader.ReadLine();

					// lineNumber is keeping track of what line we're on, so we can
					// diplay to the user which line we are on.
					lineNumber++;

					// skip any blank lines
					if (string.IsNullOrWhiteSpace(fileLine))
					{
						continue;
					}

					// Regex is to match on anything NOT IN a-z, A-Z, 0-9, or space
					Regex expression = new Regex(@"[^a-zA-Z0-9\s]");

					// charNumber is to keep track of which character to display to the
					// user where the invalid character was found
					int charNumber = 0;

					// iterate through each character one by one and check for a match
					foreach (char character in fileLine)
					{
						charNumber++;
						if (expression.IsMatch(character.ToString()))
						{
							Console.WriteLine($"Line #{lineNumber} Char #{charNumber}: " + character);
						}
					}
				}
			}
		}
	}
}