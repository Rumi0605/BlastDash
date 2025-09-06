using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjectScript", menuName = "PlayerBulletDataList")]
public class PlayerBulletDataList : ScriptableObject
{
    /// <summary>
    /// 攻撃データのリスト
    /// </summary>
    [SerializeField] 
    private List<PlayerBulletData> playerAttackDataList = new List<PlayerBulletData>();

    /// <summary>
    /// タイプにあった攻撃データを取得
    /// </summary>
    /// <returns></returns>
    public PlayerBulletData GetPlayerTypeBulletData(Enums.PlayerType type)
    {
        var data = playerAttackDataList.FirstOrDefault(x => x.PlayerType == type);
        if (data == null)
        {
            Debug.LogWarning($"指定された PlayerType({type}) に対応する PlayerAttackData が見つかりませんでした。");
            return null;
        }
        return data;
    }
    
    /// <summary>
    /// 全てのデータを返す
    /// </summary>
    /// <returns></returns>
    public List<PlayerBulletData> GetAllData()
    {
        return playerAttackDataList;
    }
}
