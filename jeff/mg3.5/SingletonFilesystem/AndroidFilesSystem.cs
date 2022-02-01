using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameLibrary.GameFiles;

namespace SingletonFilesystem
{
    class AndroidFilesSystem : FileSystem
    {
        public override void CreateTextFile(string fileName, string fileContents)
        {
            //Android uses IsolatedStorageFile
            IsolatedStorageFile gameStorage = IsolatedStorageFile.GetUserStoreForApplication();
            IsolatedStorageFileStream fs;
            fs = gameStorage.OpenFile(fileName, System.IO.FileMode.Create);
            if (fs != null)
            {
                
               fs.Write(System.Text.Encoding.UTF8.GetBytes(fileContents), 0, fileContents.Length);
                
            }
            //base.CreateTextFile(fileName, fileContents);
        }


    }
}
