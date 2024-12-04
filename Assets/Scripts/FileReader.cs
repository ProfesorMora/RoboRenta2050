using UnityEngine;
using System.IO;
using System.Xml.Linq;
using UnityEditor;

public class FileReader : MonoBehaviour
{
    //public string file_path;
    public DialogManager dialogManager;

    //public int entryNumber;

    bool endedCurrentFile = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Lee la línea lineNumber del archivo en file_path
    public string readTextFile(TextAsset file_path, int entryNumber)
    {
        endedCurrentFile = false;
        if (!file_path) 
        {
            Debug.LogError("No localizamos la ruta");
            return "";
        }
        Debug.Log("Ended Current File: " + endedCurrentFile);
        if(endedCurrentFile) return "";
        
        string inp_ln = "";
        using (StringReader reader = new StringReader(file_path.text))
        {
        for(int i = 0; i < entryNumber; i++)
        {
            Debug.Log("loop:"+i);
            string line = reader.ReadLine();
            if (line != null)
            {
                inp_ln = line;
                Debug.Log("read line: "+inp_ln);
            }else{
                endedCurrentFile = true;
                inp_ln = "";
            }
        }
        }
        return inp_ln;
    }
}
