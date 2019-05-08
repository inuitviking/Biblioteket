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

		/// <summary>
		/// 	LaanerNummer acts as a getter and setter for this.laanerNummer.
		/// 	The setter is private, as it will only be used within this class
		/// </summary>
		/// <value>{string}</value>
		public string LaanerNummer{
			get{
				return this.laanerNummer;
			}
			set{
				this.laanerNummer = value;
			}
		}// end of LaanerNummer

		/// <summary>
		/// 	Navn acts as a getter and setter for this.navn.
		/// </summary>
		/// <value>{string}</value>
		public string Navn{
			get{
				return this.navn;
			}
			set{
				this.navn = value;
			}
		}// End of Navn

		/*
			This is the class constructor.
		*/
		/// <summary>
		/// 	This is the constructor.
		/// 	It sets this.laanerNummer and this.navn through their setters
		/// </summary>
		/// <param name="navn"></param>
		/// <param name="laanerNummer"></param>
		public Laaner(string navn, string laanerNummer){
			LaanerNummer = laanerNummer;
			Navn = navn;
		} // End of Laaner

		/// <summary>
		/// 	CheckLaanerExists checks on a hexadecimal string if an item in the
		/// 	defined list exists.
		/// </summary>
		/// <param name="newHexID"></param>
		/// <param name="laanere"></param>
		/// <returns>bool</returns>
		public static bool CheckLaanerExists(string newHexID, List<Laaner> laanere){
			bool exists = false;
			if(laanere.Where(w => w.laanerNummer.Contains(newHexID)).Any()){
				exists = true;
			}
			return exists;
		} // End of CheckLaanerExists

	}
}