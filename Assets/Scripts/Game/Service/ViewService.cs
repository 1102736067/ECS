using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// View�����
    /// </summary>
    public abstract class ViewService : MonoBehaviour, IView
    {
        public abstract void Init(Contexts contexts, IEntity entity);
    }
}
