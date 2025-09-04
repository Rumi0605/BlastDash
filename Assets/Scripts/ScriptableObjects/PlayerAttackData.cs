using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackData", menuName = "PlayerAttackData")]
public class PlayerAttackData : ScriptableObject
{
    /// <summary>
    /// タイプ
    /// </summary>
    [SerializeField]
    private Enums.PlayerType playerType;
    
    /// <summary>
    /// 最大チャージ時間
    /// </summary>
    [SerializeField]
    private List<ChargeLevelData> chargeDataList = new List<ChargeLevelData>();
    
    /// <summary>
    /// タイプの取得
    /// </summary>
    public Enums.PlayerType PlayerType =>  playerType;
    
    public List<ChargeLevelData> ChargeDataList =>  chargeDataList;
}

/// <summary>
/// チャージデータ
/// </summary>
[Serializable]
public class ChargeLevelData
{
    [SerializeField,Tooltip("この段階に到達するまでのチャージ時間 (秒)")] 
    private float chargeTime;
    public float ChargeTime => chargeTime;

    [SerializeField,Tooltip("この段階の弾の速さ")]
    private float speed;
    public float Speed => speed;

    [SerializeField,Tooltip("この段階の弾のダメージ")] 
    private int damage;
    public int Damage => damage;

    [SerializeField,Tooltip("弾のPrefab")]
    private GameObject prefab;
    public GameObject Prefab => prefab;
}
