using System;
using System.Text.RegularExpressions;

namespace PASClient.model
{
    class Instance
    {
        public string Class { get; set; }
        private string content;

        public string Content
        {
            get { return content; }
            set { content = $"\"{RemoveSpecialCharaters(value)}\", ?"; }
        }

        public Instance()
        {
            Class = "";
            Content = "";
        }

        public Instance(string _class, string content)
        {
            Class = _class;
            Content = content;
        }

        public String getNewInstance()
        {
            if (Class.Length == 0)
            {
                Class = "?";
            }

            return $"\"{Content}\", {Class}" ;
        }

        private string RemoveSpecialCharaters(string str)
        {
            return Regex.Replace(str, @"\""", "");
        }
    }
}
