namespace API_Livros.Helpers
{
    public interface ISendEmail
    {
        bool Send(string email, string subject, string compose);
    }
}
