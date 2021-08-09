using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject ball;
    public GameObject player1Paddle;

    public GameObject player1Goal;
    public GameObject player2Paddle;
    public GameObject player2Goal;
    public GameObject player1Text;
    public GameObject player2Text;

    private int Player1Score;

    private int Player2Score;

    public void Player1Scored()
    {
        Player1Score++;
        player1Text.GetComponent<TextMeshProUGUI>().text = Player1Score.ToString();
        ResetPosition();
    }public void Player2Scored()
    {
        Player2Score++;
        player2Text.GetComponent<TextMeshProUGUI>().text = Player2Score.ToString();
        ResetPosition();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ResetPosition()
    {
        ball.GetComponent<Ball>().Reset();
        player1Paddle.GetComponent<Paddle>().Reset();
        player2Paddle.GetComponent<Paddle>().Reset();
    }
}


