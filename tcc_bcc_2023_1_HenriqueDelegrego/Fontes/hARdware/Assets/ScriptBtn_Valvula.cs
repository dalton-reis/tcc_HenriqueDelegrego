using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine.XR;
using System.IO;

public class ScriptBtn_Valvula : MonoBehaviour
{
    public GameObject texto_Valvula;
    public GameObject texto_ValvulaConsertado;
    public GameObject codigoConsertado;
    public GameObject videoPlayer;
    public GameObject painelValvula;
    public static bool hasPressed = false;
    public static bool comeco = true;
    private bool ligaDesliga = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonPressed(acaoBtn_Valvula);
        this.GetComponent<VirtualButtonBehaviour>().RegisterOnButtonReleased(releaseBtn_Valvula);        
    }

    private void AcaoLed(bool acao)
    {
        try
        {
            string gateway = "192.168.4.1";
            int port = 8080;
            string message = "";
            if (acao)
            {
                message = "LIGA";
            }
            else
            {
                message = "DESLIGA";
            }

            message.Replace("\r", "").Replace("\n", "\r\n");

            // Create a new TCP client and connect to the specified IP address and port
            TcpClient client = new TcpClient(gateway, port);

            // Convert the message to bytes
            byte[] data = Encoding.UTF8.GetBytes(message + "\r\n");


            // Get the network stream from the client
            NetworkStream stream = client.GetStream();

            // Send the message
            stream.Write(data, 0, data.Length);

            // Close the stream and client
            stream.Close();
            client.Close();
            print("Message sent successfully!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    private void ReiniciaSequencia()
    {
        this.AcaoLed(false);
        this.texto_Valvula.SetActive(true);
        this.texto_ValvulaConsertado.SetActive(false);
        this.codigoConsertado.SetActive(false);
        this.videoPlayer.SetActive(true);
        this.painelValvula.SetActive(false);
        ScriptBtn_Valvula.hasPressed = false;
        ScriptBtn_Valvula.comeco = true;
        this.ligaDesliga = false;
    }

    public void acaoBtn_Valvula(VirtualButtonBehaviour vb)
    {
        if (this.ligaDesliga) // Quando já tá consertado
        {
            this.AcaoLed(true);
            Invoke("ReiniciaSequencia", 11);
            texto_ValvulaConsertado.SetActive(true);
            this.codigoConsertado.SetActive(true);
            this.painelValvula.SetActive(true);
            this.ligaDesliga = false;


        }
        else // Quando ainda não tá consertado
        {
            this.texto_Valvula.SetActive(false);
            this.texto_ValvulaConsertado.SetActive(false);
            this.codigoConsertado.SetActive(false);
            this.videoPlayer.SetActive(false);
            this.painelValvula.SetActive(false);
            this.AcaoLed(false);
            ScriptBtn_Valvula.hasPressed = true;
            this.ligaDesliga = true;

        }
    }
     public void releaseBtn_Valvula(VirtualButtonBehaviour vb)
    {
        // Colocar um texto falando pro usuário colocar a válvula de volta?
    }
}
