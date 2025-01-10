using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaffardBankRepo.Models
{

    public class Industry
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public virtual ICollection<Field>? Fields { get; set; }

    }

    public class Field
    {
        [Key]
        public int Id { get; set; }
        public int IndustryId { get; set; }
        public string? FieldName { get; set; }
        public string? FieldType { get; set; }
        [ForeignKey(nameof(IndustryId))]
        public virtual Industry? Industry { get; set; }
    }

    public class Account
    {
        [Key]
        public int Id { get; set; }
        public string? CustomerAccount { get; set; }
        public int IndustryId { get; set; }
        [ForeignKey(nameof(IndustryId))]
        public virtual Industry? Industry { get; set; }
    }

    public class TransactionField
    {
        [Key]
        public int Id { get; set; }
        public int TransactionId { get; set; }
        public int FieldId { get; set; }
        public string? FieldValue { get; set; }
        [ForeignKey(nameof(TransactionId))]
        public virtual Transaction? Transaction { get; set; }
        [ForeignKey(nameof(FieldId))]
        public virtual Field? Field { get; set; }
    }
    public class Transaction
    {
        [Key]
        public int Id { get; set; }
        public int AccountId { get; set; }
        public DateTime? TransactionDate { get; set; } = DateTime.Now;
        [ForeignKey(nameof(AccountId))]
        public virtual Account? Account { get; set; }
    }

}
