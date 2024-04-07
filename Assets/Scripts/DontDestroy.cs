using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private static GameObject go;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (go == null)
            go = gameObject;
        else
            Destroy(gameObject);
    }
}