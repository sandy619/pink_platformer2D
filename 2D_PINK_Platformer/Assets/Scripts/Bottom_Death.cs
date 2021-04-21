using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom_Death : MonoBehaviour
{

    public PlayerMovement player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Death();
        }
    }
}
