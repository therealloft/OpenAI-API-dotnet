﻿using OpenAI_API.Embedding;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OpenAI.Polly
{
    public static partial class OpenAIAPIExtensions
    {
        /// <summary>
        /// Executes a given asynchronous function with retry logic, handling rate limits for the OpenAI API.
        /// </summary>
        /// <typeparam name="TResult">The type of the result returned by the function.</typeparam>
        /// <param name="endpoint">The endpoint on which the function is executed.</param>
        /// <param name="func">The asynchronous function to be executed with retry logic.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public static Task<TResult> WithRetry<TResult>(this IEmbeddingEndpoint endpoint, Func<IEmbeddingEndpoint, Task<TResult>> func)
        {
            return AsyncRetryPolicy.ExecuteAsync(() => func(endpoint));
        }
    }
}
