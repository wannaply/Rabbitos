using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPoint : MonoBehaviour
{
    private Vector3 offset = new Vector3(0, 1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 0.3f);
        transform.localPosition += offset;
        transform.Rotate(0, 42, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
