using UnityEngine;
using UnityEngine.SceneManagement;

public class BallControl : MonoBehaviour
{
    public PuntosEstrellasUI puntosEstrellasUI;

    void Start()
    {
        puntosEstrellasUI = GameObject.FindObjectOfType<PuntosEstrellasUI>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("Space key was released");
            if (GetComponent<Rigidbody>() != null)
            {
                GetComponent<Rigidbody>().useGravity = true;
            }
        }
    }

    void OnCollisionEnter(Collision c)
    {
        if (Input.GetKey(KeyCode.A))
        {
            Debug.Log("Colisión con: " + c.gameObject.tag);

            if (c.gameObject.CompareTag("Azul"))
            {
                Transform currentPlatform = c.transform.parent;
                Transform nextPlatform = GetNextPlatform(currentPlatform);
                Rigidbody rb = GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.velocity = new Vector3(rb.velocity.x, 0f, rb.velocity.z);
                }

                Destroy(currentPlatform.gameObject);
                puntosEstrellasUI.IncrementarPuntos(1);
                

                if (nextPlatform != null)
                {
                    Destroy(nextPlatform.gameObject);
                }
            }
            else if (c.gameObject.CompareTag("Negro"))
            {
                SceneManager.LoadScene("Game Over");
            }
        }

        if (c.gameObject.CompareTag("punto"))
        {
            puntosEstrellasUI.IncrementarEstrellas(1);
            Destroy(c.gameObject);
        }

        if (c.gameObject.CompareTag("Win"))
        {
            SceneManager.LoadScene("Win");
        }
    }

    Transform GetNextPlatform(Transform currentPlatform)
    {
        return null;
    }
}
