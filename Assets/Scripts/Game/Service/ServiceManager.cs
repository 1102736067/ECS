

using System.Collections.Generic;
using System.Linq;
using Manager.Parent;
using Module.Timer;
using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// �������������ӿ�
    /// </summary>
    public interface IServiceManager : IInitService, IExecuteService
    {

    }

    public class ServiceManager : IServiceManager
    {
        private Dictionary<int, HashSet<IInitService>> _initServices;
        private HashSet<IExecuteService> _executeServices;

        public ServiceManager(GameParentManager parentManager)
        {
            _initServices = new Dictionary<int, HashSet<IInitService>>();
            _executeServices = new HashSet<IExecuteService>();

            IInitService[] services = InitServices(parentManager);

            AddInitServices(services);
            AddExecuteServices(services);

            var result = from temp in _initServices orderby temp.Key select temp;
            _initServices = result.ToDictionary(pair => pair.Key, pair => pair.Value);
        }

        /// <summary>
        /// ��ʼ������������鷽��
        /// </summary>
        /// <param name="parentManager"></param>
        /// <returns></returns>
        private IInitService[] InitServices(GameParentManager parentManager)
        {
            IInitService[] services =
            {
                new FindObjectService(),
                new EntitasInputService(),
                new LogService(),
                new LoadService(parentManager),
                new TimerService(new TimerManager()),
                new UnityInputService()
            };

            return services;
        }

        public void Init(Contexts contexts)
        {
            foreach (var service in _initServices)
            {
                foreach (IInitService initService in service.Value)
                {
                    initService.Init(contexts);
                }
            }
        }

        public int GetPriority()
        {
            throw new System.NotImplementedException();
        }

        public void Excute()
        {
            foreach (IExecuteService service in _executeServices)
            {
                service.Excute();
            }
        }

        private void AddInitServices(IInitService[] services)
        {
            foreach (var service in services)
            {
                AddInitService(service.GetPriority(),service);
            }
        }

        private void AddExecuteServices(IInitService[] services)
        {
            foreach (var service in services)
            {
                IExecuteService temp = service as IExecuteService;
                if (temp != null)
                {
                    AddExecuteService(temp);
                }
            }
        }

        /// <summary>
        /// ��ӳ�ʼ��������� ��һ������Ϊ���ȼ���0��ʼ
        /// </summary>
        /// <param name="service"></param>
        private void AddInitService(int priority, IInitService service)
        {
            if (priority < 0)
            {
                Debug.LogError("���ȼ���0��ʼ������Ϊ��");
                return;
            }
            if (!_initServices.ContainsKey(priority))
            {
                _initServices[priority] = new HashSet<IInitService>();
            }

            _initServices[priority].Add(service);
        }

        /// <summary>
        /// ���֡�����������
        /// </summary>
        /// <param name="service"></param>
        private void AddExecuteService(IExecuteService service)
        {
            _executeServices.Add(service);
        }

    }
}
