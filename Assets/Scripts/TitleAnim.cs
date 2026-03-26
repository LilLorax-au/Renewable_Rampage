using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TitleAnim : MonoBehaviour
{
    public GameObject parent;
    public float frequency = 1.0f;
    public float magnitude = 1.0f;
    public float elapsedTime = 0f;
    public float speed = 0.5f;
    public float offsetDistance;


    private Vector3 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (parent != null)
        {
            Vector3 offset = new Vector3(0, offsetDistance, 0);
            elapsedTime += Time.deltaTime;
            transform.position = pos + (transform.up * Mathf.Sin(elapsedTime * frequency) * magnitude) + parent.transform.position + offset;
            //transform.position += Vector3.left * speed * Time.deltaTime;
        }
    }
}
