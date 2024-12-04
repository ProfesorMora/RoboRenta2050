using UnityEngine;

public class ClickableObjectPlus : MonoBehaviour
{
    public GameObject text;
    public GameObject YesButton;
    public GameObject NoButton;
    public GameObject Signal;

    public DialogManager dialogManager;

    private bool isDestroyed = false; // Nueva variable para simular destrucción

    void Start()
    {
        Signal.SetActive(true);
        DisableText();
    }

    public void DisableText()
    {
        if (isDestroyed) return; // No ejecutar si el objeto está "destruido"

        text.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);
        Signal.SetActive(true);
    }

    public void YesClick()
    {
        if (isDestroyed) return; // No ejecutar si el objeto está "destruido"

        // Simular destrucción con SetActive(false)
        Signal.SetActive(false);
        text.SetActive(false);
        YesButton.SetActive(false);
        NoButton.SetActive(false);

        isDestroyed = true; // Marcar como "destruido"

        GlobalVariables.price += 200;
    }

    public void EnableText()
    {
        if (isDestroyed) return; // No ejecutar si el objeto está "destruido"

        text.SetActive(true);
        YesButton.SetActive(true);
        NoButton.SetActive(true);
        Signal.SetActive(false);
    }

    public void ResetObject()
    {
        // Método para "revivir" el objeto si es necesario
        isDestroyed = false;
        Signal.SetActive(true);
        DisableText();
    }
}