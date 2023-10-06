using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    public Transform puntoDeReaparicion; // Punto de reaparición del personaje.
    public Transform puntoDeReaparicionTrap;
    // Método para hacer reaparecer al personaje en el punto de reaparición.
    public void ReaparecerPersonajeAve()
    {
        //personaje.transform.position = puntoDeReaparicion.position;
        transform.position = puntoDeReaparicion.position;
    }

    public void ReaparecerPersonajeTrap()
    {
        //personaje.transform.position = puntoDeReaparicion.position;
        transform.position = puntoDeReaparicionTrap.position;
    }
}
