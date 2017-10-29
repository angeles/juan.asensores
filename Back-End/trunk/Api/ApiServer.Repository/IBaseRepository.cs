using ApiServer.Repository.Entities;
using System;
using System.Collections.Generic;

namespace ApiServer.Repository
{
	public interface IBaseRepository<TEntity> where TEntity : BaseEntity
	{
		TEntity GetById(Guid id);

		void Add(TEntity entity);

		void Delete(TEntity entity);

		void Delete(Guid id);

		void Update(TEntity entity);

		ICollection<TEntity> GetAll();
	}
}
