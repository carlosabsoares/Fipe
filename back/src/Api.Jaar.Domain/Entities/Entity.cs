﻿using System.ComponentModel.DataAnnotations;

namespace Api.Jaar.Domain.Entities
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}