using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectionManager : MonoBehaviour
{

    [SerializeField] private string selectableTab = "Selectable";
    [SerializeField] private Material selectedMaterial;
    [SerializeField] private Material defaultMaterial;

    private Transform _selection;

    void Update()
    {
        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = defaultMaterial;   
            }
        }
        
        var ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        
        _selection = null;
        if (Physics.Raycast(ray, out var hit))
        {
            var selection = hit.transform;
            if (selection.CompareTag(selectableTab))
            {
                _selection = selection;
            }
        }

        if (_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            if (selectionRenderer != null)
            {
                selectionRenderer.material = selectedMaterial;
            }
        }
    }
}
