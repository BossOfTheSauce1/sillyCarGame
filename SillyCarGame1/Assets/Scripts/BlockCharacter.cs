using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCharacter : MonoBehaviour
{
    public BoxCollider characterCollider;
    public BoxCollider characterBlockerCollider;


    // Start is called before the first frame update
    void Start()
    {
        Physics.IgnoreCollision(characterCollider, characterBlockerCollider, true);
    }

}
