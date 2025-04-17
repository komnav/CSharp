namespace Lesson_8;

public class User
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    int _balance;

    public int Balance
    {
        get { return _balance; }

        set
        {
            if (value >= 0)
            {
                _balance = value;
            }

            else
            {
                _balance = 0;
            }
        }
    }

    Lock _lockBalance = new Lock();

    public void Withdraw(int amount)
    {
        lock (_lockBalance)
        {
            if (Balance > 0)
            {
                if (Balance > amount)
                {
                    Balance -= amount;
                }
            }

            else
            {
                throw new Exception("Not enough money");
            }
        }
    }
}