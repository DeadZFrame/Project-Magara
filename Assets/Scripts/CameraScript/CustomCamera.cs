using UnityEngine;

namespace CameraScript
{
    public class CustomCamera : MonoBehaviour
    {
        [SerializeField] private Transform earth;
        private void Update()
        {
            transform.RotateAround(earth.position, Vector3.up, 5 * Time.deltaTime);
        }
    }
}
