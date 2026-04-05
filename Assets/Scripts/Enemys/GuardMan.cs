using System;
using UnityEngine;

namespace Enemys
{
    public class GuardMan : EnemyBase
    {
        /// <summary>
        /// 向いている方向
        /// </summary>
        private Enums.FacingDirection direction = Enums.FacingDirection.Right;

        /// <summary>
        /// 行動ステート
        /// </summary>
        private Enums.GuardManState moveState;
        
        [SerializeField]
        private GameObject shield;
        
        private float timeElapsed = 0;

        private const float CHANGE_TIME = 5f;
        private const string SCRIPT_NAME = nameof(GuardMan);

        private void Awake()
        {
            base.Awake();

            if (shield == null)
            {
                Debug.LogWarning($"{SCRIPT_NAME}:盾が設定されてないよ");
                enabled = false;
            }
        }

        private void Start()
        {
            moveState = Enums.GuardManState.Weak;
            ChangeState();
        }

        private void Update()
        {
            timeElapsed += Time.deltaTime;

            if (timeElapsed <= CHANGE_TIME)
            {
                return;
            }

            timeElapsed = 0;

            ChangeState();
        }
        
        protected override void Move()
        {
            //移動なし
        }

        /// <summary>
        /// 弱点解放
        /// </summary>
        private void Weak()
        {
            shield.SetActive(false);
        }
        
        /// <summary>
        /// 盾の構え
        /// </summary>
        private void Guard()
        {
            shield.SetActive(true);
        }

        /// <summary>
        /// ステート切り替え
        /// </summary>
        private void ChangeState()
        {
            switch (moveState)
            {
                case Enums.GuardManState.Guard:
                    moveState =  Enums.GuardManState.Weak;
                    Weak();
                    break;
                case Enums.GuardManState.Weak:
                    moveState = Enums.GuardManState.Guard;
                    Guard();
                    break;
            }
        }
    }
}