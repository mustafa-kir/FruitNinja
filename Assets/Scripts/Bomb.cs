using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private float rotationForce = 200;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Random.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            FindObjectOfType<gameManager>().GameOver();
        }
    }
}
