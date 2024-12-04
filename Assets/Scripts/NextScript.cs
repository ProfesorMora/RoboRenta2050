using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScript : MonoBehaviour
{
    bool finishing = false;
    public Canvas priceCanvas;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void NextScene()
    {
        if(finishing)
            SceneManager.LoadScene(4);
        else{
            finishing = true;
            priceCanvas.enabled = false;
            //dialogManager.reactivate();
            //dialogManager.nextEntry();
        }
    }
}
