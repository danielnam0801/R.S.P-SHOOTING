using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject bulletPrefab;
    private Camera mainCam;


    private void Start()
    {
        mainCam = Camera.main;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            RaycastHit hitResult;
            if (Physics.Raycast(mainCam.ScreenPointToRay(Input.mousePosition), out hitResult))
            {
                var direction = new Vector3(hitResult.point.x, transform.position.y, hitResult.point.z) - transform.position;
                var bullet = Instantiate(bulletPrefab, transform.position + direction.normalized, Quaternion.identity).GetComponent<Bullet>();
                bullet.Shoot(direction.normalized);
            }
        }
    }
}
