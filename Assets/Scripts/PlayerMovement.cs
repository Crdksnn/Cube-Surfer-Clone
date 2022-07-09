using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    private Transform m_TransToMove;
    public float speed;
    public float xBorder = 1f;
    private Touch curTouch;
    private Vector3 newPos = Vector3.zero;

    void Start()
    {
        m_TransToMove = GetComponent<Transform>();   
    }
    

    void Update()
    {
        
        Move();

    }

    private void Move()
    {
        if (Input.touchCount > 0)
        {

            curTouch = Input.GetTouch(0);

            if (curTouch.phase == TouchPhase.Moved)
            {
                float newX = curTouch.deltaPosition.x * speed * Time.deltaTime;

                newPos.x += newX;
                newPos.x = Mathf.Clamp(newPos.x, -xBorder, xBorder);
               
            }
        }

        m_TransToMove.DOLocalMoveX(newPos.x, 0);        
    }
  
}
