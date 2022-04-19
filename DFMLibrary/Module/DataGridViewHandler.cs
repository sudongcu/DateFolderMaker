using System.Windows.Forms;

namespace DFMLibrary.Module
{
	public class DataGridViewHandler
	{
		private DataGridView dgv = null;

		private int count = 0;

		public int Count { get { return count; } }

		public DataGridViewHandler(DataGridView dgv)
		{
			this.dgv = dgv;
			this.dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgv.RowHeadersVisible = false;
		}

		/// <summary>
		/// Return DateGridView
		/// </summary>
		/// <returns></returns>
		public DataGridView GetDataGridView()
		{
			return dgv;
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

		/// <summary>
		/// Show DateGridView Header
		/// </summary>
		public void HeaderShow()
		{
			dgv.ColumnHeadersVisible = true;
		}

		/// <summary>
		/// Hide DateGridView Header
		/// </summary>
		public void HeaderHide()
		{
			dgv.ColumnHeadersVisible = false;
		}

		/// <summary>
		/// Add Row Values
		/// </summary>
		/// <param name="values"></param>
		public void RowAdd(params object[] values)
		{
			dgv.Rows.Add(values);
			count++;
		}

		/// <summary>
		/// Remove Row
		/// </summary>
		/// <param name="values"></param>
		public void RowRemove(int row)
		{
			dgv.Rows.RemoveAt(row);
			count--;
		}

		/// <summary>
		/// DataGridView Clear And Refresh
		/// </summary>
		public void ClearAndRefreshGrid()
		{
			dgv.Rows.Clear();
			dgv.Refresh();
			count = 0;
		}
	}
}
