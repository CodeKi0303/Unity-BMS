using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class FileManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        init_file_viewer();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    void init_file_viewer()
    {
        file_viewer("");
    }

    public string song_path_win = "\\Assets\\Resources\\Song";
    void file_viewer(string add_path)
    {
        string song_path = System.Environment.CurrentDirectory + song_path_win;
        DirectoryInfo di = new DirectoryInfo(song_path);
        foreach (DirectoryInfo Dir in di.GetDirectories())
        {
            Debug.Log(Dir.Name);
        }
    }
}
