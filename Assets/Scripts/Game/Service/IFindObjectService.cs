using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// ���ҳ������������ӿ�
    /// </summary>
    public interface IFindObjectService : IInitService
    {
        T[] FindAllType<T>() where T : Object;
        IView[] FindAllView();
    }
}
