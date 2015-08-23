#pragma warning disable 0649 // Disables warnings for "Field XYZ is never assigned to..."
using UnityEngine;

public class Entity : MonoBehaviour
{
    public EntityStats Stats;
    [SerializeField]
    private GameObject _deathEffect;
    [SerializeField]
    private AudioClip _deathSound;

    [SerializeField]
    private GameObject _levelUpEffect;
    [SerializeField]
    private AudioClip _levelUpSound;

    [SerializeField]
    private bool _destroyParentOnDeath = true;

    [SerializeField]
    private bool _isEnemy = true;

    private int _nextLevelXp {
        get
        {
            return Mathf.RoundToInt((Stats.Level * Stats.Level) + (2f * Stats.Level))+1;
        }
    }

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
        Destroy(_destroyParentOnDeath ? gameObject.transform.parent.gameObject : gameObject);
    }

    void Update()
    {
        if (_isEnemy) return;
        checkLevel();
    }

    private void checkLevel()
    {
        if (Stats.Experience < _nextLevelXp) return;
        LevelUp();
    }

    public void LevelUp()
    {
        GameObject effect = Instantiate(_levelUpEffect);
        effect.transform.parent = transform;
        effect.transform.localPosition = Vector2.zero;
        AudioSource.PlayClipAtPoint(_levelUpSound, transform.position);
        Stats.Level++;
        Stats.MaxHealth = Stats.Level * 100;
        Stats.Health = Stats.MaxHealth;
        Stats.Attack = Stats.Level*2;
    }
}
#pragma warning restore 0649
