using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{

    public GameObject gameOverText, restartBtn;
    // Start is called before the first frame update

    void Start()
    {
        gameOverText.SetActive(false);
        restartBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Enemy"))
        {
            gameOverText.SetActive(true);
            restartBtn.SetActive(true);
        }
    }
}