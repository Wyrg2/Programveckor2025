using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight_Slash_Attack : MonoBehaviour
{
    Knight_Movement_Script KMS;
    // Start is called before the first frame update
    void Start()
    {
        KMS = FindAnyObjectByType<Knight_Movement_Script>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (Vector3.left * KMS.KnightDirection * Time.deltaTime * 3);
    }
}
