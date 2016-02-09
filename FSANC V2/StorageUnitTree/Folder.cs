using System;
using System.Collections.Generic;

namespace FSANC_V2.StorageUnitTree
{
	public sealed class Folder : StorageUnit
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private readonly List<StorageUnit> _list;

		//=============================================================
		//	Public constructors
		//=============================================================

		/// <summary>
		/// Creates object of this class for given path.
		/// </summary>
		/// <param name="path"></param>
		/// <exception cref="ArgumentNullException">When path is null.</exception>
		/// <exception cref="ArgumentException">When path is empty.</exception>
		public Folder(string path)
			: base(path)
		{
			_list = new List<StorageUnit>();
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// List of files and folder inside this folder.
		/// </summary>
		public List<StorageUnit> Children
		{
			get { return _list; }
		}
	}
}
