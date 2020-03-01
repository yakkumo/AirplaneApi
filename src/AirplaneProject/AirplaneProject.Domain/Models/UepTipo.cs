﻿using AirplaneProject.Domain.Bases;
using System.Collections.Generic;

namespace AirplaneProject.Domain.Models
{
	public class UepTipo : Entity
	{
        public string Nome { get; set; }
		public string Codigo { get; set; }
		public string Descricao { get; set; }
		public IList<Uep> Ueps { get; set; }

		public override string Value => this.Nome;
	}
}