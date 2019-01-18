using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���Ԥ��View
    /// </summary>
    public class PlayerView : ViewService
    {
        public override void Init(Contexts contexts, IEntity entity)
        {
            gameObject.Link(entity, contexts.game);
        }
    }
}
