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

    // Start is called before the first frame update
    void Start()
    {
        loadingscreen.SetActive(false);
        waiting = false;
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
        StartCoroutine(Loading());
    }

    public void SoaringSedans()
    {
        loadingscreen.SetActive(true);
        StartCoroutine(Loading2());
    }

    public void PerilousParking()
    {
        loadingscreen.SetActive(true);
        StartCoroutine(Loading3());
    }

    public void SnaringSUVS()
    {
        loadingscreen.SetActive(true);
        StartCoroutine(Loading4());
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
