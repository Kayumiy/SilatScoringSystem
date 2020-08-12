using UnityEngine;

public class ActiveInActive : MonoBehaviour
{

    public GameObject activeInActiveObject;     

    public void SetActiveGameObject()
    {
        activeInActiveObject.SetActive(true);

    }

    public void SetDeActiveGameObject()
    {
        activeInActiveObject.SetActive(false);

    }

}
