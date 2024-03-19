using System.Collections;
using UnityEngine;

public class Nivel : MonoBehaviour
{
    public GameObject PlatformPrefab;
    public int PlatformAmount = 20;
    public float PlatformHeight = 1f;
    public float RotationSpeed = 30f;
    public float AlternateRotation = 90f;
    public int AlternatePlatformSpacing = 5;
    public float AdditionalSpacing = 2f;
    public Vector3[] AlternatePlatformPositions; 
    public bool[] AlternatePlatformClockwise;

    private void Start()
    {
        GeneradorDeNivel();
    }

    public void GeneradorDeNivel()
    {
        float angleStep = 180f / PlatformAmount;
        float totalSpacing = AdditionalSpacing;

        for (int i = 0; i < PlatformAmount; i++)
        {
           
            GameObject platformInstance = Instantiate(PlatformPrefab, Vector3.up * -PlatformHeight * (i + totalSpacing), Quaternion.Euler(0, angleStep * i, 0), transform);
            StartCoroutine(RotatePlatform(platformInstance.transform));

            
            if ((i + 1) % AlternatePlatformSpacing == 0 && i + 1 < PlatformAmount)
            {
                totalSpacing += AdditionalSpacing; 

               
                for (int j = 0; j < AlternatePlatformPositions.Length; j++)
                {
                    float alternateAngle = angleStep * (i + 1) + (AlternateRotation * (j + 1));
                    Vector3 alternatePosition = Vector3.up * -PlatformHeight * (i + 1) + AlternatePlatformPositions[j]; 

                    
                    float rotationDirection = AlternatePlatformClockwise[j] ? 1f : -1f;

                    
                    Quaternion alternateRotation = Quaternion.Euler(0, alternateAngle * rotationDirection, 0);

                    GameObject alternatePlatformInstance = Instantiate(PlatformPrefab, alternatePosition, alternateRotation, transform);
                    StartCoroutine(RotatePlatform(alternatePlatformInstance.transform));
                }
            }
        }
    }

    IEnumerator RotatePlatform(Transform platformTransform)
    {
        while (true)
        {
            if (platformTransform == null)
            {
                yield break;
            }

            platformTransform.Rotate(Vector3.up, RotationSpeed * Time.deltaTime);

            yield return null;
        }
    }

    public void Clean()
    {
        int childCount = transform.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}
