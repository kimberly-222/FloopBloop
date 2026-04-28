using UnityEngine;

public class PipeMoveScript : MonoBehaviour
{
    public float moveSpeed = 5; // default speed
    public float deadZone = -10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // move the pipe to the left every frame
        // (-5, 0, 0) move left at speed 5
        //transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;
        transform.position += Vector3.left * moveSpeed * Time.deltaTime;
        
        if (transform.position.x < deadZone)
        {
            Debug.Log("Clean");
            Destroy(gameObject);
        }
    }
}
