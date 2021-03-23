using UnityEngine;
using Wakaba;
public class CallTest : MonoSingleton<CallTest>
{
    [SerializeField] private RunnableTest runnableTest;

    [SerializeField] private bool testEnabled = true;

    private void Start()
    {
        CreateInstance();
        FlagAsPersistant();

        RunnableUtils.Setup(ref runnableTest, gameObject, "Emily", new Vector3(1, 1, 1));
    }

    private void Update()
    {
        runnableTest.Enabled = testEnabled;
        RunnableUtils.Run(ref runnableTest, gameObject);
    }
}