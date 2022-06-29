using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager _Instance = null;
    [SerializeField] List<PoolingData> _poolingData = new List<PoolingData>();

    private void Awake()
    {
        if (_Instance == null)
            _Instance = this;

        InitialPooling();
    }
    /// <summary>
    /// 풀링 할 오브젝트를 미리 생성
    /// </summary>
    private void InitialPooling()
    {
        for (int i = 0; i < _poolingData.Count; i++)
        {
            for (int j = 0; j < _poolingData[i]._poolingMaxCount; j++)
            {
                GameObject poolObj = Instantiate(_poolingData[i]._poolObj);
                poolObj.GetComponent<PoolingObj>().name = _poolingData[i]._poolObj.name;
                poolObj.SetActive(false);
                _poolingData[i]._poolingList.Add(poolObj);
            }
        }
    }
    /// <summary>
    /// 풀링 된 것을 불러오는 함수
    /// </summary>
    /// <param name="objName"></param>
    /// <returns></returns>
    public GameObject PopObj(string objName)
    {
        //반환 해 줄 값
        GameObject returnObj = null;
        //_poolingData는 리스트이므로 그 리스트의 수만큼 반복
        foreach (PoolingData poolingData in _poolingData)
        {
            //받아온 이름이랑 poolingData의 이름이 같다면
            if (poolingData._poolName == objName)
            {
                //만약 리스트에 값이 안 들어있다면
                if (poolingData._poolingList.Count <= 0)
                {
                    //새로 생성 후 리스트에 넣음
                    returnObj = Instantiate(poolingData._poolObj);
                    returnObj.GetComponent<PoolingObj>().name = poolingData._poolName;
                }
                else
                {
                    returnObj = poolingData._poolingList[0];
                    poolingData._poolingList.RemoveAt(0);
                }

                returnObj.SetActive(true);

                //반환
                return returnObj;
            }
        }
        return null;
    }
    /// <summary>
    /// 오브젝트 비활성화
    /// </summary>
    /// <param name="objName"></param>
    /// <param name="obj"></param>
    public void PushObj(string objName, GameObject obj)
    {
        foreach (PoolingData poolingData in _poolingData)
        {
            //받아온 이름이랑 poolingData의 이름이 같다면
            if (poolingData._poolName == objName)
            {
                Debug.Log("PoolingSuccess");
                obj.SetActive(false);
                poolingData._poolingList.Add(obj);
                return;
            }
        }
        Debug.Log("PoolingFail");
    }
}
[System.Serializable]
public class PoolingData
{
    [Header("풀링 데이터")]

    [Tooltip("풀링 할 오브젝트를 저장할 리스트")]
    public List<GameObject> _poolingList = new List<GameObject>();
    [Tooltip("풀링 할 객체")]
    public GameObject _poolObj;
    [Tooltip("풀링 할 오브젝트의 이름")]
    public string _poolName = string.Empty;
    [Tooltip("풀링을 얼마나 할건지")]
    public int _poolingMaxCount;
}