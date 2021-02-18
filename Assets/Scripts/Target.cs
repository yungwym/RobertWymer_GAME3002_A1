using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMoveUp()
    {
        this.transform.Translate(Vector3.back * 5.0f * Time.deltaTime);
    }

    public void OnMoveDown()
    {
        this.transform.Translate(Vector3.forward * 5.0f * Time.deltaTime);
    }

    public void OnMoveLeft()
    {
        this.transform.Translate(Vector3.left * 5.0f * Time.deltaTime);
    }

    public void OnMoveRight()
    {
        this.transform.Translate(Vector3.right * 5.0f * Time.deltaTime);
    }

    public void OnReset()
    {
        this.enabled = true;
    }


    public void OnTriggerEnter(Collider other)
    {
        this.enabled = false;
    }
}
