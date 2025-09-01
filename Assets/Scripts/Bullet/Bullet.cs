using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float frameCount = 0;
    private const int deleteFrame = 500;
    private void Update()
    {
        if (++frameCount >= deleteFrame)
        {
            Destroy(gameObject);
        }
        transform.Translate(Vector3.up * Time.deltaTime * 5);
    }
}
