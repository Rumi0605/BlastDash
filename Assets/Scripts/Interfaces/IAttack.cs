using UnityEngine;

public interface IAttack
{
    public void Attack(Enums.PlayerType playerType, Enums.FacingDirection direction);

    public void Charge();
}
