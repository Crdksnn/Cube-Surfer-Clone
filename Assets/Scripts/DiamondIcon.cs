using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondIcon : MonoBehaviour
{
    Transform diamondUI;
    UIController uiController;
    public float speed;

    void Start()
    {
        uiController = UIController.instance;
        diamondUI = uiController.diamonIcon;
        uiController.AddScore();
    }

    void Update()
    {

        if(transform.position != diamondUI.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, diamondUI.transform.position, speed);
        }

        else
        {
            Destroy(gameObject);
        }

    }
}
