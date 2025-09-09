using UnityEngine;

[CreateAssetMenu(fileName = "EnemyStatus", menuName = "Status/Enemy/Status")]
public class EnemyStatusData : ScriptableObject
{
    /// <summary>
    /// 最大体力
    /// </summary>
    [SerializeField] 
    private int maxHP;
    
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField] 
    private float moveSpeed;

    /// <summary>
    /// 攻撃によるダメージ
    /// </summary>
    [SerializeField] 
    private int attackDamage;

    /// <summary>
    /// 接触によるダメージ
    /// </summary>
    [SerializeField] 
    private int contactDamage;
    
    [SerializeField] 
    private bool canFly = false;
    [SerializeField] 
    private bool isBoss = false;
    
    /// <summary>
    /// 最大体力を取得
    /// </summary>
    public int MaxHP => maxHP;
    
    /// <summary>
    /// 最大体力を取得
    /// </summary>
    public float MoveSpeed => moveSpeed;
    
    /// <summary>
    /// 攻撃によるダメージを取得
    /// </summary>
    public int AttackDamage => attackDamage;
    
    /// <summary>
    /// 接触によるダメージを取得
    /// </summary>
    public int ContactDamage => contactDamage;
    
    /// <summary>
    /// 飛んでいるかを取得
    /// </summary>
    public bool CanFly => canFly;
    
    /// <summary>
    /// ボスかを取得
    /// </summary>
    public bool IsBoss => isBoss;
}
