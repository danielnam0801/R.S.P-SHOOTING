using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionAutoDestroyer : MonoBehaviour
{
    [SerializeField] StageData stageData;
    [SerializeField] float destroySize = 2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void LateUpdate()
    {
        if (transform.position.x < stageData.LimitMin.x - destroySize || transform.position.x > stageData.LimitMax.x + destroySize ||
           transform.position.y < stageData.LimitMin.y - destroySize || transform.position.y > stageData.LimitMax.y + destroySize)
        {
            if(this.gameObject.layer == 20)
            {
                GetComponent<PoolingObj>().PushObj1();
            }
            else
            {
                Destroy(gameObject);
            }
            
            //Debug.Log()
        }
    }
}
