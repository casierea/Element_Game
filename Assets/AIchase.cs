using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIchase : MonoBehaviour
{
  public GameObject player;
  public float speed;

  private float distance;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position); // distance to player
        Vector2 direction = player.transform.position - transform.position; // face player

        //rotate toward player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();


        if (distance > 5) 
        {
          transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime); // move toward player
        }
        
        transform.rotation = Quaternion.Euler(Vector3.forward * angle); //rotate
        

    }
}
