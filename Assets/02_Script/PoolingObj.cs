using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolingObj : MonoBehaviour
{
    [SerializeField] private string _name = null;

    /// <summary>
    /// ������Ʈ�� �ٽ� ��Ȱ��ȭ ��Ű�� ���� �̸��� ����
    /// </summary>
    /// <param name="name"></param>
    public void SetName(string name)
    {
        _name = name;
    }

    /// <summary>
    /// ������Ʈ�� �ٽ� ��Ȱ��ȭ ��Ű�� �ڵ�� ����
    /// </summary>
    public void PushObj()
    {
        PoolingManager._instance.PushObj(_name, this.gameObject);
    }
}