using System.Collections.Generic;
using UnityEngine;

public class SoapGenerator : MonoBehaviour
{
    public GameObject soapPrefab;
    public List<Transform> showerees = new List<Transform>();

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
            var showereeIndex = Random.Range(0, showerees.Count);

            GameObject spawnedSoap = Instantiate(soapPrefab, showerees[showereeIndex]);
            Vector2 horizontalDirection = UnityEngine.Random.value > 0.5f ? Vector2.right : Vector2.left;
            spawnedSoap.GetComponent<Rigidbody2D>().AddForce(horizontalDirection * UnityEngine.Random.Range(11f, 122f));
            spawnedSoap.GetComponent<Rigidbody2D>().AddForce(Vector3.up * UnityEngine.Random.Range(0f, 111f));


            spawningTime = Random.Range(0.5f, 2.5f);
        }
    }
}
