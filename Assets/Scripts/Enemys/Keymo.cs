using System;
using UnityEngine;

namespace Enemys
{
    public class Keymo : EnemyBase
    {
        /// <summary>
        /// 足元判定用Ray発射位置
        /// </summary>
        [SerializeField]
        private Transform groundCheck;
        
        /// <summary>
        /// 前方判定用Ray発射位置
        /// </summary>
        [SerializeField]
        private Transform wallCheck;

        /// <summary>
        /// ターン判定Rayの距離
        /// </summary>
        [SerializeField]
        private float checkTurnDistance = 1f;

        /// <summary>
        /// プレイヤー発見Rayの距離
        /// </summary>
        [SerializeField]
        private float checkPlayerDistance = 1f;
        
        /// <summary>
        /// 向いている方向
        /// </summary>
        private Enums.FacingDirection direction = Enums.FacingDirection.Right;
        
        /// <summary>
        /// 地面／壁レイヤー
        /// </summary>
        [SerializeField] 
        private LayerMask turnLayer;
        
        /// <summary>
        /// プレイヤーレイヤー
        /// </summary>
        [SerializeField] 
        private LayerMask playerLayer;

        /// <summary>
        /// 通常時の移動場率
        /// </summary>
        private const int DEFAULT_SPEED_TIMES = 1;
        
        /// <summary>
        /// プレイヤー発見時の移動速度
        /// </summary>
        private const int PLAYER_DISCOVERY_TIMES = 3;
        private const string SCRIPT_NAME = nameof(Keymo);
        
        private void Awake()
        {
            base.Awake();

            if (groundCheck == null)
            {
                Debug.LogWarning($"{SCRIPT_NAME}:地面判定用Transformが設定されてないよ");
                enabled = false;
            }
            
            if (wallCheck == null)
            {
                Debug.LogWarning($"{SCRIPT_NAME}:壁判定用Transformが設定されてないよ");
                enabled = false;
            }
        }
        
        private void Update()
        {
            Move();
        }

        public override void TakeDamage(int damage)
        {
            currentHP -= damage;

            Debug.Log($"{SCRIPT_NAME}:受けたダメージ：{damage}｜残り体力：{statusData.MaxHP}");
        }
        
        protected override void Move()
        {
            if (IsCheckTurn())
            {
                Flip();
            }
            
            var moveDirection = direction ==  Enums.FacingDirection.Right  ? 1 : -1;
            
            var speedTimes = IsCheckPlayer() ? PLAYER_DISCOVERY_TIMES : DEFAULT_SPEED_TIMES;
            
            rigidbody2D.linearVelocity = new Vector2(moveDirection * statusData.MoveSpeed * speedTimes, rigidbody2D.linearVelocity.y);
        }
        
        public override void Die()
        {
            //ダミーなので死なない
        }

        private bool IsCheckPlayer()
        {
            Vector3 directionLine = direction == Enums.FacingDirection.Right ? Vector3.right : Vector3.left;
            bool isPlayerAhead = Physics2D.Raycast(wallCheck.position, directionLine, checkPlayerDistance, playerLayer);
            
            //エディタで可視化用
            Debug.DrawRay(transform.position, directionLine * checkPlayerDistance, Color.green);
            return isPlayerAhead;
        }
        
        /// <summary>
        /// ターンが必要かをチェックする
        /// </summary>
        /// <returns></returns>
        private bool IsCheckTurn()
        {
            bool isGroundAhead = Physics2D.Raycast(groundCheck.position, Vector2.down, checkTurnDistance, turnLayer);

            // 壁チェック
            Vector3 directionLine = direction == Enums.FacingDirection.Right ? Vector3.right : Vector3.left;
            bool isWallAhead = Physics2D.Raycast(wallCheck.position, directionLine, checkTurnDistance, turnLayer);
            
            //エディタで可視化用
            Debug.DrawRay(groundCheck.position, Vector2.down * checkTurnDistance, Color.red);
            Debug.DrawRay(wallCheck.position, directionLine * checkTurnDistance, Color.red);
            
            return !isGroundAhead || isWallAhead;
        }
        
        /// <summary>
        /// 向き変更
        /// </summary>
        private void Flip()
        {
            direction = direction == Enums.FacingDirection.Left  ? Enums.FacingDirection.Right : Enums.FacingDirection.Left;
            
            transform.rotation = direction switch
            {
                Enums.FacingDirection.Right => Quaternion.Euler(0, 0, 0),
                Enums.FacingDirection.Left  => Quaternion.Euler(0, 180, 0),
                _ => transform.rotation
            };
        }
    }
}
