using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Foundation : MonoBehaviour
{
    [SerializeField]
    private Main main;

    private float thisFloor;

    [SerializeField]
    private Room roomScript;

    private Transform transForm;

    private float scaleX;
    private float scaleZ;
    void Start()
    {
        transForm = GetComponent<Transform>();
        thisFloor = roomScript.thisFloor;
        scaleX = transform.localScale.x;
        scaleZ = transform.localScale.z;
    }

    void Update()
    {
        //tranForm.scale.x 25f - ((main.floor - thisFloor) * 25f);
        if (((main.floor - thisFloor) <= 0.05f) && (((main.floor - thisFloor) >= 0f)))
        {
            transform.localScale = new Vector3(scaleX * (main.floor - thisFloor) * 20f, transform.localScale.y, scaleZ * (main.floor - thisFloor) * 20f);
        }
        else
        {
            if ((main.floor - thisFloor) > 0.05f)
            {
                transform.localScale = new Vector3(scaleX, transform.localScale.y, scaleZ);
            }
            else
            {
                transform.localScale = new Vector3(0.0001f, 0.0001f, 0.0001f);
            }
        }
    }
}
