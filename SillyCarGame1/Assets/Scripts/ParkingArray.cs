using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ParkingArray : MonoBehaviour
{
    public GameObject[] Spots;
    public GameObject[] Cars;
    public GameObject CurrentSpot;
    public GameObject CurrentCar;
    public AudioSource audioSource;
    public AudioClip Score;
    public AudioClip Doink;
    public int score = 0;
    public int insurancefund = 3000;
    int index;
    int index2;
    public TextMeshProUGUI Scoretext;

    // Start is called before the first frame update
    void Start()
    {
        CallSpot();
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Spots Parked " + score;

        if (score == 10)
        {
            StartCoroutine(Win());
        }
    }

    public void CallSpot()
    {
        index = Random.Range(0, Spots.Length);
        index2 = Random.Range(0, Cars.Length);
        CurrentSpot = Spots[index];
        CurrentSpot.SetActive(true);
        CurrentCar = Cars[index2];
        if(CurrentSpot == CurrentCar)
        {
            CurrentCar = Cars[index];
        }
        
    }

   public void Park(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Parked");
            score = score + 1;
            StartCoroutine(Reset());

        }

        if (other.gameObject.tag == "Car")
        {
            Debug.Log("Dented");
            insurancefund = insurancefund - 1000;
            audioSource.PlayOneShot(Doink, 1.0f);


        }
    }


    IEnumerator Reset()
    {
        
        audioSource.PlayOneShot(Score, 1.0f);
        yield return new WaitForSeconds(2.0f);
        CurrentSpot.SetActive(false);
        CallSpot();
    }

    IEnumerator Win()
    {
        yield return new WaitForSeconds(5.0f);
        SceneManager.LoadScene("ParkWin");


    }
}
