using UnityEngine;

[CreateAssetMenu(fileName = "CharacterObjects", menuName = "Scriptable Objects/CharacterObjects")]
public class CharacterObjects : ScriptableObject
{
    public int maxHealth;
    public int attackDamage;
    public float attackRange;
    public float attackCooldown;
    public float knockback;

    public static CharacterObjects instance;

    private void OnEnable()
    {
        instance = this;
    }
}
