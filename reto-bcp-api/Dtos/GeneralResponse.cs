﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace reto_bcp_api.Dtos
{
    public class GeneralResponse<T>
    {
        /// <summary>
        /// Gets or sets whether was succeed
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Gets or sets message
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets data
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Build result with succeed true and null message
        /// </summary>
        /// <typeparam name="T2">Type of data</typeparam>
        /// <param name="data">data</param>
        /// <returns>result model</returns>
        public static GeneralResponse<T2> BuildOk<T2>(T2 data)
        {
            return Build(true, null, data);
        }

        /// <summary>
        /// Build result with succeed false
        /// </summary>
        /// <typeparam name="T2">Type of data</typeparam>
        /// <param name="message">message</param>
        /// <param name="data">data</param>
        /// <returns>Result model</returns>
        public static GeneralResponse<T2> BuildBad<T2>(string message, T2 data)
        {
            return Build(false, message, data);
        }

        /// <summary>
        /// Build a result
        /// </summary>
        /// <typeparam name="T2">Type of data</typeparam>
        /// <param name="success">True or false</param>
        /// <param name="message">The message</param>
        /// <param name="data">The data</param>
        /// <returns>Result model</returns>
        public static GeneralResponse<T2> Build<T2>(bool success, string message, T2 data)
        {
            return new GeneralResponse<T2>
            {
                Success = success,
                Message = message,
                Data = data
            };
        }
    }
}
