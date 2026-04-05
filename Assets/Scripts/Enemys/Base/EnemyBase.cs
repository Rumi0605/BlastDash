using UnityEngine;

public abstract class EnemyBase : MonoBehaviour, IEnemy
{
    protected Rigidbody2D rigidbody2D;
    
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
        
        rigidbody2D = GetComponent<Rigidbody2D>();
        if (rigidbody2D == null)
        {
            Debug.LogWarning($"{SCRIPT_NAME}:Rigidbody2dがアタッチされてないよ");
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
            Debug.Log($"{statusData.name}:受けたダメージ：{damage}｜残り体力：{currentHP}");
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
