using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    public GameObject slicedFruitPrefab;

    public void CreateSlicedFruit()
    {
        var obj = Instantiate(slicedFruitPrefab, transform.position, transform.rotation);
        Rigidbody[] slices = obj.transform.GetComponentsInChildren<Rigidbody>();

        foreach(Rigidbody r in slices)
        {
            r.transform.rotation = Random.rotation;
            r.AddExplosionForce(Random.Range(500, 10000), transform.position, 5f);
        }

        FindObjectOfType<GameManager>().IncreaseScore();

        Destroy(gameObject);
        Destroy(obj, 5);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        blade b = collision.GetComponent<blade>();
        if (b)
        {
            CreateSlicedFruit();
        }
    }
}
