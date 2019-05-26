using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject carrot;
    Vector3 lastpos;
    float size;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;

        for (int i = 0; i < 20; i++)
        {
            SpawnRandom();
        }

        

    }

    // Update is called once per frame
    void Update()
    {

        
    }

    public void SpawnRandom()
    {
        int rand = Random.Range(0, 6);
        if (rand < 3)
        {
            SpawnX();
        }
        else if(rand >= 3)
        {
            SpawnZ();
        }
    }

    public void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);

        int rando = Random.Range(0, 4);
        if (rando < 1)
        {
            Instantiate(carrot, new Vector3(pos.x, pos.y + 1, pos.z), Quaternion.identity);
        }

    }
    public void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);
        int rando = Random.Range(0, 4);
        if (rando < 1)
        {
            Instantiate(carrot, new Vector3(pos.x, pos.y + 1, pos.z), Quaternion.identity);
        }
    }
}
