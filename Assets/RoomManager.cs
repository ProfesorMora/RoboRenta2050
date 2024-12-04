using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RoomManager : MonoBehaviour
{
    public DialogManager DialogManager;
    bool finishing = false;
    public Canvas priceCanvas;
    public TextMeshProUGUI priceText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //DialogManager.deactivate();
        priceCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
        Debug.Log("Will load next Scene");
        if (DialogManager.deactivated)
        {
            if(finishing){
                if(GlobalVariables.price <= 4000)
                    SceneManager.LoadScene(3);
                else
                    SceneManager.LoadScene(4);
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
