using UnityEngine;

public class PlayerAttackController : MonoBehaviour ,IAttack
{
    [SerializeField]
    private GameObject testBullet;
    
    public void Attack(Enums.FacingDirection direction)
    {
        var bullet = Instantiate(testBullet, transform.position, Quaternion.identity);
        bullet.transform.rotation = Quaternion.Euler(0, 0, (int)direction);
    }

    public void AttackHold()
    {
        Debug.Log("Holding attack...");
    }
}
