using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public GameObject character;
    Vector3 posOffset = new Vector3(2, 1.5f, -4);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, character.transform.position + posOffset, 0.5f);
    }
}
