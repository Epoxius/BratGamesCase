using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyCarManager : MonoBehaviour
{
    public List<GameObject> enemyCar = new List<GameObject>();
    public List<Transform> spawnPoints = new List<Transform>();
    public int speed;

    public void Start()
    {
        StartCoroutine(nameof(EnemyCarRoutine));
    }

    public void Update()
    {
    }

    public void EnemyInstantiate()
    {
        var enemyType = Random.Range(0, enemyCar.Count);
        var randomPoint = Random.Range(0, spawnPoints.Count);
        var position = GameManager.Instance.playerTransform.position;

        Instantiate(enemyCar[enemyType], spawnPoints[randomPoint].transform.position,
            new Quaternion(0, -GameManager.Instance.playerTransform.eulerAngles.y, 0, 0));
    }

    public IEnumerator EnemyCarRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            EnemyInstantiate();
        }
    }
}