using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySwordAttack : MonoBehaviour
{
    float timeDestroy = 0f;
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("SpawnAttack").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position;
        transform.rotation = target.rotation;

        timeDestroy += 1 * Time.deltaTime;
        if (timeDestroy >= 0.2f) 
        {
            Destroy(gameObject);
        }

    }
}
