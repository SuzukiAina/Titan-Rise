using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingRange : MonoBehaviour
{
    public int xRangeMin = -4;
    public int xRangeMax = 4;
    public int yRangeMin = 2;
    public int yRangeMax = 4;
    public int zRangeMin = -2;
    public int zRangeMax = 3;
    private Vector3 tmp;

    public List<Target> targets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckHit()
    {
        bool flag = true;
        for (int i = 0; i < targets.Count; i++)
        {
            flag = flag & targets[i].hit;
        }

        if (flag)
        {
            for (int i = 0; i < targets.Count; i++)
            {
                tmp = new Vector3(Random.Range(xRangeMax, xRangeMin), Random.Range(yRangeMax, yRangeMin),
                    Random.Range(zRangeMax, zRangeMin));
                for (int j = 0; j < targets.Count; j++)
                {
                    while (tmp == targets[i].transform.position)
                    {
                        tmp = new Vector3(Random.Range(xRangeMax, xRangeMin), Random.Range(yRangeMax, yRangeMin),
                            Random.Range(zRangeMax, zRangeMin));
                    }
                }
                StartCoroutine(targets[i].SmoothLerp(tmp, 0.5f));
                targets[i].hit=false;
            }
        }
    }
    
    
}
