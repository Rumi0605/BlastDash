namespace Interface
{
    public interface IPlayerInput
    {
        float Horizontal { get; }
        
        bool IsJumpPressed { get; }
        
        bool IsJumpHold { get; }
        
        bool IsAttackPressed { get; }
        
        bool IsAttackHold { get; }
    }
}
