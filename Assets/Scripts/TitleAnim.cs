using UnityEngine;

public class TitleAnim : MonoBehaviour
{
    public float frequency = 1.0f;
    public float magnitude = 1.0f;
    public float elapsedTime = 0f;
    public float speed = 0.5f;


    private Vector3 pos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        transform.position = pos + (transform.up * Mathf.Sin(elapsedTime * frequency) * magnitude);
        //transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
