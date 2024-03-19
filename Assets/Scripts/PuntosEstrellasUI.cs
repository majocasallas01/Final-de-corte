using UnityEngine;
using UnityEngine.UI;

public class PuntosEstrellasUI : MonoBehaviour
{
    public int puntos;
    public int estrellas;
    public Text puntosText;
    public Text estrellasText;

    void Start()
    {
        puntos = 0;
        estrellas = 0;
        ActualizarPuntosYEstrellasTexto();
    }

    public void IncrementarPuntos(int cantidad)
    {
        puntos += cantidad;
        ActualizarPuntosYEstrellasTexto();
    }

    public void IncrementarEstrellas(int cantidad)
    {
        estrellas += cantidad;
        ActualizarPuntosYEstrellasTexto();
    }

    void ActualizarPuntosYEstrellasTexto()
    {
        puntosText.text = " " + puntos.ToString();
        estrellasText.text = " " + estrellas.ToString();
    }
}
