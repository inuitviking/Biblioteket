using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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
					"a: Vis bibliotekets navn og dato\n"+
					"b: Opret låner\n"+
					"c: Udskriv lånere\n"+
					"d: Find låner\n"+
					"e: Find sidst oprettede låner\n"+
					"f: Udlån en bog\n"+
					"g: Opret bog\n"+
					"h: Vis liste over lånte bøger på bruger\n"+
					"i: Udskriv bøger\n"+
					"j: Opret kategori\n"+
					"k: Udskriv kategorier\n"+
					"l: Find kategori\n"+
					"m: Reserver bog til låner\n"+
					"x: Afslut\n"+
					lines
				);

				keyInfo = Console.ReadKey(); // keyInfo.Key == ConsoleKey.M

				switch (keyInfo.Key){
					case ConsoleKey.A:
						result = 'A';
						quit = true;
						break;
					case ConsoleKey.B:
						result = 'B';
						quit = true;
						break;
					case ConsoleKey.C:
						result = 'C';
						quit = true;
						break;
					case ConsoleKey.D:
						result = 'D';
						quit = true;
						break;
					case ConsoleKey.E:
						result = 'E';
						quit = true;
						break;
					case ConsoleKey.F:
						result = 'F';
						quit = true;
						break;
					case ConsoleKey.G:
						result = 'G';
						quit = true;
						break;
					case ConsoleKey.H:
						result = 'H';
						quit = true;
						break;
					case ConsoleKey.I:
						result = 'I';
						quit = true;
						break;
					case ConsoleKey.J:
						result = 'J';
						quit = true;
						break;
					case ConsoleKey.K:
						result = 'K';
						quit = true;
						break;
					case ConsoleKey.L:
						result = 'L';
						quit = true;
						break;
					case ConsoleKey.M:
						result = 'M';
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
				case 'A':
					Console.WriteLine(bibliotek.HentBibliotek());
					break;
				case 'B':
					Console.Write("Fulde navn: ");
					string newLaanerNavn = Console.ReadLine();
					Console.Write("Email: ");
					string newLaanerEmail = Console.ReadLine();
					Console.WriteLine("---");
					Console.WriteLine(bibliotek.OpretLaaner(newLaanerNavn, newLaanerEmail));
					break;
				case 'C':
					Console.WriteLine(bibliotek.HentAlleLaanere());
					break;
				case 'D':
					Console.Write("Skriv ID eller Email: ");
					Console.WriteLine(bibliotek.HentLaaner(Console.ReadLine()));
					break;
				case 'E':
					Console.WriteLine(bibliotek.HentLaaner());
					break;
				case 'F':
					Console.Write("Skriv ID eller Email: ");
					string searchString = Console.ReadLine();
					Laaner foundLaaner = Laaner.ReturnLaaner(searchString, bibliotek.laanerList);
					Console.Write("Skriv ISBN: ");
					string ISBNNumber = Console.ReadLine();
					Bog foundBog = Bog.ReturnBog(ISBNNumber, bibliotek.bogList);
					Console.WriteLine(foundLaaner.LaanBog(foundBog));
					break;
				case 'G':
					Console.Write("Titel: ");
					string bookTitle = Console.ReadLine();
					Console.Write("Forfatter: ");
					string bookAuthor = Console.ReadLine();
					Console.Write("ISBN: ");
					string bookISBN = Console.ReadLine();
					Bog newBook = new Bog(bookTitle, bookAuthor, bookISBN);
					bibliotek.bogList.Add(newBook);
					Console.WriteLine($"{bookTitle} (ISBN: {bookISBN}) af {bookAuthor} er blevet oprettet.");
					break;
				case 'H':
					Console.Write("Skriv ID eller Email: ");
					searchString = Console.ReadLine();
					foundLaaner = Laaner.ReturnLaaner(searchString, bibliotek.laanerList);
					Console.WriteLine(foundLaaner.ListLaanteBoeger());
					break;
				case 'I':
					Console.WriteLine(bibliotek.HentAlleBoeger());
					break;
				case 'J':
					Console.Write("Skriv kategorinavn: ");
					string kategoriNavn = Console.ReadLine();
					Console.WriteLine(bibliotek.OpretKategori(kategoriNavn));
					break;
				case 'K':
					Console.WriteLine(bibliotek.HentAlleKategorier());
					break;
				case 'L':
					Console.Write("Skriv kategorinavn: ");
					kategoriNavn = Console.ReadLine();
					Console.WriteLine(bibliotek.HentKategori(kategoriNavn));
					break;
				case 'M':
					Console.Write("Skriv ID eller Email: ");
					searchString = Console.ReadLine();
					Console.Write("Skriv ISBN: ");
					ISBNNumber = Console.ReadLine();
					foundBog = Bog.ReturnBog(ISBNNumber, bibliotek.bogList);
					Console.WriteLine(foundBog.ReserverBog(searchString,bibliotek.laanerList));
					break;
				case 'X':
					Console.Clear();
					Environment.Exit(0);
					break;
			}
			Console.WriteLine("\n\nTryk på en vilkårlig knap for at fortsætte.");
			Console.ReadKey();
		}// end of MenuItem

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
		}// End of ClearCurrentConsoleLine()
	}
}
