﻿using PASClient.model;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Forms;

namespace PASClient
{
    public partial class TrainingFileWindow : Window
    {
        private List<Instance> instances = new List<Instance>();
        string relationPreview = "";

        public TrainingFileWindow()
        {
            InitializeComponent();
            relationPreview += $"@relation training\r\n";
            relationPreview += "@attribute Document string\r\n";
            relationPreview += "@attribute class {yes,no}\r\n";
            relationPreview += "@data\r\n";
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string line = "";

                StreamReader file = new StreamReader(openFileDialog.FileName);
                while ((line = file.ReadLine()) != "end")
                {
                    if (!string.IsNullOrEmpty(line))
                    {
                        instances.Add(new Instance("", line));
                    }
                }
            }

            Reload();
        }

        private void btnSaveFile_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Salvar Arquivo Texto";
            saveFileDialog.Filter = "Text File|.txt";
            saveFileDialog.FilterIndex = 0;
            saveFileDialog.DefaultExt = ".txt";
            saveFileDialog.InitialDirectory = @"C:\Dev\PASClient\TrainingFiles";
            saveFileDialog.RestoreDirectory = true;
            
            DialogResult resultado = saveFileDialog.ShowDialog();
            
            if (resultado == System.Windows.Forms.DialogResult.OK)
            {
                FileStream fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
                
                StreamWriter writer = new StreamWriter(fs);
                writer.Write(txtTextFilePreview.Text);
                writer.Close();
            }
        }

        private void Reload()
        {
            PreviewTextFile();
        }

        private void PreviewTextFile()
        {
            foreach (Instance instance in instances)
            {
                relationPreview += instance.Content + "\r\n";
            }

            txtTextFilePreview.Text = relationPreview;
        }
    }
}