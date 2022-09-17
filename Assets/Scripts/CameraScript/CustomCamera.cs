using Environment;
using UnityEngine;
using UnityEngine.Networking;

namespace CameraScript
{
    public class CustomCamera : MonoBehaviour
    {
        private Transform Earth => EarthManager.Instance.gameObject.transform;
        private void Update()
        {
            transform.RotateAround(Earth.position, Vector3.up, 5 * Time.deltaTime);
        }
    }
}
