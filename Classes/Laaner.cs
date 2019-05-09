using System.Runtime.CompilerServices; // ??????
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Biblioteket.Classes
{
	public class Laaner : Person
	{
		// class fields
		string laanerNummer; // will be a hexadecimal number for fancyness
		double boede;
		public List<Bog> laanteBoegerList = new List<Bog>();

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
		/// 	This is the constructor.
		/// 	It sets this.laanerNummer and this.navn through their setters
		/// </summary>
		/// <param name="navn"></param>
		/// <param name="laanerNummer"></param>
		public Laaner(string navn, string email, string laanerNummer){
			LaanerNummer = laanerNummer;
			Navn = navn;
			Email = email;
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
			if(laanere.Where(x => x.laanerNummer.Contains(newHexID)).Any()){
				exists = true;
			}
			return exists;
		} // End of CheckLaanerExists

		/// <summary>
		/// 	CheckLaanerExistsEmail checks on an email string if an item in the
		/// 	defined list exists.
		/// </summary>
		/// <param name="email"></param>
		/// <param name="laanere"></param>
		/// <returns>bool</returns>
		public static bool CheckLaanerExistsEmail(string email, List<Laaner> laanere){
			bool exists = false;
			if(laanere.Where(x => x.Email.Contains(email)).Any()){
				exists = true;
			}
			return exists;
		}

		/// <summary>
		/// 	ReturnLaaner(List<Laaner>) returns the last item in the defined list
		/// </summary>
		/// <param name="laanere"></param>
		/// <returns></returns>
		public static Laaner ReturnLaaner(List<Laaner> laanere){
			Laaner item = laanere[laanere.Count - 1];
			return item;
		}

		/// <summary>
		/// 	ReturnLaaner(string, List<Laaner>) returns a searched for item in the defined list.
		/// 	With the help of CheckLaanerExists or CheckLaanerExistsEmail it can find a specific
		/// 	item in the laaner list. It first checks if the string matches a hexadecimal value,
		/// 	and if not, it checks if the string matches with an email. If nothing is found
		/// 	it throws an exception.
		/// </summary>
		/// <param name="searchParam"></param>
		/// <param name="laanere"></param>
		/// <returns></returns>
		public static Laaner ReturnLaaner(string searchParam,List<Laaner> laanere){
			if(Laaner.CheckLaanerExists(searchParam, laanere)){
				Laaner item = laanere.Where(x => x.laanerNummer.Contains(searchParam)).FirstOrDefault();
				return item;
			}else if(Laaner.CheckLaanerExistsEmail(searchParam, laanere)){
				Laaner item = laanere.Where(x => x.Email.Contains(searchParam)).FirstOrDefault();
				return item;
			}else{
				throw new ArgumentException("Couldn't return låner: ReturnLaaner(string,List<Laaner>)");
			}
		}

		/// <summary>
		/// 	LaanBog(Bog) returns a string telling the user that a person has rented a specific book
		/// </summary>
		/// <param name="book"></param>
		/// <returns>string</returns>
		public string LaanBog(Bog book){

			if(book.Udlaant == false){
				book.UdlaansDato = DateTime.Now;
				book.UdloebsDato = DateTime.Now.AddDays(30);
				book.Udlaant = true;
				laanteBoegerList.Add(book);
				string title = book.Titel;
				return $"{Navn} ({LaanerNummer}) har lånt bogen {title}";
			}else{
				return "Bogen er allerede udlånt!";
			}
		}

		/// <summary>
		/// 	ListLaanteBoeger() returns a string containing a list of all the currently rented books
		/// 	by this specific Laaner object. It also displays if there are any rental expiries and
		/// 	how much the Laaner needs to pay in fines. The current fine rate per book is 180
		/// </summary>
		/// <returns></returns>
		public string ListLaanteBoeger(){
			StringBuilder bookString = new StringBuilder();
			string header = "++++ Liste over lånte bøger ++++\n";
			string footer = "++++++++++++++++++++++++++++++++\n";
			string fineString = "";

			if(laanteBoegerList == null){
				bookString.Append("Ingen bøger er udlånt til denne person.\n");
			}else{
				for (int i = 0; i < laanteBoegerList.Count; i++){
					string ISBN				= laanteBoegerList[i].ISBN;
					string title			= laanteBoegerList[i].Titel;
					DateTime rentalExpiry	= laanteBoegerList[i].UdloebsDato;
					string expired 			= "";

					if(rentalExpiry < DateTime.Now){
						expired = "\tLånetid udløbet!";
						this.boede = this.boede + 180;
					}

					bookString.Append(ISBN).Append(" - ").Append(title).Append(expired).Append("\n");
				}
			}

			if(this.boede > 0){
				string fine = Convert.ToString(this.boede);
				fineString = $"{Navn} (ID:{LaanerNummer})har en bøde på {fine}kr.\n";
			}

			return header + bookString + fineString + footer;
		}

	}
}