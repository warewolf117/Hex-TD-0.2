using UnityEngine;

public class TurretStats : MonoBehaviour
{
    GameObject pref;
    public int range;
    public int damage;
    public float fireRate;
    Node node;

    public void SetTurret()
    {
        pref = node.turret;
    }

    public int GetRange()
    {
        return range;
    }
    public int GetDamage()
    {
        return damage;
    }
    public float GetFireRate()
    {
        return fireRate;
    }
}
