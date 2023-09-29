using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ave ave;
    public Dog dog;
   
    // Start is called before the first frame update

    void Start()
    {
        Ave a1 = Instantiate(ave) as Ave;
        Ave a2 = Instantiate(ave) as Ave;
        Ave a3 = Instantiate(ave) as Ave;
        Ave a4 = Instantiate(ave) as Ave;
        Ave a5 = Instantiate(ave) as Ave;

        a1.crear(8f, 3f, 4, true, 11f, 16f);//ave1
        a2.crear(8f, 5f, 4, true, 7f, 16f); //ave2
        a3.crear(8f, 8f, 4, true, 8f, 11f); //ave3
        a4.crear(10.2f, 6.9f, 4, true, 8f, 11f); //ave3
        a5.crear(12.7f, 5.3f, 4, true, 8f, 11f); //ave3

        Dog b1 = Instantiate(dog) as Dog;
        b1.crear(8f, 2.21f, 1, true, 11f, 15f);
    }

    // Update is called once per frame
    void Update()
    {

    }
}