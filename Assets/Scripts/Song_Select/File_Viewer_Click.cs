using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class File_Viewer_Click : MonoBehaviour
{
    FileManager script;

    void Start()
    {
        script = GameObject.FindGameObjectWithTag("Script").GetComponentInChildren<FileManager>();
    }
    public void onClick_DIR()
    {
        script.clear_content();
        Debug.Log(script.path_temp + "\\" + this.transform.parent.GetComponentInChildren<Text>().text);
        script.file_viewer(script.path_temp + "\\" + this.transform.parent.GetComponentInChildren<Text>().text);
    }
}

