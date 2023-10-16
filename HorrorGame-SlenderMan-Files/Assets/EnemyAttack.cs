using System;

class Player
{
    public int Health { get; set; }

    public Player(int health)
    {
        Health = health;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"Player took {damage} damage. Remaining health: {Health}");
    }
}

class Enemy
{
    public int Damage { get; set; }

    public Enemy(int damage)
    {
        Damage = damage;
    }

    public void Attack(Player player)
    {
        Console.WriteLine("Enemy attacks!");
        player.TakeDamage(Damage);
    }
}

class Program
{
    static void Main()
    {
        Player player = new Player(100);
        Enemy enemy = new Enemy(10);

        while (player.Health > 0)
        {
            enemy.Attack(player);
            Console.WriteLine();

            // You can add more game logic here, such as player attacking back or game over conditions.
        }

        Console.WriteLine("Game Over - Player is defeated.");
    }
}
