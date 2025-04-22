using Unity.VisualScripting;
using UnityEditor.Build.Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.LowLevel;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private int playerHp = 5;
    [SerializeField] private float Speed = 700.0f;
    private const float jumpForce = 7.5f;
    private int timeToWin = 60;
    private bool isOnGround = true;
    private bool isGameRunning = false;
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timeText;
    public Button gameOverButton;
    public Button startGameButton;
    PlayerController Controller;

    public float InputSpeed = 10.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameRunning)
        {
            PlayerMove();
            AntiFall();
            CheckGameOver();
        }

    }

    IEnumerator TimeRemaining()
    {
        if(timeToWin > 0)
        {
            yield return new WaitForSeconds(1);
            timeToWin -= 1;
            timeText.text = "Time Remaining: " + timeToWin;
            StartCoroutine(TimeRemaining());
        }
        else
        {
            StopAllCoroutines();
        }
    }
    public void StartGameSequence()
    {
        Controller = GetComponent<PlayerController>();
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        livesText.text = "Lives: " + playerHp;
        startGameButton.gameObject.SetActive(false);
        isGameRunning = true;
        StartCoroutine(TimeRemaining());
    }

    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Solid")
        {
            isOnGround = true;
        }

        else if (collision.gameObject.tag == "Enemy" && playerHp > 0)
        {
            playerHp -= 1;
            livesText.text = "Lives: " + playerHp;
        }
    }

    //Makes the player object move based on WASD keys and Physics
    void PlayerMove()
    {
        if(Input.GetKey(KeyCode.W))
        {
            playerRb.AddForce(focalPoint.transform.forward * Speed * Time.deltaTime);
            // transform.position += focalPoint.transform.forward * Speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.A))
        {
            playerRb.AddForce(-focalPoint.transform.right * Speed * Time.deltaTime);
            // transform.position += -focalPoint.transform.right * Speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.S))
        {
            playerRb.AddForce(-focalPoint.transform.forward * Speed * Time.deltaTime);
            // transform.position += -focalPoint.transform.forward * Speed * Time.deltaTime;
        }

        if(Input.GetKey(KeyCode.D))
        {
            playerRb.AddForce(focalPoint.transform.right * Speed * Time.deltaTime);
            // transform.position += focalPoint.transform.right * Speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }

        transform.rotation = new Quaternion(0,0,0,0);
    }

    //Respawns the player in case they fall off the map
    void AntiFall()
    {
        if(transform.position.y < 0)
        {
            transform.position = new Vector3(0, 1.59f, -20.17f);
            playerRb.linearVelocity = Vector3.zero;
        }
    }

    //Activates Game Over sequence when the player's HP is 0
    void CheckGameOver()
    {
        if(playerHp <= 0 || timeToWin == 0)
        {
            gameOverText.gameObject.SetActive(true);
            isGameRunning = false;
            gameOverButton.gameObject.SetActive(true);
        } 
    }

    public bool GetStateOfGame() {return isGameRunning;}
}
