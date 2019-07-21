using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject bowStringPrefab;
    public GameObject ArrowPrefab;
    public GameObject [] stringPoints = new GameObject[3];
    public GameObject [] closedArea = new GameObject[4];



    private GameObject newArrow;
    private LineRenderer lineRendererComponent;
    private Vector3 initialPositionArrow;
    private Vector3 initialPositionStringPoint1;



    // Start is called before the first frame update
    void Start()
    {
        GameObject newBowString = Instantiate(bowStringPrefab);
        newArrow = Instantiate(ArrowPrefab, stringPoints[1].transform.position, Quaternion.identity);
        lineRendererComponent = newBowString.GetComponent<LineRenderer>();
        initialPositionStringPoint1 = stringPoints[1].transform.position;
        initialPositionArrow = newArrow.transform.position;
        SpawnBowString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.y = 0.0f;
            mousePos.z = 0.0f;
            if(isValid(mousePos.x, mousePos.y)){
                stringPoints[1].transform.position = mousePos;
                newArrow.transform.position = mousePos;
            }
            else
            {
                stringPoints[1].transform.position = initialPositionStringPoint1;
                newArrow.transform.position = initialPositionArrow;
            }
        }
        else
        {
            stringPoints[1].transform.position = initialPositionStringPoint1;
            newArrow.transform.position = initialPositionArrow;
        }
        SpawnBowString();
        //gameObject.transform.Rotate( new Vector3(0, 0, 0.3f) );
        //gameObject.transform.Rotate (0, 0, Time.deltaTime * 20);
        //initialPositionStringPoint1 = stringPoints[1].transform.position;
    }

    private void SpawnBowString()
    {
        lineRendererComponent.positionCount = 3;

        lineRendererComponent.SetPosition(0, new Vector3(stringPoints[0].transform.position.x, stringPoints[0].transform.position.y, stringPoints[0].transform.position.z));
        lineRendererComponent.SetPosition(1, new Vector3(stringPoints[1].transform.position.x, stringPoints[1].transform.position.y, stringPoints[1].transform.position.z));
        lineRendererComponent.SetPosition(2, new Vector3(stringPoints[2].transform.position.x, stringPoints[2].transform.position.y, stringPoints[2].transform.position.z));
    }

    private bool isValid(float x, float y)
    {
        return x>=closedArea[0].transform.position.x && x<=closedArea[1].transform.position.x && y<= closedArea[0].transform.position.y && y>= closedArea[2].transform.position.y;
    }
}
