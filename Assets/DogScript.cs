using UnityEngine;

public class DogScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource flySound;
    private float topLimit;
    private float bottomLimit;
    private Animator anim;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();

        topLimit = Camera.main.orthographicSize;
        bottomLimit = -Camera.main.orthographicSize;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive) // if space has been press
        {
            flySound.Play();
            // Vector2 = (x,y) magnitude = direction + amount
            // x=0, no horizontal movement (left/right)
            // y=flapStrength, currently set to 10 (up/down)
            // Vector3 = 3D
            myRigidbody.linearVelocity = new Vector2(0, flapStrength);
            //myRigidbody.linearVelocity = Vector2.up * flapStrength;
            anim.Play("Squish", -1, 0f);
        }

        if (transform.position.y > topLimit || transform.position.y < bottomLimit)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    // collision occurs, trigger game over script
    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }
}
