using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LontraAttack : MonoBehaviour
{
    Enemy enemy = new Enemy(0, 0, 0, 0, 0, 0, 3, false, 1f);
    public GameObject colAttack;
    public Transform spawnAttack, m_PositionPlayer;
    float time;

    void Start()
    {
        m_PositionPlayer = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        
             
    }
    

    void Shoot()
    {
            Instantiate(colAttack, spawnAttack.position, transform.rotation); 
    }
   
}
