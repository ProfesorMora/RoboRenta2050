using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class RoomManager : MonoBehaviour
{
    public DialogManager DialogManager;
    bool finishing = false;
    public Canvas priceCanvas;
    public TextMeshProUGUI priceText;
    public CanvasGroup canvasGroup;
    public float blackFadeDuration = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DialogManager.deactivate();
        priceCanvas.enabled = false;
        canvasGroup.alpha = 0;
        StartCoroutine(fadeCanvasGroup(0, 1, blackFadeDuration));
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
        Debug.Log("Will load next Scene");
        if (GlobalVariables.gActiveClick == true)
        {
            if (DialogManager.deactivated)
            {
                if(finishing){
                    if(GlobalVariables.price > 4000)
                        SceneManager.LoadScene("Bad Ending");
                    else
                        SceneManager.LoadScene("Good Ending");
                }else{
                    Debug.Log("Will submit form");
                    int newPrice = GlobalVariables.price;
                    priceText.text = newPrice.ToString() + "€";
                    priceCanvas.enabled = true;
                    Debug.Log("global price" + GlobalVariables.price.ToString());
                    finishing = true;
                    //dialogManager.reactivate();
                    //dialogManager.nextEntry();
                }
            }
    }
    }

    private IEnumerator fadeCanvasGroup(float begin, float end, float duration)
    {
        float elapsedTime = 0.0f;
        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            canvasGroup.alpha = begin + (elapsedTime / duration)*(end - begin);
            yield return null;
        }
        canvasGroup.alpha = end;
    }
}
