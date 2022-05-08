using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange2 : MonoBehaviour
{
    public TargetEnemy enemy;
    public GameObject enemyPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void CreateEnemy()
    {
        StartCoroutine(CreateEnemyIE());
    }
    
    private IEnumerator CreateEnemyIE()
    {
        yield return new WaitForSeconds(5f);
        var tmp=Instantiate(enemyPrefab,transform);
        enemy = tmp.GetComponent<TargetEnemy>();
        enemy.hitEvent.AddListener(CreateEnemy);
    }
}
