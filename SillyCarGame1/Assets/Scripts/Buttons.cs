using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public AudioClip Vroom;
    public AudioSource audioSource;
    public GameObject loadingscreen;
    public Animator carAnimation;
    public CanvasGroup canvasGroup;
    private bool waiting;
   
    string sceneName;
    // Start is called before the first frame update
    void Start()
    {
        loadingscreen.SetActive(false);
        waiting = false;
        
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Loading()
    {
        waiting = true;
        canvasGroup.alpha = 0;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("CannonTutorial");
    }

    IEnumerator Loading2()
    {
        waiting = true;
        canvasGroup.alpha = 0;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("FlyingTutorial");
    }

    IEnumerator Loading3()
    {
        waiting = true;
        canvasGroup.alpha = 0;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("ParkingTutorial");
    }

    IEnumerator Loading4()
    {
        waiting = true;
        canvasGroup.alpha = 0;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("CopTutorial");
    }

    public void CannonCars()
    {
        loadingscreen.SetActive(true);
        if (sceneName == "Main Menu")
        {
            StartCoroutine(Loading());
        }
        else
        {
            SceneManager.LoadScene("ShootGame");
        }

    }

    public void SoaringSedans()
    {
        loadingscreen.SetActive(true);

        if (sceneName == "Main Menu")
        {
            StartCoroutine(Loading2());
        }
        else
        {
            SceneManager.LoadScene("FlyingMini");
        }

    }

    public void PerilousParking()
    {
        loadingscreen.SetActive(true);

        if(sceneName == "Main Menu")
        {
            StartCoroutine(Loading3());
        }
        else
        {
            SceneManager.LoadScene("ParkingGame");
        }
        
    }

    public void SnaringSUVS()
    {
        loadingscreen.SetActive(true);
        if (sceneName == "Main Menu")
        {
            StartCoroutine(Loading4());
        }
        else
        {
            SceneManager.LoadScene("CrazyTaxi");
        }

    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

    public void vroom()
    {
        audioSource.PlayOneShot(Vroom, 1.0f);
    }
}
