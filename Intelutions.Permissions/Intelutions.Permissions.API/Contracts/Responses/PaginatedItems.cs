//---------------------------------------------------------------------------
// <copyright file="PaginatedItems.cs" company="Intelutions">
// Copyright (c) 2021 Todos los derechos reservados.
// </copyright>
// <created><author>apedrozo</author><date>21-feb-2021</date></created>
//---------------------------------------------------------------------------
namespace Intelutions.Permissions.API.Contracts.Responses
{
    using System.Collections.Generic;

    /// <summary>
    /// Define las propiedades de un listado de objetos.
    /// </summary>
    /// <typeparam name="TEntity">Tipo de entidad a paginar.</typeparam>
    public class PaginatedItems<TEntity> where TEntity : class
    {
        /// <summary>
        /// Indice de página.
        /// </summary>
        public int PageIndex { get; private set; }

        /// <summary>
        /// Tamaño de página.
        /// </summary>
        public int PageSize { get; private set; }

        /// <summary>
        /// Número total de registros.
        /// </summary>
        public long Count { get; private set; }

        /// <summary>
        /// Listado de objetos.
        /// </summary>
        public IEnumerable<TEntity> Data { get; private set; }

        /// <summary>
        /// Establece la información las propiedades del objeto.
        /// </summary>
        /// <param name="pageIndex">Indice de página.</param>
        /// <param name="pageSize">Tamaño de página.</param>
        /// <param name="count">Número total de registros.</param>
        /// <param name="data">Listado de objetos.</param>
        public PaginatedItems(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data)
        {
            this.PageIndex = pageIndex;
            this.PageSize = pageSize;
            this.Count = count;
            this.Data = data;
        }
    }
}
