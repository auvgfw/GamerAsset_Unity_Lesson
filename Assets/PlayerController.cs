using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform OriginalPos;
    GameObject Animal;
    Vector3 nextpos,nextrot;
    Sequence mySequence;
    void Start()
    {
        Animal = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGoButton()
    {
        nextpos = transform.position;
        nextrot = transform.eulerAngles;
        mySequence = DOTween.Sequence();

        int i;
        Go();
        for (i = 0; i < 10; i++)
        {
            
            Turn();
            Go();
        }
    }
    
    
    void Go()
    {
        if (nextrot.y == 0)
        {
            nextpos.z++;
        }
        if (nextrot.y == 90)
        {
            nextpos.x++;
        }
        if (nextrot.y == 180)
        {
            nextpos.z--;
        }
        if (nextrot.y == 270)
        {
            nextpos.x--;
        }
        mySequence.Append(transform.DOMove(nextpos,1));
    }
    void Turn()
    {
        if (nextrot.y == 0)
        {
            nextrot.y = 90;
        }
        else if (nextrot.y == 90)
        {
            nextrot.y=180;
        }
        else if (nextrot.y == 180)
        {
            nextrot.y=270;
        }
        else if (nextrot.y == 270)
        {
            nextrot.y=0;
        }
        mySequence.Append(transform.DORotate(nextrot, 1));
    }
    void ResetPos()
    {
        transform.position = OriginalPos.position;
        transform.rotation = OriginalPos.rotation;
    }

}
