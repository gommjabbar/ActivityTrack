using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;


namespace ActivityTrack
{
    /// <summary>
    /// Un HTTP response de tipul application/json care contine in body un obiect serializat in formatul Json folosint un contractResolver
    /// </summary>
    public class JsonContent : HttpContent
    {
        private readonly object _responseValue;
        private IContractResolver _contractResolver;

        /// <summary>
        /// Constructorul principal care seteaza variabila readonly _responseValue serializata in metoda SerializeToStreamAsync si optional si contractResolver folosit pentru serializare
        /// </summary>
        /// <param name="responseValue">Obiectul care va fi serializat si scris in Stream de metoda SerializeToStreamAsync</param>
        /// <param name="contractResolver">Daca parametrul este null sau nespecificat se foloseste o instanta noua de tip DefaultContractResolver</param>
        public JsonContent(object responseValue, IContractResolver contractResolver = null)
        {
            _responseValue = responseValue;
            if (contractResolver == null)
                contractResolver = new DefaultContractResolver();
            _contractResolver = contractResolver;

            Headers.ContentType = new MediaTypeHeaderValue("application/json");
        }

        /// <summary>
        /// Metoda scrie un rezultatul serializarii in json a obiectului _responseValue
        /// </summary>
        protected override Task SerializeToStreamAsync(Stream stream, TransportContext context)
        {
            var jw = new JsonTextWriter(new StreamWriter(stream))
            {
                Formatting = Formatting.Indented
            };

            var jsonSettings = new JsonSerializerSettings()
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = _contractResolver
            };
            var jsonResult = JsonConvert.SerializeObject(_responseValue, jsonSettings);
            jw.WriteRaw(jsonResult);
            jw.Flush();
            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Metoda care nu se foloseste si deci nu este implementata.
        /// </summary>
        protected override bool TryComputeLength(out long length)
        {
            length = -1;
            return false;
        }
    }
}