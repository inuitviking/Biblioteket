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

		static Char Menu(){

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
					case ConsoleKey.X:
						result = 'X';
						quit = true;
						break;
					default:
						ClearCurrentConsoleLine();
						Console.WriteLine("\nDet var vist ikke en mulighed på menuen.");
						Thread.Sleep(2000);
						break;
				}

			} while (!quit);

			return result;
		}

		static void MenuItem(Char menuItem, Bibliotek bibliotek){
			switch (menuItem){
				case 'V':
					ClearCurrentConsoleLine();
					Console.WriteLine("\n");
					Console.WriteLine(bibliotek.HentBibliotek());
					Thread.Sleep(2000);
					break;
				case 'O':
					ClearCurrentConsoleLine();
					Console.WriteLine("\n");
					Console.Write("Fulde navn: ");
					Console.WriteLine(bibliotek.OpretLaaner(Console.ReadLine()));
					Thread.Sleep(2000);
					break;
				case 'U':
					ClearCurrentConsoleLine();
					Console.WriteLine(bibliotek.HentAlleLaanere());
					Thread.Sleep(2000);
					break;
				case 'X':
					Console.Clear();
					Environment.Exit(0);
					break;
			}
		}

		// https://stackoverflow.com/questions/8946808/can-console-clear-be-used-to-only-clear-a-line-instead-of-whole-console
		public static void ClearCurrentConsoleLine(){
			//Variable that holds the current line
			int currentLineCursor = Console.CursorTop;
			//Sets cursor position
			Console.SetCursorPosition(0, Console.CursorTop);
			//Replaces line content with a space
			Console.Write(new string(' ', Console.WindowWidth));
			//Sets cursor position
			Console.SetCursorPosition(0, currentLineCursor);
		}
	}
}
