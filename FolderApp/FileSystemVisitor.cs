using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FolderApp
{
    public class FileSystemVisitor : IEnumerable<string>
    {
        private string PathFile { get; set; }
        private string SearchPattern { get; set; }

        delegate string PathDel(string pa);
        public  delegate void ActionHandler(string fi);
        public event ActionHandler Notify;
        public FileSystemVisitor(string path, string searchPattern)
        {
            PathDel stringDel = y =>
            {
                if (path == string.Empty) 
                {
                    Console.WriteLine("The folder is empty. Please rewrite path:");
                    path = Console.ReadLine();
                    Notify?.Invoke($"Try to implement {path} to payh");
                    return path;
                   
                    
                }
                else { return path; }
            };
            
            stringDel(path);

            PathFile = path;
            SearchPattern = searchPattern;
        }
        public IEnumerator<string> GetEnumerator()
        {
            string[] folders = Directory.GetDirectories(PathFile, "*", SearchOption.TopDirectoryOnly);
            Notify?.Invoke("Start scanning");
            for (int i = 0; i < folders.Length; i++)
            {
              //  Console.WriteLine(folders[i]);
                yield return folders[i];
                string[] files = Directory.GetFiles(folders[i], "*."+SearchPattern, SearchOption.AllDirectories);
                foreach (var item in files)
                {
                    // Console.WriteLine("     " + Path.GetFileName(item));
                    yield return "       " + Path.GetFileName(item);
                }
                
                
            }
            Notify?.Invoke("Finish scanning");
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }


}

