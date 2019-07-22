using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowController : MonoBehaviour
{
    public GameObject bowStringPrefab;
    public GameObject arrowPrefab;
    public GameObject arrowObject;
    public GameObject [] stringPoints = new GameObject[3];
    public GameObject [] closedArea = new GameObject[4];




    private GameObject newArrow;
    private LineRenderer lineRendererComponent;
    private Collider2D boxColliderComponent;
    private Vector3 initialPositionArrow;
    private Vector3 initialPositionStringPoint1;
    private Vector3 initialPositionClosedArea0;
    private Vector3 initialPositionClosedArea1;
    private Vector3 initialPositionClosedArea2;
    private Vector3 initialPositionClosedArea3;



    // Start is called before the first frame update
    void Start()
    {
        GameObject newBowString = Instantiate(bowStringPrefab);
        //newArrow = Instantiate(arrowPrefab, stringPoints[1].transform.position, Quaternion.identity);

        lineRendererComponent = newBowString.GetComponent<LineRenderer>();
        boxColliderComponent = gameObject.GetComponent<Collider2D>();

        initialPositionStringPoint1 = stringPoints[1].transform.position;
        initialPositionArrow = arrowObject.transform.position;
        initialPositionClosedArea0 = closedArea[0].transform.position;
        initialPositionClosedArea1 = closedArea[1].transform.position;
        initialPositionClosedArea2 = closedArea[2].transform.position;
        initialPositionClosedArea3 = closedArea[3].transform.position;

        SpawnBowString();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            
            Vector3 mousePos;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if(isValid(mousePos.x, mousePos.y)){
                float A = Mathf.Abs(mousePos.x-initialPositionStringPoint1.x);
                float B = Mathf.Abs(mousePos.y-initialPositionStringPoint1.y);
                float angle = Mathf.Atan(B/A) * Mathf.Rad2Deg;

                if(mousePos.y >= 0)
                {
                    gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, -angle);
                    //arrowObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, -angle);
                }
                else
                {
                    gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);
                    //arrowObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, angle);
                }

                Vector3 temp = mousePos;
                temp.z = 0.0f;

                stringPoints[1].transform.position = temp;
                arrowObject.transform.position = temp;
            }
            else
            {
                stringPoints[1].transform.position = initialPositionStringPoint1;
                arrowObject.transform.position = initialPositionArrow;
                gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                //arrowObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
        else
        {
            gameObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            arrowObject.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            stringPoints[1].transform.position = initialPositionStringPoint1;
            //arrowObject.transform.position = initialPositionArrow;
        }
        
        SpawnBowString();
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
        return x>=initialPositionClosedArea0.x && x<=initialPositionClosedArea1.x && y<= initialPositionClosedArea0.y && y>= initialPositionClosedArea2.y;
    }
}
