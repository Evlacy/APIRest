﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace APIRestCodeFirst.Models.EntityFramework
{
    [Table("t_e_utilisateur_utl")]
    public partial class Utilisateur
    {
        public Utilisateur()
        { }

        [Key]
        [Column("utl_id")]
        public int UtilisateurId { get; set; }

        [Column("utl_nom")]
        [StringLength(50)]
        public String? Nom { get; set; }

        [Column("utl_prenom")]
        [StringLength(50)]
        public String? Prenom { get; set; }

        [Column("utl_mobile", TypeName = "char(10)")]
        [RegularExpression(@"^0[0-9]{9}$", ErrorMessage = "La longueur d’un téléphone doit être de 10, commancant par un 0 et n'ayant que des chiffres.")]
        public String? Mobile { get; set; }

        [Column("utl_mail")]
        [EmailAddress]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "La longueur d’un email doit être comprise entre 6 et 100 caractères.")]
        public String? Mail { get; set; } = null!;

        [Column("utl_pwd")]
        [StringLength(64)]
        public String? Pwd { get; set; } = null!;

        [Column("utl_rue")]
        [StringLength(200)]
        public String? Rue { get; set; }

        [Column("utl_cp", TypeName = "char(5)")]
        public String? CodePostal { get; set; }

        [Column("utl_ville")]
        [StringLength(50)]
        public String? Ville { get; set; }

        [Column("utl_pays")]
        [StringLength(50)]
        public String? Pays { get; set; } = "France";

        [Column("utl_latitude")]
        public float? Latitude { get; set; }

        [Column("utl_longitude")]
        public float? Longitude { get; set; }

        [Required]
        [Column("utl_datecreation")]
        public DateTime DateCreation { get; set; } = DateTime.UtcNow;

        [InverseProperty(nameof(Notation.UtilisateurNavigation))]
        public virtual ICollection<Notation> NotesUtilisateur { get; set; } = new List<Notation>();
    }
}
