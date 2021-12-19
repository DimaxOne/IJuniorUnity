using UnityEngine;

public class UZI : Weapon
{
    [SerializeField] private int _bulletsCountOneShot;

    public override void Shoot(Transform shootPoint)
    {
        for (int i = 0; i < _bulletsCountOneShot; i++)
        {
            Instantiate(Bullet, new Vector2 (shootPoint.position.x + (i/1), shootPoint.position.y), Quaternion.identity);
        }
    }
}
