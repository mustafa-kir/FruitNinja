using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjects : MonoBehaviour
{
    private GameObject[] objects;
    public float left;
    public float right;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnRandomObject());
        objects = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            objects[i] = transform.GetChild(i).gameObject;
        }
    }
   

    private IEnumerator SpawnRandomObject()
    {
        yield return new WaitForSeconds(1);
        while (FindObjectOfType<gameManager>().gameIsOver == false)
        {
            InstantiateRandomObject();
            yield return new WaitForSeconds(RandomRepeatrate());
        }
    }
  private void InstantiateRandomObject()
    {
        GameObject obj = GetInactiveObject();

        if (obj != null)
        {
            obj.SetActive(true);
            Rigidbody rb = obj.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            if (rb != null)
            {
                rb.AddForce(RandomVector() * RandomForce(), ForceMode.Impulse);
            }
            obj.transform.rotation = Quaternion.identity;
        }
    }

    private GameObject GetInactiveObject()
    {
        List<GameObject> inactiveObjects = new List<GameObject>();
        foreach (GameObject obj in objects)
        {
            if (!obj.activeSelf)
            {
                inactiveObjects.Add(obj);
            }
        }
        if (inactiveObjects.Count > 0)
        {
            int randomIndex = Random.Range(0, inactiveObjects.Count);
            return inactiveObjects[randomIndex];
        }
        return null;
    }

    private float RandomForce()
    {
        float force = Random.Range(14f, 16f);
        return force;


    }
    private float RandomRepeatrate()
    {
        float repeatrate = Random.Range(0.5f, 3f);
        return repeatrate;
    }
    private Vector2 RandomVector()
    {
        Vector2 moveDirection = new Vector2(Random.Range(left, right), 1).normalized;
        return moveDirection;
    }
}
