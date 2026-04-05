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
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        var targetTag = other.gameObject.tag;

        switch (targetTag)
        {
            case "Ground" or "Wall":
                gameObject.SetActive(false);
                return;
            case "Shield":
                other.gameObject.GetComponent<Shield>().OnHit();
                gameObject.SetActive(false);
                return;
            case "Enemy":
                OnHit(other.gameObject.GetComponent<IEnemy>());
                gameObject.SetActive(false);
                return;
        }
    }
}
