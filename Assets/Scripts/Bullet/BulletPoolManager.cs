using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager Instance { get; private set; }

    /// <summary>
    /// 弾のデータ
    /// </summary>
    [SerializeField]
    private PlayerBulletDataList bulletDataList;
    
    /// <summary>
    /// 弾を格納するオブジェクト
    /// </summary>
    [SerializeField] 
    private Transform poolParent;

    /// <summary>
    /// 弾ごとのプールディクショナリ
    /// </summary>
    private Dictionary<Enums.BulletType, BulletPool> bulletPools = new();

    private const string SCRIPT_NAME = nameof(BulletPoolManager);

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        if (poolParent == null)
        {
            Debug.LogWarning($"{SCRIPT_NAME}: 弾を管理するオブジェクトを設定してください");
            enabled = false;
            return;
        }

        if (bulletDataList == null)
        {
            Debug.LogWarning($"{SCRIPT_NAME}: 弾リストを設定してください");
            enabled = false;
            return;
        }

        Initialize();
    }

    /// <summary>
    /// 初期化
    /// </summary>
    private void Initialize()
    {
        foreach (var charge in from playerBulletData in bulletDataList.GetAllData() 
                 from charge in playerBulletData.ChargeDataList 
                 where !bulletPools.ContainsKey(charge.BulletType) select charge)
        {
            bulletPools.Add(charge.BulletType, new BulletPool());
        }
    }

    /// <summary>
    /// 弾の注文
    /// </summary>
    public GameObject OrderBullet(Enums.PlayerType playerType, float chargeTime)
    {
        var useBulletData = GetChargeData(playerType, chargeTime);

        if (!bulletPools.TryGetValue(useBulletData.BulletType, out var pool))
        {
            Debug.LogWarning($"{SCRIPT_NAME}: {useBulletData.BulletType} のプールが存在しません");
            return null;
        }

        // プールから取得（無ければ生成）
        var data = pool.GetBullet();

        if (data == null)
        {
            data = pool.CreateBullet(useBulletData.Prefab, poolParent);
        }
        
        // ステータス設定
        var bulletComp = data.GetComponent<Bullet>();
        bulletComp.SetStatus(useBulletData.Speed, useBulletData.Damage);

        return data;
    }

    /// <summary>
    /// 現在のホールド時間に対応するチャージ段階を取得
    /// </summary>
    private ChargeLevelData GetChargeData(Enums.PlayerType playerType, float chargeTime)
    {
        var data = bulletDataList.GetPlayerTypeBulletData(playerType);
        if (data == null)
        {
            return null;
        }
        
        return data.ChargeDataList
            .Where(x => chargeTime >= x.ChargeTime)
            .OrderByDescending(x => x.ChargeTime)
            .FirstOrDefault();
    }
}

/// <summary>
/// 弾プールクラス
/// </summary>
public class BulletPool
{
    /// <summary>
    /// 弾のプール
    /// </summary>
    private readonly List<GameObject> pool = new();

    /// <summary>
    /// 非アクティブの弾を返す
    /// </summary>
    public GameObject GetBullet()
    {
        var bullet = pool.FirstOrDefault(b => !b.activeSelf);
        
        if (bullet == null)
        {
            return null;
        }
        
        return bullet;
    }

    /// <summary>
    /// プールに弾を追加
    /// </summary>
    public GameObject CreateBullet(GameObject prefab, Transform parent)
    {
        var newBullet = Object.Instantiate(prefab, parent);
        newBullet.SetActive(false);
        pool.Add(newBullet);
        return newBullet;
    }
}
