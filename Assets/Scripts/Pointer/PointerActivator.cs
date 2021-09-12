using System;
using UnityEngine;
using Valve.VR;

public class PointerActivator : MonoBehaviour
{
    public GameObject pointer;

    private int grabCount = 0;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UI"))
        {
            pointer.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UI"))
        {
            pointer.SetActive(false);
        }
    }

    public void Attach()
    {
        grabCount++;
        pointer.SetActive(false);
    }

    public void Detach()
    {
        grabCount--;
        if (grabCount == 0)
        {
            pointer.SetActive(true);
        }
    }
}