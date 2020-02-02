using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public GameObject heart, heart1, heart2, gameOver, restartBtn, exitBtn;
    public static int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        heart.gameObject.SetActive(true);
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        gameOver.gameObject.SetActive(false);
        restartBtn.gameObject.SetActive(false);
        exitBtn.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {


        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                heart.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                break;
            case 2:
                heart.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                break;
            case 1:
                heart.gameObject.SetActive(true);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                break;
            case 0:
                heart.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                gameOver.gameObject.SetActive(true);
                restartBtn.gameObject.SetActive(true);
                exitBtn.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;

        }
    }
}
