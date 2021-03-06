using System;
using System.Windows.Forms;

namespace DFMLibrary.Module
{
	public class DataGridViewHandler
	{
		private DataGridView dgv = null;

		private int _ColumnCount = 0;
		private int _RowCount = 0;

		public int ColumnCount { get { return _ColumnCount; } }
		public int RowCount { get { return _RowCount; } }

		public DataGridViewHandler(DataGridView dgv)
		{
			this.dgv = dgv;
			this.dgv.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
			this.dgv.RowHeadersVisible = false;
		}

		/// <summary>
		/// return datagridview
		/// </summary>
		/// <returns></returns>
		public DataGridView GetDataGridView()
		{
			return dgv;
		}

		/// <summary>
		/// add column header
		/// </summary>
		/// <param name="headertext">Column Header Text</param>
		/// <param name="name">Column Name</param>
		/// <param name="colNum">Column Index</param>
		/// <param name="width">Column Width</param>
		/// <param name="align">Text Alignment</param>
		public int AddHeader(string headertext, string name, int colNum, int width, DataGridViewContentAlignment align)
		{
			int count = 0;

			try
			{
				DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn
				{
					HeaderText = headertext,
					Name = name
				};
				dgv.Columns.Add(col);
				dgv.Columns[colNum].Width = width;
				dgv.Columns[colNum].DefaultCellStyle.Alignment = align;

				count++;
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				_ColumnCount += count;
			}

			return count;
		}

		/// <summary>
		/// show header
		/// </summary>
		public void ShowHeader()
		{
			dgv.ColumnHeadersVisible = true;
		}

		/// <summary>
		/// hide header
		/// </summary>
		public void HideHeader()
		{
			dgv.ColumnHeadersVisible = false;
		}

		/// <summary>
		/// add Row
		/// </summary>
		/// <param name="values"></param>
		public void AddRow(params object[] values)
		{
			int count = 0;

			try
			{
				dgv.Rows.Add(values);
				count++;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				_RowCount += count;
			}
		}

		/// <summary>
		/// add rows
		/// </summary>
		/// <param name="rows"></param>
		public void AddRowRange(DataGridViewRow[] rows)
		{
			int count = 0;
			try
			{
				dgv.Rows.AddRange(rows);
				count = rows.Length;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				_RowCount += count;
			}

		}

		/// <summary>
		/// remove Row
		/// </summary>
		/// <param name="values"></param>
		public void RemoveRow(int row)
		{
			int count = 0;

			try
			{
				dgv.Rows.RemoveAt(row);
				count++;
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				_RowCount -= count;
			}
		}

		/// <summary>
		/// clear And refresh datagridview
		/// </summary>
		public void ClearAndRefresh()
		{
			dgv.Rows.Clear();
			dgv.Refresh();
			_RowCount = 0;
		}
	}
}
