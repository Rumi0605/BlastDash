using UnityEngine;

public interface IAttack
{
    public void Attack(Enums.FacingDirection direction);

    public void Charge();

    public void SetAttackData(PlayerAttackData attackData);
}
