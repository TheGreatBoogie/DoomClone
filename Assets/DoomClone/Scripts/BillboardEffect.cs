using UnityEngine;

public class BillboardEffect : MonoBehaviour
{

    [SerializeField] private bool freezeXZAxis = true;

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 cameraAngle = Camera.main.transform.rotation.eulerAngles;

        if (freezeXZAxis)
        {
            transform.rotation = Quaternion.Euler(0f, cameraAngle.y , 0f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(cameraAngle.x, cameraAngle.y , cameraAngle.z);
        }
    }
}