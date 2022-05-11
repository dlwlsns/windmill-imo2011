using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointsGeneration : MonoBehaviour, IPointerClickHandler
{
    public Point point;
    public List<Point> points;
    public Line line;

    // Start is called before the first frame update
    void Start()
    {
        points = GeneratePoints();

        line.u = new Vector2(0, 1);
        line.points = points;
        line.UpdatePoint(points[Random.Range(0,points.Count-1)].transform.position);
    }

    // Update is called once per frame
    void Update(){}

    List<Point> GeneratePoints()
    {
        List<Point> points = new List<Point>();

        for(int i = 0; i < 10; i++) {
            Vector2 v = new Vector2(Random.Range(-10.0f,10.0f), Random.Range(-10.0f,10.0f));

            Point e = GameObject.Instantiate(point);
            e.transform.position = v;
            points.Add(e);
        }

        return points;
    }

    /*public void OnPointerClick(PointerEventData data)
    {
        //Vector2 v = new Vector2(Random.Range(-20.0f,20.0f), Random.Range(-20.0f,20.0f));
            Point e = GameObject.Instantiate(point);
            e.transform.position = eventData.position;
            points.Add(e);
        Debug.Log("OnPointerClick called.");
    }*/
    public void OnPointerClick (PointerEventData eventData) {
        if (eventData.button == PointerEventData.InputButton.Right) {
            Debug.Log ("Right Mouse Button Clicked on: " + name);
        }
     }
}
