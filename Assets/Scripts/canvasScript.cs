using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class canvasScript : MonoBehaviour
{
    public bool goodEnding;
    //public Canvas priceCanvas;
    public TextMeshProUGUI subtext;
    public TextMeshProUGUI title;
    public Image goddEndingImage;
    public Image badEndingImage;
    public Sprite spriteGood;
    public Sprite spriteBad;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // subtext.text = "";
        // title.text = "";
        // goddEndingImage.enabled = false;
        // badEndingImage.enabled = false;

        // Debug.Log("Current price" + GlobalVariables.price.ToString());
        // if(GlobalVariables.price <= 4000)
        // {
        //     goodEnding = true;
        //     subtext.text = "¿Pero a qué precio? El salario apenas te alcanza para pagar. Más gente se mudará contigo y el alquiler subirá cada 3 meses.";
        //     title.text = "¡ENHORABUENA! EL PISO ES TUYO";
        //     goddEndingImage.enabled = true;
        //     badEndingImage.enabled = false;
        // }else{
        //     goodEnding = false;
        //     subtext.text = "Ahora tendrás que irte fuera de la ciudad para encontrar casa. Gastarás más tiempo y dinero en transporte y apenas cubrirás tus gastos.";
        //     title.text = "¡QUÉ MAL! ¡NO CONSEGUISTE PISO!";
        //     badEndingImage.enabled = true;
        //     goddEndingImage.enabled = false;
        //     Debug.Log("Here");
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}