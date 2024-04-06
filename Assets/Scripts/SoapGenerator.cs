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
            var showereeIndex = Random.Range(0, showerees.Count - 1);

            Instantiate(soapPrefab, showerees[showereeIndex]);
            spawningTime = Random.Range(0.5f, 2.5f);
        }
    }
}
