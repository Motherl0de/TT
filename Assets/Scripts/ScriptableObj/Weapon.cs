using UnityEngine;

namespace TT
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapon/New Weapon")]
    public sealed class Weapon : ScriptableObject
    {
        [SerializeField] private string _nameWeapon;
        [SerializeField] private int _takeDamage;
        [SerializeField] private GameObject _prefab;

        public string NameWeapon
        {
            get { return _nameWeapon; }
        }

        public int TakeDamage
        {
            get { return _takeDamage; }
        }

        public GameObject Prefab
        {
            get { return _prefab; }
        }
    }
}
