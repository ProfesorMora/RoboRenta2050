using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MenuManager : MonoBehaviour
{

    public CanvasGroup canvasGroup;
    public float fadeDuration;
    private bool fadingOut = false;

    public void Start()
    {
        canvasGroup.alpha = 0;
        StartCoroutine(fadeCanvasGroup(0, 1, fadeDuration));
    }

    public void Update()
    {
        if(fadingOut && canvasGroup.alpha == 0.0f)
            SceneManager.LoadScene("Formulario");
    }

    public void StartGame()
    {
        StartCoroutine(fadeCanvasGroup(1, 0, fadeDuration));
        fadingOut = true;
    }

    public void EndGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
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
