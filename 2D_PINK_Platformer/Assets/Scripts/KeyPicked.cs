using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPicked : MonoBehaviour
{
    //bool isKeyCollected=false;
    [SerializeField] GameObject doorRed;
    [SerializeField] GameObject doorGreen;
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("KeyPick");
            doorRed.SetActive(false);
            doorGreen.SetActive(true);
            Destroy(gameObject);
        }
    }

}
