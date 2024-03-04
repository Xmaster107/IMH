using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{
    [SerializeField]
    private Main main;

    private float thisFloor;

    [SerializeField]
    private float animTime;

    [SerializeField]
    private Animator anim;

    [SerializeField]
    private Room roomScript;
    void Start()
    {
        anim.enabled = false;
        if (roomScript != null)
        {
            thisFloor = roomScript.thisFloor;
        }
    }

    void Update()
    {
        animTime = 25f - ((main.floor - thisFloor) * 25f);
        anim.Play(anim.GetCurrentAnimatorClipInfo(0)[0].clip.name, 0, (float)animTime / anim.GetCurrentAnimatorClipInfo(0)[0].clip.frameRate); // ”станавливаем анимацию на определенный кадр
        anim.Update(0f);
    }
}
