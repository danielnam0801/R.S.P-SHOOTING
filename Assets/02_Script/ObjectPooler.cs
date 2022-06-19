using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField]
    GameObject prefab;
    [SerializeField] int poolsize = 20;

    List<GameObject> objects = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < poolsize; i++)
        {
            GameObject obj = Instantiate(prefab);
            obj.SetActive(false);
            objects.Add(obj);
        }
    }


    public GameObject SpawnObject(Vector3 position, Quaternion rotation)
    {
        GameObject newObj;

        if (objects.Count > 0)
        {
            newObj = objects[0];
            objects.RemoveAt(0);
        }
        else
        {
            newObj = Instantiate(prefab);
        }
        newObj.SetActive(true);
        newObj.transform.position = position;
        newObj.transform.rotation = rotation;
        return newObj;
    }

    public void ReturnObject(GameObject returnObj)
    {
        returnObj.SetActive(false);
        objects.Add(returnObj);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
