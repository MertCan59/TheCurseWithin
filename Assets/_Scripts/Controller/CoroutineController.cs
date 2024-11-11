using System.Collections;
using UnityEngine;

public class CoroutineController : MonoBehaviour
{
    public static CoroutineController Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void StartCustomCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
