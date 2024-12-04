using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Linq;
using UnityEngine.SceneManagement;

public class formScript : MonoBehaviour
{
    public GameObject formPanel;
    public GameObject submitButton;
    public DialogManager dialogManager;
    public List<TMP_InputField> listOfInputs;
    public ToggleGroup toggleGroupPet; // Esto no lo pilla el formScript
    public ToggleGroup toggleGroupWork; //
    public Canvas priceCanvas;
    public TextMeshProUGUI priceText;
    bool formSubmitted, finishedTalking;

    List<bool> listOfToggleBools;
    List<int> listOfToggleValues;
    int petSelection;
    int bloodSelection;
    int workSelection;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        formPanel.SetActive(false);
        submitButton.SetActive(false);
        priceCanvas.enabled = false;
        listOfToggleBools = new List<bool>{false, false, false};
        listOfToggleValues = new List<int>{0,0,0};
        formSubmitted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!formSubmitted)
        {
            if(dialogManager.deactivated) formPanel.SetActive(true);
            if(isFormFilled()) submitButton.SetActive(true);
        }
    }

    public bool isFormFilled()
    {
        foreach(var b in listOfToggleBools)
        {
            if(!b) return false;
        }

        return true;
    }

    public void assign(string where, int what)
    {
        if(where == "pet") petSelection = what;
        if(where == "blood") bloodSelection = what;
        if(where == "work") workSelection = what;
    }

    public void petSelected()
    {
        listOfToggleBools[0] = true;
    }

    public void bloodSelected()
    {
        listOfToggleBools[1] = true;
    }

    public void workSelected()
    {
        listOfToggleBools[2] = true;
    }

    public void submitForm()
    {
        if(!formSubmitted)
        {
            Debug.Log("Will submit form");
            int newPrice = calculatePrice();
            formPanel.SetActive(false);
            GlobalVariables.price = newPrice;
            priceText.text = newPrice.ToString() + "€";
            priceCanvas.enabled = true;
            formSubmitted = true;
            Debug.Log("global price" + GlobalVariables.price.ToString());
        }else{
            if(finishedTalking) changeScene();
            else{
                priceCanvas.enabled = false;
                dialogManager.reactivate();
                dialogManager.nextEntry();
                //submitButton.SetActive(false);
                finishedTalking = true;
            }
        }
    }

    int calculatePrice()
    {
        int currentPrice = GlobalVariables.price;

        var togglePet = toggleGroupPet.ActiveToggles().First();
        Debug.Log(togglePet.name);
        if(togglePet.name == "togGatos"){
            Debug.Log("Gatos");
            currentPrice -= 300;
        }
        if(togglePet.name == "togPerros"){
            Debug.Log("Perros");
            currentPrice += 300;
        }
        
        var toggleWork = toggleGroupWork.ActiveToggles().First();
        Debug.Log(toggleWork.name);
        if (toggleWork.name == "togIndefinido")
        {
            Debug.Log("Indefinido");
            currentPrice -= 300;
        }
        if (toggleWork.name == "togTemporal")
        {
            Debug.Log("Temporal");
            currentPrice += 300;
        }

        currentPrice -= 150;

        Debug.Log("Current Price: " + currentPrice);

        return currentPrice;
    }

    void changeScene()
    {
        Debug.Log("Will change scene");
        SceneManager.LoadScene(2);
    }
}
