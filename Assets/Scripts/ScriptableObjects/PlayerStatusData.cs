using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectScript", menuName = "PlayerStatusData")]
public class PlayerStatusData : ScriptableObject
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField,Tooltip("左右の移動速度")]
    private float movementSpeed;

    /// <summary>
    /// ジャンプで加算される力
    /// </summary>
    [SerializeField,Tooltip("最初のジャンプ力")] 
    private float jumpForce;
    
    /// <summary>
    /// ジャンプホールドで加算される力
    /// </summary>
    [SerializeField,Tooltip("長押しした時の上昇量")] 
    private float jumpHoldForce;
    
    /// <summary>
    /// ジャンプホールドできる最大時間
    /// </summary>
    [SerializeField,Tooltip("上昇し続けられる時間")] 
    private float maxJumpHoldTime;
    
    /// <summary>
    /// ジャンプできる最大回数
    /// </summary>
    [SerializeField,Tooltip("ジャンプできる数")] 
    private int maxJumpCount;
    
    /// <summary>
    /// 移動速度の取得
    /// </summary>
    public float MovementSpeed => movementSpeed;
    
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
