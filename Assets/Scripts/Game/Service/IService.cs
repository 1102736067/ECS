using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// ��ʼ������ӿ�
    /// </summary>
    public interface IInitService
    {
        void Init(Contexts contexts);
    }

    /// <summary>
    /// ֡�����ӿ�
    /// </summary>
    public interface IExecuteService
    {
        void Excute();
    }
}
