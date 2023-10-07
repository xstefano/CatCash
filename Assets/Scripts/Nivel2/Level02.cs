using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level02 : MonoBehaviour
{
    public int vidas;
    public int pescado;
    public string llave;
    public string mapa;
    // Start is called before the first frame update
    void Start()
    {
        vidas = PlayerPrefs.GetInt("vidas");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
