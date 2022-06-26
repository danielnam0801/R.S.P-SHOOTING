using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager _instance;

    [SerializeField] private List<PoolObj> _poolObjList = new List<PoolObj>();
    [SerializeField] private Transform _poolTransform = null;

    private void Awake()
    {
        if (_instance == null)
            _instance = this;
    }

    private void Start()
    {
        CreatePooledObj();
    }

    /// <summary>
    /// 풀링 될 오브젝트를 생성하는 함수
    /// </summary>
    private void CreatePooledObj()
    {
        for (int i = 0; i < _poolObjList.Count; i++)
        {
            for (int j = 0; j < _poolObjList[i].maxCount; j++)
            {
                GameObject obj = Instantiate(_poolObjList[i].obj, _poolTransform);
                obj.GetComponent<PoolingObj>().SetName(_poolObjList[i].name);
                obj.SetActive(false);
                _poolObjList[i].objQueue.Enqueue(obj);
            }
        }
    }

    /// <summary>
    /// 오브젝트를 꺼내오는 함수
    /// 풀링한 오브젝트의 이름을 넣으면 작동
    /// </summary>
    /// <param name="objName"></param>
    /// <returns></returns>
    public GameObject PopObj(string objName)
    {
        int i = 0;
        for (i = 0; i < _poolObjList.Count; i++)
        {
            if (_poolObjList[i].name == objName)
            {
                break;
            }
        }

        GameObject obj = null;

        if (_poolObjList[i].objQueue.Count > 0)
        {
            obj = _poolObjList[i].objQueue.Dequeue();
        }
        else
        {
            obj = Instantiate(_poolObjList[i].obj, _poolTransform);
            obj.GetComponent<PoolingObj>().SetName(_poolObjList[i].name);
        }
        obj.SetActive(true);

        return obj;
    }

    /// <summary>
    /// 오브젝트를 다시 비활성하는 함수
    /// 오브젝트의 이름을 넣으면 Queue에 들어가며 작동
    /// </summary>
    /// <param name="objName"></param>
    /// <param name="obj"></param>
    public void PushObj(string objName, GameObject obj)
    {
        int i = 0;
        for (i = 0; i < _poolObjList.Count; i++)
        {
            if (_poolObjList[i].name == objName)
            {
                break;
            }
        }

        obj.SetActive(false);
        _poolObjList[i].objQueue.Enqueue(obj);
    }
}

[System.Serializable]
public class PoolObj
{
    [Header("풀링 될 오브젝트의 속성")]
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    [Tooltip("풀링 될 오브젝트의 네임")]
    public string name;
    [Tooltip("풀링 될 오브젝트의 갯수")]
    [Range(0, 100)]
    public int maxCount;
    [Tooltip("풀링 될 오브젝트")]
    public GameObject obj;
}