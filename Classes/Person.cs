using System;
namespace Biblioteket.Classes
{
	public class Person
	{
		string navn, email;

		public string Navn{
			get{
				return this.navn;
			}
			set{
				this.navn = value;
			}
		}
		public string Email{
			get{
				return this.email;
			}
			set{
				this.email = value;
			}
		}
	}
}