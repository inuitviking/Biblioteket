using System.Threading;
using System.Security;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Biblioteket.Classes
{
	public class Bog
	{
		string titel, forfatter, kategori, reserveretTil;
		bool udlaant, reserveret;
		DateTime udlaansDato, udloebsDato;

		public bool Reserveret{
			get{
				return this.reserveret;
			}
			set{
				this.reserveret = value;
			}
		}

		public string ReserveretTil{
			get{
				return this.reserveretTil;
			}
			set{
				this.reserveretTil = value;
			}
		}
		// A book has to have a title
		public string Titel{
			get{
				return this.titel;
			}
			set{
				this.titel = value;
			}
		}

		// A book has to have an author
		public string Forfatter{
			get{
				return this.forfatter;
			}
			set{
				this.forfatter = value;
			}
		}

		public string Kategori{
			get{
				return this.kategori;
			}
			set{
				this.kategori = value;
			}
		}

		// We also want to check if the book has been rented or not.
		public bool Udlaant{
			get{
				return this.udlaant;
			}
			set{
				this.udlaant = value;
			}
		}

		// Books usually have an ISBN number; here they always do
		public string ISBN{get;set;}

		// We'd like to know when the book was rented
		public DateTime UdlaansDato{
			get{
				return this.udlaansDato;
			}
			set{
				this.udlaansDato = value;
			}
		}

		// We want to make sure renters only have until a specific date
		public DateTime UdloebsDato{
			get{
				return this.udloebsDato;
			}
			set{
				this.udloebsDato = value;
			}
		}
		// ++++ END OF PROPERTIES ++++

		/// <summary>
		/// 	This is the constructor. It makes sure that the book object contains necessary values.
		/// </summary>
		/// <param name="bookTitle"></param>
		/// <param name="author"></param>
		/// <param name="ISBNID"></param>
		public Bog(string bookTitle, string author, string ISBNID){
			Titel = bookTitle;
			Forfatter = author;
			ISBN = ISBNID;
			Udlaant = false;
			Reserveret = false;
		}// end of Bog

		/// <summary>
		/// 	CheckBookExists checks if a book exists based on the ISBN number
		/// </summary>
		/// <param name="ISBNID"></param>
		/// <param name="bogList"></param>
		/// <returns>bool</returns>
		public static bool CheckBookExists(string ISBNID, List<Bog> bogList){
			bool exists = false;
			if(bogList.Where(x => x.ISBN.Contains(ISBNID)).Any()){
				exists = true;
			}
			return exists;
		}// end of CheckBookExists

		/// <summary>
		/// 	ReturnBog(string,List<Bog>) returns a Bog Object from a specified Bog List.
		/// </summary>
		/// <param name="searchParam"></param>
		/// <param name="bogList"></param>
		/// <returns>Bog</returns>
		public static Bog ReturnBog(string searchParam,List<Bog> bogList){
			if(Bog.CheckBookExists(searchParam, bogList)){
				Bog item = bogList.Where(x => x.ISBN.Contains(searchParam)).FirstOrDefault();
				return item;
			}else{
				throw new ArgumentException("Couldn't return bog: Returnbog(string,List<Bog>)");
			}
		}// End of ReturnBog

		/// <summary>
		/// 	ReserverBog returns a string telling the user that the reservet field is set to true, or
		/// 	if already true, tells the user that
		/// </summary>
		/// <param name="hexID"></param>
		/// <param name="laanerList"></param>
		/// <returns>string</returns>
		public string ReserverBog(string hexID, List<Laaner> laanerList){
			string result = "";
			if(Reserveret == false){
				Laaner laaner = Laaner.ReturnLaaner(hexID, laanerList);
				Reserveret = true;
				ReserveretTil = laaner.LaanerNummer;
				result = $"Bogen \"{this.Titel}\" er reserveret til {laaner.Navn}(ID:{laaner.LaanerNummer})";
			}else{
				result = $"Bogen \"{this.Titel}\" er allerede reserveret til en anden";
			}
			return result;
		}// End of ReserverBog

	}
}