using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

public class UnitSelectionManager : MonoBehaviour
{
    public static UnitSelectionManager Instance { get; set; }


    public List<GameObject> allUnitsList = new List<GameObject>();
    public List<GameObject> unitsSelected = new List<GameObject>();

    public LayerMask pressable;
    public LayerMask ground;
    public GameObject groundMarker;

    private Camera cam;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }


    private void Start()
    {
        cam = Camera.main;

    }

    private void Update()
    {

        if (Input.GetMouseButton(0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, pressable))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    MultiSelect(hit.collider.gameObject);
                }
                else
                {
                    ClickSelect(hit.collider.gameObject);
                }
            }
            else
            {
                if (Input.GetKey(KeyCode.LeftShift) == false)
                {
                    DeselectAll();
                }
            }
        }

        if (Input.GetMouseButton(1) && unitsSelected.Count > 0)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, ground))
            {
                groundMarker.transform.position = hit.point;

                groundMarker.SetActive(false);
                groundMarker.SetActive(true);
            }

        }


    }

    private void MultiSelect(GameObject unit)
    {
        if (unitsSelected.Contains(unit) == false)
        {
            unitsSelected.Add(unit);
            SelectUnits(unit, true);
        }
        else
        {

            SelectUnits(unit, false);
            unitsSelected.Remove(unit);
        }   

    }

    void ClickSelect(GameObject unit)
    {
        DeselectAll();
       
        unitsSelected.Add(unit);
        SelectUnits(unit, true);
    }

   public void DeselectAll()
    {
        foreach (var unit in unitsSelected)
        {
            SelectUnits(unit, false);
        }
        groundMarker.SetActive(false);  
        unitsSelected.Clear();
    }

    private void EnableUnitMovement(GameObject unit, bool shouldMove)
    {
        unit.GetComponent<UnitMovement>().enabled = shouldMove;
    }

    private void TriggerIndicator(GameObject unit, bool selected)
    {
        unit.transform.GetChild(0).gameObject.SetActive(selected);
    }

    internal void DragSelect(GameObject unit)
    {
        if (unitsSelected.Contains(unit) == false )
        {
            unitsSelected.Add(unit);
            SelectUnits(unit, true);
        }
    }

    private void SelectUnits(GameObject unit, bool isSelected)
    {
        TriggerIndicator(unit, isSelected);
        EnableUnitMovement(unit, isSelected);
    }
}
