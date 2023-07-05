using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using TMPro;

public class ScriptBtn_ISA : MonoBehaviour
{

    public GameObject texto_ISA;
    public GameObject canvasQuadradoISA;


    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(AcaoBtn_ISA);
        this.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(ReleaseBtn_ISA);
    }


    public void AcaoBtn_ISA(VirtualButtonBehaviour vb)
    {
        if(Script_Motherboard.ordemCPU == 3 || Script_Motherboard.ordemCPU == 0)
        {
            this.canvasQuadradoISA.SetActive(false);
            texto_ISA.SetActive(true);
 
        }
    }
     public void ReleaseBtn_ISA(VirtualButtonBehaviour vb)
    {
        texto_ISA.SetActive(false);
        if (Script_Motherboard.ordemCPU == 3)
        {
            Script_Motherboard.ordemCPU = 0;
        }       
    }
}
