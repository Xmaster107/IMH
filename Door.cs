using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField]
    private Transform[] LeftDoor = new Transform[4];
    [SerializeField]
    private Transform[] RightDoor = new Transform[4];
    [SerializeField]
    private Material green;
    [SerializeField]
    private Material yellow;
    [SerializeField]
    private Material red;

    [SerializeField]
    private int idLeft;
    [SerializeField]
    private int idRight;

    [SerializeField]
    private Room roomScriptRight;
    [SerializeField]
    private Room roomScriptLeft;
    private int i;

    [SerializeField]
    private Main main;

    private float thisFloor;

    [SerializeField]
    private float animTime;

    [SerializeField]
    private Animator anim;
    void Start()
    {
        anim.enabled = false;

        if (roomScriptLeft != null)
        {
            idLeft = roomScriptLeft.mode;
            thisFloor = roomScriptLeft.thisFloor;
        }
        else
        {
            idLeft = 0;
        }
        if (roomScriptRight != null)
        {
            idRight = roomScriptRight.mode;
            thisFloor = roomScriptLeft.thisFloor;
        }
        else
        {
            idRight = 0;
        }
        while (i < 4)
        {
            if (idRight == 1)
            {
                RightDoor[i].gameObject.GetComponent<Renderer>().material = green;
            }
            if (idLeft == 1)
            {
                LeftDoor[i].gameObject.GetComponent<Renderer>().material = green;
            }
            if (idRight == 2)
            {
                RightDoor[i].gameObject.GetComponent<Renderer>().material = yellow;
            }
            if (idLeft == 2)
            {
                LeftDoor[i].gameObject.GetComponent<Renderer>().material = yellow;
            }
            if (idRight == 3)
            {
                RightDoor[i].gameObject.GetComponent<Renderer>().material = red;
            }
            if (idLeft == 3)
            {
                LeftDoor[i].gameObject.GetComponent<Renderer>().material = red;
            }
            i++;
        }
    }
    void Update()
    {
        animTime = 25f - ((main.floor - thisFloor) * 25f);
        anim.Play(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, (float)animTime / anim.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate); // ”станавливаем анимацию на определенный кадр
        anim.Update(0f);
    }
}
