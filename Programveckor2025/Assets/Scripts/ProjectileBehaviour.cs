using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    // Start is called before the first frame update

    Rigidbody2D projectilerb;

    public float direction;

    void Start()
    {
        projectilerb = GetComponent<Rigidbody2D>();
        projectilerb.velocity = new Vector2(direction, projectilerb.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
