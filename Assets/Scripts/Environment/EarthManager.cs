using System;
using Data;
using Unity.Mathematics;
using UnityEngine;

namespace Environment
{
    [DefaultExecutionOrder(-3)]
    public class EarthManager : MonoBehaviour
    {
        public static EarthManager Instance;
        [SerializeField] private EnvData envData;

        public GameObject FirstEarth => envData.firstEarth;
        public GameObject RockyEarth => envData.rockyEarth;

        private void Awake()
        {
            Instance = this;

            var earth = Instantiate(FirstEarth, transform.position, quaternion.identity);
            earth = FirstEarth;
        }
    }
}
