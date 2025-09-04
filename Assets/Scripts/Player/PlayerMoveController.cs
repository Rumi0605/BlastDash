using UnityEngine;

namespace Player
{
    public class PlayerMoveController : MonoBehaviour ,IMove
    {
        private new Rigidbody2D rigidbody2D;
        
        /// <summary>
        /// 挙動に関するステータス
        /// </summary>
        [SerializeField]
        private PlayerStatusData playerStatusData;
        
        /// <summary>
        /// 残りのジャンプできる回数
        /// </summary>
        private int canJumpCount;
        
        /// <summary>
        /// 現在のホールド時間
        /// </summary>
        [SerializeField]
        private float currentJumpHoldTime = 0f;
        
        private const string SCRIPT_NAME = nameof(PlayerMoveController);
        
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            if (rigidbody2D == null)
            {
                Debug.LogWarning($"{SCRIPT_NAME}:Rigidbody2dがアタッチされてないよ");
                enabled = false;
                return;
            }
            
            if (playerStatusData == null)
            {
                Debug.LogWarning($"{SCRIPT_NAME}:ステータスがアタッチされてないよ");
                enabled = false;
                return;
            }
            
            canJumpCount = playerStatusData.MaxJumpCount;
        }
        
        /// <summary>
        /// 水平移動
        /// </summary>
        public void Move(float moveX)
        {
            rigidbody2D.linearVelocity = new Vector2(moveX * playerStatusData.MovementSpeed, rigidbody2D.linearVelocity.y);
        }
        
        /// <summary>
        /// ジャンプ
        /// </summary>
        public void Jump()
        {
            if (canJumpCount <= 0)
            {
                return;    
            }

            rigidbody2D.linearVelocity = Vector2.zero;
            rigidbody2D.AddForce(Vector2.up * playerStatusData.JumpForce, ForceMode2D.Impulse);
            
            canJumpCount--;
        }

        /// <summary>
        /// ジャンプホールド
        /// </summary>
        public void JumpHold()
        {
            if (playerStatusData.MaxJumpHoldTime <= currentJumpHoldTime)
            {
                return;
            }
            
            currentJumpHoldTime = Mathf.Min(currentJumpHoldTime + Time.deltaTime, playerStatusData.MaxJumpHoldTime);

            rigidbody2D.AddForce(Vector2.up * playerStatusData.JumpHoldForce, ForceMode2D.Force);
        }
    
        /// <summary>
        /// ジャンプ状態のリセット
        /// </summary>
        public void Reset()
        {
            canJumpCount = playerStatusData.MaxJumpCount;
            currentJumpHoldTime = 0f;
        }
    }
}
