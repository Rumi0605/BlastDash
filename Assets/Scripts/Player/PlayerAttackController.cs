using System.Linq;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour ,IAttack
{
    private PlayerAttackData attackData;

    /// <summary>
    /// 現在のホールド時間
    /// </summary>
    [SerializeField] 
    private float currentChargeTime = 0;

    private const string SCRIPT_NAME = nameof(PlayerAttackController);
    
    /// <summary>
    /// 攻撃種類の変更
    /// </summary>
    /// <param name="attackData"></param>
    public void SetAttackData(PlayerAttackData attackData)
    {
        this.attackData = attackData;
    }
    
    public void Attack(Enums.FacingDirection direction)
    {
        var data = GetChargeLevelData();
        
        if (data == null)
        {
            Debug.LogWarning($"{SCRIPT_NAME}:攻撃データが見つからないよ");
            return;
        }
        
        var prefab = Instantiate(data.Prefab, transform.position, Quaternion.identity);
        var bullet = prefab.transform.GetComponent<Bullet>();
        bullet.SetStatus(data.Speed, data.Damage);
        prefab.transform.rotation = Quaternion.Euler(0, 0, (int)direction);

        Reset();
    }

    /// <summary>
    /// 攻撃チャージ
    /// </summary>
    public void Charge()
    {
        currentChargeTime = Mathf.Min(currentChargeTime + Time.deltaTime, attackData.ChargeDataList.Max(x => x.ChargeTime));
    }

    /// <summary>
    /// 現在のホールド時間に対応するチャージ段階を取得
    /// </summary>
    private ChargeLevelData GetChargeLevelData()
    {
        return attackData.ChargeDataList
            .Where(x => currentChargeTime >= x.ChargeTime)
            .OrderByDescending(x => x.ChargeTime)
            .FirstOrDefault();
    }
    
    /// <summary>
    ///  攻撃状態のリセット
    /// </summary>
    private void Reset()
    {
        currentChargeTime = 0;
    }
}
