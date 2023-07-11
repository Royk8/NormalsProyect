using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Normales : MonoBehaviour
{
    public Texture2D imagen;
    public Image handle;
    public Color color;
    float miX =0, miY=1;
    public int tamaño = 512;
    [Header("Flechas")]
    public float area = 5;
    public Transform flechero;
    public Transform flechaAnormal;
    void Start()
    {
        Graficar();
    }

    public void CambiarSeleccionX(float x)
    {
        miX = x;
        Graficar();
    }
    public void CambiarSeleccionY(float y)
    {
        miY = 1-y;
        Graficar();
    }

    void Graficar()
    {
        color = imagen.GetPixel(Mathf.FloorToInt(miX * tamaño), Mathf.FloorToInt(miY * tamaño));
        handle.color = color;
        flechero.position = ((Vector3.forward * miY + Vector3.right * miX) * area);
        flechaAnormal.localEulerAngles = 
            Vector3.forward * (180 * (1 - color.r) + 270) + 
            Vector3.right * (180 * (color.g) + 270)
            ;
    }
}
