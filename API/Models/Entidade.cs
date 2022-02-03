using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace API
{
    public class Entidade
    {
        public Guid Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public DateTime? DeletadoEm { get; private set; }
        public DateTime? AtualizadoEm { get; private set; }

        [NotMapped]
        public bool EstaDeletado => DeletadoEm != default(DateTime?);
    }
}
