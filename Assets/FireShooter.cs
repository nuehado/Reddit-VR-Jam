using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FireShooter : MonoBehaviour
{
    public AxisHandler1D primaryAxis1DHandler = null;
    [SerializeField] ParticleSystem fire;

    public void OnEnable()
    {
        primaryAxis1DHandler.OnValueChange += ShootFire;
    }

    public void OnDisable()
    {
        primaryAxis1DHandler.OnValueChange -= ShootFire;
        fire.Stop();
    }

    private void ShootFire(XRController controller, float value)
    {
        if (value >= 0.5f)
        {
            fire.Play();
        }
        else
        {
            fire.Stop();
        }
    }
}
