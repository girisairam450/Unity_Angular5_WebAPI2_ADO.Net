﻿using API_Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using Unity_Angular5_WebAPI2_ADO.Common.Exceptions;

namespace Services_WebApi2.Controllers
{
    public class BaseApiController : ApiController
    {
        #region Post methods

        protected async Task<IHttpActionResult> PostAsync<TEntity, TKey>(Func<TEntity, Task<TKey>> execPostAsync, TEntity entity)
            where TEntity : class
            where TKey : struct
        {
            var entityKeyValue = await execPostAsync(entity);
            return Ok(entityKeyValue);
        }

        protected async Task<IHttpActionResult> PostWithResultAsync<TEntity, TResult>(Func<TEntity, Task<TResult>> execPostAsync, TEntity entity)
            where TEntity : class
            where TResult : class
        {
            var result = await execPostAsync(entity);

            return Ok(result);
        }

        #endregion

        #region Put methods

        /// <exception cref="EntityNotFoundException">If entity does not exist</exception>
        protected async Task<IHttpActionResult> PutAsync<TEntity>(Func<TEntity, Task> execPutAsync, TEntity entity)
            where TEntity : class
        {
            await execPutAsync(entity);

            return Ok();
        }

        /// <exception cref="EntityNotFoundException">If entity does not exist</exception>
        protected async Task<IHttpActionResult> PutWithResultAsync<TEntity, TResult>(Func<TEntity, Task<TResult>> execPutAsync, TEntity entity)
            where TEntity : class
            where TResult : class
        {
            var result = await execPutAsync(entity);

            return Ok(result);
        }

        #endregion

        #region Delete methods

        /// <exception cref="EntityNotFoundException">If entity does not exist</exception>
        protected async Task<IHttpActionResult> DeleteAsync<TKey>(Func<TKey, Task> execDeleteAsync, TKey entityKeyValue)
            where TKey : struct
        {
            await execDeleteAsync(entityKeyValue);

            return Ok();
        }

        protected async Task<IHttpActionResult> DeleteWithResultAsync<TKey, TResult>(Func<TKey, Task<TResult>> execDeleteAsync, TKey entityKeyValue)
            where TKey : struct
        {
            var result = await execDeleteAsync(entityKeyValue);

            return Ok(result);
        }
        protected async Task<IHttpActionResult> DeleteEntityAsync<TEntity>(Func<TEntity, Task> execDeleteAsync, TEntity entityKeyValue)
            where TEntity : class
        {
            await execDeleteAsync(entityKeyValue);

            return Ok();
        }

        #endregion

        #region Get methods

        protected async Task<IHttpActionResult> GetAllAsync<TEntity>(Func<Task<IEnumerable<TEntity>>> execGetAsync)
            where TEntity : class
        {
            var entities = await execGetAsync();
            return Ok(entities);
        }

        protected async Task<IHttpActionResult> GetAllWithPagingAsync<TEntity>(Func<int, int, Task<PageContainer<TEntity>>> execGetAsync, int skip, int take)
            where TEntity : class
        {
            var page = await execGetAsync(skip, take);
            return Ok(page);
        }

        protected async Task<IHttpActionResult> GetAllWithPagingAsync<TEntity>(Func<int, int, Task<PageContainerCombined<TEntity>>> execGetAsync, int skip, int take)
            where TEntity : class
        {
            var page = await execGetAsync(skip, take);
            return Ok(page);
        }

        protected async Task<IHttpActionResult> GetAllByFilterAsync<TEntity, TFilter>(Func<TFilter, Task<IEnumerable<TEntity>>> execGetAsync, TFilter filter)
            where TEntity : class
        {
            var entities = await execGetAsync(filter);
            return Ok(entities);
        }

        protected async Task<IHttpActionResult> GetAllByFilterWithPagingAsync<TEntity, TFilter>(Func<TFilter, int, int, Task<PageContainer<TEntity>>> execGetAsync, TFilter filter, int skip, int take)
            where TEntity : class
        {
            var page = await execGetAsync(filter, skip, take);
            return Ok(page);
        }

        /// <exception cref="EntityNotFoundException">If entity does not exist</exception>
        protected async Task<IHttpActionResult> GetSingleByKeyAsync<TEntity, TKey>(Func<TKey, Task<TEntity>> execGetAsync, TKey entityKeyValue)
            where TEntity : class
        {
            var entity = await execGetAsync(entityKeyValue);

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return Ok(entity);
        }

        /// <exception cref="EntityNotFoundException">If entity does not exist</exception>
        protected async Task<IHttpActionResult> GetSingleAsync<TEntity>(Func<Task<TEntity>> execGetAsync)
            where TEntity : class
        {
            var entity = await execGetAsync();

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return Ok(entity);
        }

        /// <exception cref="EntityNotFoundException">If entity does not exist</exception>
        protected IHttpActionResult GetSingle<TEntity>(Func<TEntity> execGet)
            where TEntity : class
        {
            var entity = execGet();

            if (entity == null)
            {
                throw new EntityNotFoundException();
            }

            return Ok(entity);
        }

        protected async Task<IHttpActionResult> GetFileAsync(Func<Task<byte[]>> getBytesAsync, string fileName, string mimeType)
        {
            var bytes = await getBytesAsync();
            var response = Request.CreateResponse(HttpStatusCode.OK, 0);

            response.Content = new ByteArrayContent(bytes);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
            response.Content.Headers.ContentLength = bytes.Length;

            return ResponseMessage(response);
        }

        protected IHttpActionResult GetFile(byte[] bytes, string fileName, string mimeType)
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, 0);

            response.Content = new ByteArrayContent(bytes);
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue(mimeType);
            response.Content.Headers.ContentLength = bytes.Length;

            return ResponseMessage(response);
        }

        #endregion

    }
}
