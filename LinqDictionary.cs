using System;
using System.Linq;
using System.Collections.Generic;

// This Code is need a mono.

namespace LinqDictionary
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var Dict = new DictionaryClass();

			Dict.GetDictItem();

			Dict.GetAllKey();

			Dict.newDictionary();

			Dict.DuplicateKey();

		}
	}

	class DictionaryClass
	{
		
		// 辞書型を定義
		Dictionary<string, int> flowerDict = new Dictionary<string, int>()
		{
			["sunflower"] = 400,
			["pansy"] = 300,
			["tulip"] = 350,
			["rose"] = 500,
			["dahlia"] = 450,
		};

		public void GetDictItem()
		{
			// 全てを出力
			foreach (var item in flowerDict)
				Console.WriteLine("{0} = {1}", item.Key, item.Value);
			Console.WriteLine();

			// 平均を算出
			var average = flowerDict.Average(x => x.Value);
			Console.WriteLine(average);
			Console.WriteLine();

			// 合計を算出
			var total = flowerDict.Sum(x => x.Value);
			Console.WriteLine(total);
			Console.WriteLine();

			// Keyが5文字以下のものを出力
			var items = flowerDict.Where(x => x.Key.Length <= 5);
			foreach (var item in items)
				Console.WriteLine("{0} = {1}", item.Key, item.Value);
			Console.WriteLine();
		}

		// 全てのKeyを取り出す
		public void GetAllKey()
		{
			foreach (var key in flowerDict.Keys)
				Console.WriteLine(key);
			Console.WriteLine();
		}

		// 新たな辞書型を生成
		public void newDictionary()
		{
			var newDict = flowerDict.Where(x => x.Value >= 400)
									.ToDictionary(flower => flower.Key, flower => flower.Value);
			foreach (var item in newDict.Keys)
				Console.WriteLine(item);
			Console.WriteLine();
		}

		// Keyの重複を許可する辞書型
		public void DuplicateKey()
		{
			// 重複辞書型
			var dict = new Dictionary<string, List<string>>()
			{
				{ "PC", new List<string> {"パーソナル コンピュータ", "プログラム カウンタ", } },
				{ "CD", new List<string> {"コンパクト ディスク", "キャッシュ ディスペンサー", } },
			};

			// 辞書型に追加
			var key = "EC";
			var value = "電子商取引";
			if (dict.ContainsKey(key)) {
				dict[key].Add(value);
			} else {
				dict[key] = new List<string> { value };
			}

			// 辞書型の内容を列挙
			foreach (var item in dict)
			{
				foreach (var term in item.Value)
				{
					Console.WriteLine("{0} : {1}", item.Key, term);
				}
			}
		}		
	}
}






















