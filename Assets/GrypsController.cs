using System;
using System.Collections;
using UnityEngine;

public class GrypsController : MonoBehaviour
{
    public AudioClip[] Grypses;
    public AudioSource OknoWCeli;

    public int[] grypsIndicesOrder;
    public int currentGryps = 0;

    void Start()
    {
        grypsIndicesOrder = ArrayShuffler.GetShuffledIndices(Grypses.Length);
        StartCoroutine(StartGrypsing());
    }

    bool initial = true;
    private IEnumerator StartGrypsing()
    {
        if(initial)
            yield return new WaitForSeconds(6f);

        initial = false;
        print("gryps");
        OknoWCeli.PlayOneShot(Grypses[grypsIndicesOrder[currentGryps]]);
        currentGryps++;

        yield return new WaitForSeconds(Grypses[currentGryps].length + UnityEngine.Random.Range(2f, 3.5f));

        StartCoroutine(StartGrypsing());
    }

    void Update()
    {
        
    }
}

public class ArrayShuffler
{
    // Method to shuffle indices of an array using Unity's Random
    public static int[] GetShuffledIndices(int arrayLength)
    {
        UnityEngine.Random.InitState((int)DateTime.Now.Ticks);
        // Create an array of indices [0, 1, 2, ..., arrayLength-1]
        int[] indices = new int[arrayLength];
        for (int i = 0; i < arrayLength; i++)
        {
            indices[i] = i;
        }

        // Shuffle the indices array
        Shuffle(indices);

        return indices;
    }

    // Fisher-Yates shuffle algorithm adapted for Unity's Random
    private static void Shuffle(int[] array)
    {
        int n = array.Length;
        for (int i = n - 1; i > 0; i--)
        {
            // Pick a random index from 0 to i
            int j = UnityEngine.Random.Range(0, i + 1);

            // Swap array[i] with the element at random index
            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}

