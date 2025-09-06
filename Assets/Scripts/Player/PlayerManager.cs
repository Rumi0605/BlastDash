using System;
using Input;
using Interface;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMoveController))]
    [RequireComponent(typeof(PlayerAttackController))]
    public class PlayerManager : MonoBehaviour
    {
        private IPlayerInput playerInput;
        private IMove  MoveController;
        private IAttack  AttackController;
        
        [SerializeField]
        private Enums.PlayerType playerType;
        /// <summary>
        /// 向いている方向
        /// </summary>
        private Enums.FacingDirection currentFacingDirection = Enums.FacingDirection.Right;
        
        
        /// <summary>
        /// 床の判定をするクラス
        /// </summary>
        private GroundChecker groundChecker;
        
        private const string SCRIPT_NAME = nameof(PlayerManager);
        
        private void Awake()
        {
            groundChecker = GetComponentInChildren<GroundChecker>();
            MoveController = GetComponent<PlayerMoveController>();
            AttackController = GetComponent<PlayerAttackController>();
            playerInput = new PlayerInputSystem();
            
            if (groundChecker == null)
            {
                Debug.LogWarning($"{SCRIPT_NAME}:床判定するスクリプトの参照が正しくないよ");
                enabled = false;
                return;
            }
            
            groundChecker.OnEnterGroundEvent += MoveController.Reset;
        }

        private void Start()
        {
            ChangeType(Enums.PlayerType.Normal);
        }

        private void Update()
        {
            MoveAction();
            JumpAction();  
            AttackAction();
        }

        /// <summary>
        /// 移動アクションの管理
        /// </summary>
        private void MoveAction()
        {
            var moveX = playerInput.Horizontal;
            
            currentFacingDirection = moveX switch
            {
                > 0 when currentFacingDirection != Enums.FacingDirection.Right => Enums.FacingDirection.Right,
                < 0 when currentFacingDirection != Enums.FacingDirection.Left => Enums.FacingDirection.Left,
                _ => currentFacingDirection
            };

            MoveController.Move(moveX);
        }

        /// <summary>
        /// 攻撃アクションの管理
        /// </summary>
        private void AttackAction()
        {
            if (playerInput.IsAttackPressed)
            {
                AttackController.Attack(currentFacingDirection, playerType);
            }

            if (playerInput.IsAttackHold)
            {
                AttackController.Charge();
            }
        }
        
        /// <summary>
        /// ジャンプアクションの管理
        /// </summary>
        private void JumpAction()
        {
            if (playerInput.IsJumpPressed)
            {
                MoveController.Jump();
            }
            
            if (playerInput.IsJumpHold)
            {
                MoveController.JumpHold();
            }
        }

        /// <summary>
        /// タイプの変更
        /// </summary>
        /// <param name="type"></param>
        private void ChangeType(Enums.PlayerType type)
        {
            playerType = type;
        }
        
        private void OnDestroy()
        {
            if (groundChecker == null || MoveController == null)
            {
                return;
            }
            
            groundChecker.OnEnterGroundEvent -= MoveController.Reset;
        }
    }
}