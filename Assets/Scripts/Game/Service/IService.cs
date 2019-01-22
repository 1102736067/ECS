using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// ��ʼ������ӿ�
    /// </summary>
    public interface IInitService
    {
        void Init(Contexts contexts);
        /// <summary>
        /// ��ȡִ�����ȼ�
        /// </summary>
        /// <returns></returns>
        int GetPriority();
    }

    /// <summary>
    /// ֡�����ӿ�
    /// </summary>
    public interface IExecuteService
    {
        void Excute();
    }
}
