using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���ҳ������������ӿ�
    /// </summary>
    public interface IFindObjectService
    {
        T[] FindAllType<T>() where T : Object;
        IView[] FindAllView();
    }
}
