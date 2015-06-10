using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace ActivityTrack
{
    public class JsonNamedCollectionResponse<T> : GenericResponse<IEnumerable<T>>
    {
        /// <summary>
        /// Named result
        /// </summary>
        public IEnumerable<T> Result { get; set; }

        public JsonNamedCollectionResponse(HttpRequestMessage request, Func<IEnumerable<T>> getResponseCollection, string collectionName = null)
            : base(request,getResponseCollection, collectionName)
        {            
        }
    }
}