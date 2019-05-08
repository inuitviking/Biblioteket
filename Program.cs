using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Biblioteket.Classes;

namespace Biblioteket
{
	class Program
	{
		static void Main(string[] args)
		{

			Bibliotek bibliotek = new Bibliotek("Sønderborg Bibliotek");
			Char menuItem;

			do{
				menuItem = Menu();
				MenuItem(menuItem, bibliotek);
			} while (true);

		}

		/// <summary>
		/// 	Menu displays a string containing instructions to the user, so they can
		/// 	navigate the program. It listens for key presses from the user, and
		/// 	checks if the keypresses are the correct keys.
		/// </summary>
		/// <returns>{Char}</returns>
		static Char Menu(){

			Console.Clear();
			// Exactly 26 characters long (or so I beleive)
			string lines = "--------------------------";
			ConsoleKeyInfo keyInfo;
			Char result = 'Å'; // it absolutely needed a value for whatever reason, so Å is used :P
			bool quit = false;

			do{
				Console.WriteLine(
					lines + "\n" +
					"Du kan vælge følgende:\n"+
					"v: Vis bibliotekekts navn og dato\n"+
					"o: Opret låner\n"+
					"u: Udskriv lånere\n"+
					"h: Find låner på ID\n"+
					"x: Afslut\n"+
					lines
				);

				keyInfo = Console.ReadKey(); // keyInfo.Key == ConsoleKey.M

				switch (keyInfo.Key){
					case ConsoleKey.V:
						result = 'V';
						quit = true;
						break;
					case ConsoleKey.O:
						result = 'O';
						quit = true;
						break;
					case ConsoleKey.U:
						result = 'U';
						quit = true;
						break;
					case ConsoleKey.F:
						result = 'F';
						quit = true;
						break;
					case ConsoleKey.X:
						result = 'X';
						quit = true;
						break;
					default:
						ClearCurrentConsoleLine();
						Console.WriteLine("\nDet var vist ikke en mulighed på menuen.");
						break;
				}

			} while (!quit);

			return result;
		} // End of Menu class

		/// <summary>
		/// 	MenuItem writes the appropriate things according to Char menuItem.
		/// 	It also needs to know which Bibliotek to it needs to use (even if
		/// 	there is only one).
		/// </summary>
		/// <param name="menuItem"></param>
		/// <param name="bibliotek"></param>
		static void MenuItem(Char menuItem, Bibliotek bibliotek){
			Console.Clear();
			switch (menuItem){
				case 'V':
					ClearCurrentConsoleLine();
					Console.WriteLine("\n");
					Console.WriteLine(bibliotek.HentBibliotek());
					Console.WriteLine("\n\nTryk på en vilkårlig knap for at fortsætte.");
					Console.ReadKey();
					break;
				case 'O':
					ClearCurrentConsoleLine();
					Console.WriteLine("\n");
					Console.Write("Fulde navn: ");
					string newLaanerNavn = Console.ReadLine();
					Console.Write("Email: ");
					string newLaanerEmail = Console.ReadLine();
					Console.WriteLine("---");
					Console.WriteLine(bibliotek.OpretLaaner(newLaanerNavn, newLaanerEmail));
					Console.WriteLine("\n\nTryk på en vilkårlig knap for at fortsætte.");
					Console.ReadKey();
					break;
				case 'U':
					ClearCurrentConsoleLine();
					Console.WriteLine(bibliotek.HentAlleLaanere());
					Console.WriteLine("\n\nTryk på en vilkårlig knap for at fortsætte.");
					Console.ReadKey();
					break;
				case 'F':
					Console.Write("Skriv ID eller Email: ");
					Console.WriteLine(bibliotek.HentLaaner(Console.ReadLine()));
					Console.WriteLine("\n\nTryk på en vilkårlig knap for at fortsætte.");
					Console.ReadKey();
					break;
				case 'X':
					Console.Clear();
					Environment.Exit(0);
					break;
			}
		}// end of MenuItem

		/// <summary>
		/// 	https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
		/// 	ClearCurrentConsoleLine moves Console.CursorLeft to 0 on the current line
		/// 	and writes spaces to it to overwrite the line's contents
		/// </summary>
		public static void ClearCurrentConsoleLine(){
			//Variable that holds the current line
			int currentLineCursor = Console.CursorTop;
			//Sets cursor position
			Console.SetCursorPosition(0, Console.CursorTop);
			//Replaces line content with a space
			Console.Write(new string(' ', Console.WindowWidth));
			//Sets cursor position
			Console.SetCursorPosition(0, currentLineCursor);
		}// End of ClearCurrentConsoleLine
	}
}
