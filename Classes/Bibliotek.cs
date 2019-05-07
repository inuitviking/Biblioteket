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

		/*
			This is the class constructor
		*/
		public Bibliotek(string navn){
			this.biblioteksNavn = navn;
		} // End of Bibliotek

		/*
			This method returns a string welcoming the user to the library,
			to then display the current date. It's simple, really.
		*/
		public string HentBibliotek(){
			string welcome		= "Velkommen til " + this.biblioteksNavn;
			string currentdate	= " - datoen idag er: " + DateTime.Now.ToString("d/M/yyyy");
			return welcome + currentdate;
		} // End of HentBibliotek

		/*
			This displays laanerNummer, laaner navn, and which library the laaner is
			subscribed to.
		*/
		public string HentLaaner(){
			return "Lånernummer: " + laaner.LaanerNummer
				+ " - Navn: " + laaner.Navn
				+ " er låner hos: " + this.biblioteksNavn;
		} // End of HentLaaner

		/*
			This method creates a laaner. It takes two paramters:
				1. (string) navn
				2. (List<Laaner>) laanerList

			It then uses the RandomHex to generate an 8 character
			hexadecimal string, and then checks if that string
			exists withing the laanerList. If it does, it
			continues to loop until it gets a hexadecimal string
			that doesn't match any laanerNummer in the list.
		*/
		public void OpretLaaner(string navn, List<Laaner> laanerList){

			bool laanerExists = true;
			string newHexID;
			do{
				newHexID = RandomHex(8);
				if(!Laaner.CheckLaanerExists(newHexID, laanerList)){
					laanerExists = false;
				}
			}while(laanerExists);

			laaner = new Laaner(navn, newHexID);
		}// End of OpretLaaner

		/*
			This method creates a random hexadecimal string in a defined number of characters.
			It returns a data type "string" containg a hexadecimal value.
			I've taking it from here:
			https://stackoverflow.com/a/1054087/3613647
		*/
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