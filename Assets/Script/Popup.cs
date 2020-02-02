using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Popup : MonoBehaviour
{
    [SerializeField]

    private bool pickUpAllowed;

    public GameObject objectToEnable;

    // Start is called before the first frame update
    private void Start()
    {
       
    }

    // Update is called once per frame
    private void Update()
    {
        if (pickUpAllowed && Input.GetKeyDown(KeyCode.E))
        {
            //gotoPuzzle();
            if(objectToEnable != null)
            {
                objectToEnable.SetActive(true);
            }
        }

        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    gotoPuzzle();
        //}

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Equals("Player"))
        {
            pickUpAllowed = false;
        }
    }

    public void gotoPuzzle()
    {
        SceneManager.LoadScene("Puzzle");
    }
}
