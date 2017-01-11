using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameLibrary.GameFiles
{
    public class FileSystem
    {
        protected static FileSystem _filesystem;

        private string path; //Private instance data mamber
        public string Path {
            get { return path; }
            set { this.path = value; }
        }

        

        public static FileSystem Instance
        {
            get
            {
                if (_filesystem == null)
                    _filesystem = new FileSystem();
                return _filesystem;
            }
        }

        protected FileSystem()
        {
            
        }

        public virtual void CreateTextFile(string Name)
        {
            bool fileExists = System.IO.File.Exists(System.IO.Path.Combine(Path, Name));
            //using (StreamWriter writer = new StreamWriter(System.IO.Path.Combine(Path, Name), true))
            //{
            //    writer.Write(true);
            //};
        }

        public virtual System.IO.FileStream GetOpenORCreateFileStream(string Name)
        {
            return new System.IO.FileStream(System.IO.Path.Combine(Path, Name), System.IO.FileMode.OpenOrCreate);
        }

    }
}
