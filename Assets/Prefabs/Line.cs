using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    private LineRenderer lr;

    public Vector2 pivot;
    public List<Point> points;
    public Vector2 u;

    private int check_count = 0;
    private Vector2 prev;

    private void Awake(){
        lr = GetComponent<LineRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach(Point point in points)
        {
            Vector2 p = point.transform.position;
            if(p.x == pivot.x && p.y == pivot.y){

                SpriteRenderer sr = point.GetComponent<SpriteRenderer>();
                sr.material.SetColor("_Color", Color.yellow);
                break;
            }
        }
        //Debug.Log(pivot.x + " " + pivot.y);
    }

    // Update is called once per frame
    void Update()
    {
        Rotate(0.003f);

        lr.SetPosition(0, GetFunction(-50));
        lr.SetPosition(1, GetFunction(50));

        foreach(Point point in points)
        {
            Vector2 p = point.transform.position;
            if(p.x != pivot.x || p.y != pivot.y){

                Vector2 n = new Vector2(u.y, -u.x);
                Vector2 pq = p-pivot;
                
                if(p != prev || check_count > 100){
                    

                    if(Mathf.Abs(Vector2.Dot(pq, n)  / n.magnitude) <= 0.1f){
                        prev = pivot;
                        check_count = 0;

                        SpriteRenderer sr = point.GetComponent<SpriteRenderer>();
                        sr.material.SetColor("_Color", Color.yellow);

                        UpdatePoint(point.transform.position);
                        break;
                    }
                }else{
                    check_count++;
                }
                
            }
        }
    }

    public Vector2 GetFunction(float x)
    {
        Vector2 dum = pivot;
        dum = dum + (x * u);
        return dum;
    }

    void Rotate(float alpha)
    {
        Vector2[] dum = {new Vector2(Mathf.Cos(alpha), Mathf.Sin(alpha)), new Vector2(-Mathf.Sin(alpha), Mathf.Cos(alpha))};
        u = new Vector2(u.x * dum[0].x + u.y * dum[0].y, u.x * dum[1].x + u.y * dum[1].y);
    }

    public void UpdatePoint(Vector2 newPoint)
    {
        prev = pivot;
        pivot = newPoint;

        foreach(Point point in points)
        {
            Vector2 p = point.transform.position;
            if(p.x == prev.x && p.y == prev.y){

                SpriteRenderer sr = point.GetComponent<SpriteRenderer>();
                sr.material.SetColor("_Color", Color.white);
                break;
            }
        }
    }
}
