using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectScript", menuName = "CharacterStatus")]
public class CharacterStatusScriptableObject : ScriptableObject
{
    /// <summary>
    /// 移動速度
    /// </summary>
    [SerializeField]
    private float movementSpeed;

    /// <summary>
    /// ジャンプで加算される力
    /// </summary>
    [SerializeField] 
    private float jumpForce;
    
    /// <summary>
    /// ホールドジャンプで加算される力
    /// </summary>
    [SerializeField] 
    private float jumpHoldForce;
    
    /// <summary>
    /// ホールドジャンプのできる最大時間
    /// </summary>
    [SerializeField] 
    private float maxJumpHoldTimer;
    
    /// <summary>
    /// ジャンプできる最大回数
    /// </summary>
    [SerializeField] 
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
    /// ホールドジャンプで加算される力の取得
    /// </summary>
    public float JumpHoldForce => jumpHoldForce;
    
    /// <summary>
    /// ホールドジャンプのできる最大時間の取得
    /// </summary>
    public float MaxJumpHoldTimer => maxJumpHoldTimer;
    
    /// <summary>
    /// ジャンプできる最大回数の取得
    /// </summary>
    public int MaxJumpCount => maxJumpCount;
}
