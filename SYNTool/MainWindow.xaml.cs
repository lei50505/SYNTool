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
using SYNTool.Src.Util;
using System.IO;
using System.Windows.Forms;

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
        private delegate void ProgressBarStartMaximumAndValueGate(int maximum, int value);
        private void ProgressBarStartMaximumAndValue(int maximum, int value)
        {
            if (ProgressBarStart.Dispatcher.Thread != Thread.CurrentThread)
            {
                ProgressBarStartMaximumAndValueGate gate = new ProgressBarStartMaximumAndValueGate(ProgressBarStartMaximumAndValue);
                Dispatcher.Invoke(gate, new object[] { maximum, value });
            }
            else
            {
                ProgressBarStart.Maximum = maximum;
                ProgressBarStart.Value = value;
            }
        }
        private delegate void ListBoxHistoryItemsAddGate(string item);
        private void ListBoxHistoryItemsAdd(string item)
        {
            if (ListBoxHistory.Dispatcher.Thread != Thread.CurrentThread)
            {
                ListBoxHistoryItemsAddGate gate = new ListBoxHistoryItemsAddGate(ListBoxHistoryItemsAdd);
                Dispatcher.Invoke(gate, new object[] { item });
            }
            else
            {
                ListBoxHistory.Items.Add(ListBoxHistory.Items.Count + "：" + item);
                ListBoxHistory.SelectedIndex = ListBoxHistory.Items.Count - 1;
                ListBoxHistory.ScrollIntoView(ListBoxHistory.SelectedItem);
            }
        }
        private delegate void ListBoxHistoryItemsClearGate();
        private void ListBoxHistoryItemsClear()
        {
            if (ListBoxHistory.Dispatcher.Thread != Thread.CurrentThread)
            {
                ListBoxHistoryItemsClearGate gate = new ListBoxHistoryItemsClearGate(ListBoxHistoryItemsClear);
                Dispatcher.Invoke(gate, new object[] {  });
            }
            else
            {
                ListBoxHistory.Items.Clear();
            }
        }

        private delegate void LabelHistoryContentGate(string content);
        private void LabelHistoryContent(string content)
        {
            if (LabelHistory.Dispatcher.Thread != Thread.CurrentThread)
            {
                LabelHistoryContentGate sg = new LabelHistoryContentGate(LabelHistoryContent);
                Dispatcher.Invoke(sg, new object[] { content });
            }
            else
            {
                LabelHistory.Content = content;
            }
        }
        private delegate void ComboBoxSaveSelectedItemGate(string item);
        private void ComboBoxSaveSelectedItem(string item)
        {
            if (ComboBoxSave.Dispatcher.Thread != Thread.CurrentThread)
            {
                ComboBoxSaveSelectedItemGate sg = new ComboBoxSaveSelectedItemGate(ComboBoxSaveSelectedItem);
                Dispatcher.Invoke(sg, new object[] { item });
            }
            else
            {
                ComboBoxSave.SelectedItem = item;

            }
        }
        private delegate void ComboBoxSaveSelectedIndexGate(int index);
        private void ComboBoxSaveSelectedIndex(int index)
        {
            if (ComboBoxSave.Dispatcher.Thread != Thread.CurrentThread)
            {
                ComboBoxSaveSelectedIndexGate sg = new ComboBoxSaveSelectedIndexGate(ComboBoxSaveSelectedIndex);
                Dispatcher.Invoke(sg, new object[] { index });
            }
            else
            {
                ComboBoxSave.SelectedIndex = index;

            }
        }
        private delegate void ComboBoxSaveItemsRemoveGate(string item);
        private void ComboBoxSaveItemsRemove(string item)
        {
            if (ComboBoxSave.Dispatcher.Thread != Thread.CurrentThread)
            {
                ComboBoxSaveItemsRemoveGate sg = new ComboBoxSaveItemsRemoveGate(ComboBoxSaveItemsRemove);
                Dispatcher.Invoke(sg, new object[] { item });
            }
            else
            {
                ComboBoxSave.Items.Remove(item);
            }
        }
        private delegate void ComboBoxSaveItemsAddGate(string item);
        private void ComboBoxSaveItemsAdd(string item)
        {
            if (ComboBoxSave.Dispatcher.Thread != Thread.CurrentThread)
            {
                ComboBoxSaveItemsAddGate sg = new ComboBoxSaveItemsAddGate(ComboBoxSaveItemsAdd);
                Dispatcher.Invoke(sg, new object[] { item });
            }
            else
            {
                ComboBoxSave.Items.Add(item);
            }
        }
        private delegate void TextBoxOldTextGate(string text);
        private void TextBoxOldText(string text)
        {
            if (TextBoxOld.Dispatcher.Thread != Thread.CurrentThread)
            {
                TextBoxOldTextGate sg = new TextBoxOldTextGate(TextBoxOldText);
                Dispatcher.Invoke(sg, new object[] { text });
            }
            else
            {
                TextBoxOld.Text = text;
            }
        }
        private delegate void TextBoxNewTextGate(string text);
        private void TextBoxNewText(string text)
        {
            if (TextBoxNew.Dispatcher.Thread != Thread.CurrentThread)
            {
                TextBoxNewTextGate sg = new TextBoxNewTextGate(TextBoxNewText);
                Dispatcher.Invoke(sg, new object[] { text });
            }
            else
            {
                TextBoxNew.Text = text;
            }
        }
        private string oldRootDirPath;
        private string newRootDirPath;

        private Thread threadStart = null;
        private void threadStartImpl()
        {

            threadIsAbort = false;

            //设置控件开始状态
            ListBoxHistoryItemsClear();
            LabelHistoryContent("准备就绪");
            TextBoxOldIsEnabled(false);
            TextBoxNewIsEnabled(false);
            ComboBoxSaveIsEnabled(false);
            ButtonOldIsEnabled(false);
            ButtonNewIsEnabled(false);
            ButtonDeleteIsEnabled(false);
            ButtonSaveIsEnabled(false);
            ButtonStartAllIsEnabled(false);
            ButtonStartIsEnabled(false);
            ButtonAbortIsEnabled(true);
            ProgressBarStartMaximumAndValue(100, 0);

            int progressBarStartMaximum = 0;
            int progressBarStartValue = 0;

            List<string> oldSubFilePaths = UFile.GetSubFilePaths(oldRootDirPath);
            List<string> newSubFilePaths = UFile.GetSubFilePaths(newRootDirPath);
            List<string> oldSubDirPaths = UFile.GetSubDirPaths(oldRootDirPath);
            List<string> newSubDirPaths = UFile.GetSubDirPaths(newRootDirPath);

            progressBarStartMaximum = oldSubDirPaths.Count;
            progressBarStartValue = 0;

            ListBoxHistoryItemsAdd("(1/4)正在复制文件夹");
            LabelHistoryContent("(1/4)正在复制文件夹");

            foreach (string oldSubDirPath in oldSubDirPaths)
            {
                if (UFile.CopyDir(oldSubDirPath, oldRootDirPath, newRootDirPath))
                {
                    ListBoxHistoryItemsAdd("(1/4)正在复制文件夹：" + oldSubDirPath);
                    LabelHistoryContent("(1/4)正在复制文件夹：" + oldSubDirPath);
                }
                progressBarStartValue++;
                ProgressBarStartMaximumAndValue(progressBarStartMaximum, progressBarStartValue);
                if (threadIsAbort == true)
                {
                    ListBoxHistoryItemsAdd("用户手动中止操作");
                    LabelHistoryContent("用户手动中止操作");
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
                    return;
                }
            }

            progressBarStartMaximum = oldSubFilePaths.Count;
            progressBarStartValue = 0;
            ListBoxHistoryItemsAdd("(2/4)正在复制文件");
            LabelHistoryContent("(2/4)正在复制文件");
            foreach (string oldSubFilePath in oldSubFilePaths)
            {
                if (UFile.CopyFile(oldSubFilePath, oldRootDirPath, newRootDirPath))
                {
                    ListBoxHistoryItemsAdd("(2/4)正在复制文件：" + oldSubFilePath);
                    LabelHistoryContent("(2/4)正在复制文件：" + oldSubFilePath);
                }
                progressBarStartValue++;
                ProgressBarStartMaximumAndValue(progressBarStartMaximum, progressBarStartValue);
                if (threadIsAbort == true)
                {
                    ListBoxHistoryItemsAdd("用户手动中止操作");
                    LabelHistoryContent("用户手动中止操作");
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
                    return;
                }
            }

            //删除在newFiles里不在oldFiles里的File
            progressBarStartMaximum = newSubFilePaths.Count;
            progressBarStartValue = 0;
            ListBoxHistoryItemsAdd("(3/4)正在删除文件");
            LabelHistoryContent("(3/4)正在删除文件");
            foreach (string newSubFilePath in newSubFilePaths)
            {
                if (UFile.DelFile(newSubFilePath, oldRootDirPath, newRootDirPath))
                {
                    ListBoxHistoryItemsAdd("(3/4)正在删除文件：" + newSubFilePath);
                    LabelHistoryContent("(3/4)正在删除文件：" + newSubFilePath);
                }
                progressBarStartValue++;
                ProgressBarStartMaximumAndValue(progressBarStartMaximum, progressBarStartValue);
                if (threadIsAbort == true)
                {
                    ListBoxHistoryItemsAdd("用户手动中止操作");
                    LabelHistoryContent("用户手动中止操作");
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
                    return;
                }
            }

            progressBarStartMaximum = newSubDirPaths.Count;
            progressBarStartValue = 0;
            //删除在newDirs里不在oldDirs里的Dir
            ListBoxHistoryItemsAdd("(4/4)正在删除文件夹");
            LabelHistoryContent("(4/4)正在删除文件夹");
            foreach (string newSubDirPath in newSubDirPaths)
            {
                if (UFile.DelDir(newSubDirPath, oldRootDirPath, newRootDirPath))
                {
                    ListBoxHistoryItemsAdd("(4/4)正在删除文件夹：" + newSubDirPath);
                    LabelHistoryContent("(4/4)正在删除文件夹：" + newSubDirPath);
                }
                progressBarStartValue++;
                ProgressBarStartMaximumAndValue(progressBarStartMaximum, progressBarStartValue);
                if (threadIsAbort == true)
                {
                    ListBoxHistoryItemsAdd("用户手动中止操作");
                    LabelHistoryContent("用户手动中止操作");
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
                    return;
                }
            }
            //设置完成状态
            ListBoxHistoryItemsAdd("操作完成");
            LabelHistoryContent("操作完成");
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
            ProgressBarStartMaximumAndValue(100, 100);

        }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //设置初始状态
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

            ListBoxHistoryItemsAdd("By.");
            ListBoxHistoryItemsAdd("QQ: 183515951");
            ListBoxHistoryItemsAdd("听风吹雨作品");

            List<string> names = UConfig.readComboName();

            foreach (string name in names)
            {
                ComboBoxSaveItemsAdd(name);
            }
            ComboBoxSaveSelectedIndex(0);
        }

        private void ComboBoxSave_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ComboBoxSave.Items.Count == 0 || ComboBoxSave.SelectedItem == null)
            {
                TextBoxOldText("");
                TextBoxNewText("");
                return;
            }


            string n = ComboBoxSave.SelectedItem.ToString();
            string[] c = UConfig.readAll(n);
            TextBoxOldText(c[0]);
            TextBoxNewText(c[1]);
        }

        private void ButtonOld_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = false;
            fb.Description = "请选择源文件夹";
            fb.ShowDialog();
            if (fb.SelectedPath != "")
            {
                TextBoxOld.Text = fb.SelectedPath;
            }
            fb.Dispose();
        }

        private void ButtonNew_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fb = new FolderBrowserDialog();
            fb.ShowNewFolderButton = true;
            fb.Description = "请选择目标文件夹";
            fb.ShowDialog();
            if (fb.SelectedPath != "")
            {
                TextBoxNew.Text = fb.SelectedPath;
            }
            fb.Dispose();
        }

        private void ButtonSave_Click(object sender, RoutedEventArgs e)
        {
            ListBoxHistory.Items.Clear();
            LabelHistoryContent("准备就绪");
            ProgressBarStartMaximumAndValue(100, 0);

            if (TextBoxOld.Text.Equals("") || TextBoxNew.Text.Equals(""))
            {
                ListBoxHistoryItemsAdd("请选择文件夹");
                return;
            }
            string o = TextBoxOld.Text;
            string n = TextBoxNew.Text;

            if (
                 o.EndsWith("\\") || n.EndsWith("\\") ||
                 o.EndsWith("/") || n.EndsWith("/") ||
                 o.EndsWith(":") || n.EndsWith(":") ||
                 o.EndsWith("*") || n.EndsWith("*") ||
                 o.EndsWith("?") || n.EndsWith("?") ||
                 o.EndsWith("\"") || n.EndsWith("\"") ||
                 o.EndsWith("<") || n.EndsWith("<") ||
                 o.EndsWith(@">") || n.EndsWith(">") ||
                 o.EndsWith("|") || n.EndsWith("|")
                )
            {
                ListBoxHistoryItemsAdd("输入的文件夹名不能以下列任何字符结尾 \\ / : * ? \" < > |");
                return;
            }
            if (!Directory.Exists(o))
            {
                ListBoxHistoryItemsAdd("源文件夹不存在");
                return;
            }
            if (!Directory.Exists(n))
            {
                ListBoxHistoryItemsAdd("目标文件夹不存在");
                return;
            }



            string oldDriver = UFile.GetDriverByPath(o);
            string newDeiver = UFile.GetDriverByPath(n);

            string oldLastDirName = UFile.GetLastDirByDirPath(o);
            string newLastDirName = UFile.GetLastDirByDirPath(n);

            string name = oldDriver + ":\\...\\" + oldLastDirName + " -> " + newDeiver + ":\\...\\" + newLastDirName;
            bool flag = UConfig.writeAll(name, o, n);

            
            if (flag)
            {
                ListBoxHistoryItemsAdd("保存成功");
                ComboBoxSaveItemsAdd(name);
                ComboBoxSaveSelectedItem(name);
                return;
            }
            ListBoxHistoryItemsAdd("已存在");
        }


        private void ButtonDelete_Click(object sender, RoutedEventArgs e)
        {
            ListBoxHistory.Items.Clear();
            LabelHistoryContent("准备就绪");
            ProgressBarStartMaximumAndValue(100, 0);

            if (ComboBoxSave.Items.Count == 0)
            {
                ListBoxHistoryItemsAdd("已清空");
                return;
            }

            MessageBoxResult result = System.Windows.MessageBox.Show("是否删除?", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result != MessageBoxResult.OK)
            {
                return;
            }

            string name = ComboBoxSave.SelectedItem.ToString();

            UConfig.delete(name);
            ComboBoxSaveItemsRemove(name);
            ComboBoxSaveSelectedIndex(0);
            ListBoxHistoryItemsAdd("删除 " + name + " 成功");


        }

        private void ButtonStart_Click(object sender, RoutedEventArgs e)
        {
            ListBoxHistoryItemsClear();
            LabelHistoryContent("准备就绪");
            ProgressBarStartMaximumAndValue(100, 0);

            if (TextBoxOld.Text.Equals("") || TextBoxNew.Text.Equals(""))
            {
                ListBoxHistoryItemsAdd("请选择文件夹");
                return;
            }

            string o = TextBoxOld.Text;
            string n = TextBoxNew.Text;

            if (
                 o.EndsWith("\\") || n.EndsWith("\\") ||
                 o.EndsWith("/") || n.EndsWith("/") ||
                 o.EndsWith(":") || n.EndsWith(":") ||
                 o.EndsWith("*") || n.EndsWith("*") ||
                 o.EndsWith("?") || n.EndsWith("?") ||
                 o.EndsWith("\"") || n.EndsWith("\"") ||
                 o.EndsWith("<") || n.EndsWith("<") ||
                 o.EndsWith(@">") || n.EndsWith(">") ||
                 o.EndsWith("|") || n.EndsWith("|")
                )
            {
                ListBoxHistoryItemsAdd("输入的文件夹名不能以下列任何字符结尾 \\ / : * ? \" < > |");
                return;
            }
            if (!Directory.Exists(o))
            {
                ListBoxHistoryItemsAdd("源文件夹不存在");
                return;
            }
            if (!Directory.Exists(n))
            {
                ListBoxHistoryItemsAdd("目标文件夹不存在");
                return;
            }
            oldRootDirPath = o;
            newRootDirPath = n;

            MessageBoxResult result = System.Windows.MessageBox.Show("是否开始同步?", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result != MessageBoxResult.OK)
            {
                return;
            }

            threadStart = new Thread(threadStartImpl);
            threadStart.IsBackground = true;
            threadStart.Start();

        }

        private bool threadIsAbort = false;
        private void ButtonAbort_Click(object sender, RoutedEventArgs e)
        {
            ButtonAbortIsEnabled(false);
            threadIsAbort = true;
        }

        private void ButtonStartAll_Click(object sender, RoutedEventArgs e)
        {
            ListBoxHistory.Items.Clear();
            LabelHistoryContent("准备就绪");
            ProgressBarStartMaximumAndValue(100, 0);
            MessageBoxResult result = System.Windows.MessageBox.Show("是否开始同步?", "警告", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (result != MessageBoxResult.OK)
            {
                return;
            }
            Thread t = new Thread(threadStartAllImpl);
            t.IsBackground = true;
            t.Start();
        }

        private void threadStartAllImpl()
        {
            threadIsAbort = false;

            //设置控件开始状态
            ListBoxHistoryItemsClear();
            LabelHistoryContent("准备就绪");
            TextBoxOldIsEnabled(false);
            TextBoxNewIsEnabled(false);
            ComboBoxSaveIsEnabled(false);
            ButtonOldIsEnabled(false);
            ButtonNewIsEnabled(false);
            ButtonDeleteIsEnabled(false);
            ButtonSaveIsEnabled(false);
            ButtonStartAllIsEnabled(false);
            ButtonStartIsEnabled(false);
            ButtonAbortIsEnabled(true);
            ProgressBarStartMaximumAndValue(100, 0);

            int progressBarStartMaximum = 0;
            int progressBarStartValue = 0;

            string[] lines = UConfig.GetAllLines();
            if (lines == null || lines.Length %3 != 0)
            {
                //设置完成状态
                ListBoxHistoryItemsAdd("配置文件不存在");
                LabelHistoryContent("配置文件不存在");
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
                return;
            }
            int index = 0;
            for (int i = 0; i < lines.Length; i+=3)
            {
                index++;

                string lineName = lines[i].Split('?')[1];

                ListBoxHistoryItemsAdd("("+index+"/"+lines.Length/3+")正在处理："+lineName);
                LabelHistoryContent("(" + index + "/" + lines.Length / 3 + ")正在处理：" + lineName);

                string oldRootDirPath = lines[i + 1];
                string newRootDirPath = lines[i + 2];

                if (!(Directory.Exists(oldRootDirPath) && Directory.Exists(newRootDirPath)))
                {
                    ListBoxHistoryItemsAdd("文件夹不存在");
                    LabelHistoryContent("文件夹不存在");
                    continue;
                }

                List<string> oldSubFilePaths = UFile.GetSubFilePaths(oldRootDirPath);
                List<string> newSubFilePaths = UFile.GetSubFilePaths(newRootDirPath);
                List<string> oldSubDirPaths = UFile.GetSubDirPaths(oldRootDirPath);
                List<string> newSubDirPaths = UFile.GetSubDirPaths(newRootDirPath);

                progressBarStartMaximum = oldSubDirPaths.Count;
                progressBarStartValue = 0;

                ListBoxHistoryItemsAdd("(1/4)正在复制文件夹");
                LabelHistoryContent("(1/4)正在复制文件夹");

                foreach (string oldSubDirPath in oldSubDirPaths)
                {
                    if (UFile.CopyDir(oldSubDirPath, oldRootDirPath, newRootDirPath))
                    {
                        ListBoxHistoryItemsAdd("(1/4)正在复制文件夹：" + oldSubDirPath);
                        LabelHistoryContent("(1/4)正在复制文件夹：" + oldSubDirPath);
                    }
                    progressBarStartValue++;
                    ProgressBarStartMaximumAndValue(progressBarStartMaximum, progressBarStartValue);
                    if (threadIsAbort == true)
                    {
                        ListBoxHistoryItemsAdd("用户手动中止操作");
                        LabelHistoryContent("用户手动中止操作");
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
                        return;
                    }
                }

                progressBarStartMaximum = oldSubFilePaths.Count;
                progressBarStartValue = 0;
                ListBoxHistoryItemsAdd("(2/4)正在复制文件");
                LabelHistoryContent("(2/4)正在复制文件");
                foreach (string oldSubFilePath in oldSubFilePaths)
                {
                    if (UFile.CopyFile(oldSubFilePath, oldRootDirPath, newRootDirPath))
                    {
                        ListBoxHistoryItemsAdd("(2/4)正在复制文件：" + oldSubFilePath);
                        LabelHistoryContent("(2/4)正在复制文件：" + oldSubFilePath);
                    }
                    progressBarStartValue++;
                    ProgressBarStartMaximumAndValue(progressBarStartMaximum, progressBarStartValue);
                    if (threadIsAbort == true)
                    {
                        ListBoxHistoryItemsAdd("用户手动中止操作");
                        LabelHistoryContent("用户手动中止操作");
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
                        return;
                    }
                }

                //删除在newFiles里不在oldFiles里的File
                progressBarStartMaximum = newSubFilePaths.Count;
                progressBarStartValue = 0;
                ListBoxHistoryItemsAdd("(3/4)正在删除文件");
                LabelHistoryContent("(3/4)正在删除文件");
                foreach (string newSubFilePath in newSubFilePaths)
                {
                    if (UFile.DelFile(newSubFilePath, oldRootDirPath, newRootDirPath))
                    {
                        ListBoxHistoryItemsAdd("(3/4)正在删除文件：" + newSubFilePath);
                        LabelHistoryContent("(3/4)正在删除文件：" + newSubFilePath);
                    }
                    progressBarStartValue++;
                    ProgressBarStartMaximumAndValue(progressBarStartMaximum, progressBarStartValue);
                    if (threadIsAbort == true)
                    {
                        ListBoxHistoryItemsAdd("用户手动中止操作");
                        LabelHistoryContent("用户手动中止操作");
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
                        return;
                    }
                }

                progressBarStartMaximum = newSubDirPaths.Count;
                progressBarStartValue = 0;
                //删除在newDirs里不在oldDirs里的Dir
                ListBoxHistoryItemsAdd("(4/4)正在删除文件夹");
                LabelHistoryContent("(4/4)正在删除文件夹");
                foreach (string newSubDirPath in newSubDirPaths)
                {
                    if (UFile.DelDir(newSubDirPath, oldRootDirPath, newRootDirPath))
                    {
                        ListBoxHistoryItemsAdd("(4/4)正在删除文件夹：" + newSubDirPath);
                        LabelHistoryContent("(4/4)正在删除文件夹：" + newSubDirPath);
                    }
                    progressBarStartValue++;
                    ProgressBarStartMaximumAndValue(progressBarStartMaximum, progressBarStartValue);
                    if (threadIsAbort == true)
                    {
                        ListBoxHistoryItemsAdd("用户手动中止操作");
                        LabelHistoryContent("用户手动中止操作");
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
                        return;
                    }
                }

                ListBoxHistoryItemsAdd("(" + index + "/" + lines.Length / 3 + ")处理完成：" + lineName);
                LabelHistoryContent("(" + index + "/" + lines.Length / 3 + ")处理完成：" + lineName);
            }

            
            //设置完成状态
            ListBoxHistoryItemsAdd("操作完成");
            LabelHistoryContent("操作完成");
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
            ProgressBarStartMaximumAndValue(100, 100);

        }

    }
}
