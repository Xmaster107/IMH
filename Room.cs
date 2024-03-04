using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    private int floor;
    [SerializeField]
    public int mode;
    public int thisFloor;
    public int id;

    [SerializeField]
    private bool random = true;
    private void Awake()
    {
        if (random)
        {
            mode = Random.Range(1, 4);
        }
    }
    void Start()
    {
        //mode = Random.Range(1, 3);
    }

    void Update()
    {
        
    }
}
