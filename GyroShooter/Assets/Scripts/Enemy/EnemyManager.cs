using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
	[SerializeField]
	GameObject enemysParent;
	[SerializeField]
	GameObject enemy;

	ObjectPool enemyPool;
	GameObject[] enemys;
	[SerializeField]
    int poolNum;

	GameObject instanceEnemy;

	[SerializeField]
	float createFrequency;
	private float timeElapsed;

	private bool create = false;

	[SerializeField]
	private ParameterTable_Enemy table = null;

	Vector3 randomSpawnPos;
    
	// Use this for initialization
	void Start()
	{
		enemyPool = new ObjectPool(poolNum, new Vector3(0, 0, 30), new Vector3(1,1,1));
		enemyPool.Pool(enemysParent, enemy, poolNum);
		randomSpawnPos = table.spawnPos;
	}

	// Update is called once per frame
	void Update()
	{
		Frequency();
	}

	private void Frequency()
	{
		timeElapsed += Time.deltaTime;
		if (timeElapsed >= createFrequency)
		{
			CreateEnemy();
			timeElapsed = 0.0f;
		}
	}

    private void CreateEnemy()
	{
		instanceEnemy = enemyPool.Instantiate();
		randomSpawnPos.x = Random.Range(-0.5f, 0.5f);
		randomSpawnPos.y = Random.Range(-0.25f, 0.25f);
		instanceEnemy.transform.position = randomSpawnPos;
		instanceEnemy.transform.localScale = table.scale;
		instanceEnemy.GetComponent<Renderer>().sharedMaterial.color = table.color;
	}
}