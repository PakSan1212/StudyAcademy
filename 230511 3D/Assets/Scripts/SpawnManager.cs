using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public Transform[] points;

    public GameObject monsterPrefab;

    public float creatTime;
    public int MaxMonster = 10;
    public bool isGameOver;
   
    void Start()
    {
        points = GameObject.Find("SpawnPoint").GetComponentsInChildren<Transform>();

        if(points.Length > 0)
        {
            StartCoroutine(this.CreateMonster());
        }     
    }

    IEnumerator CreateMonster()
    {
        while (!isGameOver)
        {
            int monsterCount = (int)GameObject.FindGameObjectsWithTag("MONSTER").Length;
            if (monsterCount < MaxMonster)
            {
                yield return new WaitForSeconds(creatTime);
                int index = Random.Range(1, points.Length);

                Instantiate(monsterPrefab, points[index].position, points[index].rotation);
            }
            else
            {
                yield return null;
            }
        }
        
    }

    void Update()
    {
        
    }
}
