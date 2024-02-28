using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fruits : MonoBehaviour
{
    public GameObject slicedFruit;
    public GameObject FruitJucie;
    private float rotationForce = 200;
    private Rigidbody rb;
    public int scorePoint;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }
    private void InstantiateSlicedFruit()
    {
        GameObject instantiatedFruit = Instantiate(slicedFruit, transform.position, transform.rotation);
        GameObject instantiatedJuice = Instantiate(FruitJucie, new Vector3(transform.position.x, transform.position.y, 0), FruitJucie.transform.rotation);
        Rigidbody[] slicedRb = instantiatedFruit.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody srb in slicedRb)
        {
            srb.AddExplosionForce(130f, transform.position, 10);
            srb.velocity = rb.velocity * 1.2f;
        }
        Destroy(instantiatedFruit, 5);
        Destroy(instantiatedJuice, 5);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Blade")
        {
            gameManager.Instance.UpdateTheScore(scorePoint);
            gameObject.SetActive(false);
            
            InstantiateSlicedFruit();
            gameObject.transform.position = Vector3.zero;
        }
        if (other.tag == "BottomTrigger")
        {
            gameObject.SetActive(false);
            gameManager.Instance.UpdateLives();
            gameObject.transform.localPosition= Vector3.zero;
            gameObject.transform.localRotation = Quaternion.identity;
        }

    }
}
