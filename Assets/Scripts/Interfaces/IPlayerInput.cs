namespace Interface
{
    public interface IPlayerInput
    {
        /// <summary>
        /// 左右移動入力
        /// </summary>
        float Horizontal { get; }

        /// <summary>
        /// ジャンプボタン入力
        /// </summary>
        bool IsJumpPressed { get; }
        
        /// <summary>
        /// ジャンプボタン入力
        /// </summary>
        bool IsJumpHold { get; }
        
        /// <summary>
        /// 攻撃ボタン入力
        /// </summary>
        bool IsAttackPressed { get; }
    }
}
