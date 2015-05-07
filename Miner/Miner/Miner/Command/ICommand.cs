namespace Miner.Command
{
    /// <summary>
    /// ICommand is used to communicate between <see cref="IClient"/>s.
    /// </summary>
    public interface ICommand
    {
        void Execute();
    }
}