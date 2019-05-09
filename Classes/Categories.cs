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

		/// <summary>
		/// 	CheckCategoryExists(string, List<Categories>) checks if there's an object with a Name property that matches the string
		/// </summary>
		/// <param name="search"></param>
		/// <param name="kategoriList"></param>
		/// <returns>bool</returns>
		public static bool CheckCategoryExists(string search, List<Categories> kategoriList){
			bool exists = false;
			if(kategoriList.Where(x => x.Name.Contains(search)).Any()){
				exists = true;
			}
			return exists;
		}// end of CheckCategoryExists

		/// <summary>
		/// 	ReturnCategory(string, List<Categories>) returns a Categories object from the specified list.
		/// 	If not, then it throws an exception (because that was easier to do and I'm lazy)
		/// </summary>
		/// <param name="search"></param>
		/// <param name="kategoriList"></param>
		/// <returns>Categories</returns>
		public static Categories ReturnCategory(string search,List<Categories> kategoriList){
			if(CheckCategoryExists(search, kategoriList)){
				Categories item = kategoriList.Where(x => x.Name.Contains(search)).FirstOrDefault();
				return item;
			}else{
				throw new ArgumentException("Couldn't return category: ReturnCategory(string,List<Categories>)");
			}
		}// End of ReturnCategory
	}
}