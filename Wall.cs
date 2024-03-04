using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Wall : MonoBehaviour
{
    [SerializeField]
    private Animator anim;

    [SerializeField]
    private float animTime;

    [SerializeField]
    private Transform[] LeftWall = new Transform[6];

    [SerializeField]
    private Transform[] RightWall = new Transform[6];

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
    private Main main;

    [SerializeField]
    private Room roomScriptLeft;

    private float thisFloor;

    private float saveMainFloor;

    private int i;
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

        while (i < 6)
        {
            if (idRight == 1) 
            {
                RightWall[i].gameObject.GetComponent<Renderer>().material = green;
            }
            if (idLeft == 1)
            {
                LeftWall[i].gameObject.GetComponent<Renderer>().material = green;
            }
            if (idRight == 2)
            {
                RightWall[i].gameObject.GetComponent<Renderer>().material = yellow;
            }
            if (idLeft == 2)
            {
                LeftWall[i].gameObject.GetComponent<Renderer>().material = yellow;
            }
            if (idRight == 3)
            {
                RightWall[i].gameObject.GetComponent<Renderer>().material = red;
            }
            if (idLeft == 3)
            {
                LeftWall[i].gameObject.GetComponent<Renderer>().material = red;
            }
            i++;
        }
    }

    void Update()
    {
        if (saveMainFloor != main.floor)
        {
            animTime = 25f - ((main.floor - thisFloor) * 25f);
            anim.Play(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, (float)animTime / anim.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate); // ”станавливаем анимацию на определенный кадр
            anim.Update(0f);
            saveMainFloor = main.floor;
        }
    }
}
