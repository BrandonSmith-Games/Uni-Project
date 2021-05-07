using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentScript : MonoBehaviour
{


    public NavMeshAgent agent;
    public Transform sphere;
    public Transform goal;
    public Transform goal2;

    [SerializeField]
    public bool isSolo;

    public bool hitFirst;
    public bool hitSecond;

    public float distance;
    public float distance2;

    public GameObject destroyableObjects ;
    public GameObject destroyableObjects2 ;


    int index;

    public Vector3 currentPosition;



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    Vector3[] positionArray = new [] 
        { 
            new Vector3(18f,1f,15f),
            new Vector3(23f,1f,12f),
            new Vector3(18f,1f,10f),
            new Vector3(22f,1f,15f),
            new Vector3(23f,1f,10f),
            new Vector3(20f,1f,12f),
            new Vector3(23.74f,2.1f,9.31f),
            new Vector3(22f,1f,15f),
            new Vector3(18.08f,2.1f,11f)            
            
             };

    // Update is called once per frame
    void Update()
    {   
        
        index = Random.Range (0, positionArray.Length);
        currentPosition = positionArray[index];
        
        agent = this.GetComponent<NavMeshAgent>();

        distance = Vector3.Distance(sphere.position, goal.position);   //5
        distance2 = Vector3.Distance(sphere.position, goal2.position);  //4


        if(distance < distance2)
        {
            agent.SetDestination(goal.position);
        }
        else 
        {
            agent.SetDestination(goal2.position);
        }

        if(isSolo){
        if(destroyableObjects.activeSelf == false && destroyableObjects2.activeSelf == false && hitSecond == true)
        {   
            goal.transform.position = currentPosition;
            goal2.transform.position = currentPosition;
            destroyableObjects.SetActive(true);
            destroyableObjects2.SetActive(true);
            Debug.Log("hit first");
           
            
        }
        
        }
        if(distance <= 0.8)
        {
            Debug.Log("test1");
            destroyableObjects.SetActive(false);
            Debug.Log("destroyed1");
        }
        if(distance2 <= 0.8)
        {
            Debug.Log("test2");
            destroyableObjects2.SetActive(false);
            Debug.Log("destroyed2");
        }
        
        if (destroyableObjects.activeSelf == false)
        {
            
            agent.SetDestination(goal2.position);
        }
        else if(destroyableObjects2.activeSelf == false)
        {
            
            agent.SetDestination(goal.position);
        }
        


        
    }
}
