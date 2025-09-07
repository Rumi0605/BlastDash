using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStatus", menuName = "Status/Player/Status")]
public class PlayerStatusData : ScriptableObject
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float moveSpeed;

    /// <summary>
    /// ジャンプで加算される力
    /// </summary>
    [SerializeField] 
    private float jumpForce;
    
    /// <summary>
    /// ジャンプホールドで加算される力
    /// </summary>
    [SerializeField] 
    private float jumpHoldForce;
    
    /// <summary>
    /// ジャンプホールドできる最大時間
    /// </summary>
    [SerializeField] 
    private float maxJumpHoldTime;
    
    /// <summary>
    /// ジャンプできる最大回数
    /// </summary>
    [SerializeField] 
    private int maxJumpCount;
    
    /// <summary>
    /// 移動速度の取得
    /// </summary>
    public float MoveSpeed => moveSpeed;
    
    /// <summary>
    /// ジャンプで加算される力の取得
    /// </summary>
    public float JumpForce => jumpForce;
    
    /// <summary>
    /// ジャンプホールドで加算される力の取得
    /// </summary>
    public float JumpHoldForce => jumpHoldForce;
    
    /// <summary>
    /// ジャンプホールドのできる最大時間の取得
    /// </summary>
    public float MaxJumpHoldTime => maxJumpHoldTime;
    
    /// <summary>
    /// ジャンプできる最大回数の取得
    /// </summary>
    public int MaxJumpCount => maxJumpCount;
}
