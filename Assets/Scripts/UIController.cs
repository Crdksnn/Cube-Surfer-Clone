using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public static UIController instance;

    [Header("UI Elements")]
    public Transform diamonIcon;
    public TextMeshProUGUI scoreText;
    public GameObject arrow;
    public GameObject hand;

    [Header("Score")]
    private int currentScore = 0;
    public int score;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }    
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

   public void DisableArrowHand()
    {
        arrow.SetActive(false);
        hand.SetActive(false);
    }

    public void AddScore()
    {
        currentScore += score;
        scoreText.text = currentScore.ToString();
    }

}
