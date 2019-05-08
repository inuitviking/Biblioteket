using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace Biblioteket.Classes
{
	public class Bibliotek
	{
		string biblioteksNavn;
		Laaner laaner;
		public List<Laaner> laanerList;

		/// <summary>
		/// 	This is the class constructor.
		/// 	It doesn't return anything, but creates makes sure the
		/// 	bibliotek object has a navn and also creates a new
		/// 	list containing all book renters in a list called
		/// 	laanerList.
		/// </summary>
		/// <param name="navn"></param>
		public Bibliotek(string navn){
			this.biblioteksNavn = navn;
			laanerList = new List<Laaner>();
		} // End of Bibliotek

		/// <summary>
		/// 	HentBibliotek returns a string welcoming the user to the library,
		/// 	to then display the current date. IT's simple, really.
		/// </summary>
		/// <returns>Velkomme til {biblioteksNavn} - datoen idag er: {datetime string}</returns>
		public string HentBibliotek(){
			string welcome		= "Velkommen til " + this.biblioteksNavn;
			string currentdate	= " - datoen idag er: " + DateTime.Now.ToString("d/M/yyyy");
			return welcome + currentdate;
		} // End of HentBibliotek

		/// <summary>
		/// 	HentLaaner displays laanerNummer, laaner navn, and which library the laaner is
		///		subscribed to.
		/// 	Currently, this just returns the last value in laanerList
		/// </summary>
		/// <returns>Lånernummer: {laanerNummer} - Navn: {navn} er låner hos: {biblioteksNavn}</returns>
		public string HentLaaner(){
			return "Lånernummer: " + this.laaner.LaanerNummer
				+ " - Navn: " + this.laaner.Navn
				+ " er låner hos: " + this.biblioteksNavn;
		} // End of HentLaaner

		/// <summary>
		/// 	HentAlleLaanere returns one long string containing all laanere
		/// </summary>
		/// <returns>A full list within a single string of all values contained in laanerList</returns>

		public string HentAlleLaanere(){
			string title = "\n++++ Alle Lånere ++++\n";
			string bottom = "\n+++++++++++++++++++++";
			string userList = "";
			for (int i = 0; i < laanerList.Count; i++){
				userList += $"{i}: " + laanerList[i].LaanerNummer + " - " + laanerList[i].Navn + "\n";
			}
			string result = title + userList + bottom;
			return result;
		}// End of HentAlleLaanere

		/// <summary>
		/// 	OpretLaaner creates a laaner and returns a string
		///		containing laanerNummer and navn.
		///		It uses RandomHex method to generate an 8 character
		///		hexadecimal string, and then checks if that string
		///		exists within the laanerList. If it does, it
		///		continues to loop until it gets a hexadecimal string
		///		that doesn't match any laanerNummer in the list.
		///		The unfortunate thing, is that this isn't future
		///		proof; it can only contain 2048 users, but I think
		/// 	this is good enough to show an example.
		/// </summary>
		/// <param name="navn"></param>
		/// <returns>Låner oprettet:\n    LaanerID:\t{newHexID}\n    Navn:\t{navn}</returns>
		public string OpretLaaner(string navn){

			bool laanerExists = true;
			string newHexID;
			do{
				newHexID = RandomHex(8);
				if(!Laaner.CheckLaanerExists(newHexID, this.laanerList)){
					laanerExists = false;
				}
			}while(laanerExists);

			this.laaner = new Laaner(navn, newHexID);
			this.laanerList.Add(this.laaner);

			return $"Låner oprettet:\n    LaanerID:\t{newHexID}\n    Navn:\t{navn}";
		}// End of OpretLaaner

		/// <summary>
		/// 	RandomHex creates a random hexadecimal string in a defined number of characters.
		///		It returns a data type "string" containg a hexadecimal value.
		///		I've taking it from here:
		///		https://stackoverflow.com/a/1054087/3613647
		/// </summary>
		/// <param name="digits"></param>
		/// <returns>A hexadecimal string of a defined length of characters</returns>
		private static string RandomHex(int digits){

			Random random = new Random();
			byte[] buffer = new byte[digits / 2];
			random.NextBytes(buffer);
			string result = String.Concat(buffer.Select(x => x.ToString("X2")).ToArray());
			if (digits % 2 == 0)
				return result;
			return result + random.Next(16).ToString("X");
		} // End of RandomHex
	}
}