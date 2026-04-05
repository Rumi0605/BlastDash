public static class Enums
{
    /// <summary>
    /// 接触している地面の種類
    /// </summary>
    public enum GroundType
    {
        /// <summary>
        /// 何もない
        /// </summary>
        None = 0,
        
        /// <summary>
        /// 普通の床
        /// </summary>
        Normal,
        
        /// <summary>
        /// 抜ける床
        /// </summary>
        Passable
    }

    /// <summary>
    /// 弾の種類
    /// </summary>
    public enum BulletType
    {
        None = 0,
        NormalLv1,
        NormalLv2,
        NormalLv3,
    }
    
    /// <summary>
    /// 向いている方向
    /// </summary>
    public enum FacingDirection
    {
        Right = 0,
        Left = 180
    }

    /// <summary>
    /// 現在のプレイヤーのタイプ
    /// </summary>
    public enum PlayerType
    {
        Normal = 0,
    }

    public enum GuardManState
    {
        Guard = 0,
        Weak
    }
}
