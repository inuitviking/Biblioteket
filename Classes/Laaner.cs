using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Biblioteket.Classes
{
	public class Laaner
	{
		// class fields
		string laanerNummer; // will be a hexadecimal number for fancyness
		string navn;

		/*
			Gets the field laanerNummer.
			Set is private, since it will only be used within the class in the constructor.
		*/
		public string LaanerNummer{
			get{
				return this.laanerNummer;
			}
			set{
				this.laanerNummer = value;
			}
		}

		/*
			Gets the field navn.
			Set is private, so that it can only be used within this class
		*/
		public string Navn{
			get{
				return this.navn;
			}
			set{
				this.navn = value;
			}
		}

		/*
			This is the class constructor.
		*/
		public Laaner(string navn, string laanerNummer){
			LaanerNummer = laanerNummer;
			Navn = navn;
		} // End of Laaner

		/*
			This method checks if a Laaner exists.
			It takes two parameters:
				1. string
				2. List<Laaner>

			It checks whether the string (which is an eight character hexadecimal
			number) exists wihin the list. If it exists, it returns true, but
			false otherwise.
		*/
		public static bool CheckLaanerExists(string newHexID, List<Laaner> laanere){
			bool exists = false;
			if(laanere.Where(w => w.laanerNummer.Contains(newHexID)).Any()){
				exists = true;
			}
			return exists;
		} // End of CheckLaanerExists

	}
}