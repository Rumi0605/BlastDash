using System.Linq;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour ,IAttack
{
    /// <summary>
    /// 現在のホールド時間
    /// </summary>
    [SerializeField] 
    private float currentChargeTime = 0;

    private const string SCRIPT_NAME = nameof(PlayerAttackController);
    
    public void Attack(Enums.FacingDirection direction, Enums.PlayerType playerType)
    {
        if (BulletPoolManager.Instance == null)
        {
            Debug.LogWarning($"{SCRIPT_NAME}:PoolManagerが見つからないよ");
            return;
        }

        var bullet = BulletPoolManager.Instance.OrderBullet(playerType, currentChargeTime);
        bullet.transform.localPosition = transform.localPosition;
        bullet.transform.rotation = Quaternion.Euler(0, 0, (int)direction);
        bullet.SetActive(true);
        
        Reset();
    }

    /// <summary>
    /// 攻撃チャージ
    /// </summary>
    public void Charge()
    {
        currentChargeTime += Time.deltaTime;
    }
    
    /// <summary>
    ///  攻撃状態のリセット
    /// </summary>
    private void Reset()
    {
        currentChargeTime = 0;
    }
}
