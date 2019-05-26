using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    PlatformSpawner spawner;
    // Start is called before the first frame update
    void Awake()
    {
        spawner = GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Rabbit")
        {
            Invoke("FallDown", 0.5f);
            FallDown();
            spawner.SpawnRandom();
            
            
                
        }
    }

    void FallDown()
    {
        GetComponentInParent<Rigidbody>().useGravity = true;
        GetComponentInParent<Rigidbody>().isKinematic = false; 
        Destroy(transform.parent.gameObject, 1f);
        
    }

}
