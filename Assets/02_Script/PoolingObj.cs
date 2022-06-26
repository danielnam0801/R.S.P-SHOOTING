using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObj : MonoBehaviour
{
    [SerializeField] private string _name = null;

    /// <summary>
    /// 오브젝트를 다시 비활성화 시키기 위해 이름을 설정
    /// </summary>
    /// <param name="name"></param>
    public void SetName(string name)
    {
        _name = name;
    }

    /// <summary>
    /// 오브젝트를 다시 비활성화 시키는 코드로 전송
    /// </summary>
    public void PushObj()
    {
        PoolingManager._instance.PushObj(_name, this.gameObject);
    }
}