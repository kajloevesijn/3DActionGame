using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject enemyUnit;
    public GameObject _playerPos;

    //private float _minimalRadius;
    //private float _maximalRadius;
    private float _spawnRadius;

    private float _spawnDelay;


    // Use this for initialization
    void Start ()
    {
        _spawnDelay = 2;
        _spawnRadius = 10;

        StartCoroutine(SpawnEnemy());
	}
	
    IEnumerator SpawnEnemy()
    {
        //let it loop
        while (true)
        {
            //COULD
            //make random radius calculation
            //_spawndomSRadius = RanpawnRadius();

            //getting the center of the playerposition
            Vector3 center = _playerPos.transform.position;

            Vector3 spawnPos = CreateRandonSpawnPoint(center, _spawnRadius);

            //picks random spawnpoint and instantiate
            GameObject enemyClone = (GameObject)Instantiate(enemyUnit, spawnPos, Quaternion.identity);

            //COULD
            //change spawndelay value for increased difficulty

            //wait for new spawn
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    Vector3 CreateRandonSpawnPoint(Vector3 centerPos, float radius)
    {
        float angle = Random.value * 360;

        Vector3 randomPos;

        //calculating randomPos
        randomPos.x = centerPos.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
        randomPos.y = centerPos.y;
        randomPos.z = centerPos.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);

        return randomPos;
    }

    /*float RandomSpawnRadius()
    {
        float value = Random.value * _maximalRadius - _minimalRadius;
    }*/
}
