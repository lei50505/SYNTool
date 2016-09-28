using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SYNTool
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {

        public delegate void TextBoxOldIsEnabledGate(bool flag);
        public void TextBoxOldIsEnabled(bool flag)
        {
            if (TextBoxOld.Dispatcher.Thread != Thread.CurrentThread)
            {
                TextBoxOldIsEnabledGate gate = new TextBoxOldIsEnabledGate(TextBoxOldIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                TextBoxOld.IsEnabled = flag;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void ComboBoxSave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ButtonOld_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonAbort_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonStartAll_Click(object sender, RoutedEventArgs e)
        {

        }

        
      
    }
}
