using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISwitchable
{
    public bool IsActive { get; }

    public void Activate();
    public void Deactivate();
}


public class Switch : MonoBehaviour
{
    public ISwitchable client;

    public void Toggle()
    {
        if(client.IsActive)
        {
            client.Deactivate();
        }
        else
        {
            client.Activate();
        }
    }
}


public class Door : MonoBehaviour, ISwitchable
{
    private bool isActive;
    public bool IsActive => isActive;

    public void Activate()
    {
        isActive = true;
        Debug.Log("The door is open. ");
    }

    public void Deactivate()
    {
        isActive = false;
        Debug.Log("The door is closed. ");
    }
}
