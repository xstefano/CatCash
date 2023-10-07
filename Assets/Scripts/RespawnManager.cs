using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform puntoDeReaparicion; // Punto de reaparici n del personaje.

    // M todo para hacer reaparecer al personaje en el punto de reaparici n.
    public void ReaparecerPersonajeAve()
    {
        //personaje.transform.position = puntoDeReaparicion.position;
        transform.position = puntoDeReaparicion.position;
    }
}
