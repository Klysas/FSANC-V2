using System;
using System.IO;

namespace FSANC_V2.StorageUnitTree
{
	public sealed class File : StorageUnit
	{
		//=============================================================
		//	Public constructors
		//=============================================================

		/// <summary>
		/// Creates object of this class for given path.
		/// </summary>
		/// <param name="path"></param>
		/// <exception cref="ArgumentNullException">When path is null.</exception>
		/// <exception cref="ArgumentException">When path is empty.</exception>
		public File(string path)
			: base(path)
		{
			Extension = Path.GetExtension(path);
			OriginalName = Path.GetFileNameWithoutExtension(path);
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// [GET] File extension(e.g. ".avi").
		/// </summary>
		public string Extension
		{
			get;
			private set;
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public override string ToString()
		{
			return base.ToString() + Extension;
		}
	}
}
