using UnityEngine;

public class Plataforma : MonoBehaviour
{
    public GameObject salpicaduraPrefab; // Prefab de la salpicadura de pintura

    private Transform plataformaTransform; // Referencia al transform de la plataforma

    private void Start()
    {
        // Obtener el transform de la plataforma
        plataformaTransform = transform.parent;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball")) // Verificar si la colisión es con la pelota
        {
            // Generar la salpicadura de pintura en la posición de la colisión
            Instantiate(salpicaduraPrefab, collision.GetContact(0).point, Quaternion.identity, plataformaTransform);
        }
    }
}
