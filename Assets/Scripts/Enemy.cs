using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 1.05f;
    private GameObject player;
    private Rigidbody enemyRb;
    private Rigidbody playerRb;
    private float pushPower = 500f;

    void Start()
    {
        player = GameObject.Find("Player");
        enemyRb = GetComponent<Rigidbody>();
        playerRb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        if (gameObject.CompareTag("Enemy"))
        {
            enemyRb.AddForce(lookDirection);
        }

        if (gameObject.CompareTag("Hard Enemy"))
        {
            enemyRb.AddForce(lookDirection * speed);
        }


        if (gameObject.transform.position.y < -10)
        {
            Destroy(gameObject);
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        Vector3 knockDirection = (collision.gameObject.transform.position - gameObject.transform.position).normalized;
        if ((collision.gameObject.name == "Player") && gameObject.CompareTag("Hard Enemy"))
        {
            Debug.Log("Hard Enemy knocked you hard");
            playerRb.AddForce(knockDirection * pushPower);
        }
    }
}
