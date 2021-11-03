using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StepController : MonoBehaviour
{ 
     [SerializeField] private float stepMaxSize = 20f, stepMinSize = 10f, stepScaleY = 1f, stepScaleZ = 5f;
     private float stepPositionZ = -2.4f;
     public float stepHeight;
     private GameObject playerObj;

    // Start is called before the first frame update
    // the function disable step collider
    void Start()
    {
        playerObj = GameObject.Find("Player");   
        addStep();
    }

    // the function change step size and position
     void addStep() 
     {
        transform.localScale = new Vector3(Random.Range(stepMinSize, stepMaxSize), stepScaleY, stepScaleZ);
        float stepPosition = (50 - transform.localScale.x) / 2;
        transform.position = new Vector3(Random.Range(-stepPosition,stepPosition), stepHeight, stepPositionZ);
     }

     // Update is called once per frame
     // the function check if the player is higher from the step, if is, return the collider of the step
    void Update()
    {
        if(transform.position.y < playerObj.transform.position.y)
        {
             GetComponent<Collider>().enabled = true;
        }
        else
        {
            GetComponent<Collider>().enabled = false;
        }
    }

    // the function destroyed the step when the step touch the destructor element
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag == "destructor")
        {
            Destroy(gameObject);
        }
    }
}
