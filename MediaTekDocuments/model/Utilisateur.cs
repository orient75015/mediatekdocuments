namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Utilisateur
    /// </summary>
    public class Utilisateur
    {
        public string Login { get; set; }
        public string Pwd { get; set; }
        public string IdService { get; set; }
        public string Service { get; set; }

        public Utilisateur(string login, string pwd, string idService, string service)
        {
            this.Login = login;
            this.Pwd = pwd;
            this.IdService = idService;
            this.Service = service;
        }
    }
}