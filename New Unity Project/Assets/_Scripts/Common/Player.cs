using UnityEngine;


public class Player : MonoBehaviour
{

    public ushort juryNumber;

    // ID ni valuesi Server tomonidan belgilanadi
    public ushort ID { get; set; }

    // type mobile yoki desktop bo'lishi mumkin 
    public string type; 

}
