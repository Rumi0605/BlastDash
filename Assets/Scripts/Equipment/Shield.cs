using UnityEngine;

public class Shield : MonoBehaviour
{
    private const string SCRIPT_NAME = nameof(Shield);

    public void OnHit()
    {
        Debug.Log($"{SCRIPT_NAME}:ガードしたよ");
    }
}
