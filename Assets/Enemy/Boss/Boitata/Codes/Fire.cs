using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public Animator animFire;
    public float velAnimFire;
    float timer;
    // Start is called before the first frame update
    void Start()
    {
        animFire = GetComponent<Animator>();

        velAnimFire = Random.Range(0.5f, 2);
        animFire.speed = velAnimFire;
        

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer >= 3)
        {
            Destroy(gameObject);
        }
    }
}
