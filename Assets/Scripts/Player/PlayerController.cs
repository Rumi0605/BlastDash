using System;
using Input;
using Interface;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private new Rigidbody2D rigidbody2D;
        private IPlayerInput playerInput;

        /// <summary>
        /// 挙動に関するステータス
        /// </summary>
        [SerializeField]
        private CharacterStatusScriptableObject  characterStatusScriptableObject;
        
        /// <summary>
        /// 床の判定をするクラス
        /// </summary>
        [SerializeField] 
        private GroundChecker groundChecker;
        
        /// <summary>
        /// 現在のホールド時間
        /// </summary>
        [SerializeField]
        private float currentJumpHoldTimer = 0f;
        
        /// <summary>
        /// 残りのジャンプできる回数
        /// </summary>
        [SerializeField]
        private int canJumpCount;
        
        private const string SCRIPT_NAME = nameof(PlayerController);
        
        private void Awake()
        {
            rigidbody2D = GetComponent<Rigidbody2D>();
            playerInput = new PlayerInputSystem();
            
            if (groundChecker == null)
            {
                Debug.LogWarning($"{SCRIPT_NAME}:床判定するスクリプトの参照が正しくないよ");
                enabled = false;
                return;
            }
            
            groundChecker.OnEnterGroundEvent += JumpReset;
        }

        private void Start()
        {
            if (characterStatusScriptableObject == null)
            {
                Debug.LogWarning($"{SCRIPT_NAME}:ステータスの参照が正しくないよ");
                enabled = false;
                return;
            }
            
            canJumpCount = characterStatusScriptableObject.MaxJumpCount;
        }

        private void Update()
        {
            JumpAction();  
            MovementAction();
        }

        #region 移動
        
        /// <summary>
        /// 移動アクションの管理
        /// </summary>
        private void MovementAction()
        {
            Move();
        }
        
        /// <summary>
        /// 水平移動
        /// </summary>
        private void Move()
        {
            float moveX = playerInput.Horizontal;
            rigidbody2D.linearVelocity = new Vector2(moveX * characterStatusScriptableObject.MovementSpeed, rigidbody2D.linearVelocity.y);
        }
        
        #endregion
        
        #region ジャンプ
        
        /// <summary>
        /// ジャンプアクションの管理
        /// </summary>
        private void JumpAction()
        {
            if (playerInput.IsJumpPressed &&　canJumpCount > 0)
            {
                Jump();
                canJumpCount--;
            }
            
            if (playerInput.IsJumpHold && currentJumpHoldTimer < characterStatusScriptableObject.MaxJumpHoldTimer)
            {
                JumpBoost();
            }
        }
        
        /// <summary>
        /// ジャンプ
        /// </summary>
        private void Jump()
        {
            rigidbody2D.linearVelocity = Vector2.zero;
            rigidbody2D.AddForce(Vector2.up * characterStatusScriptableObject.JumpForce, ForceMode2D.Impulse);
        }

        /// <summary>
        /// ジャンプ加速
        /// </summary>
        private void JumpBoost()
        {
            currentJumpHoldTimer += Time.deltaTime;
            rigidbody2D.AddForce(Vector2.up * characterStatusScriptableObject.JumpHoldForce, ForceMode2D.Force);
        }
        
        /// <summary>
        /// ジャンプ状態のリセット
        /// </summary>
        private void JumpReset()
        {
            canJumpCount = characterStatusScriptableObject.MaxJumpCount;
            currentJumpHoldTimer = 0f;
            JumpAction();
        }

        #endregion
        
        private void OnDestroy()
        {
            if (groundChecker == null)
            {
                return;
            }
            
            groundChecker.OnEnterGroundEvent -= JumpReset;
        }
    }
}