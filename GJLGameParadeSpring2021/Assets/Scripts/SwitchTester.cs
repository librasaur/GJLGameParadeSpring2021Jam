using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTester : MonoBehaviour
{
    [SerializeField] private Material _bwMat1;
    [SerializeField] private Material _bwMat2;
    [SerializeField] private Material _bwEffMat1;
    [SerializeField] private Material _bwEffMat2;
    private bool _switchIt;
    
    public static int _switchID = Shader.PropertyToID("_switch");

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) _switchIt = !_switchIt;

        if (_switchIt)
        {
            _bwMat1.SetFloat(_switchID, 1);
            _bwMat2.SetFloat(_switchID, 0);
            _bwEffMat1.SetFloat(_switchID, 1);
            _bwEffMat2.SetFloat(_switchID, 0);
        }
        else
        {
            _bwMat1.SetFloat(_switchID, 0);
            _bwMat2.SetFloat(_switchID, 1);
            _bwEffMat1.SetFloat(_switchID, 0);
            _bwEffMat2.SetFloat(_switchID, 1);
        }
    }
}
