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
    /// Ǯ�� �� ������Ʈ�� �����ϴ� �Լ�
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
    /// ������Ʈ�� �������� �Լ�
    /// Ǯ���� ������Ʈ�� �̸��� ������ �۵�
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
    /// ������Ʈ�� �ٽ� ��Ȱ���ϴ� �Լ�
    /// ������Ʈ�� �̸��� ������ Queue�� ���� �۵�
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
    [Header("Ǯ�� �� ������Ʈ�� �Ӽ�")]
    public Queue<GameObject> objQueue = new Queue<GameObject>();

    [Tooltip("Ǯ�� �� ������Ʈ�� ����")]
    public string name;
    [Tooltip("Ǯ�� �� ������Ʈ�� ����")]
    [Range(0, 100)]
    public int maxCount;
    [Tooltip("Ǯ�� �� ������Ʈ")]
    public GameObject obj;
}