using System;

public class DamageManager
{
    Random random;

    public float GenerateDamage(float min, float max, float power)
    {
        random = new Random();

        float temp = random.Next((int)max);
        return (temp + min) * power;
        
    }
}