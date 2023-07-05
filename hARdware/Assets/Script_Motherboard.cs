using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Vuforia;
using TMPro;
using System.Diagnostics;
using Unity.VisualScripting;

public class Script_Motherboard : MonoBehaviour
{
    public static int ordemCPU = -1;
    public GameObject canvasQuadradoCPU;
    public GameObject textoPlaca1;
    public GameObject textoPlaca2;
    public GameObject textoPlaca3;  

    public void ReiniciaSequencia() // Para voltar ao estado inicial. Não fazer?
    {
        Invoke("IniciaSequencia", 3);
    }
    
    public void IniciaSequencia()
    {
        // ordemCPU = -1;
        Invoke("DeleteTextoInicial", 5); /* Original */
        // Invoke("DeleteTextoFinal", 5); /* Usado para pular as etapas iniciais */
      
    }

    public void DeleteTextoInicial()
    {
        this.textoPlaca1.SetActive(false);
        this.textoPlaca2.SetActive(true);
        Invoke("DeleteTextoSecundario", 5);
    }

    private void DeleteTextoSecundario()
    {
      this.textoPlaca2.SetActive(false);
      this.textoPlaca3.SetActive(true);
      Invoke("DeleteTextoFinal", 5);
    }

    private void DeleteTextoFinal()
    {
      this.textoPlaca3.SetActive(false);
      this.textoPlaca1.SetActive(false);
      this.canvasQuadradoCPU.SetActive(true);
      Script_Motherboard.ordemCPU = 1; 
    }
     

    // Start is called before the first frame update
    void Start()
    {
    }
}
