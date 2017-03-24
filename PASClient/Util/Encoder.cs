using System;
using System.IO;
using System.Text;

namespace PASClient.Util
{
    class Encoder
    {
        public string EncodedText { get; private set; }

        public string DecodedText { get; private set; }

        private const string SAVING_DIRECTORY = @"C:\Dev\PASClient\EncodedTrainingFiles\";

        public void EncodeTextFile(string text)
        {
            byte[] data = Encoding.UTF8.GetBytes(text);
            EncodedText = Convert.ToBase64String(data);
        }

        public void DecodeTextFile(string text)
        {
            byte[] data = Convert.FromBase64String(text);
            DecodedText = Encoding.UTF8.GetString(data);
        }

        public void SaveEncodedText(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(SAVING_DIRECTORY + $"{filename}.txt"))
            {
                outputFile.WriteLine(EncodedText);
            }
        }

        public void SaveDecodedText(string filename)
        {
            using (StreamWriter outputFile = new StreamWriter(SAVING_DIRECTORY + $"{filename}.txt"))
            {
                outputFile.WriteLine(DecodedText);
            }
        }
    }
}
