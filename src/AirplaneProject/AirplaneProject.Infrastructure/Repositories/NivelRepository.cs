﻿using AirplaneProject.Infrastructure.Data;
using AirplaneProject.Domain.Models;
using AirplaneProject.Infrastructure.Bases;
using AirplaneProject.Core.Repositories;

namespace AirplaneProject.Infrastructure.Repositories
{
	public class NivelRepository : Repository<Nivel>, INivelRepository
	{
		public NivelRepository(GestaoEsdContext context)
			: base(context)
		{
		}
	}
}