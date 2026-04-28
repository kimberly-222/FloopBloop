using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speed = 1f;
    public float leftLimit = -10f;
    public float rightCloudGenerate = 10f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < leftLimit)
        {
            transform.position = new Vector3(rightCloudGenerate, transform.position.y, transform.position.z);
        }
    }
}
