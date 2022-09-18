using Environment;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CameraScript
{
    public class CustomCamera : MonoBehaviour
    {
        private Transform Earth => EarthManager.Instance.transform;
        [SerializeField] private Transform earth;
        private void Update()
        {
            if (SceneManager.GetActiveScene().buildIndex == 0)
            {
                transform.RotateAround(earth.position, Vector3.up, 5 * Time.deltaTime);
            }
            else
            {
                transform.RotateAround(Earth.position, Vector3.up, 5 * Time.deltaTime);
            }
        }
    }
}
