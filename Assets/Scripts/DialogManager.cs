using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using System.Collections;

public class DialogManager : MonoBehaviour
{
    public GameObject dialogBox;
    public GameObject backImage;
    public TextMeshProUGUI dialogText;

    public FileReader fileReader;
    public int currentEntryNumber;
    public int currentScene;
    public float textSpeed;
    public TMP_FontAsset fontProta;
    public TMP_FontAsset fontRobot;
    public List<string> filePaths;
    public bool writing = false, finishedWriting = false, deactivated = false;
    public Image textBackground;
    public Sprite textBackProta;
    public Sprite textBackRobot;

    private void Start()
    {
        currentScene = 0;
        currentEntryNumber = 1;
        writing = false;
        finishedWriting = false;
    }

    
    public void showDialog(string text)
    {
        dialogBox.SetActive(true);
        dialogText.text = text; 
    }

    private string getTextFromFile(TextAsset file_path, int entryNumber)
    {
        Debug.Log("entra");
        return fileReader.readTextFile(file_path,entryNumber);
    }

    public void nextEntry()
    {
        TextAsset file = Resources.Load<TextAsset>(filePaths[currentScene]);
        Debug.Log("Reading text from file: " + file);
        string text = getTextFromFile(file, currentEntryNumber);
        Debug.Log("Got text: " + text);
        if((text != "") && (text.Substring(0,1) == "~"))
        {
            dialogText.font = fontProta;
            Debug.Log("Linea de prota");
            text = text.Remove(0,1);
           // if(textBackground != null) textBackground.overrideSprite = textBackProta;
        }else{
            dialogText.font = fontRobot;
            Debug.Log("Linea normal");
            //if(textBackground != null) textBackground.overrideSprite = textBackRobot;
        }
        IEnumerator writeToDialogRoutine  = writeToDialog(text);
        
        if(!writing)
        {
            Debug.Log("Will start writing...");
            StartCoroutine(writeToDialogRoutine);
            finishedWriting = false;
            writing = true;
        }else
        {
            StopAllCoroutines();
            showDialog(text);
            finishedWritingCurrentEntry();
        }
    }

    // Escribe la cadena de texto en el diálogo caracter a caracter
    IEnumerator writeToDialog(string input)
    {
        writing = true;
        string txt = "";
        Debug.Log("Input is " + input);
        foreach(char c in input)
        {
            txt += c;
            if(c=='\\') txt += "n";
            showDialog(txt);
            yield return new WaitForSeconds(textSpeed);
        }
        finishedWritingCurrentEntry();
        if(input == "")
        {
            deactivate();
        }
    }

    private void finishedWritingCurrentEntry()
    {
        writing = false;
        finishedWriting = true;
        currentEntryNumber++;
    }

    public void deactivate()
    {
        dialogText.enabled = false;
        backImage.SetActive(false);
        deactivated = true;
    }

    public void reactivate()
    {
        dialogText.enabled = true;
        backImage.SetActive(true);
        deactivated = false;
        currentScene ++;
        currentEntryNumber = 1;
    }

    public void LoadTextWithSceneNumber(int scene)
    {
        reactivateWithNoScene();
        currentScene = scene+1;
        nextEntry();
    }
    public void reactivateWithNoScene()
    {
        dialogText.enabled = true;
        backImage.SetActive(true);
        deactivated = false;
        currentEntryNumber = 1;
    }
}