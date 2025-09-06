using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerAttackData", menuName = "PlayerBulletData")]
public class PlayerBulletData : ScriptableObject
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
    [SerializeField] 
    private Enums.BulletType bulletType;
    public Enums.BulletType BulletType => bulletType;
    
    [SerializeField] 
    private float chargeTime;
    public float ChargeTime => chargeTime;

    [SerializeField]
    private float speed;
    public float Speed => speed;

    [SerializeField] 
    private int damage;
    public int Damage => damage;

    [SerializeField]
    private GameObject prefab;
    public GameObject Prefab => prefab;
}
