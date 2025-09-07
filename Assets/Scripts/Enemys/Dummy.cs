using UnityEngine;

namespace Enemys
{
    public class Dummy : EnemyBase
    {
        protected override void Move()
        {
            //ダミーなので移動はなし
        }
        
        public override void TakeDamage(int damage)
        {
            currentHP -= damage;

            Debug.Log($"受けたダメージ：{damage}｜総ダメージ：{statusData.MaxHP -  currentHP}");
        }
        
        public override void Die()
        {
            //ダミーなので死なない
        }
    }
}
