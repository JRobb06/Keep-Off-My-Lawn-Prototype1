using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidGenerator : MonoBehaviour
{

    public Transform generator;
    public GameObject kid;
    float timer;//Keeps track of time since last generation.
    int nextGen;//Time that needs to elapse until the next kid generation. This is randomly determined.
    int kidLimit;


    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        nextGen = Random.Range(10,20);
        kidLimit = FindObjectOfType<GameManager>().kidLimit;
    }

    // Update is called once per frame
    void Update()
    {
        //The kid generator will generate a new kid object once every 5 to 15 seconds. Once timer reaches nextGen, a new Kid object will be generated.
        int numofKids = FindObjectOfType<GameManager>().NumOfKids;//Increment the number of kids in the game that is kept in Game Manager
        timer += Time.deltaTime;
        //As long as the number of kids in game has not been reached, and time has been reached for another kid object to be generated,
        //generate a new kid object, reset timer, and update the number of kids kept in Game Manager.
        if (timer >= nextGen && numofKids < kidLimit)
        {
            Instantiate(kid, generator.position, Quaternion.identity);
            timer = 0;
            nextGen = Random.Range(5, 15);//Determine a random time for next kid generation, between 5 and 15 seconds.
            FindObjectOfType<GameManager>().NumOfKids++;
        }
    }
}