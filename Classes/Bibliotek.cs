namespace Biblioteket.Classes
{
	public class Bibliotek
	{
		string biblioteksNavn;

		public void Bibliotek(string biblioteksNavn){
			this.biblioteksNavn = biblioteksNavn;
		}

		public string HentBibliotek(){
			string welcome		= "Velkommen til " + this.biblioteksNavn;
			string currentdate	= " - datoen idag er: " + DateTime.Now.ToString("d/M/yyyy");;
		}
	}
}