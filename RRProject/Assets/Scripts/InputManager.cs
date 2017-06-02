using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour {


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            BarPanel.GetInst.KeyDown(KeyCode.D);
        if (Input.GetKeyDown(KeyCode.A))
            BarPanel.GetInst.KeyDown(KeyCode.A);
        if (Input.GetKeyDown(KeyCode.S))
            BarPanel.GetInst.KeyDown(KeyCode.S);
        if (Input.GetKeyDown(KeyCode.W))
            BarPanel.GetInst.KeyDown(KeyCode.W);
        if (Input.GetKeyDown(KeyCode.L))
            BarPanel.GetInst.KeyDown(KeyCode.L);
        if (Input.GetKeyDown(KeyCode.J))
            BarPanel.GetInst.KeyDown(KeyCode.J);
        if (Input.GetKeyDown(KeyCode.K))
            BarPanel.GetInst.KeyDown(KeyCode.K);
        if (Input.GetKeyDown(KeyCode.I))
            BarPanel.GetInst.KeyDown(KeyCode.I);

    }
}
