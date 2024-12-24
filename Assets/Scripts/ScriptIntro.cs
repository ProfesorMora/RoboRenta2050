using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class ScriptIntro : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public float           fadeTime;
    private float           alphaValue;
    private float          fadeAwayPerSecond;
    public float canvasGroupFadeDuration = 5.0f;
    private bool fadingOut = false;
    public DialogManager dialogManager;
    public CanvasGroup canvasGroup;
    private bool startedToWrite = false;

    void Start()
    {
        fadeAwayPerSecond = 1 / fadeTime;
        alphaValue = textComponent.color.a;
        canvasGroup.alpha = 0.0f;
        StartCoroutine(fadeCanvasGroup(0.0f, 1.0f, canvasGroupFadeDuration));
    }
    void Update()
    {
        if(!startedToWrite && canvasGroup.alpha > 0.8)
        {
            startedToWrite = true;
            dialogManager.nextEntry();
        }
        if(dialogManager.finishedWriting)
        {
            if (canvasGroup.alpha < 0.05)
            {
                SceneManager.LoadScene("Main Menu");
            }   
            if (fadeTime > 0)
            {
                alphaValue -= fadeAwayPerSecond * Time.deltaTime;
                textComponent.color = new Color(textComponent.color.r, textComponent.color.g, textComponent.color.b, alphaValue);
                fadeTime -= Time.deltaTime;
                if(alphaValue < 0.2)
                    StartCoroutine(fadeCanvasGroup(1.0f, 0.0f, canvasGroupFadeDuration));
            }
        }
    }

    public void setFadingOut(bool what)
    {
        fadingOut = what;
    }

    private IEnumerator fadeCanvasGroup(float begin, float end, float duration)
    {
        float elapsedTime = 0.0f;
        Debug.Log("Duration: " + duration);
        while (elapsedTime < duration)
        {
            Debug.Log("elapsedTime: " + elapsedTime);
            elapsedTime += Time.deltaTime;
            Debug.Log("calc alpha:" + begin + (elapsedTime / duration)*(end - begin));
            canvasGroup.alpha = begin + (elapsedTime / duration)*(end - begin);
            Debug.Log("current alpha:" + canvasGroup.alpha);
            yield return null;
        }
        canvasGroup.alpha = end;
    }
}