using UnityEngine;

public class BarrelGeneratorScript : MonoBehaviour
{
    public GameObject barrel;
    public float generationRate = 2;
    public float moveSpeed = 6;
    public int numberGenerated = 0;
    public float heightVariation = 4;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        if (numberGenerated > 5)
        {
            generationRate *= 0.9f;
            LogicScript.moveSpeed *= 1.09f;
            numberGenerated = 0;
        }

        if (timer > generationRate)
        {
            Generate();
            timer = 0;
        }
        else
        {
            timer += Time.deltaTime;
        }
    }

    private void Generate()
    {

        Instantiate(
            barrel, 
            new Vector3(
                transform.position.x, 
                Random.Range(transform.position.y - heightVariation, transform.position.y + heightVariation), 
                transform.position.z
            ), transform.rotation);
        numberGenerated++;
    }
}
