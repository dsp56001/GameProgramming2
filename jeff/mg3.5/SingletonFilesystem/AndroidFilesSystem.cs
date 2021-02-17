using System;
using System.Collections.Generic;
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
            System.IO
            //base.CreateTextFile(fileName, fileContents);
        }


    }
}
