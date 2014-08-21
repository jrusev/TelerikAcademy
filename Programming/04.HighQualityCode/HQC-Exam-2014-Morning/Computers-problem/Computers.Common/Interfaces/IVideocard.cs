namespace Computers.Common
{
    public interface IVideocard
    {
        bool IsMonochrome { get; }

        void Draw(string text);
    }
}
