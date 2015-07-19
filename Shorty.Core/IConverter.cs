namespace Shorty.Core
{
    public interface IConverter
    {
        string Encode(int id);
        int Decode(string hexId); 
    }
}