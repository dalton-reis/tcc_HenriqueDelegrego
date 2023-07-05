using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;

public class ScriptBtn_CPU : MonoBehaviour
{

    public GameObject texto_CPU;
    public GameObject canvasQuadradoCPU;
    public GameObject canvasQuadradoRAM;



    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(AcaoBtn_CPU);
        this.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(ReleaseBtn_CPU);
    }


    public void AcaoBtn_CPU(VirtualButtonBehaviour vb)
    {  
        if(Script_Motherboard.ordemCPU == 1 || Script_Motherboard.ordemCPU == 0)
        {
            this.canvasQuadradoCPU.SetActive(false);
            texto_CPU.SetActive(true);
        }
    }
     public void ReleaseBtn_CPU(VirtualButtonBehaviour vb)
    {    
            texto_CPU.SetActive(false);
            if(Script_Motherboard.ordemCPU == 1)
            {
                Script_Motherboard.ordemCPU = 2;
                this.canvasQuadradoRAM.SetActive(true);
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
