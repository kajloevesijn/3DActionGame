﻿using UnityEngine;
using System.Collections;

public class SpawnSystem : MonoBehaviour {
	[SerializeField]private GameObject _enemy;
	[SerializeField]private GameObject _player;
	[SerializeField]private float _spawnDelay;
	[SerializeField]private float _minSpawnDistance;

	private float _spawnArea = 31;
	void Start(){
		StartCoroutine(SpawnEnemy());
	}

	//Private Functions
	private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            //wait for new spawn
			Vector3 playerPos = _player.transform.position;
			Vector3 spawnPos = RandomWorldPoint();
			float distance = Vector3.Distance(playerPos,spawnPos);

			while(_minSpawnDistance >= distance){
				spawnPos = RandomWorldPoint();
			}

			GameObject enemyClone = (GameObject)Instantiate(_enemy, spawnPos, Quaternion.identity);
            yield return new WaitForSeconds(_spawnDelay);
        }
    }

	private Vector3 RandomWorldPoint(){
		Vector3 randomWorldPoint;
		randomWorldPoint.x = Random.Range (-_spawnArea, _spawnArea);
		randomWorldPoint.y = 1f;
		randomWorldPoint.z = Random.Range (-_spawnArea, _spawnArea);
		return randomWorldPoint;
	}
	
	//Public Functions
}