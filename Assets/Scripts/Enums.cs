public static class Enums
{
    /// <summary>
    /// 接触している地面の種類
    /// </summary>
    public enum  GroundType
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
    /// 向いている方向
    /// </summary>
    public enum FacingDirection
    {
        Left = 90,
        Right = -90
    }
}
