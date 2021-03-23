using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRb;
    public float minSpeed = 12;
    public float maxSpeed = 16;
    public float maxTorque = 10;
    public float xRange = 4;
    public float ySpawnPos = -5;
    public int pointValue = 5;
    public ParticleSystem explosionParticle;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        targetRb = gameObject.GetComponent<Rigidbody>();
        transform.position = GetRandomPos();

        targetRb.AddForce(GetRandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(GetRandomTorque(), ForceMode.Impulse);
    }

    private Vector3 GetRandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    private Vector3 GetRandomTorque()
    {
        return Vector3.one * Random.Range(-maxSpeed, maxSpeed);
    }

    private void OnMouseDown()
    {
        if (gameManager.isGameActive)
        {
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }

    private Vector3 GetRandomPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
