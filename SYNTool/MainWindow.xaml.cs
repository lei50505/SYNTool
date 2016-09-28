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
        private delegate void TextBoxOldIsEnabledGate(bool flag);
        private void TextBoxOldIsEnabled(bool flag)
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
        private delegate void TextBoxNewIsEnabledGate(bool flag);
        private void TextBoxNewIsEnabled(bool flag)
        {
            if (TextBoxNew.Dispatcher.Thread != Thread.CurrentThread)
            {
                TextBoxNewIsEnabledGate gate = new TextBoxNewIsEnabledGate(TextBoxNewIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                TextBoxNew.IsEnabled = flag;
            }
        }
        private delegate void ComboBoxSaveIsEnabledGate(bool flag);
        private void ComboBoxSaveIsEnabled(bool flag)
        {
            if (ComboBoxSave.Dispatcher.Thread != Thread.CurrentThread)
            {
                ComboBoxSaveIsEnabledGate gate = new ComboBoxSaveIsEnabledGate(ComboBoxSaveIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                ComboBoxSave.IsEnabled = flag;
            }
        }
        private delegate void ButtonOldIsEnabledGate(bool flag);
        private void ButtonOldIsEnabled(bool flag)
        {
            if (ButtonOld.Dispatcher.Thread != Thread.CurrentThread)
            {
                ButtonOldIsEnabledGate gate = new ButtonOldIsEnabledGate(ButtonOldIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                ButtonOld.IsEnabled = flag;
            }
        }
        private delegate void ButtonNewIsEnabledGate(bool flag);
        private void ButtonNewIsEnabled(bool flag)
        {
            if (ButtonNew.Dispatcher.Thread != Thread.CurrentThread)
            {
                ButtonNewIsEnabledGate gate = new ButtonNewIsEnabledGate(ButtonNewIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                ButtonNew.IsEnabled = flag;
            }
        }
        private delegate void ButtonSaveIsEnabledGate(bool flag);
        private void ButtonSaveIsEnabled(bool flag)
        {
            if (ButtonSave.Dispatcher.Thread != Thread.CurrentThread)
            {
                ButtonSaveIsEnabledGate gate = new ButtonSaveIsEnabledGate(ButtonSaveIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                ButtonSave.IsEnabled = flag;
            }
        }
        private delegate void ButtonDeleteIsEnabledGate(bool flag);
        private void ButtonDeleteIsEnabled(bool flag)
        {
            if (ButtonDelete.Dispatcher.Thread != Thread.CurrentThread)
            {
                ButtonDeleteIsEnabledGate gate = new ButtonDeleteIsEnabledGate(ButtonDeleteIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                ButtonDelete.IsEnabled = flag;
            }
        }
        private delegate void ButtonStartIsEnabledGate(bool flag);
        private void ButtonStartIsEnabled(bool flag)
        {
            if (ButtonStart.Dispatcher.Thread != Thread.CurrentThread)
            {
                ButtonStartIsEnabledGate gate = new ButtonStartIsEnabledGate(ButtonStartIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                ButtonStart.IsEnabled = flag;
            }
        }
        private delegate void ButtonStartAllIsEnabledGate(bool flag);
        private void ButtonStartAllIsEnabled(bool flag)
        {
            if (ButtonStartAll.Dispatcher.Thread != Thread.CurrentThread)
            {
                ButtonStartAllIsEnabledGate gate = new ButtonStartAllIsEnabledGate(ButtonStartAllIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                ButtonStartAll.IsEnabled = flag;
            }
        }
        private delegate void ButtonAbortIsEnabledGate(bool flag);
        private void ButtonAbortIsEnabled(bool flag)
        {
            if (ButtonAbort.Dispatcher.Thread != Thread.CurrentThread)
            {
                ButtonAbortIsEnabledGate gate = new ButtonAbortIsEnabledGate(ButtonAbortIsEnabled);
                Dispatcher.Invoke(gate, new object[] { flag });
            }
            else
            {
                ButtonAbort.IsEnabled = flag;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TextBoxOldIsEnabled(true);
            TextBoxNewIsEnabled(true);
            ComboBoxSaveIsEnabled(true);
            ButtonOldIsEnabled(true);
            ButtonNewIsEnabled(true);
            ButtonDeleteIsEnabled(true);
            ButtonSaveIsEnabled(true);
            ButtonStartAllIsEnabled(true);
            ButtonStartIsEnabled(true);
            ButtonAbortIsEnabled(false);
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
