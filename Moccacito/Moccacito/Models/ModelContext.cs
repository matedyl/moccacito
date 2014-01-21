using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
namespace Moccacito.Models
{
    public class ModelContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx

        public ModelContext()
            : base("name=ModelContext")
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<ProjectManager> ProjectManagers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<WorkUnit> WorkUnits { get; set; }
        public DbSet<Project> Projects { get; set; }
    }

    public class Client
    {
        public Client()
        {
            this.Products = new HashSet<Product>();
            this.Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        [Display(Name = "Nazwa klienta"), DataType(DataType.Text), StringLength(25, MinimumLength = 2), Required]
        public string Name { get; set; }
        [Display(Name = "E-mail"), DataType(DataType.EmailAddress), EmailAddress, Required]
        public string Email { get; set; }
        [Display(Name = "Telefon kontaktowy"), DataType(DataType.PhoneNumber), RegularExpression(@"^[0-9\.\-\+]+$", ErrorMessage = "Pole Telephone nie może zawierać znaków tekstowych")]
        public string Telephone { get; set; }
        [RegularExpression(@"^[0-9]{10}$", ErrorMessage = "Pole NIP przyjmuje wyłącznie 10-cyfrowe liczby")]
        public string NIP { get; set; }
        [Display(Name = "Ulica"), DataType(DataType.Text), StringLength(60, MinimumLength = 2)] 
        public string Street { get; set; }
        [Display(Name = "Miasto"), DataType(DataType.Text), StringLength(60, MinimumLength = 2)]
        public string City { get; set; }
        [Display(Name = "Kod pocztowy"), DataType(DataType.PostalCode), RegularExpression(@"^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Pole Zipcode przyjmuje wartości w formacie: 00-000")]
        public string Zipcode { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        public virtual ICollection<Project> Projects { get; set; }
    }

    public class Location
    {
        public Location()
        {
            this.WorkUnits = new HashSet<WorkUnit>();
        }

        public int Id { get; set; }
        [Display(Name = "Nazwa lokalizacji"), DataType(DataType.Text), StringLength(60, MinimumLength = 2), Required]
        public string Name { get; set; }
        [Display(Name = "Ulica"), DataType(DataType.Text), StringLength(60, MinimumLength = 2), Required]
        public string Street { get; set; }
        [Display(Name = "Miasto"), DataType(DataType.Text), StringLength(60, MinimumLength = 2), Required]
        public string City { get; set; }
        [Display(Name = "Kod pocztowy"), DataType(DataType.PostalCode), RegularExpression(@"^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Pole Zipcode przyjmuje wartości w formacie: 00-000"), Required]
        public string Zipcode { get; set; }
        [Display(Name = "Imię"), DataType(DataType.Text), StringLength(25, MinimumLength = 2), Required]
        public string ContactName { get; set; }
        [Display(Name = "Nazwisko"), DataType(DataType.Text), StringLength(25, MinimumLength = 2)]
        public string ContactSurname { get; set; }
        [Display(Name = "Telefon kontaktowy"), DataType(DataType.PhoneNumber), RegularExpression(@"^[0-9\.\-\+]+$", ErrorMessage = "Pole Telephone nie może zawierać znaków tekstowych"), Required]
        public string Telephone { get; set; }
        [Display(Name = "E-mail"), DataType(DataType.EmailAddress), EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Telefon alternatywny"), DataType(DataType.PhoneNumber)]
        public string TelephoneAlt { get; set; }

        public virtual ICollection<WorkUnit> WorkUnits { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa produktu"), DataType(DataType.Text), StringLength(25, MinimumLength = 2), Required]
        public string Name { get; set; }
        [Display(Name = "Zdjęcie"), UIHint("Image")]
        public string PictureUrl { get; set; }

        [Required]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
    }

    public class ProjectManager
    {
        public ProjectManager()
        {
            this.Projects = new HashSet<Project>();
        }

        public int Id { get; set; }
        [Display(Name = "Zdjęcie"), UIHint("Image")]
        public string PictureUrl { get; set; }
        [Display(Name = "Imię"), DataType(DataType.Text), StringLength(25, MinimumLength = 2), Required]
        public string Firstname { get; set; }
        [Display(Name = "Nazwisko"), DataType(DataType.Text), StringLength(25, MinimumLength = 2), Required]
        public string Lastname { get; set; }
        [Display(Name = "E-mail"), DataType(DataType.EmailAddress), EmailAddress, Required]
        public string Email { get; set; }
        [Display(Name = "Telefon kontaktowy"), DataType(DataType.PhoneNumber), RegularExpression(@"^[0-9\.\-\+]+$", ErrorMessage = "Pole Telephone nie może zawierać znaków tekstowych"), Required]
        public string Telephone { get; set; }

        public virtual ICollection<Project> Projects { get; set; }
    }

    public class Project
    {
        public Project()
        {
            this.WorkUnits = new HashSet<WorkUnit>();
            this.ProjectManagers = new HashSet<ProjectManager>();
        }

        public int Id { get; set; }
        [Display(Name = "Nazwa projektu"), DataType(DataType.Text), StringLength(60, MinimumLength = 2), Required]
        public string Name { get; set; }
        [Display(Name = "Opis"), DataType(DataType.MultilineText), StringLength(255, MinimumLength = 2)]
        public string Description { get; set; }
        [Display(Name = "Data rozpoczęcia"), DataType(DataType.Date), Required]
        public System.DateTime StartDate { get; set; }
        [Display(Name = "Data zakończenia"), DataType(DataType.Date), Required]
        public System.DateTime EndDate { get; set; }
        [Display(Name = "Domyślna stawka godzinowa"), DataType(DataType.Currency), Required]
        public int DefaultHourRate { get; set; }
        [Display(Name = "Planowana data wypłaty wynagrodzenia"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true), Required]
        public System.DateTime PlannedPaymentDate { get; set; }

        [Required]
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public virtual ICollection<WorkUnit> WorkUnits { get; set; }
        public virtual ICollection<ProjectManager> ProjectManagers { get; set; }
    }

    public class Worker
    {
        public Worker()
        {
            this.WorkUnits = new HashSet<WorkUnit>();
        }

        public int Id { get; set; }
        [Display(Name = "Imię"), DataType(DataType.Text), StringLength(25, MinimumLength = 2), Required]
        public string Firstname { get; set; }
        [Display(Name = "Nazwisko"), DataType(DataType.Text), StringLength(25, MinimumLength = 2), Required]
        public string Lastname { get; set; }
        [Display(Name = "Płeć"), Required]
        public Gender Gender { get; set; }
        [Display(Name = "Zdjęcie"), UIHint("Image")]
        public string PictureUrl { get; set; }
        [Display(Name = "Telefon kontaktowy"), DataType(DataType.PhoneNumber), RegularExpression(@"^[0-9\.\-\+]+$", ErrorMessage = "Pole Telephone nie może zawierać znaków tekstowych"), Required]
        public string Telephone { get; set; }
        [Display(Name = "E-mail"), DataType(DataType.EmailAddress), EmailAddress, Required]
        public string Email { get; set; }
        [Display(Name = "Miejsce znalezienia"), DataType(DataType.Text), StringLength(60, MinimumLength = 2)]
        public string PlaceWhereFound { get; set; }
        [Display(Name = "Ulica"), DataType(DataType.Text), StringLength(60, MinimumLength = 2), Required]
        public string Street { get; set; }
        [Display(Name = "Miasto"), DataType(DataType.Text), StringLength(60, MinimumLength = 2), Required]
        public string City { get; set; }
        [Display(Name = "Kod pocztowy"), DataType(DataType.PostalCode), RegularExpression(@"^[0-9]{2}-[0-9]{3}$", ErrorMessage = "Pole Zipcode przyjmuje wartości w formacie: 00-000"), Required]
        public string Zipcode { get; set; }

        public virtual ICollection<WorkUnit> WorkUnits { get; set; }
    }

    public class WorkUnit
    {
        public int Id { get; set; }
        [Display(Name = "Czas rozpoczęcia pracy"), DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true), Required]
        public System.DateTime StartTime { get; set; }
        [Display(Name = "Czas zakończenia pracy"), DataType(DataType.DateTime), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy HH:mm}", ApplyFormatInEditMode = true), Required]
        public System.DateTime EndTime { get; set; }
        [Display(Name = "Stawka godzinowa"), DataType(DataType.Currency), Required]
        public decimal HourRate { get; set; }
        [Display(Name = "Opłacono?")] 
        public bool IsPaid { get; set; }
        [Display(Name = "Data wypłaty wynagrodzenia"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public System.DateTime PaymentDate { get; set; }
        [Display(Name = "Ilość godzin pracy"), NotMapped]
        public int WorkHours { get { return (EndTime - StartTime).Hours; } }
        [Display(Name = "Wartość pracy"), DataType(DataType.Currency), NotMapped]
        public double Value { get { return (double)(HourRate * WorkHours); } }

        [Required]
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        [Required]
        public int LocationId { get; set; }
        public virtual Location Location { get; set; }
        public int? WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
    }

    public enum Gender
    {
        Male = 1,
        Female = 2
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}