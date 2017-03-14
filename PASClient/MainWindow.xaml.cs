using PASClient.model;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Forms;

namespace PASClient
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string textFileContent;
        string textFileName;
        TextFile textFile;

        public MainWindow()
        {
            InitializeComponent();

            this.Title = "PAS Desktop Client";
            this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            this.textFileContent = "";
            this.textFileName = "";
            textFile = new TextFile();
        }
        /*
        private void btnSaveRelationFile_Click(object sender, RoutedEventArgs e)
        {
            string relationFile = textFile.GetRelationFile();
            if (relationFile.Length != 0)
            {
                StreamWriter streamWriter = new StreamWriter(textFile.SavePath);
                streamWriter.WriteLine(relationFile);
                streamWriter.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Arquivo vazio");
            }
        }*/

        private string Dividir(string str)
        {
            string newString;

            string[] word = Regex.Split(str, @"\s\(([^)]+)\):");

            newString = word[2];

            return newString;
        }

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            TrainingFileWindow training = new TrainingFileWindow();
            training.Show();
        }
    }
}
