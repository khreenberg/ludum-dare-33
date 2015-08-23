#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

[RequireComponent(typeof(Entity))]
[RequireComponent(typeof(BasicMovement))]
public class PlayerAttack : MonoBehaviour
{
    
    private Entity _entity;
    private BasicMovement _movement;
    private Vector2 _originalMoveSpeed;

    void Awake()
    {
        _movement = GetComponent<BasicMovement>();
        _entity = GetComponent<Entity>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // FIXME: Make a queue system in the event of fighting multiple enemies.
        // TODO: Add FX
        Entity other = collision.gameObject.GetComponent<Entity>();
        if (other == null) return;
        beginAttack(other);
        resolveAttack(other);
    }

    public void OnTriggerStay2D(Collider2D collision)
    {
        Entity other = collision.gameObject.GetComponent<Entity>();
        if (other == null) return;
        resolveAttack(other);
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        // This method is apparently not called when the other collider is destroyed.
        // FIXME: Only disengage when the player is no longer fighting ANY enemies. See queue system mentioned above.
        disengageAttack();
    }

    private void beginAttack(Entity other)
    {
        _originalMoveSpeed = _movement.MoveSpeed;
        _movement.MoveSpeed = Vector2.zero;
    }

    private void resolveAttack(Entity other)
    {
        // TODO: Add a timer-thing, so this method is not called every frame. Maybe use Coroutines.
        //Debug.Log(string.Format("Player is attacking {0}. Health remaining: {1}", other.name, other.Stats.Health));
        bool kill = other.TakeDamage(_entity.Stats.Attack);
        if (kill) // Prevent the enemy from hurting the player, if the player kills it first.
        {
            // TODO: PEW PEW FX
            other.Die();
            disengageAttack(); // FIXME: Only disengage when the player is no longer fighting ANY enemies. See queue system mentioned above.
            return;
        }
        bool died = _entity.TakeDamage(other.Stats.Attack);
        if (died) _entity.Die();
    }

    private void disengageAttack()
    {
        _movement.MoveSpeed = _originalMoveSpeed;
    }
}
#pragma warning restore 0649
