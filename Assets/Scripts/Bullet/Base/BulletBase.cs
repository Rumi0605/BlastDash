using UnityEngine;

public abstract class BulletBase : MonoBehaviour
{
    /// <summary>
    /// 移動速度
    /// </summary>
    protected float speed = 5;
    
    /// <summary>
    /// 経過したフレーム
    /// </summary>
    protected float frameCount = 0;

    /// <summary>
    /// ダメージ
    /// </summary>
    protected int damage;
    
    protected const int CAN_MOVE_FRAME = 1000;
    
    protected virtual void Update()
    {
        if (++frameCount >= CAN_MOVE_FRAME)
        {
            gameObject.SetActive(false);
            return;
        }

        Move();
    }
    
    /// <summary>
    /// 弾のステータス設定
    /// </summary>
    public void SetStatus(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
        frameCount = 0;
    }

    protected abstract void Move();

    protected virtual void OnHit(IEnemy enemy)
    {
        enemy.TakeDamage(damage);
        gameObject.SetActive(false);
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            OnHit(other.gameObject.GetComponent<IEnemy>());
        }
    }
}
