using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    [SerializeField]
    protected EnemyStatusData  statusData;

    protected int currentHP;

    private const string SCRIPT_NAME = nameof(EnemyBase);
    
    protected void Awake()
    {
        if (statusData == null)
        {
            Debug.LogWarning($"{SCRIPT_NAME}:ステータスデータが見つからないよ");
            enabled = false;
            return;
        }

        currentHP = statusData.MaxHP;
    }

    /// <summary>
    /// 移動
    /// </summary>
    protected abstract void Move();
    
    /// <summary>
    /// ダメージを受ける
    /// </summary>
    public virtual void TakeDamage(int damage)
    {
        currentHP -= damage;

        if (currentHP > 0)
        {
            return;
        }
        
        Die();
    }

    /// <summary>
    /// 死あるのみ
    /// </summary>
    public virtual void Die()
    {
        Destroy(gameObject);
    }
}
