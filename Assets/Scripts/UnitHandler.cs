using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class UnitHandler : MonoBehaviour
{
    selected_dictionary selected_table;
    public Transform characterPrefab = null;
    List<GameObject> selectedUnits = new List<GameObject>();
    List<GameObject> allUnits = new List<GameObject>();
    List<Vector3> positionList;
    float unitGap = 5;
    private Vector3 worldPosition;

    public Vector3[,] getPositionGridSquare(int numberOfRows, Vector3 destination)
    {
        Vector3[,] map = new Vector3[(2 * numberOfRows) - 1, (2 * numberOfRows) - 1];
        int center = numberOfRows;
        Vector3 soldierPosition = new Vector3(destination.x - (numberOfRows * 2), 0, destination.z - (numberOfRows) * 2);//position of first soldier
        float xPosFirst = soldierPosition.x;
        float yPosFirst = soldierPosition.z;
        for (int i = 0; i < map.GetLength(0); i++)
        {
            for (int j = 0; j < map.GetLength(1); j++)
            {
                map[i, j] = new Vector3(xPosFirst + (i * 2), 0, yPosFirst + (j * 2));
            }

        }
        return map;
    }
    public int CalculateSelectedWidth()
    {
        int width = 0;
        for (int i = 0; i < selectedUnits.Count; i++)
        {
            Unit u = selectedUnits[i].GetComponent<Unit>();
            if (u.getFormation() == "square")
            {
                width += (int)Mathf.Ceil(Mathf.Sqrt(u.getNumberOfChilds()));
            }
            else if (u.getFormation() == "line")
            {
                width += u.getNumberOfChilds();
            }
        }
        return width;
    }
    public int compareVectorsDiagonality(Vector3 playerP, Vector3 clickedP)
    {
        float tolerance = 8f;
        float dx = playerP.x - clickedP.x;
        float dz = playerP.z - clickedP.z;
        if (Mathf.Abs(dx) > tolerance && Mathf.Abs(dz) > tolerance)//çapraz 
        {
            if ((dx<0&&dz<0)||(dx>0&&dz>0)) { //sol alt sağ üst 
                return 1;
            }
            else if((dx > 0 && dz < 0) || (dx < 0 && dz > 0)) {//sağ alt sol üst 
                return 2;
            }
        }
        else if (Mathf.Abs(dx) > tolerance && Mathf.Abs(dz) < tolerance) {//aşağı yukarı
            return 3; 
        }
        else if (Mathf.Abs(dx) < tolerance && Mathf.Abs(dz) > tolerance) {// 
            return 4; 
        }
        return 0;
    }
    public void SetUnitPositions(Vector3 destination) {
        int followingUnits = selectedUnits.Count - 1;
        float spacingRads = 360 / followingUnits * Mathf.Deg2Rad;
        float x = 0f;
        float y = 0f;
        float radius = 1f;
        float leaderX = destination.x;
        float leaderY = destination.z;
        GameObject leaderGo = new GameObject();leaderGo.transform.position = destination;
        selectedUnits[0].GetComponent<Unit>().setPosition(leaderGo);
        for (int i=1; i<selectedUnits.Count;i++) {
            radius = selectedUnits[i].GetComponent<Unit>().getWidth()*1.50f;
            if (compareVectorsDiagonality(destination,selectedUnits[0].GetComponent<Unit>().transform.position)==1) {
                if (i % 2 == 0)
                {
                    x = leaderX - (i * radius);
                    y = leaderY + (i* radius);
                }
                else
                {
                    x = leaderX + (i * radius);
                    y = leaderY - (i * radius);
                }
            }
            else if(compareVectorsDiagonality(destination, selectedUnits[0].GetComponent<Unit>().transform.position) == 2) {
                if (i%2==0) {
                    x = leaderX + (i*radius);
                    y = leaderY + (i * radius);
                }
                else {
                    x = leaderX - (i * radius);
                    y = leaderY - (i * radius);
                }
            }
            else if (compareVectorsDiagonality(destination, selectedUnits[0].GetComponent<Unit>().transform.position) == 4) {
                if (i % 2 == 0)
                {
                    x = leaderX + (i * radius);
                    y = leaderY;
                }
                else
                {
                    x = leaderX - (i * radius);
                    y = leaderY;
                }
            }
            else if (compareVectorsDiagonality(destination, selectedUnits[0].GetComponent<Unit>().transform.position) == 3)
            {
                if (i % 2 == 0)
                {
                    x = leaderX ;
                    y = leaderY + (i * radius);
                }
                else
                {
                    x = leaderX ;
                    y = leaderY -(i * radius);
                }
            }
            GameObject go = new GameObject(); go.transform.position = new Vector3(x, 0, y);
            selectedUnits[i].GetComponent<Unit>().setPosition(go);
        }
    }
    public void CreateDestinationNode()
    {
        GameObject DestinationNode = new GameObject();
    }
    public void GetDestinationByUnitId(int unitId)
    {

    }
    public void AddUnitGlobal(GameObject u)
    {
        allUnits.Add(u);
    }
    public void RemoveUnitGlobal(GameObject u)
    {
        allUnits.Remove(u);
    }
    public void AddUnitSelected(GameObject u)
    {
        selectedUnits.Add(u);
    }
    public void RemoveUnitSelected(GameObject u)
    {
        selectedUnits.Remove(u);
    }
    public void ClearSelected()
    {
        selectedUnits.Clear();
    }

    public void CreateUnit(int unitSize, Vector3 location)
    {


    }
    private void Move()
    {

        if (Input.GetMouseButtonUp(1))
        {
            Plane plane = new Plane(Vector3.up, 0);
            float distance;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (plane.Raycast(ray, out distance))
            {
                worldPosition = ray.GetPoint(distance);
            }
            SetUnitPositions(worldPosition);
        }
    }
    private void Start()
    {

    }
    void Update()
    {
        Move();
    }


}