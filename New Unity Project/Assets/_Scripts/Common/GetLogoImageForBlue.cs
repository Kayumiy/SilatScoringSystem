using UnityEngine;
using UnityEngine.UI;


public class GetLogoImageForBlue : MonoBehaviour
{

    Sprite logo;


    // Start is called before the first frame update
    void Start()
    {

        // load texture from resource folder
        logo = Resources.Load<Sprite>("Images/Logo/Blue/Logo");
        //Debug.Log(logo);
        GetComponent<Image>().sprite = logo;

        

    }

}
