using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruc : MonoBehaviour
{
    public Transform spawnpoint;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            //Debug.Log("destruc");
            //Destroy(collision.gameObject);
            Respawn();
        }
    }

    public void Respawn()
    {
        Debug.Log("...");
        this.transform.position = spawnpoint.position;

    }
}
