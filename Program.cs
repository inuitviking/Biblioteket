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

			Bibliotek bibliotek = new Bibliotek("Sønderborg Bibliotek");
			Console.WriteLine(bibliotek.HentBibliotek());

			// This doesn't create the "id's 1 through 3" but instead a hexadecimal number
			Console.WriteLine(bibliotek.OpretLaaner("Hans Erik Jensen"));
			Console.WriteLine(bibliotek.OpretLaaner("Jens Hanusson"));
			Console.WriteLine(bibliotek.OpretLaaner("Karen Hansen"));
			Console.WriteLine(bibliotek.HentLaaner());
			bibliotek.HentAlleLaanere();

		}
	}
}
