using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public LogicScript logic; // cant drag other script so do this

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3) // dog layer
        {
            logic.addScore(1);
        }
    }
}
