using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFire : MonoBehaviour
{
    public GameObject fire, boitata;
    public Animator animBoi;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
        boitata = GameObject.Find("Boitatao");
        animBoi = boitata.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!boitata) Destroy(gameObject);

        if(transform.localScale.x >= 2)transform.localScale += new Vector3(0.006f,0.006f,0);
        timer += Time.deltaTime;
        if (timer >= 1.2f)
        {
            animBoi.speed = 1;
            Instantiate(fire, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
