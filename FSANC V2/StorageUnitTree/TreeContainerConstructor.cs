using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FSANC_V2.StorageUnitTree
{
	public sealed class TreeContainerConstructor
	{
		//=============================================================
		//	Private variables
		//=============================================================

		private readonly List<StorageUnit> _loadedUnits;

		/// <summary>
		/// Contains root units.
		/// </summary>
		private readonly List<StorageUnit> _treeRootUnits;

		//=============================================================
		//	Public constructors
		//=============================================================

		public TreeContainerConstructor()
		{
			_loadedUnits = new List<StorageUnit>();
			_treeRootUnits = new List<StorageUnit>();
		}

		//=============================================================
		//	Public properties
		//=============================================================

		/// <summary>
		/// Contains root units. Leafs can be reached through children.
		/// </summary>
		public IEnumerable<StorageUnit> TreeRootStorageUnits
		{
			get { return _treeRootUnits.AsReadOnly(); }
		}

		//=============================================================
		//	Public methods
		//=============================================================

		public void Clear()
		{
			_loadedUnits.Clear();
			_treeRootUnits.Clear();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="unit"></param>
		/// <exception cref="ArgumentNullException">When unit is null.</exception>
		public void Remove(StorageUnit unit)
		{
			if (unit == null) throw new ArgumentNullException("unit");
			if (!IsLoaded(unit.ToString())) return;

			if (unit.Parent == null)
			{
				_treeRootUnits.Remove(unit);
			}
			else
			{
				((Folder)unit.Parent).Children.Remove(unit);
			}
			_loadedUnits.Remove(unit);

			RemoveAllChildren(unit as Folder);
		}

		/// <summary>
		/// Loads folder/file for given path(if it's not already loaded) with its all sub files/subfolders into the three.
		/// </summary>
		/// <param name="path"></param>
		/// <exception cref="ArgumentNullException">When path is null.</exception>
		/// <exception cref="ArgumentException">When path is empty.</exception>
		/// <exception cref="ArgumentException">When path is already loaded.</exception>
		public void UpdateTreeContainer(string path)
		{
			if (path == null) throw new ArgumentNullException("path");
			if (path.Equals("")) throw new ArgumentException(@"Path is empty.", "path");
			if (IsLoaded(path)) throw new ArgumentException("This file/directory already loaded.");

			if (System.IO.File.Exists(path))
			{
				var file = new File(path);
				AddAsRoot(file);
			}
			else if (Directory.Exists(path))
			{
				if (Directory.GetDirectories(path).Length == 0 && Directory.GetFiles(path).Length == 0) return;
				var folder = new Folder(path);
				AddAsRoot(folder);
				UpdateTreeContainer(folder);
			}
		}

		//-------------------------------------------------------------
		//	Private methods
		//-------------------------------------------------------------

		private void AddAsRoot(StorageUnit unit)
		{
			_loadedUnits.Add(unit);
			_treeRootUnits.Add(unit);
		}

		private bool IsLoaded(string path)
		{
			return _loadedUnits.Any(item => item.ToString().Equals(path));
		}

		/// <summary>
		/// Removes all children from loaded list: parent folder and all subfolders.
		/// </summary>
		/// <param name="folder"></param>
		private void RemoveAllChildren(Folder folder)
		{
			if (folder == null) return;
			foreach (var child in folder.Children)
			{
				RemoveAllChildren(child as Folder);
				_loadedUnits.Remove(child);
			}
		}

		private void UpdateTreeContainer(Folder folder)
		{
			foreach (var subFolderPath in Directory.GetDirectories(folder.ToString()))
			{
				if (IsLoaded(subFolderPath)) { continue; }
				var subFolder = new Folder(subFolderPath);
				if (Directory.GetDirectories(subFolder.ToString()).Length == 0 && Directory.GetFiles(subFolder.ToString()).Length == 0) continue;
				subFolder.Parent = folder;
				folder.Children.Add(subFolder);
				_loadedUnits.Add(subFolder);
				UpdateTreeContainer(subFolder);
			}

			foreach (var filePath in Directory.GetFiles(folder.ToString()))
			{
				if (IsLoaded(filePath)) { continue; }
				var file = new File(filePath) { Parent = folder };
				folder.Children.Add(file);
				_loadedUnits.Add(file);
			}
		}
	}
}
