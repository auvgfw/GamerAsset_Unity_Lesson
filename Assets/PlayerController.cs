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
    Vector3 lastPos;
    void Start()
    {
        //transform.position = new Vector3(5, 0, 5);
        Animal = transform.GetChild(0).gameObject;
        anim = Animal.GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Equals(lastPos, transform.position) == false)
        {
            anim.ResetTrigger("Idle");
            anim.SetTrigger("Walk");

        }
        else
        {
            anim.ResetTrigger("Walk");
            anim.SetTrigger("Idle");
        }
        lastPos = transform.position;

    }

    public void OnGoButton()
    {
        nextpos = transform.position;
        nextrot = transform.eulerAngles;
        mySequence = DOTween.Sequence();

        int i;
        for (i = 0; i <36; i++)
        {
            Go(1);
            Turn(10);

        }
    }
    
    
    void Go(float grid=1.0f)
    {
        /*
        
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
        */

        nextpos.x +=Mathf.Sin(nextrot.y*Mathf.PI/180) * grid;
        nextpos.z += Mathf.Cos(nextrot.y*Mathf.PI/180) * grid;


        mySequence.Append(transform.DOMove(nextpos, Mathf.Abs(grid) *speed));
    }
    void Turn(float degree=90.0f)
    {
        float rotspeed;
        rotspeed = Mathf.Abs(degree)/90.0f * 0.5f;
        while(degree<0)
        {
            degree += 360;
        }
        nextrot.y += degree;



        mySequence.Append(transform.DORotate(nextrot, rotspeed));
    }
    void ResetPos()
    {
        transform.position = OriginalPos.position;
        transform.rotation = OriginalPos.rotation;
    }

}
