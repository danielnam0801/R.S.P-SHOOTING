using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public float enemyDuration2 = 5f;

    [SerializeField]
    private StageData stageData;
    
    //[SerializeField]
    //private GameObject enemyHpSliderPrefab;
    //[SerializeField]
    //private Transform canvastransform;
    //[SerializeField]
    //private BGMController bgmController;
    //[SerializeField]
    //private GameObject textBossWarning;
    [SerializeField]
    private GameObject boss;
    //[SerializeField]
    //private GameObject panelBossHP;



    // Start is called before the first frame update
    private void Awake()
    {
        boss.SetActive(false);
        //textBossWarning.SetActive(false);
        //panelBossHP.SetActive(false);
        //maxEnemyCount = 10;

    }

    //private void SpawnEnemyHpSlider(GameObject enemy)
    //{
    //    GameObject sliderClone = Instantiate(enemyHpSliderPrefab);
    //    sliderClone.transform.SetParent(canvastransform);
    //    sliderClone.transform.localScale = Vector3.one;
    //    sliderClone.GetComponent<SliderPosition>().Setup(enemy.transform);
    //    sliderClone.GetComponent<EnemyHPViewer>().Setup(enemy.GetComponent<EnemyHp>());
    //}

    private IEnumerator SpawnBoss()
    {
        //bgmController.ChangeBGM(BGMType.Boss);
        //textBossWarning.SetActive(true);
        //textBossWarning.GetComponent<TextMoving>().ChangeState(TextState.MoveToAppearPoint);
        yield return new WaitForSeconds(1.0f);
        //textBossWarning.SetActive(false);
        //panelBossHP.SetActive(true);
        boss.SetActive(true);
        boss.GetComponent<Boss>().ChangeState(BossState.MoveToAppearPoint);

    }



}