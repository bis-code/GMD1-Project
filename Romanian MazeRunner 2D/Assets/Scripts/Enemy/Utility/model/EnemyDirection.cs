using UnityEngine;

namespace Enemy.model
{
    public class EnemyDirection
    {
        public Vector2 moveDirection { get; set; }
        public float rotation { get; set; }

        public EnemyDirection()
        {
        }

        public EnemyDirection(Vector2 moveDirection, float rotation)
        {
            this.moveDirection = moveDirection;
            this.rotation = rotation;
        }
    }
}