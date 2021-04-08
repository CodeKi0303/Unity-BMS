using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;

public class SongInfoLoading : MonoBehaviour
{
    public Transform ParentObj;
    public Transform[] tpList;
    public string[] songList;
    public int index;

    public void ParseData(int index)
    {
        string temp = "";
        tempStr = "";
        for(int i = 1; i < tempSplit.Length; i++)
        {
            tempStr += tempSplit[i] + " ";
        }
        temp = tempSplit[0].Substring(1, tempSplit[0].Length - 1);
        tpList[index].GetComponent<Text>().text = temp + " : " + tempStr;
    }

    public void ParseBackImg(int index)
    {
        SpriteRenderer spriteRenderer;
        spriteRenderer = tpList[index].GetComponent<SpriteRenderer>();
        Sprite sp = Resources.Load<Sprite>("Song/" + SongName + "/BG");
        spriteRenderer.sprite = sp;
    }

    protected FileInfo fileName = null;
    protected StreamReader reader = null;
    protected string path;
    protected string StrText;
    protected string SongName;

    private char[] seps;
    private string[] tempSplit;
    private string tempStr;

    // Start is called before the first frame update
    void Start()
    {
        index = 0;
        tempSplit = null;
        tempStr = "";
        StrText = "";
        SongName = "";
        path = "Assets/Resources/Song/";
        seps = new char[]{ ' ', ':' };

        SongName = songList[index];
        path = path + songList[index] + "/";
        fileName = new FileInfo(path + songList[index] + ".bms");

        if(fileName != null)
        {
            reader = fileName.OpenText();
        }
        else
        {
            Debug.Log("65Line, BMS Parse Error");
        }
        tpList = ParentObj.gameObject.GetComponentsInChildren<Transform>();
        StartCoroutine("startParse");
    }

    IEnumerator startParse()
    {
        while (StrText != "*---------------------- HEADER FIELD END")
        {
            if (StrText != null)
            {
                StrText = reader.ReadLine();
                tempSplit = StrText.Split(seps);

                if (tempSplit[0].Equals("#TITLE")) ParseData(1);
                else if (tempSplit[0].Equals("#ARTIST")) ParseData(2);
                else if (tempSplit[0].Equals("#GENRE")) ParseData(3);
                else if (tempSplit[0].Equals("#BPM")) ParseData(4);
                else if (tempSplit[0].Equals("#PLAYERLEVEL")) ParseData(5);
                else if (tempSplit[0].Equals("#RANK")) ParseData(6);
                else if (tempSplit[0].Equals("#STAGEFILE")) ParseBackImg(10);
                else Debug.Log("[NotErr]Nothing: " + StrText);
            }
            yield return new WaitForFixedUpdate();
        }
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
