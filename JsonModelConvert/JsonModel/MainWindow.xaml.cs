using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace JsonModel
{
	// Token: 0x02000003 RID: 3
	public partial class MainWindow : Window
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002093 File Offset: 0x00000293
		public MainWindow()
		{
			this.InitializeComponent();
		}

		// Token: 0x06000005 RID: 5 RVA: 0x000020A4 File Offset: 0x000002A4
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				this.NewMethod();
				string[] array = this.txt_01.Text.Replace("\n", "").Split(new char[]
				{
					'\r'
				});
				string text = "";
				foreach (string text2 in array)
				{
					bool flag = string.IsNullOrEmpty(text2);
					if (!flag)
					{
						string[] array3 = text2.Split(new char[]
						{
							' '
						});
						string[] array4 = array3[2].Split(new char[]
						{
							'_'
						});
						string text3 = "";
						foreach (string text4 in array4)
						{
							text3 = text3 + text4.Substring(0, 1).ToUpper() + text4.Substring(1);
						}
						bool flag2 = array3[1].Contains("[]");
						if (flag2)
						{
							array3[1] = "List<" + array3[1].Replace("[]", "") + ">";
						}
						string text5 = string.Concat(new string[]
						{
							"public ",
							array3[1],
							" ",
							text3,
							" { get; set; }"
						});
						text = string.Concat(new string[]
						{
							text,
							"/// <summary>\r\n/// \r\n/// </summary>\r\n[JsonProperty(\"",
							array3[2],
							"\")]\r\n",
							text5,
							"\r\n"
						});
					}
				}
				text = text.Substring(0, text.Length - 2);
				Clipboard.SetDataObject(text);
				this.txt_02.Text = text;
				this.txt_01.Text = "";
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002290 File Offset: 0x00000490
		private void NewMethod()
		{
			string[] array = this.txt_01.Text.Replace("\n", "").Split(new char[]
			{
				'\r'
			});
			string text = "";
			foreach (string text2 in array)
			{
				text = text + text2.Trim() + "\r\n";
			}
			this.txt_01.Text = text;
		}
	}
}
