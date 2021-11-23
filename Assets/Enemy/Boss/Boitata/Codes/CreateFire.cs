using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateFire : MonoBehaviour
{
    public GameObject fire;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.003f,0.003f,0);
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            Instantiate(fire, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
