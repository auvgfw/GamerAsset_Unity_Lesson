using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform OriginalPos;
    GameObject Animal;
    Animator anim;
    Vector3 nextpos,nextrot;
    Sequence mySequence;
    float speed = 0.5f;
    void Start()
    {
        Animal = transform.GetChild(0).gameObject;
        anim = Animal.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnGoButton()
    {
        nextpos = transform.position;
        nextrot = transform.eulerAngles;
        anim.Play("Base Layer.walk");
        mySequence = DOTween.Sequence();

        int i;
        for (i = 0; i <4; i++)
        {
            Go(2);
            Turn(90);
            Go(2);
            Turn(-90);

        }
    }
    
    
    void Go(float grid=1.0f)
    {
        
        if (nextrot.y%360 == 0)
        {
            nextpos.z += grid; ;
        }
        if (nextrot.y%360 == 90)
        {
            nextpos.x+=grid;
        }
        if (nextrot.y%360 == 180)
        {
            nextpos.z-=grid;
        }
        if (nextrot.y%360 == 270)
        {
            nextpos.x-=grid;
        }
        mySequence.Append(transform.DOMove(nextpos, Mathf.Abs(grid) *speed));
    }
    void Turn(float degree=90.0f)
    {
        while(degree<0)
        {
            degree += 360;
        }
        nextrot.y += degree;

        mySequence.Append(transform.DORotate(nextrot, 0.5f));
    }
    void ResetPos()
    {
        transform.position = OriginalPos.position;
        transform.rotation = OriginalPos.rotation;
    }

}
