using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
namespace Biblioteket.Classes
{
	public class Categories
	{
		public string Name{get;set;}

		public Categories(string name){
			Name = name;
		}

		public static bool CheckCategoryExists(string search, List<Categories> kategoriList){
			bool exists = false;
			if(kategoriList.Where(x => x.Name.Contains(search)).Any()){
				exists = true;
			}
			return exists;
		}

		public static Categories ReturnCategory(string search,List<Categories> kategoriList){
			if(CheckCategoryExists(search, kategoriList)){
				Categories item = kategoriList.Where(x => x.Name.Contains(search)).FirstOrDefault();
				return item;
			}else{
				throw new ArgumentException("Couldn't return category: ReturnCategory(string,List<Categories>)");
			}
		}
	}
}