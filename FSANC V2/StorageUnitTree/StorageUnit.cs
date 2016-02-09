using System;
using System.IO;

namespace FSANC_V2.StorageUnitTree
{
	public class StorageUnit
	{
		//=============================================================
		//	Protected constructors
		//=============================================================

		/// <summary>
		/// Creates object of this class for given path.
		/// </summary>
		/// <param name="path"></param>
		/// <exception cref="ArgumentNullException">When path is null.</exception>
		/// <exception cref="ArgumentException">When path is empty.</exception>
		protected StorageUnit(string path)
		{
			if (path == null) throw new ArgumentNullException("path");
			if (path.Equals("")) throw new ArgumentException(@"Path is empty.", "path");

			OriginalName = Path.GetFileName(path);
			OriginalPath = Path.GetDirectoryName(path);
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// [GET] Full path to file or directory(excluding name).
		/// </summary>
		public string OriginalPath
		{
			get;
			protected set;
		}

		/// <summary>
		/// [GET] File or directory name only.
		/// </summary>
		public string OriginalName
		{
			get;
			protected set;
		}

		/// <summary>
		/// [GET/SET] 
		/// </summary>
		public StorageUnit Parent
		{
			get;
			set;
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public override string ToString()
		{
			return Path.Combine(OriginalPath, OriginalName);
		}
	}
}
