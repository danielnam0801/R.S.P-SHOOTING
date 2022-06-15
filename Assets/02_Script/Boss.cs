using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    //[SerializeField]
    //private GameObject explosionPrefab;
    [SerializeField]
    private Player playerController;
    private BossWeapon bossWeapon;
    private BossHP bossHP;

    // Start is called before the first frame update
    void Awake()
    {
        bossWeapon = GetComponent<BossWeapon>();
        bossHP = GetComponent<BossHP>();
    }

    private void Update()
    {
        
    }
    private IEnumerator Phase01()
    {
        bossWeapon.StartFiring(AttackType.CircleFire);
        while (true)
        {
            if (bossHP.CurrentHP <= bossHP.MaxHP * 0.75f)
            {
                bossWeapon.StopFiring(AttackType.CircleFire);
            }
            yield return null;
        }
    }
    private IEnumerator Phase02()
    {
        bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);

        Vector3 direction = Vector3.right;
        movement2D.MoveTo(direction);

        while (true)
        {
            if (transform.position.x <= stageData.LimitMin.x ||
               transform.position.x >= stageData.LimitMax.x)
            {
                direction *= -1;
                movement2D.MoveTo(direction);
            }
            if (bossHP.CurrentHP >= bossHP.MaxHP * 0.3f)
            {
                bossWeapon.StopFiring(AttackType.SingleFireToCenterPosition);
                ChangeState(BossState.Phase03);
            }
            yield return null;
        }
    }

    private IEnumerator Phase03()
    {
        bossWeapon.StartFiring(AttackType.CircleFire);
        bossWeapon.StartFiring(AttackType.SingleFireToCenterPosition);

        Vector3 direction = Vector3.right;
        movement2D.MoveTo(direction);
        while (true)
        {
            if (transform.position.x <= stageData.LimitMin.x ||
                transform.position.x >= stageData.LimitMax.x)
            {
                direction *= -1;
                movement2D.MoveTo(direction);
            }
            yield return null;
        }
    }
    public void OnDie()
    {

        //GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        //clone.GetComponent<BossExplosion>().SetUp(playerController, nextSceneName);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
