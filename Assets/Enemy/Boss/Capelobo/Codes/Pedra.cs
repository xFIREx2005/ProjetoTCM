using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedra : MonoBehaviour
{
    float timer;
    public GameObject colPedra;
    Animator animPedra;
    private bool impacto;

    void Start()
    {
        impacto = false;
        animPedra = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
        timer += Time.deltaTime;
        if(impacto == false)
        if(timer >= 0.8f)
        {
            Instantiate(colPedra, transform.position, transform.rotation);
            animPedra.SetBool("Impacto", true);
            impacto = true;
        }else transform.position -= new Vector3(0, 0.01f, 0);
    }
    public void PedraStop()
    {
        
        animPedra.speed = 0;
        StartCoroutine(PedraDestroy());
    }

    IEnumerator PedraDestroy()
    {
        yield return new WaitForSeconds(0.8f);
        Destroy(gameObject);
    }
}
