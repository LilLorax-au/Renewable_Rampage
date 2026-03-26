using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    public float scrollSpeed = -5f;
    public Vector2 startPos;
    public int distance;

    // Start is called before the first frame update
    void Awake()
    {
        startPos = transform.position;
    }

    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Mathf.Repeat(Time.time * scrollSpeed, distance);
        transform.position = startPos + Vector2.left * newPos;
    }
}


