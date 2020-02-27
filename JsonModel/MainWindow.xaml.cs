using System;
using System.Collections.Generic;
using System.Windows;
using JsonModel.Util;

namespace JsonModel
{
    public partial class MainWindow : Window
	{
        public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
            {
                var x = StringUtil.StringReplaceSplit(Txt01.Text);
                var y = StringUtil.NameConverter(x);
                Txt02.Text = y;
            }
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
    }
}
