using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
  private GameObject player;
  private Rigidbody2D rb; 
  private float timer;
  public float force;
  

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        Vector3 direction = player.transform.position - transform.position;

        //rotate toward player
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        direction.Normalize();
        transform.rotation = Quaternion.Euler(0, 0, angle - 90); //rotate

        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 10) 
        {
          Destroy(gameObject); // bullets delete themselves after 10 seconds
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
      if (other.gameObject.CompareTag("Player"))
      {
        Destroy(gameObject); // bullets delete themselves after hitting player
      }
    }
}
