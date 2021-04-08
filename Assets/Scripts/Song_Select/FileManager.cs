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
        file_viewer(game_dir_win + song_dir);
    }

    private string game_dir_win = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\Unity_BMS";
    private string song_dir = "\\Songs";
    public string path_temp = "";
    public void file_viewer(string path)
    {
        path_temp = path;
        DirectoryInfo di = new DirectoryInfo(path);
        foreach (DirectoryInfo Dir in di.GetDirectories())
        {
           add_content("directory", Dir.Name);
        }
        foreach(FileInfo fi in di.GetFiles())
        {
            if(fi.Extension == ".bms") add_content("bms", fi.Name);
        }
    }

    public Transform Container;
    public Transform prefab_dir;
    public Transform prefab_bms;
    public List<Transform> contents;
    public void add_content(string type,string name)
    {
        Transform added_prefab;
        if(type == "directory") added_prefab = prefab_dir;
        else added_prefab = prefab_bms;

        Transform created_obj = Instantiate(added_prefab, new Vector3(0, 0, 0), Quaternion.identity);
        created_obj.SetParent(Container);
        created_obj.GetComponentInChildren<Text>().text = name;
        contents.Add(created_obj);
    }

    public void clear_content()
    {
        foreach(Transform tr in contents)
        {
            Destroy(tr.gameObject);
        }
        contents.Clear();
    }

    public void onClick_Back()
    {
        clear_content();
        List<string> split_text = new List<string>(path_temp.Split('\\'));
        string path_back = "";
        split_text.RemoveAt(split_text.Count - 1);
        foreach (string text in split_text)
        {
            path_back += text + "\\";
        }

        path_back = path_back.Substring(0,path_back.Length-1);
        Debug.Log(path_back);

        file_viewer(path_back);
    }
}
