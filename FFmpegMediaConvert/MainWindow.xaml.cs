﻿using FFmpegMediaConvert.Controler;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Windows;
using System.Windows.Forms;

namespace FFmpegMediaConvert
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<ConvertItem> listConvert = new ObservableCollection<ConvertItem>();
        private Timer timer;

        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            listConvert.CollectionChanged += ListConvert_CollectionChanged;
        }

        private void ListConvert_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (listConvert.Count <= 0)
            {
                txt_progress.Text = "Complete: 100%";
                progress.Value = progress.Maximum;
                bt_Convert.IsEnabled = true;
                bt_Convert.Content = "Start Convert";
                listView.Items.Refresh();           
                timer.Stop();
            }
            else
            {
                LoadListConvertInfo();
            }
        }

        private void LoadListConvertInfo()
        {
            if(listConvert.Count > 0)
            {
                listView.ItemsSource = listConvert;              
            }            
            txt_progress.Text = "Total File Convert: " + progress.Maximum.ToString("00");
        }

        private static IEnumerable<string> getAllFile(string rootDirectory)
        {
            IEnumerable<string> files = Enumerable.Empty<string>();
            IEnumerable<string> directories = Enumerable.Empty<string>();
            try
            {
                // The test for UnauthorizedAccessException.
                var permission = new FileIOPermission(FileIOPermissionAccess.PathDiscovery, rootDirectory);
                permission.Demand();

                files = Directory.GetFiles(rootDirectory);
                directories = Directory.GetDirectories(rootDirectory);
            }
            catch
            {
                // Ignore folder (access denied).
                rootDirectory = null;
            }

            if (rootDirectory != null)
                yield return rootDirectory;

            foreach (var file in files)
            {
                yield return file;
            }

            // Recursive call for SelectMany.
            var subdirectoryItems = directories.SelectMany(getAllFile);
            foreach (var result in subdirectoryItems)
            {
                yield return result;
            }
        }

        private void addFileToConverter(string fileInput)
        {
            FileInfo fin = new FileInfo(fileInput);
            string extend = fin.Extension.ToLower();
            if (extend == ".mp4" || extend == ".mkv" || extend == ".avi" || extend == ".vob" || extend == ".flv" || extend == ".wmv" || extend == ".mov" || extend == ".dat")
            {
                ConvertItem convertItem = new ConvertItem();
                convertItem.AddFile(fileInput, fin.Name);
                listConvert.Add(convertItem);
                progress.Maximum = listConvert.Count;
            }
        }

        private void GetFileFromFolder(string pathFolder)
        {
            foreach (string file in getAllFile(pathFolder))
            {
                addFileToConverter(file);
            }

        }

        private bool HideControl
        {
            get { return group_Video.IsEnabled; }
            set
            {
                group_Video.IsEnabled = value;
                group_Audio.IsEnabled = value;
                bt_selectOutputFolder.IsEnabled = value;               
            }
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            VideosSelected.LoadData();
            AudioSelected.LoadData();
            for(int i = 1; i<=10; i++)
            {
                cb_totalFileConvert.Items.Add(i.ToString());
            }
            cb_totalFileConvert.SelectedIndex = 0;
            timer = new System.Windows.Forms.Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            txt_outputFolder.Text = AppDomain.CurrentDomain.BaseDirectory;
        }

        private void CloesProcess()
        {
            var a00 = Process.GetProcesses();
            foreach (Process proc in a00)
            {
                if (proc.ProcessName.Contains("ffmpeg"))
                {
                    proc.Kill();
                    proc.WaitForExit();
                }
            }
          //  File.Delete(System.Windows.Forms.Application.StartupPath + "\\avtemp.temp");
           // File.Delete(System.Windows.Forms.Application.StartupPath + "\\\\temp.mp4");
        }


        private void bt_Convert_Click(object sender, RoutedEventArgs e)
        {
            //  Console.WriteLine("-i \"file_input\" " + VideosSelected.GetCommand +" " + AudioSelected.getCommand + " -map 0:v -map 0:a? -threads 2 \"file_outPut\"");
            if (bt_Convert.Content.ToString() == "Start Convert")
            {
                if (listConvert.Count <= 0)
                {
                    System.Windows.MessageBox.Show("Please add files to convert", "No file convert");
                    return;
                }
                bt_Convert.Content = "Stop";
                HideControl = false;
                timer.Start();
            }
            else
            {
                if (System.Windows.MessageBox.Show("bạn chắc chắn muốn dừng các tiến trình?", "Dừng chuyển đổi", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    bt_Convert.Content = "Start Convert";
                    HideControl = true;          
                    timer.Stop();
                    CloesProcess();
                }
            }

        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            if (listConvert.Count > 0)
            {
                for (int i = 0; i < int.Parse(cb_totalFileConvert.Text); i++)
                {
                    if (i < listConvert.Count)
                    {
                        var item = listConvert[i];
                        if (item.Converting == false && item.Complete == false)
                        {
                           
                            item.SetOutputFile(txt_outputFolder.Text.Trim(),VideosSelected.GetCommand,AudioSelected.getCommand);
                            bt_Convert.Content = "Stop";
                            item.StartConvert("mp4"); //convert to mp4 file
                        }
                        else if (item.Complete == true)
                        {
                            listConvert.Remove(item);
                        }
                        else if (item.Converting == true && item.Complete == false)
                        {
                            txt_progress.Text =
                                "Converting: " + item.GetFileName + " - Total remaining: " + listConvert.Count.ToString("0");
                        }
                    }
                }
            }
            timer.Start();
        }

        private void bt_selectOutputFolder_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fd = new FolderBrowserDialog();
            fd.Description = "select output folder";
            DialogResult result = fd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
            {
                txt_outputFolder.Text = fd.SelectedPath;
            }
        }

        private void bt_SelectFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.Multiselect = true;
            fd.Filter = "All media files (*.*)|*.*";
            // = "Suport file: MKV, MP4, AVI,WMV, MOV, VOB, DAT, FLV";
            DialogResult result = fd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.FileName))
            {
                foreach (var file in fd.FileNames)
                {
                    addFileToConverter(file);
                }
                progress.Maximum = listConvert.Count;
                LoadListConvertInfo();
            }
        }       

        private void bt_InsertFolder_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fd = new System.Windows.Forms.FolderBrowserDialog();
            fd.Description = "Hỗ trợ các file: MKV, MP4, AVI,WMV, MOV, VOB, DAT, FLV";
            System.Windows.Forms.DialogResult result = fd.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK && !string.IsNullOrWhiteSpace(fd.SelectedPath))
            {
                GetFileFromFolder(fd.SelectedPath);
                LoadListConvertInfo();
            }
        }
    }
}
