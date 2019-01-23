using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// View�����
    /// </summary>
    public abstract class ViewBase : MonoBehaviour, IView
    {
        public virtual void Init(Contexts contexts, IEntity entity)
        {
            gameObject.Link(entity, contexts.game);
        }
    }
}
