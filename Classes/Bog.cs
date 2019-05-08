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
		string titel, forfatter;
		DateTime udlaansDato, udloebsDato;

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
		}// end of Bog

		public static bool CheckBookExists(string ISBNID, List<Bog> bogList){
			bool exists = false;
			if(bogList.Where(x => x.ISBN.Contains(ISBNID)).Any()){
				exists = true;
			}
			return exists;
		}

		public static Bog ReturnBog(string searchParam,List<Bog> bogList){
			if(Bog.CheckBookExists(searchParam, bogList)){
				Bog item = bogList.Where(x => x.ISBN.Contains(searchParam)).FirstOrDefault();
				return item;
			}else{
				throw new ArgumentException("Couldn't return bog: Returnbog(string,List<Bog>)");
			}
		}

	}
}