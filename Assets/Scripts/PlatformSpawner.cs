using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject spawnPlatform;
    public GameObject trap;
    public GameObject coin;
    Vector3 lastPos;
    float size;
    public bool gameOver;
    private PlayerController pc;
    private void Start()
    {
        pc = GameObject.FindObjectOfType<PlayerController>().GetComponent<PlayerController>();
        lastPos = spawnPlatform.transform.position;
        size = spawnPlatform.transform.localScale.x;

        for(int i = 0;i< 20; i++)
        {
            SpawnPlatforms();
        }

        InvokeRepeating("SpawnPlatforms", 2f, 0.2f);
       
       
    }

    private void Update()
    {
        gameOver =pc.gameOver;
        if (gameOver)
        {
            CancelInvoke("SpawnPlatforms");
        }
    }
    void SpawnPlatforms()
    {
        
        int rand = Random.Range(0, 7);
        if(rand <3)
        {
            SpawnX();
        }
        else
        {
            SpawnZ();
        }
    }
    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;
        lastPos = pos;
        Instantiate(spawnPlatform, pos, Quaternion.identity);
        int random = Random.Range(0, 4);
        if(random <1)
        {
            Instantiate(trap, pos + new Vector3(0, -0.5f, 2.5f), coin.transform.rotation);
        }
      

    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;
        lastPos = pos;
        Instantiate(spawnPlatform, pos, Quaternion.identity);
       
        int random = Random.Range(0, 8);
        if (random < 1)
        {
            Instantiate(coin, pos + new Vector3(0,1,0), coin.transform.rotation);
        }

    }

   
}
