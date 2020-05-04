using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ExampleListener : MonoBehaviour
{
    public ButtonHandler primaryAxisClickHandler = null;
    public AxisHandler1D primaryAxis1DHandler = null;
    public AxisHandler2D primaryAxis2DHandler = null;

    public void OnEnable()
    {
        primaryAxisClickHandler.OnButtonDown += PrintPrimaryButtonDown;
        primaryAxisClickHandler.OnButtonUp += PrintPrimaryButtonUp;

        primaryAxis1DHandler.OnValueChange += PrintPrimaryAxis1D;

        primaryAxis2DHandler.OnValueChange += PrintPrimaryAxis2D;
    }

    public void OnDisable()
    {
        primaryAxisClickHandler.OnButtonDown -= PrintPrimaryButtonDown;
        primaryAxisClickHandler.OnButtonUp -= PrintPrimaryButtonUp;

        primaryAxis1DHandler.OnValueChange -= PrintPrimaryAxis1D;

        primaryAxis2DHandler.OnValueChange -= PrintPrimaryAxis2D;
    }

    private void PrintPrimaryButtonDown(XRController controller)
    {
        Debug.Log("primary button down");
    }
    private void PrintPrimaryButtonUp(XRController controller)
    {
        Debug.Log("primary button up");
    }

    private void PrintPrimaryAxis1D(XRController controller, float value)
    {
        Debug.Log("1D axis value: " + value);
    }

    private void PrintPrimaryAxis2D(XRController controller, Vector2 value)
    {
        Debug.Log("2D axis value: " + value);
    }
}
