using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectScript", menuName = "PlayerAttackDataList")]
public class PlayerAttackDataList : ScriptableObject
{
    /// <summary>
    /// 攻撃データのリスト
    /// </summary>
    [SerializeField] 
    private List<PlayerAttackData> playerAttackDataList = new List<PlayerAttackData>();

    /// <summary>
    /// タイプにあった攻撃データを取得
    /// </summary>
    /// <returns></returns>
    public PlayerAttackData GetPlayerAttackData(Enums.PlayerType type)
    {
        var data = playerAttackDataList.FirstOrDefault(x => x.PlayerType == type);
        if (data == null)
        {
            Debug.LogWarning($"指定された PlayerType({type}) に対応する PlayerAttackData が見つかりませんでした。");
            return null;
        }
        return data;
    }
}
