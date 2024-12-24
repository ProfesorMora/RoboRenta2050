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
    public Color colorProta;
    public Color colorRobot;
    public List<string> filePaths;
    public bool writing = false, finishedWriting = false, deactivated = false;
    public Image textBackground;
    private Image arrendabot;
    public GameObject robot;
    public GameObject textBox;
    public Sprite textBackProta;
    public Sprite textBackRobot;
    public Sprite arrendabotIdle;
    public Sprite arrendabotFeliz;
    public Sprite arrendabotEnojado;
    public Sprite arrendabotSorprendido;

    public float vibrationDuration, vibrationSpeed, vibrationMagnitude;

    private void Start()
    {
        if(robot != null) arrendabot = robot.GetComponent<Image>();
        currentScene = 0;
        currentEntryNumber = 1;
        writing = false;
        finishedWriting = false;
        if(colorRobot == null) colorRobot = new Color(255,255,255,255);
        if(colorProta == null) colorProta = new Color(213,135,198,255);
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
            dialogText.color = colorProta;
            Debug.Log("Linea de prota");
            text = text.Remove(0,1);
            if(textBackground != null) textBackground.overrideSprite = textBackProta;
        }else{
            if(text != "")
            {
                switch(text.Substring(0,1)){
                    case "ç":
                        if(arrendabot != null) arrendabot.overrideSprite = arrendabotFeliz;
                        text = text.Remove(0,1);
                        break;
                    case "]":
                        if(arrendabot != null) arrendabot.overrideSprite = arrendabotSorprendido;
                        text = text.Remove(0,1);
                        break;
                    case "¬":
                        if(arrendabot != null) arrendabot.overrideSprite = arrendabotEnojado;
                        if(robot != null) StartCoroutine(angryVibration(robot,vibrationDuration, vibrationSpeed, vibrationMagnitude));
                        if(textBox != null) StartCoroutine(angryVibration(textBox,vibrationDuration, vibrationSpeed, vibrationMagnitude));
                        text = text.Remove(0,1);
                        break;
                    default:
                        if(arrendabot != null) arrendabot.overrideSprite = arrendabotIdle;
                        break;
                }
            }
            dialogText.font = fontRobot;
            dialogText.color = colorRobot;
            Debug.Log("Linea normal");
            if(textBackground != null) textBackground.overrideSprite = textBackRobot;
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
        string txt;
        int length = input.Length;
        int i = 0;
        while(i < length)
        {
            if(input[i] == '\\') i = i + 2;
            txt = input.Substring(0, i);
            txt += "<alpha=#00>";
            txt += input.Substring(i, length-i);
            Debug.Log("txt: " + txt);
            showDialog(txt);
            yield return new WaitForSeconds(textSpeed);
            i++;
        }
        showDialog(input);
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

    private IEnumerator angryVibration(GameObject target, float duration, float speed, float magnitude)
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float despX = Random.Range(-magnitude, magnitude);
            float despY = Random.Range(-magnitude, magnitude);
            target.transform.position = target.transform.position + new Vector3(despX, despY, 0);
            yield return new WaitForSeconds(speed);
            target.transform.position = target.transform.position - new Vector3(despX, despY, 0);
            elapsedTime += Time.deltaTime;
        }
    }
}