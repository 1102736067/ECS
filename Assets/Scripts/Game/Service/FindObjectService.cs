using UnityEngine;

namespace Game.Service
{
    /// <summary>
    /// ���ҳ���������ķ���
    /// </summary>
    public class FindObjectService : IFindObjectService
    {
        public void Init(Contexts contexts)
        {
            contexts.service.SetGameServiceFindObjectService(this);
        }

        public int GetPriority()
        {
            return 0;
        }

        public T[] FindAllType<T>() where T : Object
        {
            T[] temp = Object.FindObjectsOfType<T>();
            if (temp == null || temp.Length == 0)
            {
                Debug.LogError("δ�ҵ����ͣ�" + typeof(T).FullName + "����");
            }
            return temp;
        }

        /// <summary>
        /// ���ҳ����ڵ�View
        /// </summary>
        /// <returns></returns>
        public IView[] FindAllView()
        {
            return FindAllType<ViewBase>();
        }
       
    }
}
