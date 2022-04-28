using DFMLibrary.Module;
using DFMLibrary.Utils;
using DFMObject.Enums;
using DFMObject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DateFolderMaker
{
	public partial class DateFolderMaker : Form
	{
		// loaded files
		private string[] Files;
		// after load file, move into setFileList
		private List<string> FilesList = new List<string>();

		delegate void ShowDelegate();

		private DataGridViewHandler dataGridViewHandler;

		public DateFolderMaker()
		{
			InitializeComponent();
		}

		private void DateFolderMaker_Load(object sender, EventArgs e)
		{
			text_path.Text = "";
			text_new.Text = "";

			total_label.Text = DataUtil.TotalTextFormat(0);

			InitGrid();
		}

		/// <summary>
		/// initialize datagridview
		/// </summary>
		private void InitGrid()
		{
			dataGridViewHandler = new DataGridViewHandler(dataGridView);
			dataGridViewHandler.AddHeader("File", "File", (int)COL.FILE, 400, DataGridViewContentAlignment.MiddleLeft);
			dataGridViewHandler.AddHeader("Date", "Date", (int)COL.DATE, 200, DataGridViewContentAlignment.MiddleLeft);
			dataGridViewHandler.ClearAndRefreshGrid();
		}

		/// <summary>
		/// initialize progressbar
		/// </summary>
		/// <param name="totFiles"></param>
		private void InitProgressBar(int totFiles)
		{
			progressBar.Style = ProgressBarStyle.Continuous;
			progressBar.Minimum = 0;
			progressBar.Maximum = totFiles;
			progressBar.Step = 1;
			progressBar.Value = 0;
		}

		/// <summary>
		/// load files and bind to datagridview
		/// </summary>
		private void SetLoadFiles()
		{
			try
			{
				// clear GridView
				dataGridViewHandler.ClearAndRefreshGrid();

				InitProgressBar(FilesList.Count + 1);

				// hide grid header, until progress is over for speed
				dataGridViewHandler.HideHeader();

				List<DataGridViewRow> rows = new List<DataGridViewRow>();

				foreach (string file in FilesList)
				{
					DataGridViewRow row = new DataGridViewRow();
					row.CreateCells(dataGridViewHandler.GetDataGridView());
					row.Cells[(int)COL.FILE].Value = file.Substring(text_path.Text.Length + 1);
					row.Cells[(int)COL.DATE].Value = FileUtil.GetFileDate(file);

					rows.Add(row);

					progressBar.PerformStep();
				}

				dataGridViewHandler.AddRowRange(rows.ToArray());
				progressBar.PerformStep();

				// show grid header
				dataGridViewHandler.ShowHeader();

				total_label.Text = DataUtil.TotalTextFormat(dataGridViewHandler.RowCount);
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		/// <summary>
		/// clear all controls
		/// </summary>
		private void Clear()
		{
			dataGridViewHandler.ClearAndRefreshGrid();

			text_path.Text = "";
			text_new.Text = "";

			total_label.Text = DataUtil.TotalTextFormat(0);

			Files = null;
			FilesList.Clear();

			InitProgressBar(0);
		}

		/// <summary>
		/// copy files from 'path' to 'new path'
		/// </summary>
		/// <param name="item"></param>
		/// <param name="originPath"></param>
		/// <param name="newPath"></param>
		/// <returns></returns>
		private async Task FileCopy(DataGridViewModel item, string originPath, string newPath)
		{
			try
			{
				await Task.Run(() =>
				{
				// get directory info
				DirectoryInfo directoryInfo = new DirectoryInfo(DataUtil.FilePath(newPath, item.folder));

				// if the directory does not exist, create new one
				if (!directoryInfo.Exists)
						directoryInfo.Create();

					foreach (string file in item.fileList)
					{
						if (new FileInfo(DataUtil.FilePath(newPath, item.folder, file)).Exists == false)
						{
							File.Copy(DataUtil.FilePath(originPath, file), DataUtil.FilePath(newPath, item.folder, file), false);
							if (InvokeRequired)
							{
								ShowDelegate sd = new ShowDelegate(progressBar.PerformStep);
								Invoke(sd);
							}
							else
							{
								progressBar.PerformStep();
							}
						}
					}
				});
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		#region Event

		/// <summary>
		/// file load button click event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_load_Click(object sender, EventArgs e)
		{
			try
			{
				OpenFileDialog of = new OpenFileDialog
				{
					Title = "Load Files",
					RestoreDirectory = true,
					Multiselect = true
				};

				if (of.ShowDialog() == DialogResult.OK)
				{
					if (of.FileNames.Length == 0)
						return;

					Files = of.FileNames;
					for (int i = 0; i < Files.Length; i++)
					{
						FilesList.Add(Files[i]);
					}

					// get first file path
					string filePath = Path.GetDirectoryName(FilesList[0]);

					if (filePath != "")
					{
						text_path.Text = filePath;
						text_new.Text = filePath + "\\DateFolderMaker";
					}

					// add files to gridview
					SetLoadFiles();
				}
			}
			catch(Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		/// <summary>
		/// new file load button click event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_newload_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog dialog = new FolderBrowserDialog
			{
				SelectedPath = @"C:\"
			};
			dialog.ShowDialog();
			text_new.Text = dialog.SelectedPath;
		}

		/// <summary>
		/// create button event
		/// - create folder and copy all files on dataviewgrid
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_create_Click(object sender, EventArgs e)
		{
			// result grid view list, grid view divides by create date
			List<DataGridViewModel> list = new List<DataGridViewModel>();

			#region Bind List Model

			if (dataGridViewHandler.RowCount > 0)
			{
				// create temp grid view data
				DataGridView tempDataGridView = dataGridViewHandler.GetDataGridView();
				// sort by date asc
				tempDataGridView.Sort(tempDataGridView.Columns["Date"], ListSortDirection.Ascending);

				// model of grid view 
				DataGridViewModel model = new DataGridViewModel();

				// list of file data
				List<string> fileList = new List<string>();

				for (int i = 0; i < tempDataGridView.Rows.Count; i++)
				{
					// if file name is empty, move to next
					if (tempDataGridView.Rows[i].Cells[0].Value is null)
						continue;

					// if folder is empty, create folder and add list
					if (string.IsNullOrEmpty(model.folder))
					{
						model.folder = DataUtil.ShortDateTimeFormat(tempDataGridView.Rows[i].Cells[(int)COL.DATE].Value.ToString());
						fileList.Add(tempDataGridView.Rows[i].Cells[(int)COL.FILE].Value.ToString());
					}
					else
					{
						// when date is same, add item
						if (model.folder == DataUtil.ShortDateTimeFormat(tempDataGridView.Rows[i].Cells[(int)COL.DATE].Value.ToString()))
						{
							fileList.Add(tempDataGridView.Rows[i].Cells[(int)COL.FILE].Value.ToString());
						}
						else
						{
							// if date is changed, set model add list
							model.fileList = fileList;
							list.Add(model);

							model = null;
							fileList = null;
							model = new DataGridViewModel();
							fileList = new List<string>();

							model.folder = DataUtil.ShortDateTimeFormat(tempDataGridView.Rows[i].Cells[(int)COL.DATE].Value.ToString());
							fileList.Add(tempDataGridView.Rows[i].Cells[(int)COL.FILE].Value.ToString());
						}
					}

					// add last grid view
					// count - 1 - 1( last empty row )
					if (i == tempDataGridView.Rows.Count - 2)
					{
						model.fileList = fileList;
						list.Add(model);
					}
				}
			}


			#endregion / Bind List Model


			#region Files Copy

			string originPath = text_path.Text;
			string newPath = text_new.Text;

			if (list.Count > 0)
			{
				// progress bar init
				InitProgressBar(list.Sum(s => s.fileList.Count()));

				try
				{
					List<Task> taskList = new List<Task>();

					// add task queue
					foreach (DataGridViewModel item in list)
					{
						taskList.Add(FileCopy(item, originPath, newPath));
					}

					// tasking
					Task taskAll = Task.WhenAll(taskList);

					Task taskComplete = taskAll.ContinueWith(task =>
					{
						MessageBox.Show("Complete!", "Complete", MessageBoxButtons.OK, MessageBoxIcon.None);
					}, TaskScheduler.FromCurrentSynchronizationContext());
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}

			#endregion / Files Copy
		}

		/// <summary>
		/// clear button click event
		/// - clear everything
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void btn_clear_Click(object sender, EventArgs e)
		{
			Clear();
		}

		/// <summary>
		/// path label double click event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void path_label_DoubleClick(object sender, EventArgs e)
		{
			FileUtil.OpenDirectory(text_path.Text);
		}

		/// <summary>
		/// new label double click event
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void newpath_label_DoubleClick(object sender, EventArgs e)
		{
			FileUtil.OpenDirectory(text_new.Text);
		}

		#endregion / Event

	}
}
