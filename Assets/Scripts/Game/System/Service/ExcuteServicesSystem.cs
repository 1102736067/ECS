using Entitas;
using Game.Service;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���÷��񲿷ֵ�֡����
    /// </summary>
    public class ExcuteServicesSystem : IExecuteSystem     
    {
        private Contexts _contexts;
        private ServiceManager _services;

        public ExcuteServicesSystem(Contexts contexts, ServiceManager services)        
        {
            _contexts = contexts;
            _services = services;
        }

        public void Execute()
        {
            //_services.UnityInputService.Update();
        }
    }
}
