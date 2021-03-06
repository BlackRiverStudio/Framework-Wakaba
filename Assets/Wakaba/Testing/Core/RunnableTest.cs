using UnityEngine;
using Wakaba;
using Wakaba.Mobile;
public class RunnableTest : RunnableBehaviour
{
    [SerializeField] private TextMesh namePlate;
    [SerializeField, Tag] private string groundTag;
    [SerializeField, SceneField] private string otherLevel;

    protected override void OnRun(params object[] _params)
    {
        transform.position += transform.forward * MobileInput.GetJoystickAxis(JoystickAxis.Vertical) * Time.deltaTime;
        transform.position += transform.right * MobileInput.GetJoystickAxis(JoystickAxis.Horizontal) * Time.deltaTime;
    }

    protected override void OnSetup(params object[] _params)
    {
        string username = (string)_params[0];
        Vector3 spawnPoint = (Vector3)_params[1];

        namePlate.text = username;
        transform.position = spawnPoint;

        MobileInput.Initialise();
    }
}