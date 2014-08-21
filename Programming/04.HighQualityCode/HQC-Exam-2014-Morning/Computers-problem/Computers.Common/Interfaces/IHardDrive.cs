namespace Computers.Common
{
    public interface IHardDrive
    {
        string LoadData(int address);

        void SaveData(int addr, string data);
    }
}
