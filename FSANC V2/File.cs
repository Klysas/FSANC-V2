using System;
using System.IO;

namespace FSANC_V2
{
	public sealed class File
	{
		//=============================================================
		//	Public constructors
		//=============================================================

		/// <summary>
		/// Creates file for given path.
		/// </summary>
		/// <param name="path">File path.</param>
		public File(string path)
		{
			if (path == null) throw new ArgumentNullException("path");

			Extension = Path.GetExtension(path);
			OriginalName = Path.GetFileNameWithoutExtension(path);
			OriginalPath = Path.GetDirectoryName(path);
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

		/// <summary>
		/// [GET] Full path to file(excluding file name and extension).
		/// </summary>
		public string OriginalPath
		{
			get;
			private set;
		}

		/// <summary>
		/// [GET] File name without extension.
		/// </summary>
		public string OriginalName
		{
			get;
			private set;
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public override string ToString()
		{
			return Path.Combine(OriginalPath, OriginalName + Extension);
		}
	}
}
