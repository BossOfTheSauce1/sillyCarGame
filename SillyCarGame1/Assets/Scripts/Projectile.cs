using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Projectile : MonoBehaviour
{
    public GameObject projectile;
    public AudioSource audioSource;
    public float launchVelocity;
    public Slider CooldownSlider;
    bool cantShoot;
    public AudioClip shoot;
    public float ShootCD = 3.0f;
    public float shootCdCurrent = 0.0f;
    public TextMeshProUGUI Reloading;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    IEnumerator Shoot()
    {
        audioSource.PlayOneShot(shoot);
        yield return new WaitForSeconds(3);
        cantShoot = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (shootCdCurrent >= ShootCD)
        {
            cantShoot = false;
            Reloading.enabled = false;
        }
        else
        {
            shootCdCurrent = shootCdCurrent + Time.deltaTime;
            cantShoot = true;
            Reloading.enabled = true;
        }

        CooldownSlider.value = shootCdCurrent / ShootCD;


        if (Input.GetKeyDown(KeyCode.Space) && cantShoot == false)
        {
            GameObject ball = Instantiate(projectile, transform.position, transform.rotation);

            ball.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, launchVelocity, 0));
            shootCdCurrent = 0.0f;
            
            StartCoroutine(Shoot());

        }

        

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("AGH");

    }





}
