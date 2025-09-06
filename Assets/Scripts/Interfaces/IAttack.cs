using UnityEngine;

public interface IAttack
{
    public void Attack(Enums.FacingDirection direction, Enums.PlayerType playerType);

    public void Charge();
}
