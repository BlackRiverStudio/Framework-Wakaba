using System.Collections.Generic;
using UnityEngine;
namespace Wakaba.Utils.Comparers
{
    public class GameObjectComparer : IComparer<GameObject>
    {
        readonly GameObject gameObject;
        public GameObjectComparer(string _name) => gameObject = new GameObject { name = _name };

        public int Compare(GameObject _x, GameObject _y)
        {
            for (int i = 0; i < Mathf.Min(_x.name.Length, _y.name.Length); i++)
            {
                int xLetter = _x.name.ToLower()[i];
                int yLetter = _y.name.ToLower()[i];

                if (xLetter < yLetter) return -1;
                else if (xLetter > yLetter) return 1;
            }
            return _x.name.Length - _y.name.Length;
        }
    }
}