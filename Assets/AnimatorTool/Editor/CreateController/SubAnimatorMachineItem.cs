using System.Collections.Generic;
using UnityEngine;

namespace CustomTool
{
    [System.Serializable]
    public class SubAnimatorMachineItem     
    {
        [SerializeField]
        public string SubMachineName;
        [SerializeField]
        public List<GameObject> AnimationObjects = new List<GameObject>();
        /// <summary>
        /// �Ƿ������Ҽ�������Ӷ����ļ�
        /// </summary>
        public bool IsAutoAdd;
    }
}
