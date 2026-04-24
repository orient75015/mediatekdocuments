using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using System.Linq;
using NLog;

namespace MediaTekDocuments.dal
{
    public class Access
    {
        private static readonly string uriApi = System.Configuration.ConfigurationManager.AppSettings["uriApi"];
        private static Access instance = null;
        private readonly ApiRest api = null;
        private const string GET = "GET";
        private const string POST = "POST";
        private const string PUT = "PUT";
        private const string DELETE = "DELETE";
        private const string CHAMPS = "champs=";
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private Access()
        {
            String authenticationString;
            try
            {
                authenticationString = System.Configuration.ConfigurationManager.AppSettings["apiCredentials"];
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                logger.Error(e, e.Message);
                Environment.Exit(0);
            }
        }

        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre", null);
            return new List<Categorie>(lesGenres);
        }

        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon", null);
            return new List<Categorie>(lesRayons);
        }

        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public", null);
            return new List<Categorie>(lesPublics);
        }

        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre", null);
            return lesLivres;
        }

        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd", null);
            return lesDvd;
        }

        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue", null);
            return lesRevues;
        }

        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument, null);
            return lesExemplaires;
        }

        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try
            {
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire", CHAMPS + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
            return false;
        }

        public List<Suivi> GetAllSuivis()
        {
            List<Suivi> lesSuivis = TraitementRecup<Suivi>(GET, "suivi", null);
            return lesSuivis;
        }

        public List<CommandeDocument> GetCommandesDocument(string idLivreDvd)
        {
            String jsonId = convertToJson("id", idLivreDvd);
            List<CommandeDocument> lesCommandes = TraitementRecup<CommandeDocument>(GET, "commandedocument/" + jsonId, null);
            return lesCommandes;
        }

        public bool CreerCommandeDocument(CommandeDocument commande)
        {
            String jsonCommande = JsonConvert.SerializeObject(commande, new CustomDateTimeConverter());
            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(POST, "commandedocument", CHAMPS + jsonCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
            return false;
        }

        public bool ModifierSuiviCommande(CommandeDocument commande)
        {
            String jsonCommande = JsonConvert.SerializeObject(commande, new CustomDateTimeConverter());
            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(PUT, "commandedocument/" + commande.Id, CHAMPS + jsonCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
            return false;
        }

        public bool SupprimerCommandeDocument(string id)
        {
            String jsonId = convertToJson("id", id);
            try
            {
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(DELETE, "commandedocument/" + jsonId, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
            return false;
        }

        private List<T> TraitementRecup<T>(String methode, String message, String parametres)
        {
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message, parametres);
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    logger.Warn("code erreur = " + code + " message = " + (String)retour["message"]);
                }
            }
            catch (Exception e)
            {
                logger.Error(e, "Erreur lors de l'accès à l'API : " + e.Message);
                Environment.Exit(0);
            }
            return liste;
        }

        private static String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);
            return JsonConvert.SerializeObject(dictionary);
        }

        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

        /// <summary>
        /// Retourne les commandes d'une revue (abonnements)
        /// </summary>
        public List<CommandeRevue> GetCommandesRevue(string idRevue)
        {
            String jsonId = convertToJson("id", idRevue);
            List<CommandeRevue> lesCommandes = TraitementRecup<CommandeRevue>(GET, "abonnement/" + jsonId, null);
            return lesCommandes;
        }

        /// <summary>
        /// Crée une commande de revue (abonnement)
        /// </summary>
        public bool CreerCommandeRevue(CommandeRevue commande)
        {
            String jsonCommande = JsonConvert.SerializeObject(commande, new CustomDateTimeConverter());
            try
            {
                List<CommandeRevue> liste = TraitementRecup<CommandeRevue>(POST, "abonnement", CHAMPS + jsonCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Supprime une commande de revue
        /// </summary>
        public bool SupprimerCommandeRevue(string id)
        {
            String jsonId = convertToJson("id", id);
            try
            {
                List<CommandeRevue> liste = TraitementRecup<CommandeRevue>(DELETE, "abonnement/" + jsonId, null);
                return (liste != null);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Retourne les revues dont l'abonnement se termine dans moins de 30 jours
        /// </summary>
        public List<CommandeRevue> GetAbonnementsExpiresBientot()
        {
            List<CommandeRevue> lesAbonnements = TraitementRecup<CommandeRevue>(GET, "abonnement/expiresbientot", null);
            return lesAbonnements;
        }

        /// <summary>
        /// Retourne l'utilisateur correspondant au login/pwd ou null si introuvable
        /// </summary>
        public Utilisateur GetUtilisateur(string login, string pwd)
        {
            String jsonChamps = convertToJson("login", login);
            List<Utilisateur> lesUtilisateurs = TraitementRecup<Utilisateur>(GET, "utilisateur/" + jsonChamps, null);
            if (lesUtilisateurs != null && lesUtilisateurs.Count > 0)
            {
                Utilisateur utilisateur = lesUtilisateurs[0];
                if (utilisateur.Pwd.Equals(pwd))
                {
                    return utilisateur;
                }
            }
            return null;
        }
    }
}
