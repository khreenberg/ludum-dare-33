#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityStats Stats;
    [SerializeField]
    private GameObject _deathEffect;
    [SerializeField]
    private AudioClip _deathSound;

    /// <summary>
    /// Damages the health of the entity.
    /// </summary>
    /// <param name="damageAmount">The amount of damage to inflict on the entity.</param>
    /// <returns>Returns true if the entity was killed, false otherwise.</returns>
    public bool TakeDamage(float damageAmount)
    {
        // TODO: Add FX
        Stats.Health -= damageAmount;
        return Stats.Health <= 0;
    }

    /// <summary>
    /// Kills the entity. (Includes cleanup)
    /// </summary>
    public void Die()
    {
        Instantiate(_deathEffect, transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(_deathSound, transform.position);
        Destroy(this.gameObject);
    }

}
#pragma warning restore 0649
