using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrimOnRoads : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y <= -1)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == ("Boundary"))
        {
            Destroy(gameObject);
        }
    }

}
