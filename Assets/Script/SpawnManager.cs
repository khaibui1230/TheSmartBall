using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject enemyBigPrefab;
    public GameObject powerUpPrefab;
    public GameObject powerUpRocketPrefab;
    public GameObject rocketPrefab;

    //public Transform target;
    public int enemyCount;
    private float destroyCount = 0;
    private float spawnRange = 9;
    public int wakeNumber = 1;
    private int powerUpRocket = 0;

    //private Vector3 rocketSpeed =;

    // Start is called before the first frame update
    void Start()
    {
        SpawEnemyWave(wakeNumber);
        //khoi tao doi tuong ngay khi bat dau
        Instantiate(powerUpPrefab, RandomSpawnPoisition(), powerUpPrefab.transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            wakeNumber++;
            SpawEnemyWave(wakeNumber); // neeus khong co enemy thi se tao ra mot quai vat moi

            //khoi tao ra mot doi tuong sence trong powerUpPrefab
            Instantiate(powerUpPrefab, RandomSpawnPoisition(), powerUpPrefab.transform.rotation);
            powerUpRocket++;
            // neu ma nguoi choi chien thang 3 powerup thi se xuat hien powerup_rocket
            if (powerUpRocket > 0)
            {
                // khoi tao mot doi tuong sence trong poweruprocket
                shootRocket();
                resetPowerUpRocket();
            }

        }

    }

    private void shootRocket()
    {
        //GameObject rocket =Instantiate(powerUpRocketPrefab, RandomSpawnPoisition(), powerUpRocketPrefab.transform.rotation);
        //Rigidbody rocketRb = rocket.GetComponent<Rigidbody>();
        //rocketRb.velocity = rocket.transform.forward * rocketSpeed;

        // gan gia tri mang cac doi tuong co ten Enemy trong hinh vao mot mang
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            // gan gia tri closetEnemy =  mull
            GameObject closetEnemy = null;
            float closetDistance = Mathf.Infinity;  // gan losetDistance gia tri la duong vo cung
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector3.Distance(transform.position, enemy.transform.position);
                if (distance < closetDistance)
                {
                    closetDistance = distance;
                    closetEnemy = enemy;
                }
            }
            if (closetEnemy != null)
            {
                GameObject rocket = Instantiate(rocketPrefab, transform.position, transform.rotation);
                //Rocket rocketScript = rocket.GetComponent<Rocket>();
                //rocketScript.SetTarget(closetEnemy.transform);
            }


        }

    }

    private void resetPowerUpRocket()
    {
        powerUpRocket = 0;
    }

    void SpawEnemyWave(int enemyToSpawn)
    {
        if (destroyCount == 3)
        {
            bigEnemmy();
        }
        else
        {
            for (int i = 0; i < enemyToSpawn; i++)
            {

                Instantiate(enemyPrefab, RandomSpawnPoisition(), enemyPrefab.transform.rotation);
                destroyCount++;
            }
        }
    }

    private void bigEnemmy()
    {
        Instantiate(enemyBigPrefab, RandomSpawnPoisition(), enemyBigPrefab.transform.rotation);
    }

    private Vector3 RandomSpawnPoisition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnRandom = new Vector3(spawnPosX, 0, spawPosZ);
        return spawnRandom;
    }
}
