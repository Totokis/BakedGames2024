using UnityEngine;

public class SoapGenerator : MonoBehaviour
{
    public GameObject soapPrefab;

    private float spawningTime;

    void Start()
    {
        spawningTime = Random.Range(0.5f, 2.5f);
    }

    void Update()
    {
        spawningTime -= Time.deltaTime;
        if (spawningTime <= 0)
        {
            Instantiate(soapPrefab, transform);
            spawningTime = Random.Range(0.5f, 2.5f);
        }
    }
}
