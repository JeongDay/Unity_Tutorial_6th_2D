using System;
using System.Collections.Generic;
using UnityEngine;

public class ControlManager : MonoBehaviour
{
    public Transform[] units; // 생성되어있는 유닛

    public List<UnitMovement> selectedUnits = new List<UnitMovement>(); // 드래그해서 선택된 유닛

    private Camera mainCamera;

    private Vector3 dragStartPos;
    
    public LayerMask targetLayer;
    public LayerMask groundLayer;

    private bool isSelected = false;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SetTargetOrDrag();

        if (Input.GetMouseButtonUp(0))
            SetUnitGroup();

        if (Input.GetMouseButtonDown(1))
            SetDestination();
    }

    private void SetTargetOrDrag()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 1000f, targetLayer)) // 단일 대상 선택
        {
            selectedUnits.Clear();
            isSelected = true;
            var unit = hitInfo.collider.GetComponent<UnitMovement>();
            
            if (unit != null)
                selectedUnits.Add(unit);
        }
        else if (Physics.Raycast(ray, out hitInfo, 1000f, groundLayer)) // 드래그 시작점 설정
        {
            dragStartPos = hitInfo.point;
            Debug.Log("드래그 시작");
        }
    }

    private void SetUnitGroup()
    {
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 1000f, groundLayer))
        {
            var sizeX = Mathf.Abs(hitInfo.point.x - dragStartPos.x) / 2f;
            var sizeZ = Mathf.Abs(hitInfo.point.z - dragStartPos.z) / 2f;

            var centerX = (hitInfo.point.x + dragStartPos.x) / 2f;
            var centerZ = (hitInfo.point.z + dragStartPos.z) / 2f;

            foreach (var unit in units)
            {
                var distanceX = Mathf.Abs(centerX - unit.transform.position.x);
                var distanceZ = Mathf.Abs(centerZ - unit.transform.position.z);

                if (distanceX <= sizeX && distanceZ <= sizeZ)
                {
                    isSelected = true;
                    selectedUnits.Add(unit.GetComponent<UnitMovement>());
                    Debug.Log($"{unit.name}이 영역 안에 있습니다.");
                }
            }
        }
        
        Debug.Log("드래그 종료");
    }

    private void SetDestination()
    {
        if (!isSelected)
            return;

        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo, 1000f, groundLayer))
        {
            foreach (var unit in selectedUnits)
                unit.SetMovement(hitInfo.point);

            isSelected = false;
            selectedUnits.Clear();
        }
    }
}