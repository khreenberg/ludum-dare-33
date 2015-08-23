using System;

[Serializable]
public struct EntityStats
{
    public float Health;
    public float MaxHealth;
    public float Attack;
    public float AttackSpeed; // TODO: Use in PlayerAttack to delay attacks.
    public float MoveSpeed;
    public int Experience;
    public int Level;
    public int ScoreValue;
}
