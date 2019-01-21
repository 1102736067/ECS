using System.Linq;
using Game.Service;
using UnityEngine;

namespace Game
{
    /// <summary>
    /// ���ҳ���������ķ���
    /// </summary>
    public class FindObjectService : IFindObjectService
    {
        public void Init(Contexts contexts)
        {
            contexts.game.SetGameFindObjectService(this);
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
            return FindAllType<ViewService>();
        }
       
    }
}
