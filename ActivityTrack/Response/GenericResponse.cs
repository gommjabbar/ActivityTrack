using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace ActivityTrack
{
    /// <summary>
    /// A reusable IHttpActionResult implementation that returns an HttpResponseMessage from ExecuteAsync that has an IResponseObject serialized as json in its Content
    /// </summary>
    public abstract class GenericResponse<T> : IHttpActionResult
    {
        /// <summary>
        /// A stopwatch that should be started as soon as possible and used to set the duration of IResponseObject after _getResponseMethod is executed
        /// </summary>
        protected Stopwatch _stopwatch;

        /// <summary>
        /// The request message that requires a response
        /// </summary>
        protected HttpRequestMessage _requestMessage;
        /// <summary>
        /// An optional custom contract resolver that will be used for serialization
        /// </summary>
        protected IContractResolver _contractResolver;
        /// <summary>
        /// A delegate of the method that will generate the response object
        /// </summary>
        protected Func<T> _getResponseMethod;

        /// <summary>
        /// The response object of the function _getResponseMethod
        /// </summary>
        protected object _responseObject;

        protected string _wrapperPropertyName;

        /// <summary>
        /// Creates a new instace and starts a new _stopwatch 
        /// </summary>
        /// <param name="request">The request for which the HttpResponseMessage is needed</param>
        /// <param name="getResponseMethod">The method that gets called in ExecuteAsync and whose return value will populate the result object in the json</param>
        public GenericResponse(HttpRequestMessage request, Func<T> getResponseMethod = null, string wrapperPropertyName = null)
        {
            _stopwatch = Stopwatch.StartNew();
            _requestMessage = request;
            _getResponseMethod = getResponseMethod;
            _wrapperPropertyName = wrapperPropertyName;
        }

        /// <summary>
        /// Creates a new instace, starts a new _stopwatch and imposes a custom contract resolver
        /// </summary>
        /// <param name="request">The request for which the HttpResponseMessage is needed</param>
        /// <param name="contractResolver">A custom contract resolver that will be used for serialization</param>
        /// <param name="getResponseMethod">The method that gets called in ExecuteAsync and whose return value will populate the result object in the json</param>
        public GenericResponse(HttpRequestMessage request, IContractResolver contractResolver, Func<T> getResponseMethod = null)
            : this(request, getResponseMethod)
        {
            _contractResolver = contractResolver;
        }

        /// <summary>
        /// This method is automatically and asynchronously executed by the web.api 2.0 controllers
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public virtual Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            try
            {
                return Task.FromResult(CreateResponseMessage());
            }
            catch (Exception ex)
            {
                return Task.FromResult(CreateErrorResponseForException(ex));
            }

        }

        /// <summary>
        /// This method will create the response messge with a json object content
        /// </summary>
        /// <returns></returns>
        protected virtual HttpResponseMessage CreateResponseMessage()
        {
            if (_getResponseMethod == null)
            {
                throw new Exception("Not implemented");
            }
            _responseObject = _getResponseMethod();

            if (!string.IsNullOrEmpty( _wrapperPropertyName))
            {
                // wrap response object around a property 
                var x = new ExpandoObject() as IDictionary<string, Object>;
                x.Add(_wrapperPropertyName, _responseObject);
                _responseObject = x;
            }

            var jsonContent = new JsonContent(_responseObject, _contractResolver);

            var response = new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = jsonContent,
                RequestMessage = _requestMessage
            };
            return response;
        }

        protected virtual HttpResponseMessage CreateErrorResponseForException(Exception ex)
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.InternalServerError,
                Content = new JsonContent(new
                {
                    ex.Message
                }),
                RequestMessage = _requestMessage
            };
        }
    }
}