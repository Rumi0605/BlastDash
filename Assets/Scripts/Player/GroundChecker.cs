using UnityEngine;

namespace Player
{
    public class GroundChecker : MonoBehaviour
    {
        /// <summary>
        /// 地面の接触を感知するイベント
        /// </summary>
        public delegate void TouchGroundHandler();
        public TouchGroundHandler OnEnterGroundEvent;

        /// <summary>
        /// 現在の床
        /// </summary>
        [SerializeField]
        private Enums.GroundType currentGround = Enums.GroundType.None;
        public Enums.GroundType CurrentGround => currentGround;
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            switch (collision.tag)
            {
                case "Ground":
                    currentGround = Enums.GroundType.Normal;
                    break;
                case "PassableGround":
                    currentGround = Enums.GroundType.Passable;
                    break;
                default:
                    return;
            }
            
            OnEnterGroundEvent?.Invoke();
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            currentGround = collision.tag switch
            {
                "Ground" => Enums.GroundType.Normal,
                "PassableGround" => Enums.GroundType.Passable,
                _ => Enums.GroundType.None
            };
        }
    }
}