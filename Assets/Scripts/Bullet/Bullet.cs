using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float frameCount = 0;
    private const int deleteFrame = 500;

    /// <summary>
    /// 移動速度
    /// </summary>
    private float speed = 5;

    /// <summary>
    /// ダメージ
    /// </summary>
    private int damage;
    
    /// <summary>
    /// 弾のステータス設定
    /// </summary>
    public void SetStatus(float speed, int damage)
    {
        this.speed = speed;
        this.damage = damage;
    }

    private void Update()
    {
        if (++frameCount >= deleteFrame)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
