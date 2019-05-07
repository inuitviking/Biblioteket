using System;
using Biblioteket.Classes;

namespace Biblioteket
{
	class Program
	{
		static void Main(string[] args)
		{
			Bibliotek bibliotek = new Bibliotek("Sønderborg bibliotek");
			bibliotek.HentBibliotek();
		}
	}
}
