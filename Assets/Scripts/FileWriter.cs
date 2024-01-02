using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileWriter
{
    string filePath;

    public FileWriter(string filepath) {
        this.filePath = filepath;
        // new file every run
        if(File.Exists(filePath)) {
            File.Delete(filePath);
        }
      
    }

    public void Write(string line) {
        
        using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true)) {
            file.WriteLine(line);
        }
    }
}
