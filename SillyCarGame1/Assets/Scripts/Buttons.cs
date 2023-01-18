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

    IEnumerator Loading2()
    {
        waiting = true;
        canvasGroup.alpha = 0;
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("FlyingTutorial");
    }


    public void CannonCars()
    {
        SceneManager.LoadScene("CannonTutorial");
    }

    public void SoaringSedans()
    {
        loadingscreen.SetActive(true);
        StartCoroutine(Loading2());
    }

    public void PerilousParking()
    {
        SceneManager.LoadScene("ParkingTutorial");
    }

    public void SnaringSUVS()
    {
        SceneManager.LoadScene("CopTutorial");
    }

    public void vroom()
    {
        audioSource.PlayOneShot(Vroom, 1.0f);
    }
}
