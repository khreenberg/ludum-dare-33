#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class KnightDefenceZone : MonoBehaviour
{
    private EnemyMovement _patrol;
    private KnightChase _chase;

    void Start()
    {
        GameObject knight = transform.parent.Find("Knight").gameObject;
        _patrol = knight.GetComponent<EnemyMovement>();
        _chase = knight.GetComponent<KnightChase>();
        _patrol.enabled = true;
        _chase.enabled = false;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Equals("Player")) return;
        _patrol.enabled = false;
        _chase.enabled = true;
        _chase.Target = collision.transform;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.gameObject.tag.Equals("Player")) return;
        _patrol.enabled = true;
        _chase.enabled = false;
    }
}
#pragma warning restore 0649
