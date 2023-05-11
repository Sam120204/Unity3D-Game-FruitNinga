using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blade : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var mousepos = Input.mousePosition;
        mousepos.z = 10;
        rb.position = Camera.main.ScreenToWorldPoint(mousepos);
    }
}
