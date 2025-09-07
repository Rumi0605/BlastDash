using UnityEngine;

public class NormalBullet : BulletBase
{
    protected override void Move()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
