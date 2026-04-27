namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Service
    /// </summary>
    public class Service
    {
        /// <summary>Identifiant du service</summary>
        public string Id { get; set; }

        /// <summary>Libellé du service</summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Constructeur de la classe Service
        /// </summary>
        /// <param name="id">Identifiant du service</param>
        /// <param name="libelle">Libellé du service</param>
        public Service(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Retourne le libellé du service
        /// </summary>
        /// <returns>Libellé du service</returns>
        public override string ToString()
        {
            return this.Libelle;
        }
    }
}