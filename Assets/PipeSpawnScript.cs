using UnityEngine;
using static UnityEngine.Rendering.DebugUI.Table;

public class PipeSpawnScript : MonoBehaviour
{

    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 2;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        generatePipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer < spawnRate)
        {
            // timer = timer + Time.deltaTime;
            timer += Time.deltaTime; // count the timer up
        }
        else // spawn then reset
        {
            generatePipe();
            timer = 0;
        }
    }

    void generatePipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;
        // transform.position = where to spawn/generate
        // transform.rotation = how it's rotated
        // transform.position.x = we want same as the spawner
        Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
    }
}
