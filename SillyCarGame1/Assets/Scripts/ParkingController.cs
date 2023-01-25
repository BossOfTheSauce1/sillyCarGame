using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ParkingController : MonoBehaviour
{
    public float speed = 20;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;
    public AudioSource audioSource;
    public TextMeshProUGUI Fundtext;
    public int insurancefund = 3000;
    public AudioClip Doink;
    public bool cooldown = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Fundtext.text = "Insurance Money: $" + insurancefund;

        //left/right and forward/back movement
        horizontalInput = Input.GetAxis("Horizontal");
         forwardInput = Input.GetAxis("Vertical");


            // move the vehicle forward
            transform.Translate(Vector3.left * Time.deltaTime * speed * forwardInput);
            transform.Rotate(Vector3.down, turnSpeed * horizontalInput * Time.deltaTime * forwardInput);
      

        if (insurancefund <= 0)
        {

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Car")
        {
            StartCoroutine(Dent());


        }
    }
    IEnumerator Dent()
    {
        if (cooldown == false)
        {
            Debug.Log("Dented");
            insurancefund = insurancefund - 1000;
            audioSource.PlayOneShot(Doink, 1.0f);
            cooldown = true;
        }
        yield return new WaitForSeconds(1.5f);
        cooldown = false;

    }
}
