﻿using AirplaneProject.Core.Interfaces;
using AirplaneProject.Core.Messages;
using AirplaneProject.Core.Models.Results;
using AirplaneProject.Domain.Bases;
using System;
using System.Threading.Tasks;

namespace AirplaneProject.Core.Models.Validations
{
    public class EntityValidation<TEntity> : IEntityValidation<TEntity>
		where TEntity : Entity
	{
		private readonly IRepository<TEntity> repository;

		public EntityValidation(IRepository<TEntity> repository)
		{
			this.repository = repository;
		}

		public async Task<ISingleResult<TEntity>> RegistroExiste(int id, params string[] includes)
		{
			var entity = await repository.GetById(id, includes);
			if (entity == null)
			{
				return new SingleResult<TEntity>(MensagensNegocio.MSG04);
			}

			return new SingleResult<TEntity>(entity);
		}

		public async Task<ISingleResult<TEntity>> RegistroComMesmoCodigo(int id, string codigo)
		{
			var result = await repository.ValueExists(id, codigo);
			if (result)
			{
				return new SingleResult<TEntity>(MensagensNegocio.MSG08);
			}

			return new SingleResult<TEntity>();
		}
    }
}
