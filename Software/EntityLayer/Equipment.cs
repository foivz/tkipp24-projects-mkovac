namespace EntityLayer
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Equipment")]
    public partial class Equipment
    {
        public Equipment() { }
        public int Id { get; set; }

        [StringLength(255)]
        public String Name { get; set; }

        public int Amount { get; set; }

        [MaxLength(2000)]
        public String Description { get; set; }
    }
}
