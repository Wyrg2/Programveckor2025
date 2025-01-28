using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Slash_Attack : MonoBehaviour
{
    Knight_Movement_Script KMS;
    private Vector2 myOwnPosition;
    // Start is called before the first frame update
    void Start()
    {
        KMS = FindAnyObjectByType<Knight_Movement_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * KMS.KnightDirection * Time.deltaTime * 3);
        myOwnPosition = transform.position;
        if(myOwnPosition.x > 15 || myOwnPosition.x < -15)
        {
            Destroy(gameObject);
        }


        if(KMS.KnightDirection == 3)
        {
            transform.localScale = new Vector2(5.4f, 6.2f);
        }


        if (KMS.KnightDirection == -3)
        {
            transform.localScale = new Vector2(-5.4f, 6.2f);
        }
    }
}
