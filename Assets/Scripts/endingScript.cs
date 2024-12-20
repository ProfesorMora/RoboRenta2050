using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class endingScript : MonoBehaviour
{
    public bool goodEnding;
    //public Canvas priceCanvas;
    public TextMeshProUGUI subtext;
    public TextMeshProUGUI title;
    public Image goddEndingImage;
    public Image badEndingImage;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       /* subtext.text = "";
        title.text = "";
        goddEndingImage.gameObject.SetActive(false);
        badEndingImage.gameObject.SetActive(false);

        Debug.Log("Current price" + GlobalVariables.price.ToString());
        if(GlobalVariables.price <= 4000)
        {
            goodEnding = true;
            subtext.text = "¿Pero a qué precio? El salario apenas te alcanza para pagar. Más gente se mudará contigo y el alquiler subirá cada 3 meses.";
            title.text = "¡ENHORABUENA! EL PISO ES TUYO";
            goddEndingImage.gameObject.SetActive(true);
            badEndingImage.gameObject.SetActive(false);
        }else{
            goodEnding = false;
            subtext.text = "Ahora tendrás que irte fuera de la ciudad para encontrar casa. Gastarás más tiempo y dinero en transporte y apenas cubrirás tus gastos.";
            title.text = "¡QUÉ MAL! ¡NO CONSEGUISTE PISO!";
            badEndingImage.gameObject.SetActive(true);
            goddEndingImage.gameObject.SetActive(false);
            Debug.Log("Here");
        }*/
    }

    // Update is called once per frame
    void Update()
    {/*
        if(GlobalVariables.price >= 4000)
        {
            goodEnding = true;
            subtext.text = "¿Pero a qué precio? El salario apenas te alcanza para pagar. Más gente se mudará contigo y el alquiler subirá cada 3 meses.";
            title.text = "¡ENHORABUENA! EL PISO ES TUYO";
            goddEndingImage.gameObject.SetActive(true);
            badEndingImage.gameObject.SetActive(false);
        }else{
            goodEnding = false;
            subtext.text = "Ahora tendrás que irte fuera de la ciudad para encontrar casa. Gastarás más tiempo y dinero en transporte y apenas cubrirás tus gastos.";
            title.text = "¡QUÉ MAL! ¡NO CONSEGUISTE PISO!";
            badEndingImage.gameObject.SetActive(true);
            goddEndingImage.gameObject.SetActive(false);
        }
    }*/
    }
}
