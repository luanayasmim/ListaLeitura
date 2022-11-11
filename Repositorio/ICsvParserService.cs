namespace API_Livros.Repositorio
{
    public interface ICsvParserService
    {
        void ReadCSV(string path);
        void WriteCSV(string path);
    }
}
