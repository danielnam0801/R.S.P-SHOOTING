using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //[SerializeField]
    //private StageData stageData;
    //private Movement movement;
    public GameObject[] weapons;
    Weapon equipWeapon;
    //int equipWeaponIndex = -1;
    bool sDown1;
    bool sDown2;
    bool sDown3;
    bool fireDown;
    bool isFireReady = true;

    float fireDelay;

    //private void Awake()
    //{
    //    movement = GetComponent<Movement>();
    //}
    void Update()
    {
        Swap();
        Attack();
        GetInput();
    }
    void GetInput()
    {
        sDown1 = Input.GetButtonDown("Swap1");
        sDown2 = Input.GetButtonDown("Swap2");
        sDown3 = Input.GetButtonDown("Swap3");
        fireDown = Input.GetButtonDown("Fire1");
    }

    void Swap()
    {
        int weaponIndex = -1;
        if (sDown1) weaponIndex = 0;
        if (sDown2) weaponIndex = 1;
        if (sDown3) weaponIndex = 2;

        if (sDown1 || sDown2 || sDown3)
        {
            if (equipWeapon != null)
                equipWeapon.gameObject.SetActive(false);

            equipWeapon = weapons[weaponIndex].GetComponent<Weapon>();
            equipWeapon.gameObject.SetActive(true);
        }
    }

    void Attack()
    {
        if(equipWeapon == null)
        {
            return; 
        }

        fireDelay += Time.deltaTime;
        isFireReady = equipWeapon.rate < fireDelay;

        if(fireDown && isFireReady)
        {
            equipWeapon.Use();
        }
        fireDelay = 0;
    }

    //void Move()
    //{
    //    float x = Input.GetAxisRaw("Horizontal");
    //    float y = Input.GetAxisRaw("Vertical");

    //    movement.MoveTo(new Vector3 (x, y, 0));
    //}

    

    //private void LateUpdate()
    //{
    //    transform.position = new Vector3(Mathf.Clamp(transform.position.x, stageData.LimitMin.x, stageData.LimitMax.x),
    //                                     Mathf.Clamp(transform.position.y, stageData.LimitMin.y, stageData.LimitMax.y));   
    //}
}
