using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ��ʼ������View
    /// </summary>
    public class InitViewSystem : IInitializeSystem
    {
        private Contexts _contexts;

        public InitViewSystem(Contexts contexts)
        {
            _contexts = contexts;
        }

        public void Initialize()
        {
            //var views = _contexts.game.gameFindObjectService.FindObjectService.FindAllView();
            //foreach (IView view in views)
            //{
            //    view.Init();
            //}
        }
    }
}
