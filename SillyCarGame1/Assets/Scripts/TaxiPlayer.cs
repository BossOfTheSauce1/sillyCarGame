using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TaxiPlayer : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public int score = 0;
    private int highscore;
    private float time = 60f;
    private float displayTime;
    public float wheelsOnGround;
    private Vector3 resetRot;
    [SerializeField] GameObject gameOver;
    [SerializeField] GameObject gameOn;
    [SerializeField] float speed;
    [SerializeField] float turnSpeed;
    [SerializeField] List<GameObject> wheels;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI finalScoreText;
    [SerializeField] TextMeshProUGUI highScoreText;
    public bool isGameOver;
    public bool isOnGround;
    public AudioClip Capture;
    public AudioClip clock;
    public AudioSource audioSource;
    float audioSlider = 0;
    public Material lights;
    private Color red;
    private Color blue;



    void Start()
    {
        red = new Color(255, 0, 0);
        blue = new Color(0, 0, 255);
        isGameOver = false;
        resetRot = new Vector3(0, gameObject.transform.eulerAngles.y, 0);
        lights.SetColor("_Color", red);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        LoadHighScore();
        SaveHighScore();
        IsGrounded();
        StartCoroutine(Colors());
        if(isGameOver == false && isOnGround)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
            transform.Translate(Vector3.right * Time.deltaTime * speed * -verticalInput);
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);

            scoreText.text = "Score: " + score;
            Timer();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == ("PickUp"))
        {
            score = score + 1;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(Capture, 1.0f);
        }
        if(collision.gameObject.tag == ("Watch"))
        {
            time += 10;
            Destroy(collision.gameObject);
            audioSource.PlayOneShot(clock, 1.0f);
        }
        foreach(GameObject wheel in wheels)
        {
            if(collision.gameObject.tag == ("Ground"))
            {
                wheelsOnGround = wheelsOnGround + 1;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        foreach (GameObject wheel in wheels)
        {
            if (collision.gameObject.tag == ("Ground"))
            {
                wheelsOnGround = wheelsOnGround - 1;
            }
        }
    }

    private void Timer()
    {
        if(time > 0)
        {
            time -= Time.deltaTime;
            displayTime = Mathf.Round(time);
            timeText.text = "Time: " + displayTime;
        }
        else if(displayTime == 0)
        {
            GameOver();
        }
    }

    private void GameOver()
    {
        isGameOver = true;
        gameOn.SetActive(false);
        gameOver.SetActive(true);
        finalScoreText.text = "Final Score: " + score;
        highScoreText.text = "HighScore: " + highscore;
        Debug.Log("Game Over");
        audioSource.volume = audioSlider;
    }

    private void IsGrounded()
    {
        
        if(wheelsOnGround > 4)
        {
            isOnGround = true;
        }
        else if(wheelsOnGround <= 4)
        {
            isOnGround = false;
            if (Input.GetKeyDown(KeyCode.Space))
            {
                gameObject.transform.position = new Vector3(transform.position.x, 6, transform.position.z);
                gameObject.transform.eulerAngles = resetRot;
            }
        }
    }

    IEnumerator Colors()
    {
        if(lights.color == red)
        {
            yield return new WaitForSeconds(1);
            lights.SetColor("_Color", blue);
        }

        else if(lights.color == blue)
        {
            yield return new WaitForSeconds(1);
            lights.SetColor("_Color", red);
        }
    }

    void SaveHighScore()
    {
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("HighScore", highscore);
        }
    }

    void LoadHighScore()
    {
        if (PlayerPrefs.HasKey("HighScore"))
        {
            highscore = PlayerPrefs.GetInt("HighScore");
        }
    }
}
