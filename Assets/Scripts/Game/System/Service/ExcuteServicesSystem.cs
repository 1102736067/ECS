using Entitas;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���÷��񲿷ֵ�֡����
    /// </summary>
    public class ExcuteServicesSystem : IExecuteSystem     
    {
        private Contexts _contexts;
        private Services _services;

        public ExcuteServicesSystem(Contexts contexts, Services services)        
        {
            _contexts = contexts;
            _services = services;
        }

        public void Execute()
        {
            _services.UnityInputService.Update();
        }
    }
}
