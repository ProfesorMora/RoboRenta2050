using UnityEngine;

public class ClickableObjectPlus : MonoBehaviour
{
    public GameObject text;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject Signal;

    public DialogManager dialogManager;

    private bool isDestroyed = false;

    void Start()
    {
        Signal.SetActive(true);
        DisableText();
        GlobalVariables.gActiveClick = false;
    }

    public void DisableText()
    {
        if (isDestroyed) return;

        text.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        Signal.SetActive(true);
        GlobalVariables.gActiveClick = true;
    }

    public void YesClick()
    {
        if (isDestroyed) return;

        Signal.SetActive(false);
        text.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);

        isDestroyed = true;

        GlobalVariables.price += 200;
    }

    public void EnableText()
    {
        if (isDestroyed) return;

        if (GlobalVariables.gActiveClick == true)
        {
            text.SetActive(true);
            YesButton.SetActive(true);
            NoButton.SetActive(true);
            Signal.SetActive(false);
            GlobalVariables.gActiveClick = false;
        }
    }
}