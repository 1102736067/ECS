using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// View��ӿ�
    /// </summary>
    public interface IView
    {
        void Init(Contexts contexts,IEntity entity);
    }
}
