using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitLauncher : MonoBehaviour
{
    public GameObject[] objectsToEmit;
    public float minInterval = 0.3f;
    public float maxInterval = 1f;
    public Transform[] barrels;
    public float MinForce = 10;
    public float MaxFoce = 15;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EmitFruit());
    }
    private IEnumerator EmitFruit()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
            var b = barrels[Random.Range(0, barrels.Length)];

            GameObject fire;
            int p = Random.Range(0, 9);
            if (p < 1)
            {
                fire = objectsToEmit[0];
            } else
            {
                var ranIndex = Random.Range(1, 4);
                fire = objectsToEmit[ranIndex];
            }

            var fruit = Instantiate(fire, b.position, b.rotation);
            fruit.GetComponent<Rigidbody2D>().AddForce(b.transform.up * Random.Range(MinForce, MaxFoce), ForceMode2D.Impulse);
            Debug.Log("Emit Fruit");
            Destroy(fruit, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
