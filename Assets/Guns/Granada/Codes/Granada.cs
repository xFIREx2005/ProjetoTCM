using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Granada : MonoBehaviour
{
    float timer;
    public GameObject colGranada;

    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * Time.deltaTime * 6);

        timer += 1 * Time.deltaTime;
        if (timer >= 0.5f)
        {
            Instantiate(colGranada, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
