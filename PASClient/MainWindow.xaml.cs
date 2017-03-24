using PASClient.model;
using PASClient.Util;
using System.IO;
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

        private void btnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            TrainingFileWindow training = new TrainingFileWindow();
            training.Show();
        }

        private void btnUploadTrainingFile_Click(object sender, RoutedEventArgs e)
        {
            /*
             * Abrir o arquivo de treinamento
             * Convertelo para base64
             * Realizar o upload
             */

            OpenFileDialog openFileDialog = new OpenFileDialog();

            if(openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamReader streamReader = new StreamReader(openFileDialog.FileName);

                string fileContent = streamReader.ReadToEnd();
                string filename = openFileDialog.SafeFileName;

                if(! string.IsNullOrEmpty(fileContent))
                {
                    Encoder encoder = new Encoder();
                    encoder.EncodeTextFile(fileContent);
                    encoder.SaveEncodedText(filename);

                    PASService.FileHandlerSEIClient pasService = new PASService.FileHandlerSEIClient();
                    pasService.upload(filename, encoder.EncodedText);
                }
            }
        }
    }
}
