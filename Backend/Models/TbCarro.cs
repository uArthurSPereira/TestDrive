using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.Models
{
    [Table("tb_carro")]
    public partial class TbCarro
    {
        public TbCarro()
        {
            TbAgendamento = new HashSet<TbAgendamento>();
        }

        [Key]
        [Column("id_carro", TypeName = "int(11)")]
        public int IdCarro { get; set; }
        [Column("ds_modelo", TypeName = "varchar(50)")]
        public string DsModelo { get; set; }
        [Column("ds_marca", TypeName = "varchar(50)")]
        public string DsMarca { get; set; }
        [Column("ds_placa", TypeName = "varchar(50)")]
        public string DsPlaca { get; set; }
        [Column("dt_ano", TypeName = "year(4)")]
        public short? DtAno { get; set; }

        [InverseProperty("IdCarroNavigation")]
        public virtual ICollection<TbAgendamento> TbAgendamento { get; set; }
    }
}
