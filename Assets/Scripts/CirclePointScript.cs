using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePointScript : MonoBehaviour
{
    [SerializeField] Human human;

    [Range(0.5f, 3f)]
    public float distanceRandomHuman;
    [Range(1f, 7f)]
    public int countHumans = 4;

    private List<Human> humansInCircle = new List<Human>();

    private LayerMask layerIn;

    private void Start()
    {
        HumanPlaceInCircle(countHumans);
    }

    private void HumanPlaceInCircle(int countHumans)
    {
        List<Vector2> points = CreateRandomPoints();
        Vector3 humanRotate = new Vector3(0f, -90.0f, 0f);

        for (int i = 0; i < points.Count-1; i++)
        {

            Vector3 rndPos = new Vector3(points[i].x, human.transform.position.y, points[i].y);

            Human h = Instantiate(human, rndPos, Quaternion.Euler(humanRotate), transform);

            h.transform.localPosition = rndPos;
            #region MyRegion
            //Vector3 toCenter = h.transform.position - gameObject.transform.position;
            //if(CheckCollision(h))
            //
            //    h.transform.localPosition += Vector3.one;
            //}
            #endregion
            humansInCircle.Add(h);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        layerIn = col.gameObject.layer;
        if (layerIn == LayerMask.NameToLayer("Snake"))
        {

        }
    }

    private void OnTriggerExit(Collider col)
    {
        layerIn = col.gameObject.layer;
        if (layerIn == LayerMask.NameToLayer("Snake"))
        {

        }
    }

    //private bool CheckCollision(Human h)
    //{
    //    if (humansInCircle.Count > 0)
    //    {
    //        foreach (var el in humansInCircle)
    //        {
    //            Collider elCol = el.GetComponent<CapsuleCollider>();
    //            Collider hCol = h.GetComponent<CapsuleCollider>();
    //            if (hCol.bounds.Intersects(elCol.bounds))
    //            {
    //               return true;
    //            }
    //        }
    //    }
    //    return false;
    //}

    
    private List<Vector2> CreateRandomPoints()//Создает Случайные точки внутри окружности на дистанции не менее установленной.  
    {
        List<Vector2> points = new List<Vector2>();
        #region MyRegion

       
        //Vector3 extentsC = human.GetComponent<Collider>().bounds.extents;
        //Vector3 centerC = human.GetComponent<Collider>().bounds.center;
        //float disH = Vector3.Distance(extentsC, centerC);
        #endregion
        float disH = distanceRandomHuman;
        int crashCounter = 0;

        bool flagP = true;

        for (int i = 0; i < countHumans; i++)
        {
            Vector2 rnd = Random.insideUnitCircle * gameObject.GetComponent<SphereCollider>().radius;
            if (points.Count > 0)
            {
                foreach (var el in points)
                {
                    float dis = Vector2.Distance(el, rnd);
                    if (dis < disH)
                    {
                        flagP = false;
                        break;
                    }
                }
            }
            if (!flagP)
            {
                flagP = true;
                i--;
                crashCounter++;
            }
            else
            {
                points.Add(rnd);
            }
            if (crashCounter == 20) break;
        }
        return points;
    }

}

