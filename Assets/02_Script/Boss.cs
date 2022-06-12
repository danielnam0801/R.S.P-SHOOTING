using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum BossState {Phase01, Phase02, Phase03 }

public class Boss : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionPrefab;
    [SerializeField]
    private Player playerController;
    [SerializeField]
    private string nextSceneName;
    [SerializeField]
    private StageData stageData;
    private Movement2D movement2D;
    private BossWeapon bossWeapon;
    private BossHP bossHP;
    [SerializeField]
    int BossSpawnTime = 180;
    float playTime = 0f;

    // Start is called before the first frame update
    void Awake()
    {
        movement2D = GetComponent<Movement2D>();
        bossWeapon = GetComponent<BossWeapon>();
        bossHP = GetComponent<BossHP>();
    }
    private void Update()
    {
        playTime += Time.deltaTime;
    }
    private void LateUpdate()
    {
        int min = (int)(BossSpawnTime - playTime / 60);
        int second = (int)(60 - playTime);
    }



    //public void ChangeState(BossState newState)
    //{
    //    StopCoroutine(bossState.ToString());
    //    bossState = newState;
    //    StartCoroutine(bossState.ToString());
    //}


    private IEnumerator Phase01()
    {
        bossWeapon.StartFiring(AttackType.CircleFire);
        while (true)
        {
            if (bossHP.CurrentHP <= bossHP.MaxHP * 0.75f)
            {
                bossWeapon.StopFiring(AttackType.CircleFire);
                ChangeState(BossState.Phase02);
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

        GameObject clone = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
        clone.GetComponent<BossExplosion>().SetUp(playerController, nextSceneName);
    }
    // Update is called once per frame

}
