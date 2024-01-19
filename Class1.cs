namespace quapse
{
    public class Player
    {
        public string Name { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public int Points { get; set; }
        public Weapon CurrentWeapon { get; set; }
        public Aid HealthKit { get; set; }

        public Player(string name, int maxHealth)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            Points = 0;
            CurrentWeapon = null;
            HealthKit = null;

        }

        public void Heal()
        {
            if (HealthKit != null)
            {
                CurrentHealth += HealthKit.HealAmount;
                if (CurrentHealth > MaxHealth)
                    CurrentHealth = MaxHealth;
                HealthKit = null;
            }
        }

        public void Attack(Enemy enemy)
        {
            if (CurrentWeapon != null)
            {
                int damage = CurrentWeapon.Damage;
                enemy.TakeDamage(damage);
            }
        }
    }


    public class Enemy
    {
        public string Name { get; set; }
        public int CurrentHealth { get; set; }
        public int MaxHealth { get; set; }
        public Weapon EnemyWeapon { get; set; }

        public Enemy(string name, int maxHealth, Weapon weapon)
        {
            Name = name;
            MaxHealth = maxHealth;
            CurrentHealth = MaxHealth;
            EnemyWeapon = weapon;
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth < 0)
                CurrentHealth = 0;
        }

        public void Attack(Player player)
        {
            if (EnemyWeapon != null)
            {
                int damage = EnemyWeapon.Damage;
                player.CurrentHealth -= damage;
                if (player.CurrentHealth < 0)
                    player.CurrentHealth = 0;
            }
        }
    }

    public class Aid
    {
        public string Name { get; set; }
        public int HealAmount { get; set; }

        public Aid(string name, int healAmount)
        {
            Name = name;
            HealAmount = healAmount;
        }
    }
    public class Weapon
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Durability { get; set; }

        public Weapon(string name, int damage, int durability)
        {
            Name = name;
            Damage = damage;
            Durability = durability;
        }
    }
}