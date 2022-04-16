using System.Windows.Forms;

namespace DFMLibrary.Module
{
	public class DataGridViewHandler
	{
		DataGridView dgv = null;

		public DataGridViewHandler(DataGridView _dgv)
		{
			this.dgv = _dgv;
		}
		
		/// <summary>
		/// DataGridView Column Setting
		/// </summary>
		/// <param name="headertext">Column Header Text</param>
		/// <param name="name">Column Name</param>
		/// <param name="colNum">Column Index</param>
		/// <param name="width">Column Width</param>
		/// <param name="align">Text Alignment</param>
		public void SetHeaderInfo(string headertext, string name, int colNum, int width, DataGridViewContentAlignment align)
		{
			DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
			{
				HeaderText = headertext,
				Name = name
			};
			dgv.Columns.Add(col);
			dgv.Columns[colNum].Width = width;
			dgv.Columns[colNum].DefaultCellStyle.Alignment = align;
		}
	}
}
