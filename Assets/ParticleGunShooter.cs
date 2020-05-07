using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ParticleGunShooter : MonoBehaviour
{
    public AxisHandler1D primaryAxis1DHandler = null;
    [SerializeField] ParticleSystem particleEffect;

    public void OnEnable()
    {
        primaryAxis1DHandler.OnValueChange += ShootFire;
    }

    public void OnDisable()
    {
        primaryAxis1DHandler.OnValueChange -= ShootFire;
        particleEffect.Stop();
    }

    private void ShootFire(XRController controller, float value)
    {
        if (value >= 0.5f)
        {
            particleEffect.Play();
        }
        else
        {
            particleEffect.Stop();
        }
    }
}
