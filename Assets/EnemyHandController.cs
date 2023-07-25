using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandController : MonoBehaviour
{

    public Animator animator;

    public int turnOrder;
    public bool started;


    void Start()
    {
        //animator.SetBool("started", false);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (animator.GetBool("started") && animator.GetInteger("turnOrder") != 2)
        {
            
            while(animator.GetInteger("turnOrder") != 2)
            {
                
                
            }
            
            
        }
        else
        {
            
        }
        
    }
}
