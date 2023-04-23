using Enemy.model;
using Unity.VisualScripting;
using UnityEngine;

namespace Enemy
{
    public class EnemyUtility
    {
        private static EnemyUtility instance;

        public EnemyDirection UpdateEnemyDirection(Transform target, Transform enemyTransform, EnemyDirection enemyDirection)
        {
            if (!target.IsUnityNull())
            {
                Vector3 direction = (target.position - enemyTransform.position).normalized;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                
                enemyDirection.rotation = angle;
                enemyDirection.moveDirection = direction;
            }
            return enemyDirection;
        }
        
        public static EnemyUtility GetInstance()
        {
            if (instance == null)
            {
                instance = new EnemyUtility();
            }
            return instance;
        }
    }
}