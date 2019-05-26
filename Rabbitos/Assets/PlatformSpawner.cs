using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawnerr : MonoBehaviour
{
    public GameObject platform;
    Vector3 lastpos;
    float size;
    // Start is called before the first frame update
    void Start()
    {
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < 5; i++) 
        {
            SpawnX();
        }
    }

    void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x += size;
        lastpos = pos;
        Instantiate(platform, pos, Quaternion.identity);

    }
}
