namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Utilisateur
    /// </summary>
    public class Utilisateur
    {
        /// <summary>Login de l'utilisateur</summary>
        public string Login { get; set; }

        /// <summary>Mot de passe de l'utilisateur</summary>
        public string Pwd { get; set; }

        /// <summary>Identifiant du service</summary>
        public string IdService { get; set; }

        /// <summary>Libellé du service</summary>
        public string Service { get; set; }

        /// <summary>
        /// Constructeur de la classe Utilisateur
        /// </summary>
        /// <param name="login">Login de l'utilisateur</param>
        /// <param name="pwd">Mot de passe</param>
        /// <param name="idService">Identifiant du service</param>
        /// <param name="service">Libellé du service</param>
        public Utilisateur(string login, string pwd, string idService, string service)
        {
            this.Login = login;
            this.Pwd = pwd;
            this.IdService = idService;
            this.Service = service;
        }
    }
}