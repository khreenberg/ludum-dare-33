#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using System.Collections;
using UnityEngine;

public class AutoDestroy : MonoBehaviour
{
    [SerializeField]
    private float _secondsToLive = 1.0f;

    private Coroutine _routine;

    void Start()
    {
        _routine = StartCoroutine(destroyRoutine());
    }

    IEnumerator destroyRoutine()
    {
        yield return new WaitForSeconds(_secondsToLive);
        Destroy(this.gameObject);
    }
}
#pragma warning restore 0649
