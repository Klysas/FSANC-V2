using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FSANC_V2.Components
{
	public partial class FileRenameDisplayer : AbstractVideoDisplayer
	{

		#region Public constructors

		public FileRenameDisplayer()
		{
			InitializeComponent();
		}

		#endregion

		#region Private methods

		protected override void Update(Movie movie)
		{
			
		}

		protected override void Update(Series series)
		{
			
		}

		#endregion

		#region Public methods

		public new void Update(AbstractVideo video)
		{

			base.Update(video);
		}

		#endregion
	}
}
