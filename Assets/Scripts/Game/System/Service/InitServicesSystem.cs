using Entitas;
using Game.Service;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ��ʼ������ϵͳ
    /// </summary>
    public class InitServicesSystem : IInitializeSystem
    {
        private Contexts _contexts;
        private ServiceManager _services;

        public InitServicesSystem(Contexts contexts,ServiceManager services)
        {
            _contexts = contexts;
            _services = services;
        }

        public void Initialize()
        {
            InitUniqueComponents(_contexts, _services);

            InitServices(_contexts, _services);
        }

        private void InitServices(Contexts contexts, ServiceManager service)
        {
            //service.EntitasInputService.Init(contexts);
            //service.UnityInputService.Init(contexts);
        }

        /// <summary>
        /// ��ʼ���������
        /// </summary>
        /// <param name="contexts"></param>
        /// <param name="services"></param>
        private void InitUniqueComponents(Contexts contexts, ServiceManager services)
        {
            
           
            
            
        }
    }
}
