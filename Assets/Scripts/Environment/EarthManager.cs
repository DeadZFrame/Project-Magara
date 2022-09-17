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

        public Material FirstEarth => envData.firstEarth;
        public Material RockyEarth => envData.rockyEarth;

        private void Awake()
        {
            Instance = this;
        }
    }
}
