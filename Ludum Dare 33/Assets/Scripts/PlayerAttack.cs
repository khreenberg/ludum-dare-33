#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Entity))]
public class PlayerAttack : MonoBehaviour
{
    
    private Entity _entity;
    private PlayerMovement _movement;

    private HashSet<Entity> _currentlyEngagedEntities = new HashSet<Entity>();

    void Awake()
    {
        _entity = GetComponent<Entity>();
        _movement = GetComponent<PlayerMovement>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        // FIXME: Make a queue system in the event of fighting multiple enemies.
        // TODO: Add FX
        Entity other = collision.gameObject.GetComponent<Entity>();
        if (other == null) return;
        beginAttack(other);
        //resolveAttack(other);
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
        disengageAttack(collision.gameObject.GetComponent<Entity>());
    }

    private void beginAttack(Entity other)
    {
        if (_currentlyEngagedEntities.Contains(other)) return;
        _currentlyEngagedEntities.Add(other);
        other.Stats.MoveSpeed = 0;
        _movement.CanMove = false;
    }

    private void resolveAttack(Entity other)
    {
        // TODO: Add a timer-thing, so this method is not called every frame. Maybe use Coroutines.
        bool kill = other.TakeDamage(_entity.Stats.Attack);
        if (kill) // Prevent the enemy from hurting the player, if the player kills it first.
        {
            disengageAttack(other);
            other.Die();
            _entity.Stats.ScoreValue += other.Stats.ScoreValue;
            _entity.Stats.Experience += other.Stats.Experience;
            return;
        }
        bool died = _entity.TakeDamage(other.Stats.Attack);
        if (died) _entity.Die();
    }

    private void disengageAttack(Entity other)
    {
        _currentlyEngagedEntities.Remove(other);
        if (_currentlyEngagedEntities.Count > 0) return;
        _movement.CanMove = true;
    }
}
#pragma warning restore 0649
