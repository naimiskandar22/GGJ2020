using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WonGame : MonoBehaviour
{
    public static int checkPoint;
    // Start is called before the first frame update
    void Start()
    {
        checkPoint = 0;
    }

    // Update is called once per frame
    void Update()
    {
        switch(checkPoint)
        {
            case 1:
                wrong();
                break;
            case 2:
                won();
                break;
        }
    }

    void wrong()
    {

    }
    void won()
    {

    }
}
