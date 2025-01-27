using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineRunner : MonoBehaviour
{
    public void StartWaveCoroutine(IEnumerator coroutine)
    {
        StartCoroutine(coroutine);
    }
}
