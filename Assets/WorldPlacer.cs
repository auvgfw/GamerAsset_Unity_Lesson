using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldPlacer : MonoBehaviour
{
    public GameObject[] cubeStyles;
    public Transform startPoint;
    // Start is called before the first frame update
    void Start()
    {
        int i, j;
        for (i = 0; i < 19; i++)
        {
            for (j = 0; j < 19; j++)
            {
                Vector3 tempTrans;
                tempTrans = startPoint.position;
                tempTrans.x += i;
                tempTrans.z += j;
                int style = ((int)(Random.value * 10.0f)) % 2+1;
                GameObject cube_temp=Instantiate(cubeStyles[style], tempTrans,startPoint.rotation);
                cube_temp.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
