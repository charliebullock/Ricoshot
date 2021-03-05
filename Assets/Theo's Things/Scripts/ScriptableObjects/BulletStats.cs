
using UnityEngine;

[CreateAssetMenu(fileName = "New Bullet Stats", menuName = "Bullet Stats/Weapon", order = 1)]
public class BulletStats : ScriptableObject
{
    public float speed;
    public int numberOfReflections;
}
