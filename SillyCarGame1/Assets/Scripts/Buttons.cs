using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public GameObject loadingscreen;
    public Animator carAnimation;
    public GameObject canvas;

    // Start is called before the first frame update
    void Start()
    {
        loadingscreen.SetActive(false);
    }

    IEnumerator Loading2()
    {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("FlyingTutorial");
    }


    // Update is called once per frame
    void Update()
    {
        
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
}
