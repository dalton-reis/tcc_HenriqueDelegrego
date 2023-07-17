using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;

public class ScriptBtn_RAM : MonoBehaviour
{

    public GameObject texto_RAM;
    public GameObject canvasQuadradoRAM;
    public GameObject canvasQuadradoISA;




    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(AcaoBtn_RAM);
        this.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(ReleaseBtn_RAM);
    }

    public void AcaoBtn_RAM(VirtualButtonBehaviour vb)
    {
         if(Script_Motherboard.ordemCPU == 2 || Script_Motherboard.ordemCPU == 0)
        {
            this.canvasQuadradoRAM.SetActive(false);
            texto_RAM.SetActive(true);
        }
    }
     public void ReleaseBtn_RAM(VirtualButtonBehaviour vb)
    {
       
       texto_RAM.SetActive(false);
        if(Script_Motherboard.ordemCPU == 2)
        {
        Script_Motherboard.ordemCPU = 3;
        this.canvasQuadradoISA.SetActive(true);
        }
    }   
}
