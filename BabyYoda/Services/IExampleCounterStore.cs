namespace MauiAppShellMvvm.Services
{
    public interface IExampleCounterStore
    {
        int GetLatestCounter();
        void UpdateCounter(int counterValue);
    }
}
