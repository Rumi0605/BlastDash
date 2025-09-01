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
        private CharacterStatusScriptableObject characterStatusScriptableObject;
        
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
            
            if (characterStatusScriptableObject == null)
            {
                Debug.LogWarning($"{SCRIPT_NAME}:ステータスがアタッチされてないよ");
                enabled = false;
                return;
            }
            
            canJumpCount = characterStatusScriptableObject.MaxJumpCount;
        }
        
        /// <summary>
        /// 水平移動
        /// </summary>
        public void Move(float moveX)
        {
            rigidbody2D.linearVelocity = new Vector2(moveX * characterStatusScriptableObject.MovementSpeed, rigidbody2D.linearVelocity.y);
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
            rigidbody2D.AddForce(Vector2.up * characterStatusScriptableObject.JumpForce, ForceMode2D.Impulse);
            
            canJumpCount--;
        }

        /// <summary>
        /// ジャンプホールド
        /// </summary>
        public void JumpHold()
        {
            if (characterStatusScriptableObject.MaxJumpHoldTime <= currentJumpHoldTime)
            {
                return;
            }
            
            currentJumpHoldTime += Time.deltaTime;
            rigidbody2D.AddForce(Vector2.up * characterStatusScriptableObject.JumpHoldForce, ForceMode2D.Force);
        }
    
        /// <summary>
        /// ジャンプ状態のリセット
        /// </summary>
        public void JumpReset()
        {
            canJumpCount = characterStatusScriptableObject.MaxJumpCount;
            currentJumpHoldTime = 0f;
        }
    }
}
