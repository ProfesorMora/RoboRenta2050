using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScriptIntro : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float           fadeTime;
    private float           alphaValue;
    private float          fadeAwayPerSecond;
    private bool fadingOut = false;
    public DialogManager dialogManager;

    void Start()
    {
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = textComponent.color.a;
        Debug.Log("Started object. Call dialogManager");
        dialogManager.nextEntry();
    }
    void Update()
    {
        Debug.Log("finishedwriting" + dialogManager.finishedWriting);
        if(dialogManager.finishedWriting)
        {
            if (alphaValue < 0)
            {
                SceneManager.LoadScene(1);
            }   
            if (fadeTime > 0)
            {
                alphaValue -= fadeAwayPerSecond * Time.deltaTime;
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alphaValue);
                fadeTime -= Time.deltaTime;
            }
        }
    }

    public void setFadingOut(bool what)
    {
        fadingOut = what;
    }
}