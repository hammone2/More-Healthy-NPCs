public interface IHealth
{
    event System.Action<float, float> OnHPPctChanged;
    event System.Action OnDied;
    void TakeDamage(int amount);
}