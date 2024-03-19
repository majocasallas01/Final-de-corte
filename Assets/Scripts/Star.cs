using UnityEngine;

public class Star : MonoBehaviour
{
    public float velocidadRotacionY = 30f;
    private int puntosEstrella = 0;

    void Update()
    {
        transform.Rotate(0f, velocidadRotacionY * Time.deltaTime, 0f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            puntosEstrella++;
            Destroy(gameObject);
            Debug.Log("Puntos de la estrella: " + puntosEstrella);
        }
    }
}
