using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class StateSwitch : MonoBehaviour
{
    [SerializeField] private StateType stateType;
    [Tooltip("Variable used for VisibilitySwitch to know if objects is active on start")]
    [SerializeField] private bool isActive;
    private Material material;
    private readonly int Switch1 = Shader.PropertyToID("_switch");

    private enum StateType
    {
        MaterialSwitch,
        VisibilitySwitch
    }

    void Start()
    {
        material = stateType == StateType.MaterialSwitch ? GetComponent<MeshRenderer>().material : null;
        if (stateType != StateType.VisibilitySwitch) return;
        if (!isActive) gameObject.SetActive(isActive);
        }

    public void Switch()
    {
        switch (stateType)
        {
            case StateType.MaterialSwitch:
                var value = material.GetFloat(Switch1);
                value = value == 0 ? 1 : 0;
                material.SetFloat(Switch1,value);
                break;
            case StateType.VisibilitySwitch:
                isActive = !isActive;
                gameObject.SetActive(isActive);
                break;
        }
    }
}
