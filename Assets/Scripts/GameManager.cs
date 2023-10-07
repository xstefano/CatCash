using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ave ave;
   // public Dog dog;
   
    // Start is called before the first frame update

    void Start()
    {
        Ave a1 = Instantiate(ave) as Ave;
        Ave a2 = Instantiate(ave) as Ave;
        Ave a3 = Instantiate(ave) as Ave;
        Ave a4 = Instantiate(ave) as Ave;
        Ave a5 = Instantiate(ave) as Ave;
        Ave a6 = Instantiate(ave) as Ave;

        a1.crear(32f, 14f, 1, true, 20f, 23f);//ave1
        a2.crear(8f, 5f, 4, true, 7f, 16f); //ave2
        a3.crear(30f, 12.5f, 2, true, 22f, 25f); //ave3
        a4.crear(10.2f, 6.9f, 4, true, 7f, 12f); //ave3
        a5.crear(35f, 5.4f, 3, true, 26f, 29f); //ave3
        a6.crear(38f, 6.9f, 2, true, 29f, 32f); //ave3

                                             
    }

    // Update is called once per frame
    void Update()
    {

    }
}