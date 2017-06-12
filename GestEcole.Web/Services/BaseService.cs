using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace GestEcole.Web.Services
{
    public class BaseService<T>
    {
        /// <summary>
        /// Obtient le contenu désérialisé du fichier
        /// </summary>
        /// <param name="fileName">Fichier à déserialiser</param>
        /// <returns></returns>
        protected List<T> Deserialize(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (XmlReader xmlReader = new XmlTextReader(fileName))
            {
                try
                {
                    object tmp = serializer.Deserialize(xmlReader);
                    return (List<T>)tmp;
                }
                finally
                {
                    xmlReader.Close();
                    serializer = null;
                }
            }
        }

        /// <summary>
        /// Sérialise les données sous forme d'un arbre XML
        /// </summary>
        /// <param name="data">Données à sauvegarder</param>
        /// <param name="fileName">Données à sauvegarder</param>
        protected void Serialize(IEnumerable<T> data, string fileName)
        {
            // Sauvegarde dans le fichier XML
            XmlSerializer serializer = new XmlSerializer(typeof(List<T>));
            using (XmlWriter xmlWriter = new XmlTextWriter(fileName, Encoding.UTF8))
            {
                try
                {
                    serializer.Serialize(xmlWriter, data);
                }
                finally
                {
                    xmlWriter.Close();
                    serializer = null;
                }
            }
        }
    }
}
