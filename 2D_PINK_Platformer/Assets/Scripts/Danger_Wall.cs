using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Danger_Wall : MonoBehaviour
{

    [Tooltip("Game units per second")]
    [SerializeField] float scrollRate = 0.2f;
    public PlayerMovement player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
    }
    void Update()
    {
        float xMove = scrollRate * Time.deltaTime;
        transform.Translate(new Vector2( xMove, 0f));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.Death();
        }
    }
}