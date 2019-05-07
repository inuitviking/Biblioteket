using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using Biblioteket.Classes;

namespace Biblioteket
{
	class Program
	{
		static void Main(string[] args)
		{
			List<Laaner> laanere = new List<Laaner>();

			Bibliotek bibliotek = new Bibliotek("Sønderborg Bibliotek");
			Console.WriteLine(bibliotek.HentBibliotek());

			bibliotek.OpretLaaner("Hans Erik Jensen", laanere);
			Console.WriteLine(bibliotek.HentLaaner());
			

		}
	}
}
