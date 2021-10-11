using UnityEngine;

public class TestInstance : MonoBehaviour
{
    private void Awake()
    {
        var instName = Test.Instance.gameObject.name;
    }
}