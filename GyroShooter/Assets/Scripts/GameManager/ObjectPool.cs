using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ObjectPool
{
    private List<GameObject> pool;
    private int currentCount;
    private int max;
    private Vector3 originPosition;
    private Vector3 originScale;
    //private Vector3 originRotation;

    public ObjectPool(int _max, Vector3 _position, Vector3 _scale)
    {
        max = _max;
        currentCount = 0;
        pool = new List<GameObject>();
        originPosition = _position;
        originScale = _scale;

    }

    /// <summary>
    /// オブジェクトをプールする。
    /// </summary>
    /// <param name="_obj">_obj.</param>
    public void Pool(GameObject parent, GameObject _obj, int _number)
    {
        int count = _number;
        if (_number > max)
            count = max;
        for (int i = 0; i < count; i++)
        {
            var go = GameObject.Instantiate(_obj, originPosition, Quaternion.identity) as GameObject;
            go.transform.SetParent(parent.transform, false);
            go.SetActive(false);
            pool.Add(go);
        }
        // Debug.Log(pool.Count + "こプールしました");
    }
    /// <summary>
    /// プールしたオブジェクトを返す
    /// </summary>
    public GameObject Instantiate()
    {
        // Debug.Log ("Poolから取得します。");
        if (pool == null)
        {
            return null;
        }
        GameObject retObj = pool[currentCount];

        retObj.transform.localPosition = originPosition;
        retObj.transform.localScale = originScale;
        currentCount++;
        if (currentCount >= pool.Count)
        {
            currentCount = 0;
        }
        retObj.SetActive(true);
        return retObj;
    }
}